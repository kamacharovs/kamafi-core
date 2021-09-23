using System;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using RestSharp;
using Polly;

using kamafi.core.data;

namespace kamafi.core.services
{
    public class EventRepository : IEventRepository
    {
        private readonly ILogger<EventRepository> _logger;
        private readonly ITenant _tenant;
        private readonly IRestClient _client;
        private readonly IEnvConfiguration _envConfig;

        public EventRepository(
            ILogger<EventRepository> logger,
            ITenant tenant,
            IRestClient client,
            IEnvConfiguration envConfig)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _envConfig = envConfig;
        }

        public async Task EmitAsync<T>(Event ev)
            where T : Event, new()
        {
            if (await _envConfig?.IsEnabledAsync(FeatureFlags.Eventing) is false)
                return;

            try
            {
                await Policy.Handle<HttpRequestException>()
                    .OrResult<IRestResponse>(x => (int)x.StatusCode == StatusCodes.Status500InternalServerError)
                    .RetryAsync(3)
                    .ExecuteAsync(async () =>
                    {
                        var request = new RestRequest("/emit", Method.POST).AddJsonBody(ev);

                        return await _client.ExecuteAsync(request);
                    });
            }
            catch (Exception e)
            {
                _logger.LogError("{Tenant} | Error while emitting event={EventName}. Message={EventErrorMessage}",
                    _tenant.Log,
                    nameof(T),
                    e.Message);
            }
        }
    }
}
