CREATE PROCEDURE [dbo].[spProducts_GetById]
	@Id nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	select ProductId, ProductName, ProductDescription
	from [dbo].[Products]
	where ProductId = @Id
END
