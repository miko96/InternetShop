﻿CREATE TABLE [ISH].[Post]
(
	[PostId] INT IDENTITY(1, 1) NOT NULL,
	[Title] NVARCHAR(255) NOT NULL,
	[Content] NVARCHAR(255) NOT NULL,

	CONSTRAINT PK_Post PRIMARY KEY (PostId)
)
