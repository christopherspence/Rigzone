﻿CREATE TABLE [dbo].[Regions]
(
	[RegionID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [RegionName] NVARCHAR(50) NOT NULL, 
    [SortOrder] INT NOT NULL
)