CREATE PROCEDURE [dbo].[spProduct_Put]
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
		Quantity = @Quantity
	WHERE
		Ean = @Ean
END
