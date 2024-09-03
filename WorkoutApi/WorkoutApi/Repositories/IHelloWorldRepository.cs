using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IHelloWorldRepository
    {
        IEnumerable<HelloWorld> GetHelloWorlds();
    }
}
