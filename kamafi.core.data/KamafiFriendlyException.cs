using System;
using System.Net;

namespace kamafi.core.data
{
    public class KamafiFriendlyException : KamafiException
    {
        public KamafiFriendlyException()
        { }

        public KamafiFriendlyException(string message)
            : base(message)
        { }

        public KamafiFriendlyException(HttpStatusCode statusCode, string message)
            : base(statusCode, message)
        { }

        public KamafiFriendlyException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
