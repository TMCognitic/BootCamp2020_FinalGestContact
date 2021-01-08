CREATE FUNCTION [dbo].[CSF_GeneratePassword]
(
	@Passwd NVARCHAR(50)
)
RETURNS BINARY(64)
AS
BEGIN
	RETURN HASHBYTES('SHA2_512', dbo.CSF_GetPreSalt() + @Passwd + dbo.CSF_GetPostSalt());
END
