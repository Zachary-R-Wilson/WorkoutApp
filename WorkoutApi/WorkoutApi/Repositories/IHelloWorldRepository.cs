using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IHelloWorldRepository
    {
        List<HelloWorld> GetHelloWorlds();
    }
}
