USE [BDInventarioOtacom]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 25/10/2019 16:20:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FKLocal] [bigint] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Autor] [nvarchar](50) NOT NULL,
	[Edicao] [int] NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
	[PathImagem] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FKLocal] FOREIGN KEY([FKLocal])
REFERENCES [dbo].[Local] ([ID])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FKLocal]
GO


