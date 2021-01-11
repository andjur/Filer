CREATE VIEW [dbo].[ScansFoldersCounts]
AS 
SELECT
    [ScanId],
    COUNT(*) AS FoldersCount
FROM
    [dbo].[Path]
GROUP BY
    [ScanId]