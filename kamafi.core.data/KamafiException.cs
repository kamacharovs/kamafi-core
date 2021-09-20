using System;
using System.Net;
using System.Text.Json;

namespace kamafi.core.data
{
    public abstract class KamafiException : ApplicationException
    {
        public int StatusCode { get; set; }
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
            ContentType = @"application/problem+json";
        }
    }
}
