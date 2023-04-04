CREATE PROCEDURE [dbo].[spWorkOrderItem_Insert]
	@WorkOrderId int,
	@ProductId nvarchar(50),
	@ProductQuantity int
AS
begin
	set nocount on;

	insert into dbo.WorkOrderItems(WorkOrderId, ProductId, ProductQuantity)
	values (@WorkOrderId, @ProductId, @ProductQuantity)
end
