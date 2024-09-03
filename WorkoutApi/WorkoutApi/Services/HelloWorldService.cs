using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        private readonly IHelloWorldRepository _helloWorldRepository;

        public HelloWorldService(IHelloWorldRepository helloWorldRepository)
        {
            _helloWorldRepository = helloWorldRepository;
        }

        public IEnumerable<HelloWorld> GetHelloWorlds()
        {
            return _helloWorldRepository.GetHelloWorlds();
        }
    }

}
