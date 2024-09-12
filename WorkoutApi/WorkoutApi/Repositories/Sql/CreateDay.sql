IF OBJECT_ID('CreateDay', 'P') IS NOT NULL
    DROP PROCEDURE CreateDay;
GO
CREATE PROCEDURE CreateDay
	@WorkoutKey Uniqueidentifier,
    @DayName NVARCHAR(256)
AS
BEGIN
    DECLARE @DayKey uniqueidentifier = NEWID();

	INSERT INTO [Days]
	VALUES (@DayKey, @DayName, @WorkoutKey);

	SELECT @DayKey;
END;