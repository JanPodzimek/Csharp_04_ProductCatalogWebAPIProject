CREATE PROCEDURE [dbo].[spProduct_Delete]
	@Id int
AS
BEGIN
	UPDATE dbo.Product
	SET IsDeleted = 1
	WHERE Id = @Id

	UPDATE dbo.ProductCategory
	SET IsDeleted = 1
	WHERE ProductId = @Id
END
