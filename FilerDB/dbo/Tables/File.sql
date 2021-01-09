CREATE TABLE [dbo].[File]
(
	[PathId] BIGINT REFERENCES [dbo].[Path] (Id) NOT NULL,

	[Name] VARCHAR(MAX) NOT NULL,
	[Ext]  VARCHAR(MAX) NOT NULL,

	[Size]   BIGINT NOT NULL,
    [SizeKB] AS (CONVERT([decimal](18,1),round([Size]/CONVERT([decimal](18,1),(1024)),(1)))),
    [SizeMB] AS (CONVERT([decimal](18,1),round([Size]/CONVERT([decimal](18,1),(1024)*(1024)),(1)))),
    [SizeGB] AS (CONVERT([decimal](18,1),round([Size]/CONVERT([decimal](18,1),((1024)*(1024))*(1024)),(1)))),
    


	[Created]  DATETIME NOT NULL,
	[Modified] DATETIME NOT NULL,

	[MD5] VARCHAR(MAX)
)
