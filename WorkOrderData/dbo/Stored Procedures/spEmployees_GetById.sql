CREATE PROCEDURE [dbo].[spEmployees_GetById]
		@Id int
AS
BEGIN
	SET NOCOUNT ON;

	select EmployeeId, EmployeeFirstName, EmployeeLastName
	from [dbo].[Employee]
	where EmployeeId = @Id
END
