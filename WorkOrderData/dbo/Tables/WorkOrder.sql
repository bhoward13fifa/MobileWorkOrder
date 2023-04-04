CREATE TABLE [dbo].[WorkOrder]
(
	[WorkOrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [WorkDescription] VARCHAR(MAX) NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL,
    CONSTRAINT [CustId_WorkOrder_ToTable] FOREIGN KEY ([CustomerId]) REFERENCES Customer([CustomerId])
)
