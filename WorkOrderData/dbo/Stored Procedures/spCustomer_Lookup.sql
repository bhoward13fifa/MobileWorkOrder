CREATE PROCEDURE [dbo].[spCustomer_Lookup]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CustomerId, CustomerFirstName, CustomerLastName
	FROM [dbo].[Customer]
	ORDER BY CustomerId;
END
