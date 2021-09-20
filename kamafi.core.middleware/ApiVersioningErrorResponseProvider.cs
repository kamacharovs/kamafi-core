using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

using kamafi.core.data;

namespace kamafi.core.middleware
{
    public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            var problem = new KamafiProblemDetailBase
            {
                Code = StatusCodes.Status400BadRequest,
                Message = Constants.DefaultUnsupportedApiVersionMessage
            };

            return new ObjectResult(problem)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
