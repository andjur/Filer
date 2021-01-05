CREATE TABLE [dbo].[Scan]
(
	[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,

	[StartPath]         VARCHAR(MAX) NOT NULL,
	[DriveLabel]        VARCHAR(MAX) NOT NULL,
	--[DriveSerialNumber] VARCHAR(MAX),

	[Started]   DATETIME NOT NULL,
	[Completed] DATETIME NULL,

	[DurationInSeconds] AS            DATEDIFF(second, [Started], [Completed]),
	[DurationInMinutes] AS CAST(ROUND(DATEDIFF(second, [Started], [Completed])/ CAST(60    AS DECIMAL(18,1)), 1) AS DECIMAL(18,1)),
	[DurationInHours]   AS CAST(ROUND(DATEDIFF(second, [Started], [Completed])/ CAST(60*60 AS DECIMAL(18,1)), 1) AS DECIMAL(18,1))
)
