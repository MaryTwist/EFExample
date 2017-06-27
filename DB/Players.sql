CREATE TABLE [dbo].[Players]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Position] NVARCHAR(256) NULL, 
    [Age] INT NULL, 
    [TeamId] INT NULL, 
    CONSTRAINT [FK_Players_ToTeam] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)
