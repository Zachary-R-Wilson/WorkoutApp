namespace WorkoutApi.Models
{
    public class TrackingModel
    {
        public TrackingModel()
        {
            Exercises = new Dictionary<string, TrackingInfo>();
        }

        public Dictionary<string, TrackingInfo> Exercises { get; set; }
    }

    public class TrackingInfo
    {
        public DateTime Date { get; set; }
        public string? Weight { get; set; }
        public int? CompletedReps { get; set; }
        public int? RPE { get; set; }
        public Guid ExerciseKey { get; set; }
    }
}
