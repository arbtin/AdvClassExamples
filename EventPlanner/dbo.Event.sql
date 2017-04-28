CREATE TABLE [dbo].[Event] (
    [Id]          INT            NOT NULL,
    [Title]       VARCHAR (50)   NOT NULL,
    [Location]    VARCHAR (250)  NULL,
    [EventDate]   DATETIME       NULL,
    [EventTypeId] INT            NOT NULL,
    [Price]       DECIMAL (5, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Event_EventType] FOREIGN KEY ([EventTypeId]) REFERENCES [EventType]([Id])
);

