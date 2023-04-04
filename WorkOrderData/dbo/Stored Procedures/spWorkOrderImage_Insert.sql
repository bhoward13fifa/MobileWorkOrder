CREATE PROCEDURE [dbo].[spWorkOrderImage_Insert]
	@WorkOrderId int,
	@ImageFileName nvarchar(128),
	@ImageData varbinary(MAX)
AS
begin
	set nocount on;

	insert into dbo.WorkOrderImages(WorkOrderId, ImageFileName, ImageData)
	values (@WorkOrderId, @ImageFileName, @ImageData)
end
