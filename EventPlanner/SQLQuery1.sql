CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[Location] VARCHAR(250) NULL,
	[EventDate] Datetime NULL,
	[EventTypeId] int NOT NULL,
	[Price] Decimal(5,2) NOT NULL
)

CREATE TABLE [dbo].[EventType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Label] VARCHAR(25) NOT NULL,
)