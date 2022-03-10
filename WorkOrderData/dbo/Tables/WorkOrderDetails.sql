CREATE TABLE [dbo].[WorkOrderDetails]
(
	[WorkOrderId] INT NOT NULL ,      
    [ProductId] NVARCHAR(50) NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [CustomerId] INT NOT NULL,
    [ProductQuantity] INT NOT NULL, 
    [ImageFileName] NVARCHAR(128) NULL,
    [ImageData] VARBINARY(MAX) NULL, 
    PRIMARY KEY ([WorkOrderId], [ProductId]),
    CONSTRAINT [ProdId_OrderDetails_ToTable] FOREIGN KEY ([ProductId]) REFERENCES Products([ProductId])
)
