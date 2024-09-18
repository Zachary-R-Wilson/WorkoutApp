using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class MaxesService : IMaxesService
    {
        private readonly IMaxesRepository _maxesRepository;

        public MaxesService(IMaxesRepository maxesRepository)
        {
            _maxesRepository = maxesRepository;
        }

        /// <inheritdoc />
        public MaxModel GetMaxes(Guid userKey)
        {
            return _maxesRepository.GetMaxes(userKey);
        }

        /// <inheritdoc />
        public void UpdateMaxes(Guid userKey, MaxModel trackingModel)
        {
            _maxesRepository.UpdateMaxes(userKey, trackingModel);
        }
    }
}
