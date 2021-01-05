CREATE VIEW [dbo].[FilesLatest]
AS 
SELECT
	F.*
FROM 
	[dbo].[Files] AS F

	INNER JOIN

	[dbo].[ScansLatest] AS SL
	ON (SL.[Id] = F.[ScanId])
