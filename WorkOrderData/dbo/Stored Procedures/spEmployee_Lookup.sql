CREATE PROCEDURE [dbo].[spEmployee_Lookup]
AS
begin
	set nocount on;

	select EmployeeId, EmployeeFirstName, EmployeeLastName
	from [dbo].[Employee]
	order by EmployeeId;
end
