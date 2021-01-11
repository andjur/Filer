CREATE VIEW [dbo].[ScansLatestWithStats]
AS 
SELECT
	ST.*
FROM 
	[dbo].[ScansLatest] AS SL

	LEFT OUTER JOIN

	[dbo].[ScansWithStats] AS ST ON (ST.Id = SL.Id)