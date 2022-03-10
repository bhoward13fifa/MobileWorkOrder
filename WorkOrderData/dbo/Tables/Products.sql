CREATE TABLE [dbo].[Products]
(
	[ProductId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [ProductName] VARCHAR(50) NOT NULL, 
    [ProductDescription] VARCHAR(MAX) NOT NULL, 
    [ProductCost] MONEY NOT NULL, 
    [ProductPrice] MONEY NOT NULL,
    [CreateDate] DATETIME NOT NULL,
    [LastModified] DATETIME NOT NULL
)
