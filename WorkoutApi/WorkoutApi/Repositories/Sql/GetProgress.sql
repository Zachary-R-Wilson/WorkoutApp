IF OBJECT_ID('GetProgress', 'P') IS NOT NULL
    DROP PROCEDURE GetProgress;
GO
CREATE PROCEDURE GetProgress
	@DayKey Uniqueidentifier
AS
BEGIN
	WITH LatestTracking AS (
		SELECT TOP 1
			T.[Weight], T.CompletedReps, T.RPE, T.LastWorkout, T.ExerciseKey, E.[Name] AS Exercise,
			ROW_NUMBER() OVER (PARTITION BY T.ExerciseKey ORDER BY T.LastWorkout DESC) AS LatestWorkout
		FROM [DAYS] D
		JOIN Exercises E ON E.DayKey = D.DayKey
		JOIN [Tracking] T ON T.ExerciseKey = E.ExerciseKey
		WHERE D.DayKey = @DayKey
	)
	SELECT [Weight], CompletedReps, RPE, LastWorkout, ExerciseKey, Exercise FROM LatestTracking
	WHERE LatestWorkout = 1;
END;