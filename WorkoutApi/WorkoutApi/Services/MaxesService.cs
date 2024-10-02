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
        public MaxModel GetMaxes(string token)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");
            return _maxesRepository.GetMaxes(userKey);
        }

        /// <inheritdoc />
        public void UpdateMaxes(string token, MaxModel trackingModel)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");
            _maxesRepository.UpdateMaxes(userKey, trackingModel);
        }
    }
}
