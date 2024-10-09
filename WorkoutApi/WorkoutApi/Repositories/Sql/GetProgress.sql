IF OBJECT_ID('GetProgress', 'P') IS NOT NULL
    DROP PROCEDURE GetProgress;
GO
CREATE PROCEDURE GetProgress
	@DayKey Uniqueidentifier
AS
BEGIN
	DECLARE @RecentWorkout TABLE ( ExerciseKey UNIQUEIDENTIFIER, LastWorkout DATETIME );
	INSERT INTO @RecentWorkout (ExerciseKey, LastWorkout) (
		SELECT 
			E.ExerciseKey, MAX(T.LastWorkout) AS LastWorkout
		FROM [DAYS] D
		JOIN Exercises E ON E.DayKey = D.DayKey
		LEFT JOIN [Tracking] T ON T.ExerciseKey = E.ExerciseKey
		WHERE D.DayKey = @DayKey
		GROUP BY E.ExerciseKey
	)

	IF EXISTS (SELECT 1 FROM @RecentWorkout WHERE LastWorkout IS NULL)
		SELECT
			D.[Name] AS 'DayName', 
			E.ExerciseKey, E.[Name] AS 'ExerciseName', E.Reps, E.[Sets],
			NULL [Weight], NULL CompletedReps, NULL RPE,  NULL LastWorkout
		FROM [DAYS] D
		JOIN Exercises E ON E.DayKey = D.DayKey
		LEFT JOIN @RecentWorkout RW ON E.ExerciseKey = RW.ExerciseKey
		WHERE D.DayKey = @DayKey;
	ELSE
		SELECT
			D.[Name] AS 'DayName', 
			E.ExerciseKey, E.[Name] AS 'ExerciseName', E.Reps, E.[Sets],
			T.[Weight], T.CompletedReps, T.RPE, T.LastWorkout
		FROM [DAYS] D
		JOIN Exercises E ON E.DayKey = D.DayKey
		JOIN [Tracking] T ON T.ExerciseKey = E.ExerciseKey
		JOIN @RecentWorkout RW ON T.LastWorkout = RW.LastWorkout
		WHERE D.DayKey = @DayKey;
END;