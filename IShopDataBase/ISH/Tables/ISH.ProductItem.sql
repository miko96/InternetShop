CREATE TABLE [ISH].[ProductItem]
(
	[ProductItemId] INT IDENTITY(1, 1) NOT NULL,
	[Name]  NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL,

	CONSTRAINT PK_ProductItem PRIMARY KEY ([ProductItemId])
)
