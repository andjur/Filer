CREATE PROCEDURE [dbo].[Scan_update_Completed]
	@Id BIGINT
AS
BEGIN
	UPDATE [dbo].[Scan] 
		SET [Completed] = GETDATE()
	WHERE
		[Id] = @Id
END