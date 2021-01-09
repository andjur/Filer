CREATE VIEW [dbo].[Files]
AS 
SELECT
	S.[Id] AS ScanId,
	S.[DriveLabel],
	S.[StartPath],
	S.[Started],
	S.[Completed],
	S.[DurationInSeconds],
	S.[DurationInMinutes],
	S.[DurationInHours],
	P.[Id] AS PathId,
	P.[Path],
	S.[DriveLabel] + ' :\ ' + P.[Path] AS PathEx,
	F.[Name],
	F.[Ext],
	F.[Size],
	F.[SizeKB],
	F.[SizeMB],
	F.[SizeGB],
	F.[Created],
	F.[Modified],
	F.[MD5]
FROM 
	[dbo].[File] AS F

	LEFT OUTER JOIN

	[dbo].[Path] AS P ON (P.Id = F.PathId)

	LEFT OUTER JOIN

	[dbo].[Scan] AS S ON (S.Id = P.ScanId)
