CREATE VIEW [dbo].[ScansWithStats]
AS 
SELECT
	S.*,
	CASE 
        WHEN (ST.[HasMD5] > 0) THEN CAST((ROUND(ST.[FilesSizeMB]/S.[DurationInSeconds], 1)) AS DECIMAL(18,1)) 
        ELSE NULL
    END AS SpeedMBps,
	ST.*
FROM 
	[dbo].[Scan] AS S

	LEFT OUTER JOIN

	[dbo].[ScansStats] AS ST ON (ST.ScanId = S.Id)
