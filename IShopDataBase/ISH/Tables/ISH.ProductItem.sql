CREATE TABLE [ISH].[ProductItem]
(
	[ProductItemId] INT IDENTITY(1, 1) NOT NULL,
	[ProductKey] NVARCHAR(36) NOT NULL,
	[Name]  NVARCHAR(255) NOT NULL,
	[Description] NVARCHAR(255) NOT NULL,
	[ImageKey] NVARCHAR(64) NULL,

	CONSTRAINT PK_ProductItem PRIMARY KEY ([ProductItemId])
)
