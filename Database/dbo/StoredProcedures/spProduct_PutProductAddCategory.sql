CREATE PROCEDURE [dbo].[spProduct_PutProductAddCategory]
	@ProductId int,
	@CategoryId int,
	@IsMain bit = 0

AS
BEGIN
	INSERT INTO dbo.ProductCategory (ProductId, CategoryId, IsMain)
	VALUES (@ProductId, @CategoryId, @IsMain)
END
