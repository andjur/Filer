CREATE PROCEDURE [dbo].[Volume_insert]
	@Label        VARCHAR(MAX),
	--@SerialNumber VARCHAR(MAX),
	@DriveLeter   VARCHAR(MAX),

	@AvailableFreeSpace BIGINT,
	@TotalSize          BIGINT,

	@EffectiveDate DATETIME,

	@Id BIGINT OUTPUT
AS
BEGIN
	INSERT [dbo].[Volume] (
		[Label],
		--[SerialNumber],
		[DriveLeter],

		[AvailableFreeSpace],
		[TotalSize],

		[EffectiveDate]
	)
	VALUES(
		@Label,
		--@SerialNumber,
		@DriveLeter,

		@AvailableFreeSpace,
		@TotalSize,

		@EffectiveDate
	)

	SET @Id = SCOPE_IDENTITY()
END