using System.Collections.Generic;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as a problem detail reporting class
    /// </summary>
    public class KamafiProblemDetail : KamafiProblemDetailBase, IKamafiProblemDetail
    {
        public string TraceId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    /// <summary>
    /// Serves as a base problem detail reporting class
    /// </summary>
    public class KamafiProblemDetailBase : IKamafiProblemDetailBase
    {
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
