CREATE PROCEDURE [dbo].[spProductCategory_GetAll]

AS
BEGIN
	SELECT pc.ProductId, pc.CategoryId, pc.IsMain, c.[Name] AS 'CategoryName'
	FROM ProductCategory pc
	INNER JOIN Category c ON pc.CategoryId = c.Id
END