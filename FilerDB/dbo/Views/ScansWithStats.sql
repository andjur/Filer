CREATE VIEW [dbo].[ScansWithStats]
AS 
SELECT
	S.*,
	SFC.[FoldersCount],
	CASE 
        WHEN (ST.[HasMD5] > 0) THEN CAST((ROUND(ST.[FilesSizeMB]/S.[DurationInSeconds], 1)) AS DECIMAL(18,1)) 
        ELSE NULL
    END AS SpeedMBps,
	ST.*
FROM 
	[dbo].[Scan] AS S

	LEFT OUTER JOIN

	[dbo].[ScansStats] AS ST ON (ST.ScanId = S.Id)

	LEFT OUTER JOIN

	[dbo].[ScansFoldersCounts] AS SFC ON (SFC.[ScanId] = S.[Id])
