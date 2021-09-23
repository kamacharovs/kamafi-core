using System;
using System.Net;
using System.Text.Json;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as the base class for all exceptions
    /// </summary>
    public abstract class KamafiException : ApplicationException
    {
        /// <summary>
        /// The HTTP status code of the exception
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The content type of the exception
        /// </summary>
        public string ContentType { get; set; }

        protected KamafiException()
        { }

        protected KamafiException(int statusCode)
        {
            StatusCode = statusCode;
        }

        protected KamafiException(string message)
            : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        protected KamafiException(string message, Exception inner)
            : base(message, inner)
        { }

        protected KamafiException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        protected KamafiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = (int)statusCode;
        }

        protected KamafiException(int statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected KamafiException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected KamafiException(int statusCode, JsonElement errorObject)
            : this(statusCode, errorObject.ToString())
        {
            ContentType = Constants.ApplicationProblemJson;
        }
    }
}
