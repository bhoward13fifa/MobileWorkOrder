CREATE PROCEDURE [dbo].[spWorkOrder_GetAll]
AS
begin
	set nocount on;

	select WorkOrderId, WorkDescription, StartTime, EndTime, UserId, CustomerId
	from [dbo].[WorkOrder]
	order by EndTime DESC;
end
