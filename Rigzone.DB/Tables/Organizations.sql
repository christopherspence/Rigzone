CREATE TABLE [dbo].[Organizations]
(
	[OrganizationID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [OrganizationName] NVARCHAR(50) NOT NULL, 
    [SortOrder] INT NOT NULL
)
