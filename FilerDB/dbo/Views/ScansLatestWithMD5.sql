CREATE VIEW [dbo].[ScansLatestWithMD5]
AS 
SELECT
    S.*
FROM
    (
        SELECT
            [DriveLabel],
            MAX([Completed]) AS Completed
        FROM
            [dbo].[ScansWithStats]
        WHERE
            [StartPath] LIKE '_:\'
            AND
            [Completed] IS NOT NULL
            AND
            [HasMD5] = 1
        GROUP BY
            [DriveLabel]
    ) AS LATEST

    LEFT OUTER JOIN

    [dbo].[Scan] AS S ON (
        (S.[DriveLabel] = LATEST.[DriveLabel]) 
        AND 
        (S.[Completed] = LATEST.Completed)
    )