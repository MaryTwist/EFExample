﻿CREATE TABLE [dbo].[Teams]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Coach] NVARCHAR(50) NULL
)
