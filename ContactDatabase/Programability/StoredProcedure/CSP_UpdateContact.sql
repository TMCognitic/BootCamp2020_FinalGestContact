CREATE PROCEDURE [dbo].[CSP_UpdateContact]
    @Id int,
	@LastName NVARCHAR(75), 
    @FirstName NVARCHAR(75), 
    @Email NVARCHAR(320), 
    @Phone NVARCHAR(20), 
    @BirthDate DATE,
    @CustomerId INT
AS
BEGIN
	UPDATE Contact 
    SET LastName = @LastName, 
        FirstName = @FirstName, 
        Email = @Email, 
        Phone = @Phone, 
        BirthDate = @BirthDate 
    WHERE Id = @Id And CustomerId = @CustomerId;
END
