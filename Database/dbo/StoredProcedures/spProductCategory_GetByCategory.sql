CREATE PROCEDURE [dbo].[spProductCategory_GetByCategory]
@Id int

AS
BEGIN
	SELECT pc.ProductId, pc.CategoryId, pc.IsMain, c.[Name] AS 'CategoryName'
	FROM ProductCategory pc
	INNER JOIN Category c ON pc.CategoryId = c.Id
	WHERE ProductId IN (
		SELECT ProductId 
		FROM ProductCategory 
		WHERE CategoryId = @Id);
END
