IF OBJECT_ID('InsertTracking', 'P') IS NOT NULL
    DROP PROCEDURE InsertTracking;
GO
CREATE PROCEDURE InsertTracking
	@ExerciseKey Uniqueidentifier,
    @Date Date,
	@Weight NVARCHAR(256),
	@CompletedReps INTEGER,
	@RPE INTEGER
AS
BEGIN
	INSERT INTO [Tracking] 
	VALUES (@Date, @Weight, @CompletedReps, @RPE, @ExerciseKey);
END;