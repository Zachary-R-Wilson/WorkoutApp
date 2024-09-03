USE master
GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'WorkoutDb'
)
CREATE DATABASE WorkoutDb
GO

USE WorkoutDb
IF OBJECT_ID('[dbo].[helloworld]', 'U') IS NOT NULL
DROP TABLE [dbo].[helloworld]
GO

CREATE TABLE [dbo].[helloworld]
(
	[helloKey] uniqueidentifier NOT NULL PRIMARY KEY,
	[helloString] NVARCHAR(50) NOT NULL,
);
GO

INSERT INTO [dbo].[helloworld] ([helloKey], [helloString])
VALUES
  (NEWID(), 'Hello World 1'),
  (NEWID(), 'Hello World 2'),
  (NEWID(), 'Hello World 3'),
  (NEWID(), 'Hello World 4'),
  (NEWID(), 'Hello World 5'),
  (NEWID(), 'Hello World 6'),
  (NEWID(), 'Hello World 7'),
  (NEWID(), 'Hello World 8'),
  (NEWID(), 'Hello World 9'),
  (NEWID(), 'Hello World 10');