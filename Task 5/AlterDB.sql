USE [GameWebsite]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developer](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESRB_Rating]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESRB_Rating](
	[RatingID] [int] NOT NULL,
	[Rating] [nvarchar](25) NOT NULL,
	[LowestAge] [tinyint] NULL,
	[HighestAge] [tinyint] NULL,
 CONSTRAINT [PK_ESRB_Rating] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DeveloperID] [int] NOT NULL,
	[ESRBRatingID] [int] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_Genre]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_Genre](
	[GameID] [int] NOT NULL,
	[GenreID] [int] NOT NULL,
 CONSTRAINT [PK_Game_Genre] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC,
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_Platform]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_Platform](
	[GameID] [int] NOT NULL,
	[PlatformID] [int] NOT NULL,
	[ReleaseDate] [datetime] NULL,
 CONSTRAINT [PK_Game_Platform] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC,
	[PlatformID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_User_Platform]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_User_Platform](
	[GameID] [int] NOT NULL,
	[UserNickname] [nvarchar](30) NOT NULL,
	[PlatformID] [int] NOT NULL,
	[Mark] [decimal](10, 1) NOT NULL,
	[Review] [nvarchar](200) NULL,
 CONSTRAINT [PK_Game_User_Platform] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC,
	[UserNickname] ASC,
	[PlatformID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platform]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platform](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Platform] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.03.2021 1:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Nickname] [nvarchar](30) NOT NULL,
	[IsCritic] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Developer] FOREIGN KEY([DeveloperID])
REFERENCES [dbo].[Developer] ([ID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Developer]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_ESRB_Rating] FOREIGN KEY([ESRBRatingID])
REFERENCES [dbo].[ESRB_Rating] ([RatingID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_ESRB_Rating]
GO
ALTER TABLE [dbo].[Game_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Game_Genre_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[Game_Genre] CHECK CONSTRAINT [FK_Game_Genre_Game]
GO
ALTER TABLE [dbo].[Game_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Game_Genre_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Game_Genre] CHECK CONSTRAINT [FK_Game_Genre_Genre]
GO
ALTER TABLE [dbo].[Game_Platform]  WITH CHECK ADD  CONSTRAINT [FK_Game_Platform_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[Game_Platform] CHECK CONSTRAINT [FK_Game_Platform_Game]
GO
ALTER TABLE [dbo].[Game_Platform]  WITH CHECK ADD  CONSTRAINT [FK_Game_Platform_Platform] FOREIGN KEY([PlatformID])
REFERENCES [dbo].[Platform] ([ID])
GO
ALTER TABLE [dbo].[Game_Platform] CHECK CONSTRAINT [FK_Game_Platform_Platform]
GO
ALTER TABLE [dbo].[Game_User_Platform]  WITH CHECK ADD  CONSTRAINT [FK_Game_User_Platform_Game_Platform] FOREIGN KEY([GameID], [PlatformID])
REFERENCES [dbo].[Game_Platform] ([GameID], [PlatformID])
GO
ALTER TABLE [dbo].[Game_User_Platform] CHECK CONSTRAINT [FK_Game_User_Platform_Game_Platform]
GO
ALTER TABLE [dbo].[Game_User_Platform]  WITH CHECK ADD  CONSTRAINT [FK_Game_User_Platform_User] FOREIGN KEY([UserNickname])
REFERENCES [dbo].[User] ([Nickname])
GO
ALTER TABLE [dbo].[Game_User_Platform] CHECK CONSTRAINT [FK_Game_User_Platform_User]
GO
ALTER TABLE [dbo].[Game_User_Platform]  WITH CHECK ADD  CONSTRAINT [CK_Game_User_Platform] CHECK  (([Mark]>=(0) AND [Mark]<=(10)))
GO
ALTER TABLE [dbo].[Game_User_Platform] CHECK CONSTRAINT [CK_Game_User_Platform]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Game_User_Platform', @level2type=N'CONSTRAINT',@level2name=N'CK_Game_User_Platform'
GO
