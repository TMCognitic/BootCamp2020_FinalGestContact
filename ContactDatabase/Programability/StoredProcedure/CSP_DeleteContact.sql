CREATE PROCEDURE [dbo].[CSP_DeleteContact]
	@Id INT,
	@CustomerId INT
AS
BEGIN
	DELETE FROM Contact
	WHERE Id = @Id And CustomerId = @CustomerId;
END
