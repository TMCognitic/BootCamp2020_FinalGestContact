CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(75) NOT NULL, 
    [FirstName] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Phone] NVARCHAR(20) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Contact_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) 
)
