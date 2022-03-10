CREATE TABLE [dbo].[WorkOrder]
(
	[WorkOrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [WorkDescription] VARCHAR(MAX) NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [EmployeeId] INT NOT NULL, 
    [CustomerId] INT NOT NULL,
    CONSTRAINT [EmpId_WorkOrder_ToTable] FOREIGN KEY ([EmployeeId]) REFERENCES Employee([EmployeeId]),
    CONSTRAINT [CustId_WorkOrder_ToTable] FOREIGN KEY ([CustomerId]) REFERENCES Customer([CustomerId])
)
