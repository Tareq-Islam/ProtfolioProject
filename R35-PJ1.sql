USE [R35-PJ1]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08/29/2018 7:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CatName] [varchar](250) NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_pCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryMGRef]    Script Date: 08/29/2018 7:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMGRef](
	[CategoryMGRefID] [bigint] IDENTITY(1,1) NOT NULL,
	[fkMGID] [bigint] NOT NULL,
	[fkCategoryID] [bigint] NOT NULL,
 CONSTRAINT [PK_CategoryMG] PRIMARY KEY CLUSTERED 
(
	[CategoryMGRefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaGallery]    Script Date: 08/29/2018 7:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MediaGallery](
	[MGID] [bigint] IDENTITY(1,1) NOT NULL,
	[fkParentMGID] [bigint] NULL,
	[Caption] [varchar](250) NULL,
	[FilePathOrLink] [varchar](250) NOT NULL,
	[ShortDetails] [varchar](250) NULL,
	[IsDefault] [bit] NULL,
	[IsThumbnail] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MediaGallery] PRIMARY KEY CLUSTERED 
(
	[MGID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 08/29/2018 7:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[fkCategoryID] [bigint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [text] NULL,
	[ProductFeature] [varchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_p_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductMGRef]    Script Date: 08/29/2018 7:49:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMGRef](
	[ProductMGRefID] [bigint] IDENTITY(1,1) NOT NULL,
	[fkMGID] [bigint] NOT NULL,
	[fkProductID] [bigint] NOT NULL,
 CONSTRAINT [PK_p_ProductMG] PRIMARY KEY CLUSTERED 
(
	[ProductMGRefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CategoryMGRef]  WITH CHECK ADD  CONSTRAINT [FK_CategoryMGRef_Category] FOREIGN KEY([fkCategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[CategoryMGRef] CHECK CONSTRAINT [FK_CategoryMGRef_Category]
GO
ALTER TABLE [dbo].[CategoryMGRef]  WITH CHECK ADD  CONSTRAINT [FK_CategoryMGRef_MediaGallery] FOREIGN KEY([fkMGID])
REFERENCES [dbo].[MediaGallery] ([MGID])
GO
ALTER TABLE [dbo].[CategoryMGRef] CHECK CONSTRAINT [FK_CategoryMGRef_MediaGallery]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product] FOREIGN KEY([fkCategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product]
GO
ALTER TABLE [dbo].[ProductMGRef]  WITH CHECK ADD  CONSTRAINT [FK_ProductMGRef_MediaGallery1] FOREIGN KEY([fkMGID])
REFERENCES [dbo].[MediaGallery] ([MGID])
GO
ALTER TABLE [dbo].[ProductMGRef] CHECK CONSTRAINT [FK_ProductMGRef_MediaGallery1]
GO
ALTER TABLE [dbo].[ProductMGRef]  WITH CHECK ADD  CONSTRAINT [FK_ProductMGRef_Product] FOREIGN KEY([fkProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductMGRef] CHECK CONSTRAINT [FK_ProductMGRef_Product]
GO
