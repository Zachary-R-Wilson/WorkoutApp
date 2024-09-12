using WorkoutApi.Models;

namespace WorkoutApi.Services
{
    public interface IWorkoutService
    {
        /// <summary>
        /// Creates the workout.
        /// </summary>
        /// <param name="workoutModel">The data stored in the workout.</param>
        void CreateWorkout(WorkoutModel workoutModel);
    }
}
