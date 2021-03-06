USE [RequirementsST]
GO
/****** Object:  Table [dbo].[Applicative]    Script Date: 12/05/2021 12:47:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicative](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Applicative] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/05/2021 12:47:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Area_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevelopmentEngineer]    Script Date: 12/05/2021 12:47:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevelopmentEngineer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstMidName] [varchar](50) NULL,
 CONSTRAINT [PK_DevelopmentEngineer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 12/05/2021 12:47:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requirement]    Script Date: 12/05/2021 12:47:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requirement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AreaID] [int] NULL,
	[ApplicativeID] [int] NULL,
	[ScopeRequirement] [varchar](1000) NULL,
	[ApplicationDate] [datetime] NULL,
	[PriorityID] [int] NULL,
	[DevelopmentEngineerID] [int] NULL,
	[DevelopmentDays] [int] NULL,
	[DevelopmentDate] [datetime] NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Applicative] ON 

INSERT [dbo].[Applicative] ([ID], [Description]) VALUES (1, N'Workep: Project Management Software')
INSERT [dbo].[Applicative] ([ID], [Description]) VALUES (2, N'Salesforce - Sales Cloud')
SET IDENTITY_INSERT [dbo].[Applicative] OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([ID], [Description]) VALUES (1, N'TI')
INSERT [dbo].[Area] ([ID], [Description]) VALUES (2, N'PMO')
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[DevelopmentEngineer] ON 

INSERT [dbo].[DevelopmentEngineer] ([ID], [LastName], [FirstMidName]) VALUES (1, N'Santafe Zorrilla', N'David')
SET IDENTITY_INSERT [dbo].[DevelopmentEngineer] OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON 

INSERT [dbo].[Priority] ([ID], [Description]) VALUES (1, N'Alta')
INSERT [dbo].[Priority] ([ID], [Description]) VALUES (2, N'Media')
INSERT [dbo].[Priority] ([ID], [Description]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[Priority] OFF
GO
SET IDENTITY_INSERT [dbo].[Requirement] ON 

INSERT [dbo].[Requirement] ([ID], [AreaID], [ApplicativeID], [ScopeRequirement], [ApplicationDate], [PriorityID], [DevelopmentEngineerID], [DevelopmentDays], [DevelopmentDate]) VALUES (2, 2, 1, N'Proyecto', CAST(N'2021-05-12T00:41:37.000' AS DateTime), 1, 1, 2, CAST(N'2021-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Requirement] ([ID], [AreaID], [ApplicativeID], [ScopeRequirement], [ApplicationDate], [PriorityID], [DevelopmentEngineerID], [DevelopmentDays], [DevelopmentDate]) VALUES (3, 1, 2, N'Proyecto', CAST(N'2021-05-12T00:43:01.000' AS DateTime), 2, 1, 10, CAST(N'2021-05-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Requirement] OFF
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_Applicative] FOREIGN KEY([ApplicativeID])
REFERENCES [dbo].[Applicative] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_Applicative]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_DevelopmentEngineer] FOREIGN KEY([DevelopmentEngineerID])
REFERENCES [dbo].[DevelopmentEngineer] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_DevelopmentEngineer]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Area_Priority] FOREIGN KEY([PriorityID])
REFERENCES [dbo].[Priority] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Area_Priority]
GO
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Requirement_Area] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Area] ([ID])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Requirement_Area]
GO
