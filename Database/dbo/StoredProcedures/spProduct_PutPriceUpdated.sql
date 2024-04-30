CREATE PROCEDURE [dbo].[spProduct_PutPriceUpdated]
	@Ean nvarchar(20),
	@Description nvarchar(50),
	@Price int,
	@PriceUpdated datetime2,
	@Quantity int
AS
BEGIN
	UPDATE Product
	SET
		Description = @Description,
		Price = @Price,
		PriceUpdated = @PriceUpdated,
		Quantity = @Quantity
	WHERE
		Ean = @Ean
END
