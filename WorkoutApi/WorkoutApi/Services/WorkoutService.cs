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
        public void CreateWorkout(WorkoutModel workoutModel)
        {
            _workoutRepository.CreateWorkout(workoutModel);
        }
    }
}
