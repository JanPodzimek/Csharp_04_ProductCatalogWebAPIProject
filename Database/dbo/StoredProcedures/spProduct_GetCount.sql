CREATE PROCEDURE [dbo].[spProduct_GetCount]
	
AS
BEGIN
	SELECT COUNT(p.Id) FROM dbo.Product p
END
