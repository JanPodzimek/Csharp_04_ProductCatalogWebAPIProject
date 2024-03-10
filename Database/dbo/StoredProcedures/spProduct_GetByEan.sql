CREATE PROCEDURE [dbo].[spProduct_GetByEan]
	@Ean nvarchar(20)
AS
BEGIN
	SELECT * 
	FROM dbo.Product p
	WHERE p.Ean = @Ean AND p.IsDeleted = 0
END
