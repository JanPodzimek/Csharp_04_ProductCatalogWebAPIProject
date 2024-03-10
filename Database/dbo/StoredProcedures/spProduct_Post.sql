CREATE PROCEDURE [dbo].[spProduct_Post]
	@Ean nvarchar(20),
	@Description nvarchar(50),
	@Price int,
	@Quantity int,
	@CategoryId int
AS
BEGIN
	INSERT INTO dbo.Product (Ean, Description, Price, Quantity)
	VALUES (@Ean, @Description, @Price, @Quantity)

	DECLARE @ProductId INT;
	SET @ProductId = SCOPE_IDENTITY();

	INSERT INTO ProductCategory (ProductId, CategoryId)
    VALUES (@ProductId, @CategoryId)
END
