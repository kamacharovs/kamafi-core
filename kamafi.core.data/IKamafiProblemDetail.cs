using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as a problem detail reporting class
    /// </summary>
    public interface IKamafiProblemDetail : IKamafiProblemDetailBase
    {
        string TraceId { get; set; }
        IEnumerable<string> Errors { get; set; }
    }

    /// <summary>
    /// Serves as a base problem detail reporting class
    /// </summary>
    public interface IKamafiProblemDetailBase
    {
        int? Code { get; set; }
        string Message { get; set; }
    }
}
