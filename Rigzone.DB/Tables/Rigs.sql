CREATE TABLE [dbo].[Rigs]
(
	[RigID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[RigName] NVARCHAR(50) NOT NULL, 
	[RigTypeID] UNIQUEIDENTIFIER NOT NULL,
    [WaterDepth] INT NOT NULL, 
    [DrillingDepth] INT NOT NULL,
	[ManagerID] UNIQUEIDENTIFIER NOT NULL,
	[LocationID] UNIQUEIDENTIFIER NOT NULL, 
    [RegionID] UNIQUEIDENTIFIER NOT NULL, 
    [CountryID] UNIQUEIDENTIFIER NOT NULL, 
    [CurrentBlockOrWell] NVARCHAR(50) NULL, 
    [CurrentStartDate] DATETIME NOT NULL, 
    [CurrentEndDate] DATETIME NULL, 
	CONSTRAINT [FK_Rigs_ToRigTypes] FOREIGN KEY ([RigTypeID]) REFERENCES [RigTypes]([RigTypeID]),
	CONSTRAINT [FK_Rigs_ToLocations] FOREIGN KEY ([LocationID]) REFERENCES [RigTypes]([RigTypeID]),
    CONSTRAINT [FK_Rigs_ToOrganizations] FOREIGN KEY ([ManagerID]) REFERENCES [Organizations]([OrganizationID]),
	CONSTRAINT [FK_Rigs_ToRegions] FOREIGN KEY ([RegionID]) REFERENCES [Regions]([RegionID]),
	CONSTRAINT [FK_Rigs_ToCountry] FOREIGN KEY ([CountryID]) REFERENCES [Countries]([CountryID])    
)
