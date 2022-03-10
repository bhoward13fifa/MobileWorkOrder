CREATE PROCEDURE [dbo].[spProducts_Lookup]
AS
begin
	set nocount on;

	select ProductId, ProductName, ProductDescription
	from [dbo].[Products]
	order by ProductId;
end
