CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Ean] NVARCHAR(20) NOT NULL,
    [Description] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL, 
    [PriceUpdated] DATETIME2 NULL, 
    [Quantity] INT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
)
