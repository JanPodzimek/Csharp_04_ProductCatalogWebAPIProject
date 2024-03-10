CREATE PROCEDURE [dbo].[spCategory_GetAll]

AS
BEGIN
	SELECT Id, [Name] FROM dbo.Category
	WHERE IsDeleted = 0
END
