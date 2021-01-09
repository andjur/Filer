CREATE TABLE [dbo].[Scan]
(
	[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,

	[StartPath]         VARCHAR(MAX) NOT NULL,
	[DriveLabel]        VARCHAR(MAX) NOT NULL,
	--[DriveSerialNumber] VARCHAR(MAX),

	[Started]   DATETIME NOT NULL,
	[Completed] DATETIME NULL,

    [DurationInSeconds] AS            (datediff(second,[Started],[Completed])),
    [DurationInMinutes] AS            (CONVERT([decimal](18,1),round(datediff(second,[Started],[Completed])/CONVERT([decimal](18,1),(60)),(1)))),
    [DurationInHours]   AS            (CONVERT([decimal](18,1),round(datediff(second,[Started],[Completed])/CONVERT([decimal](18,1),(60)*(60)),(1)))),
)
