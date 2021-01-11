CREATE VIEW [dbo].[ScansStats]
AS 
SELECT
	S.[Id] AS ScanId,
	COUNT(F.[Name]) AS FilesCount,
	SUM(F.[Size]) AS FilesSize,
	CAST(ROUND(SUM(F.[Size]) / CAST((1024*1024) AS decimal(18,1)),1) AS decimal(18,1)) AS FilesSizeMB,
	CAST(ROUND(SUM(F.[Size]) / CAST((1024*1024*1024) AS decimal(18,1)),1) AS decimal(18,1)) AS FilesSizeGB,
    CASE WHEN (COUNT(F.[MD5]) > 0) THEN 1 ELSE 0 END AS HasMD5
FROM 
	[dbo].[File] AS F

	LEFT OUTER JOIN

	[dbo].[Path] AS P ON (P.Id = F.PathId)

	LEFT OUTER JOIN

	[dbo].[Scan] AS S ON (S.Id = P.ScanId)
GROUP BY
	S.[Id]
