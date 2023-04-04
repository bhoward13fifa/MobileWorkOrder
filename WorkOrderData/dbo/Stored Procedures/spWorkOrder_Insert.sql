CREATE PROCEDURE [dbo].[spWorkOrder_Insert]
	@WorkOrderId int output,
	@WorkDescription varchar(MAX),
	@StartTime datetime2,
	@EndTime datetime2,
	@CustomerId int,
	@UserId nvarchar(128)
AS
begin
	set nocount on;
	insert into dbo.WorkOrder(WorkDescription, StartTime, EndTime, CustomerId, UserId)
	values (@WorkDescription, @StartTime, @EndTime, @CustomerId, @UserId)
end
	SELECT @WorkOrderId = @@Identity;
RETURN 0
