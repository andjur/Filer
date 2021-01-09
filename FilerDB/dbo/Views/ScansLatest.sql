CREATE VIEW [dbo].[ScansLatest]
AS 
SELECT
    S.*
FROM
    (
        SELECT
            [DriveLabel],
            MAX([Completed]) AS Completed
        FROM
            [dbo].[Scan]
        WHERE
            [StartPath] LIKE '_:\'
            AND
            [Completed] IS NOT NULL
        GROUP BY
            [DriveLabel]
    ) AS LATEST

    LEFT OUTER JOIN

    [dbo].[Scan] AS S ON (
        (S.[DriveLabel] = LATEST.[DriveLabel]) 
        AND 
        (S.[Completed] = LATEST.Completed)
    )
