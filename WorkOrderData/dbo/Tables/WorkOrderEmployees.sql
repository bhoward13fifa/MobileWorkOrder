CREATE TABLE [dbo].[WorkOrderEmployees]
(
	[WorkOrderId] INT NOT NULL,
	[EmployeeId] INT NOT NULL,
	PRIMARY KEY ([WorkOrderId], [EmployeeId]),
	CONSTRAINT [OrderId_OrderEmployees_ToTable] FOREIGN KEY ([WorkOrderId]) REFERENCES WorkOrder([WorkOrderId]),
    CONSTRAINT [EmpId_OrderEmployees_ToTable] FOREIGN KEY ([EmployeeId]) REFERENCES Employee([EmployeeId])
)
