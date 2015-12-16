USE [AngkorColorEcommerce]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 12/13/2015 4:20:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Products](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductCode] [varchar](20) NULL,
	[ProductDesc] [nvarchar](max) NULL,
	[ProductBrand] [uniqueidentifier] NULL,
	[ProductCategory] [uniqueidentifier] NULL,
	[Price] [decimal](18, 2) NULL,
	[DateCreated] [date] NULL,
	[DateModified] [date] NULL,
	[DateDeleted] [date] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

