CREATE PROCEDURE [dbo].[GetRigs]
	@ID NVARCHAR(MAX) = NULL,
	@Name NVARCHAR(MAX) = NULL,
	@Manager NVARCHAR(MAX) = NULL,
	@Region NVARCHAR(MAX) = NULL,
	@Country NVARCHAR(MAX) = null,
	@CurrentBlockOrWell NVARCHAR(MAX) = null,
	@CurrentStartDate DATETIME = null,
	@CurrentEndDate DATETIME = null,
	@ExactMatch BIT = 0
AS
	DECLARE @query NVARCHAR(MAX)
	DECLARE @whereClause NVARCHAR(MAX)
	DECLARE @criteriaPrefix NVARCHAR(10)
	DECLARE @criteriaSuffix NVARCHAR(10)

	SET @query = 'SELECT r.RigID, r.RigName, r.WaterDepth, r.DrillingDepth, r.ManagerID, o.OrganizationName as ManagerName, ' +
	'r.RegionID, reg.RegionName, r.CountryID, c.CountryName, r.CurrentBlockOrWell, r.CurrentStartDate, ' +
	'r.CurrentEndDate ' +
	'FROM Rigs r ' +
	'LEFT JOIN Organizations o on o.OrganizationID = r.ManagerID ' +
	'LEFT JOIN Regions reg on reg.RegionID = r.RegionID ' +
	'LEFT JOIN Countries c on c.CountryID = r.CountryID '
	SET @whereClause = ''

	-- Use like if exact match, else use =
	IF @ExactMatch = 1
	BEGIN
		SET @criteriaPrefix = ' = '''
		SET @criteriaSuffix = ' ' 
	END
	ELSE
	BEGIN
		SET @criteriaPrefix = ' LIKE ''%' 
		SET @criteriaSuffix = '%'' '
	END
	

	-- build the where clause based on parameters entered
	IF @ID IS NOT NULL
		SET @whereClause = @whereClause + 'AND RigID' + @criteriaPrefix + @ID + @criteriaSuffix
	IF @Name IS NOT NULL
		SET @whereClause = @whereClause + 'AND RigName' + @criteriaPrefix + @Name + @criteriaSuffix
	IF @Manager IS NOT NULL
		SET @whereClause = @whereClause + 'AND ManagerName' + @criteriaPrefix + @Manager + @criteriaSuffix
	IF @Region IS NOT NULL
		SET @whereClause = @whereClause + 'AND RegionName' + @criteriaPrefix + @Region + @criteriaSuffix
	IF @Country IS NOT NULL
		SET @whereClause = @whereClause + 'AND c.CountryName' + @criteriaPrefix + @Country + @criteriaSuffix
	IF @CurrentBlockOrWell IS NOT NULL
		SET @whereClause = @whereClause + 'AND CurrentBlockOrWell' + @criteriaPrefix + @CurrentBlockOrWell + @criteriaSuffix
	IF @CurrentStartDate IS NOT NULL
		SET @whereClause = @whereClause + 'AND CurrentStartDate'  + @criteriaPrefix + @CurrentStartDate + @criteriaSuffix
	IF @CurrentEndDate IS NOT NULL
		SET @whereClause = @whereClause + 'AND CurrentEndDate' + @criteriaPrefix + + @CurrentEndDate + @criteriaSuffix

	SET @whereClause = 'WHERE' + SUBSTRING(@whereClause, 4, LEN(@whereClause))

	--SELECT @whereClause
	EXEC sp_executesql @query
GO