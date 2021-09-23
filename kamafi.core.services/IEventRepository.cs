using System.Threading.Tasks;

using kamafi.core.data;

namespace kamafi.core.services
{
    public interface IEventRepository
    {
        Task EmitAsync<T>(Event ev)
            where T : Event, new();
    }
}
