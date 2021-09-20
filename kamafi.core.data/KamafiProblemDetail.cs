using System.Collections.Generic;

namespace kamafi.core.data
{
    public class KamafiProblemDetail : KamafiProblemDetailBase, IKamafiProblemDetail
    {
        public string TraceId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public class KamafiProblemDetailBase : IKamafiProblemDetailBase
    {
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
