using WorkoutApi.Models;
using WorkoutApi.Repositories;

namespace WorkoutApi.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository) 
        {
            _workoutRepository = workoutRepository;
        }

        /// <inheritdoc />
        public void CreateWorkout(string token, WorkoutModel workoutModel)
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            _workoutRepository.CreateWorkout(userKey, workoutModel);
        }

        /// <inheritdoc />
        public void DeleteWorkout(Guid workoutKey)
        {
            _workoutRepository.DeleteWorkout(workoutKey);
        }

        /// <inheritdoc />
        public WorkoutModel GetWorkout(Guid WorkoutKey)
        {
            return _workoutRepository.GetWorkout(WorkoutKey);
        }

        /// <inheritdoc />
        public WorkoutCollection GetAllWorkouts(string token) 
        {
            Guid userKey = JwtHelper.ExtractUserKey(token)
                ?? throw new ArgumentNullException(nameof(token), "Invalid or missing userKey in the token.");

            return _workoutRepository.GetAllWorkouts(userKey);
        }
    }
}
