CREATE PROCEDURE [dbo].[spProduct_GetByCategory]
@Id int

AS
BEGIN
	SELECT p.Id, p.Ean, p.Description, p.Price, p.Quantity 
	FROM dbo.Product p
	INNER JOIN dbo.ProductCategory pc ON pc.ProductId = p.Id
	WHERE pc.CategoryId = @Id
END
