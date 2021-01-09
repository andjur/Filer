CREATE PROCEDURE [dbo].[Path_insert]
	@ScanId BIGINT,
	@Path   VARCHAR(MAX),

	@Id BIGINT OUTPUT
AS
BEGIN
	INSERT [dbo].[Path] (
		[ScanId],
		[Path]
	)
	VALUES (
		@ScanId,
		@Path
	)

	SET @Id = SCOPE_IDENTITY()
END