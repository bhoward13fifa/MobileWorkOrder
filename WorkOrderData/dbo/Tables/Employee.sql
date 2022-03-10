CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [EmployeeFirstName] VARCHAR(25) NOT NULL, 
    [EmployeeLastName] VARCHAR(25) NOT NULL, 
    [EmployeeEmail] VARCHAR(254) NOT NULL, 
    [EmployeePhone] NCHAR(15) NOT NULL
)
