using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kamafi.core.data
{
    public interface IKamafiProblemDetail : IKamafiProblemDetailBase
    {
        string TraceId { get; set; }
        IEnumerable<string> Errors { get; set; }
    }

    public interface IKamafiProblemDetailBase
    {
        int? Code { get; set; }
        string Message { get; set; }
    }
}
