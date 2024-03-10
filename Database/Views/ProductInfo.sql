SELECT TOP (1000) p.Id, p.Ean, p.Description, c.Name AS 'Category'
FROM [ProductCatalogWebAPIProjectDB].[dbo].[Product] p
JOIN ProductCategory pc ON p.Id = pc.ProductId
JOIN Category c ON pc.CategoryId = c.Id