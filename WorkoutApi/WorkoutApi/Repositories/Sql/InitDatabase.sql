IF OBJECT_ID('[dbo].[Tracking]', 'U') IS NOT NULL
DROP TABLE [dbo].[Tracking]
GO
IF OBJECT_ID('[dbo].[Exercises]', 'U') IS NOT NULL
DROP TABLE [dbo].[Exercises]
GO
IF OBJECT_ID('[dbo].[Days]', 'U') IS NOT NULL
DROP TABLE [dbo].[Days]
GO
IF OBJECT_ID('[dbo].[Workouts]', 'U') IS NOT NULL
DROP TABLE [dbo].[Workouts]
GO
IF OBJECT_ID('[dbo].[Maxes]', 'U') IS NOT NULL
DROP TABLE [dbo].[Maxes]
GO
IF OBJECT_ID('[dbo].[users]', 'U') IS NOT NULL
DROP TABLE [dbo].[users]
GO

USE master
GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'WorkoutDb'
)
CREATE DATABASE WorkoutTracker
GO

USE WorkoutDb
GO

CREATE TABLE [dbo].[users]
(
	[userKey] uniqueidentifier NOT NULL PRIMARY KEY,
	[email] NVARCHAR(254) NOT NULL,
	[passwordHash] NVARCHAR(75) NOT NULL
	ON DELETE CASCADE
);
GO
CREATE TABLE [dbo].[Maxes]
(
	[MaxId] INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Squat] INTEGER,
	[Deadlift] INTEGER,
	[Benchpress] INTEGER,
	[UserKey] uniqueidentifier NOT NULL FOREIGN KEY REFERENCES [Users](UserKey)
	ON DELETE CASCADE
);
GO
CREATE TABLE [dbo].[Workouts]
(
	[WorkoutKey] uniqueidentifier NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[UserKey] uniqueidentifier NOT NULL FOREIGN KEY REFERENCES [Users](UserKey)
	ON DELETE CASCADE
);
GO
CREATE TABLE [dbo].[Days]
(
	[DayKey] uniqueidentifier NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[WorkoutKey] uniqueidentifier NOT NULL FOREIGN KEY REFERENCES [Workouts]([WorkoutKey])
	ON DELETE CASCADE
);
GO
CREATE TABLE [dbo].[Exercises]
(
	[ExerciseKey] uniqueidentifier NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[Reps] NVARCHAR(256) NOT NULL,
	[Sets] INTEGER NOT NULL,
	[Order] INTEGER NOT NULL,
	[DayKey] uniqueidentifier NOT NULL FOREIGN KEY REFERENCES [Days]([DayKey])
	ON DELETE CASCADE
);
GO
CREATE TABLE [dbo].[Tracking]
(
	[TrackingId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[LastWorkout] Date NOT NULL,
	[Weight] NVARCHAR(50),
	[CompletedReps] INT,
	[RPE] INT,
	[Notes] NVARCHAR(256),
	[ExerciseKey] uniqueidentifier NOT NULL FOREIGN KEY REFERENCES [Exercises]([ExerciseKey])
	ON DELETE CASCADE
);
GO