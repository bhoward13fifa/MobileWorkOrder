CREATE PROCEDURE [dbo].[spWorkOrder_Lookup]
	@UserId nvarchar(128),
	@StartTime datetime2,
	@EndTime datetime2
AS
begin
	set nocount on;

	select WorkOrderId
	from dbo.WorkOrder
	where UserId = @UserId and StartTime = @StartTime and EndTime = @EndTime;
end
