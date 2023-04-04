CREATE PROCEDURE [dbo].[spWorkOrderEmployee_Insert]
	@WorkOrderId int,
	@EmployeeId int
AS
begin
	set nocount on;

	insert into dbo.WorkOrderEmployees (WorkOrderId, EmployeeId)
	values (@WorkOrderId, @EmployeeId)
end