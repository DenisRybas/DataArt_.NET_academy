USE [PhysFacGroups]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 19.04.2021 0:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group_1] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 19.04.2021 0:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](40) NOT NULL,
	[Patronymic] [nvarchar](30) NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Groups] ([GroupId], [Name]) VALUES (0, N'радиофизика')
INSERT [dbo].[Groups] ([GroupId], [Name]) VALUES (1, N'микроэлектроника')
INSERT [dbo].[Groups] ([GroupId], [Name]) VALUES (2, N'общая физика')
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (10, N'Сергеев', N'Сергей', N'Сергеевич', 1)
INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (11, N'Антонов', N'Антон', N'Антонович', 2)
INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (12, N'Денисов', N'Денис', N'Денисович', 1)
INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (13, N'Андреев', N'Андре', N'Андреевич', 0)
INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (14, N'Физик', N'Физикович', N'Физиков', 2)
INSERT [dbo].[Students] ([StudentId], [Name], [Surname], [Patronymic], [GroupId]) VALUES (16, N'Иванов', N'Иван', N'Иванович', 0)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
