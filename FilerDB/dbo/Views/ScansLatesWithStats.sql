CREATE VIEW [dbo].[ScansLatesWithStats]
AS 
SELECT
	ST.*
FROM 
	[dbo].[ScansLatest] AS SL

	LEFT OUTER JOIN

	[dbo].[ScansWithStats] AS ST ON (ST.Id = SL.Id)