﻿using WorkoutApi.Models;

namespace WorkoutApi.Repositories
{
    public interface IWorkoutRepository
    {
        /// <summary>
        /// Writes the workout to the SQL database.
        /// </summary>
        /// <param name="workoutModel">The data stored in the workout.</param>
        void CreateWorkout(Guid userKey, WorkoutModel workoutModel);

        /// <summary>
        /// Deletes a workout from the database by the workoutKey
        /// </summary>
        /// <param name="workoutKey">The Guid of the workout</param>
        void DeleteWorkout(Guid workoutKey);
    }
}