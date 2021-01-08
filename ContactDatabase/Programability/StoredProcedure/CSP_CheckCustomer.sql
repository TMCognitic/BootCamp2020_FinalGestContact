CREATE PROCEDURE [dbo].[CSP_CheckCustomer]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
Begin
	Select Id, LastName, FirstName, Email From Customer Where Email = @Email And Passwd = dbo.CSF_GeneratePassword(@Passwd);
End
