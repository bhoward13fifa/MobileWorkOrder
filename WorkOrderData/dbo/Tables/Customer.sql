CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerFirstName] VARCHAR(35) NOT NULL, 
    [CustomerLastName] VARCHAR(35) NOT NULL, 
    [CustomerAddress] VARCHAR(35) NOT NULL, 
    [CustomerCity] VARCHAR(25) NOT NULL, 
    [CustomerState] VARCHAR(15) NOT NULL, 
    [CustomerZip] VARCHAR(9) NOT NULL, 
    [CustomerEmail] VARCHAR(254) NOT NULL, 
    [CustomerPhone] NVARCHAR(15) NOT NULL
)
