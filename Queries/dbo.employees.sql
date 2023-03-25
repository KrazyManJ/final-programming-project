CREATE TABLE [dbo].[employees]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstname] NVARCHAR(50) NOT NULL, 
    [lastname] NVARCHAR(50) NOT NULL, 
    [birthdate] DATE NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [phonenumber] NVARCHAR(50) NOT NULL
)
