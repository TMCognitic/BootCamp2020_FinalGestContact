CREATE PROCEDURE [dbo].[CSP_RegisterCustomer]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
Begin
	Insert into Customer (LastName, FirstName, Email, Passwd) values (@LastName, @FirstName, @Email, dbo.CSF_GeneratePassword(@Passwd));
End
