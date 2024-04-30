CREATE PROCEDURE [dbo].[spProductCategory_Get]
@Id int

AS
BEGIN
	SELECT pc.ProductId, pc.CategoryId, pc.IsMain, c.[Name] AS 'CategoryName' 
	FROM dbo.ProductCategory pc
	INNER JOIN Category c ON pc.CategoryId = c.Id
	WHERE pc.ProductId = @Id AND pc.IsDeleted = 0
END

