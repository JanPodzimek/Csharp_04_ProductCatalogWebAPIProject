CREATE PROCEDURE [dbo].[spProduct_Get]
	@Id int
AS
BEGIN
	SELECT * 
	FROM dbo.Product p
	WHERE p.Id = @Id AND p.IsDeleted = 0
END
