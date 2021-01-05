CREATE PROCEDURE [dbo].[File_insert]
	@PathId BIGINT,

	@Name VARCHAR(MAX),
	@Ext  VARCHAR(MAX),

	@Size     BIGINT,
	@Created  DATETIME,
	@Modified DATETIME,

	@MD5 VARCHAR(MAX)

AS
BEGIN
	INSERT [dbo].[File] (
		[PathId],

		[Name],
		[Ext],

		[Size],
		[Created],
		[Modified],

		[MD5]
	)
	VALUES (
		@PathId,

		@Name,
		@Ext,

		@Size,
		@Created,
		@Modified,

		@MD5
	)

END