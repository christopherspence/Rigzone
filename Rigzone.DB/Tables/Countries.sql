CREATE TABLE [dbo].[Countries]
(
	[CountryID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CountryName] NVARCHAR(50) NOT NULL, 
    [SortOrder] INT NOT NULL
)