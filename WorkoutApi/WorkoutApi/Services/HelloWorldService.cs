using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        private readonly IHelloWorldRepository _repository;

        public HelloWorldService(IHelloWorldRepository repository)
        {
            _repository = repository;
        }

        public List<HelloWorld> GetHelloWorlds()
        {
            return _repository.GetHelloWorlds();
        }
    }
}