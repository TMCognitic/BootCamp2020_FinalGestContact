CREATE PROCEDURE [dbo].[CSP_ExistEmail]
	@Email NVARCHAR(320)
AS
BEGIN
	IF Exists(Select * from Customer Where Email = @Email)
		select convert(bit, 1);
	Else
		select convert(bit, 0);
END