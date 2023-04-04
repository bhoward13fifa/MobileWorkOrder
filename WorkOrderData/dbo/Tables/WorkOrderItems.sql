CREATE TABLE [dbo].[WorkOrderItems]
(
	[WorkOrderId] INT NOT NULL ,      
    [ProductId] NVARCHAR(50) NOT NULL, 
    [ProductQuantity] INT NOT NULL
    CONSTRAINT PK_WorkOrderItems PRIMARY KEY (WorkOrderId, ProductId)
    CONSTRAINT [OrderId_OrderItems_ToTable] FOREIGN KEY ([WorkOrderId]) REFERENCES WorkOrder([WorkOrderId]),
    CONSTRAINT [ProdId_OrderItems_ToTable] FOREIGN KEY ([ProductId]) REFERENCES Products([ProductId])
)
