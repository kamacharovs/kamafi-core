using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

using FluentValidation;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public class KamafiExceptionMiddleware
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;
        private readonly RequestDelegate _next;

        public KamafiExceptionMiddleware(
            ILogger<KamafiExceptionMiddleware> logger,
            IWebHostEnvironment env,
            RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                if (httpContext.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                var id = string.IsNullOrEmpty(httpContext?.TraceIdentifier)
                    ? Guid.NewGuid().ToString()
                    : httpContext.TraceIdentifier;
                var tenant = new Tenant(httpContext).Log;

                _logger.LogError(e, "{Tenant} | An exception was thrown during the request. {Id}", tenant, id);

                await WriteExceptionResponseAsync(httpContext, e, id);
            }
        }

        private async Task WriteExceptionResponseAsync(
            HttpContext httpContext,
            Exception e,
            string id)
        {
            var canViewSensitiveInfo = _env
                .IsDevelopment();

            var problem = new KamafiProblemDetail()
            {
                Message = canViewSensitiveInfo
                    ? e.Message
                    : Constants.DefaultMessage,
                Code = StatusCodes.Status500InternalServerError,
                TraceId = $"kamafi:error:{id}"
            };

            if (e is KamafiException ke)
            {
                problem.Code = ke.StatusCode;
                problem.Message = ke.Message;
            }
            else if (e is ValidationException ve)
            {
                problem.Code = StatusCodes.Status400BadRequest;
                problem.Message = Constants.DefaultValidationMessage;
                problem.Errors = ve.Errors.Select(x => x.ErrorMessage);
            }

            var problemjson = JsonSerializer
                .Serialize(problem, Constants.JsonSerializerSettings);

            httpContext.Response.StatusCode = problem.Code ?? StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = Constants.ApplicationProblemJson;

            await httpContext.Response
                .WriteAsync(problemjson);
        }
    }
}
