CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL, 
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Customer_Email] UNIQUE ([Email]) 
)
