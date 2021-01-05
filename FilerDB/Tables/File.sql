CREATE TABLE [dbo].[File]
(
	[PathId] BIGINT REFERENCES [dbo].[Path] (Id) NOT NULL,

	[Name] VARCHAR(MAX) NOT NULL,
	[Ext]  VARCHAR(MAX) NOT NULL,

	[Size]     BIGINT NOT NULL,
	[SizeKB]   AS CAST(ROUND([Size] / CAST((1024)           AS decimal(18,1)),2) AS decimal(18,1)),
	[SizeMB]   AS CAST(ROUND([Size] / CAST((1024*1024)      AS decimal(18,1)),2) AS decimal(18,1)),
	[SizeGB]   AS CAST(ROUND([Size] / CAST((1024*1024*1024) AS decimal(18,1)),2) AS decimal(18,1)),

	[Created]  DATETIME NOT NULL,
	[Modified] DATETIME NOT NULL,

	[MD5] VARCHAR(MAX)
)
