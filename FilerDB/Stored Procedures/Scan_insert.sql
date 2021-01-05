CREATE PROCEDURE [dbo].[Scan_insert]
	@StartPath  VARCHAR(MAX),
	@DriveLabel VARCHAR(MAX),
	--@DriveSerialNumber VARCHAR(MAX),

	@Id BIGINT OUTPUT
AS
BEGIN
	INSERT [dbo].[Scan] (
		[StartPath],
		[DriveLabel],
		--[DriveSerialNumber],

		[Started]
	)
	VALUES (
		@StartPath,
		@DriveLabel,
		--@DriveSerialNumber,

		GETDATE()
	)

	SET @Id = SCOPE_IDENTITY()
END