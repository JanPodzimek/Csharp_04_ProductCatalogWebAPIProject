CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [CategoryId] INT NOT NULL,
    [IsMain] BIT NOT NULL DEFAULT 1,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
