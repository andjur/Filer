
CREATE VIEW [dbo].[ScansLatesWithStatsWithMD5]
AS 
SELECT
	ST.*
FROM 
	[dbo].[ScansLatestWithMD5] AS SL

	LEFT OUTER JOIN

	[dbo].[ScansWithStats] AS ST ON (ST.Id = SL.Id)