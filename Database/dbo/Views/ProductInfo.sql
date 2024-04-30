CREATE VIEW [dbo].[ProductInfo]

AS 
SELECT p.Id, p.Ean, p.[Description], c.[Name] AS 'Category'
FROM dbo.Product p
JOIN ProductCategory pc ON p.Id = pc.ProductId
JOIN Category c ON pc.CategoryId = c.Id
