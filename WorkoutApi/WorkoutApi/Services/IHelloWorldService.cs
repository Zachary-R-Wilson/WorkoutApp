using WorkoutApi.Models;

namespace WorkoutApi.Services
{
    public interface IHelloWorldService
    {
        IEnumerable<HelloWorld> GetHelloWorlds();
    }
}
