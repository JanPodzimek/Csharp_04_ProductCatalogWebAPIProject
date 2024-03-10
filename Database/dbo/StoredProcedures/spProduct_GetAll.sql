CREATE PROCEDURE [dbo].[spProduct_GetAll]

AS
BEGIN
	SELECT p.Id, p.Ean, p.Description, p.Price, p.Quantity 
	FROM dbo.Product p
	WHERE IsDeleted = 0
END
