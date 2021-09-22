using System;
using System.Net;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as a not found exception
    /// </summary>
    public class KamafiNotFoundException : KamafiFriendlyException
    {
        private const string DefaultMessage = "The requested item was not found.";

        public KamafiNotFoundException()
            : base(HttpStatusCode.NotFound, DefaultMessage)
        { }

        public KamafiNotFoundException(string message)
            : base(HttpStatusCode.NotFound, message)
        { }

        public KamafiNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        public KamafiNotFoundException(Exception inner)
            : base(DefaultMessage, inner)
        { }
    }
}
