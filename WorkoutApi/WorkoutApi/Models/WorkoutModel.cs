﻿using System.ComponentModel.DataAnnotations;

namespace WorkoutApi.Models
{
    public class WorkoutModel
    {
        [Required(ErrorMessage = "Workout Name is Required.")]
        public required string Name { get; set; }

        public Dictionary<string, List<Exercise>> Days { get; set; } = new Dictionary<string, List<Exercise>>();
    }

    public class Exercise
    {
        [Required(ErrorMessage = "Exercise Name is Required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Exercise Reps are Required.")]
        public required string Reps { get; set; }
       
        [Required(ErrorMessage = "Exercise Sets are Required.")]
        public required int Sets { get; set; }
    }

    public class WorkoutCollection
    {
        public Dictionary<string, WorkoutInfo> Workouts { get; set; } = new Dictionary<string, WorkoutInfo>();
    }

    public class WorkoutInfo
    {
        public Guid WorkoutKey { get; set; }
        public List<string> Days { get; set; } = new List<string>();
    }
}
