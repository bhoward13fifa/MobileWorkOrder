CREATE TABLE [dbo].[WorkOrderImages]
(
	[ImageId] INT NOT NULL IDENTITY,
	[WorkOrderId] INT NOT NULL,
	[ImageFileName] NVARCHAR(128) NOT NULL,
	[ImageData] VARBINARY(MAX) NOT NULL
	CONSTRAINT PK_WorkOrderImages PRIMARY KEY (WorkOrderId, ImageId),
	CONSTRAINT [OrderId_OrderImages_ToTable] FOREIGN KEY ([WorkOrderId]) REFERENCES WorkOrder([WorkOrderId])

)