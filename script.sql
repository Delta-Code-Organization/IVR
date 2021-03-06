USE [master]
GO
/****** Object:  Database [IVRDB]    Script Date: 03/03/2014 14:53:52 ******/
CREATE DATABASE [IVRDB] ON  PRIMARY 
( NAME = N'IvrDB', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IvrDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IvrDB_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IvrDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IVRDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IVRDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IVRDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [IVRDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [IVRDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [IVRDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [IVRDB] SET ARITHABORT OFF
GO
ALTER DATABASE [IVRDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [IVRDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [IVRDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [IVRDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [IVRDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [IVRDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [IVRDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [IVRDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [IVRDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [IVRDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [IVRDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [IVRDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [IVRDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [IVRDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [IVRDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [IVRDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [IVRDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [IVRDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [IVRDB] SET  READ_WRITE
GO
ALTER DATABASE [IVRDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [IVRDB] SET  MULTI_USER
GO
ALTER DATABASE [IVRDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [IVRDB] SET DB_CHAINING OFF
GO
USE [IVRDB]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [int] NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[Term_associated] [nvarchar](50) NULL,
	[CreditHours] [int] NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (7, 2514, N'عربي', N'الاول', 2)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (8, 2545, N'انجليزي', N'الاول', 54)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (43, 2757, N'khklho', N'jhkhk', 2)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (44, 2010, N'add', N'sss', 7)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (48, 6566, N'tjhwt', N'uku', 5)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (49, 2827, N'gghghg', N'ytitdj', 2)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (50, 25252, N'yuiuy', N'ujjjj', 5)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (52, 5554, N'french', N'hhhh', 1)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (53, 555, N'jkjjkj', N'lll', 8)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (54, 55555, N'hhhhh', N'kkkk', 55)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (55, 22222, N'jjjjjjjjjjj', N'llllllllll', 3)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (56, 77777, N'hyhyhhy', N'hhhh', 7)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (57, 8888, N'hhhh', N'tgtt', 5)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (58, 8888, N'popopo', N'tgtt', 4)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (59, 5557, N'jjjj', N'lll', 10)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (60, 6666, N'hggggggggggg', N'ffff', 4)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (61, 3963, N'mnmnnnmmmmmmmmm', N'llll', 2)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (62, 4111, N'llllllllllll', N'kkkk', 10)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (63, 1471, N'ghgbwe', N'kkk', 11)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (64, 444, N'llll44', N'.llll', 4)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (65, 125, N'كيمياء', N'الاول', 2)
INSERT [dbo].[Course] ([CourseID], [CourseCode], [CourseName], [Term_associated], [CreditHours]) VALUES (66, 1112, N'1عربي', N'اول', 5)
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  Table [dbo].[SystemUser]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SystemUser] ON
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (1, N'wesam ', N'123', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (2, N'nor', N'456', 5)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (3, N'ايمان', N'789', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (4, N'أحمد محمد احمد محمد احمد ليش', N'246', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (10, N'ali', N'7895', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (14, N'ghk', N'124654', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (17, N'uuuu', N'666', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (18, N'qsqsq', N'qwqw', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (20, N'anisa', N'123', 1)
INSERT [dbo].[SystemUser] ([ID], [UserName], [Password], [Status]) VALUES (21, N'لما', N'246', 1)
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[S_email] [nvarchar](50) NULL,
	[S_name] [nvarchar](50) NULL,
	[S_pw] [nvarchar](50) NULL,
	[S_phone] [nvarchar](50) NULL,
	[Credits_aquired] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (6, N'Email', N'maha11', N'20', N'01283', 5)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (8, N'dstwfdue24', N'samy', N'24', N'012012224', 2)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (11, N'iwrhjq', N'juhgujg', N'545', N'0122547', 4)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (13, N'walaa@yahoo.com', N'walaa', N'100', N'25', 6)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (14, N'fbvyt3vb', N'sanaa', N'100', N'01212', 3)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (15, N'yhytgb', N'alaa', N'7528', N'502521', 1)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (16, N'yhytgb', N'fanan', N'7528', N'502521', 1)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (19, N'wd2wd', N'hjgre', N'20122', N'wddw', 12)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (20, N'r4hg6 h', N'gamal', N'125', N'012547897', 20)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (21, N'/y.7ki,.k', N'nermeen', N'5546', N'012527', 5)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (27, N'dcqwv w', N'bnvnvn', N'1233', N'01245', 10)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (28, N'jh;tgug', N',mmnm', N'57432', N'012', 7)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (29, N'vjgj', N'soha', N'123', N'01254', 2)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (31, N'gjhstj', N'sohaad', N'22742', N'041547', 24)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (32, N';upou', N'oioip', N'5654', N'276', 1)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (39, N'vv@dd.kk', N'po', N'66', N'4155', 12)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (41, N'fff@ddd.lll', N'kkk', N'uuu', N'022141', 7)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (44, N'fgg@ddd.kl', N'hhh', N'77', N'14646', 77)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (46, N'nada25@yahoo.com', N'nada', N'255', N'0102', 15)
INSERT [dbo].[Student] ([StudentID], [S_email], [S_name], [S_pw], [S_phone], [Credits_aquired]) VALUES (47, N'sss@yy.cc', N'samy2', N'5444', N'1222', 36)
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[TimeTable]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[TimeTableID] [int] IDENTITY(1,1) NOT NULL,
	[Section_ID] [int] NULL,
	[Capacity] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Day] [int] NULL,
	[Registered] [int] NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[TimeTableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TimeTable] ON
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (5, 7, 50, CAST(0x0000A402011826C0 AS DateTime), CAST(0x0000A40701391C40 AS DateTime), 2, 25)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (8, 52, 55, CAST(0x0000A3FF0107AD2C AS DateTime), CAST(0x0000A4070128A180 AS DateTime), 4, 55)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (10, 54, 555, CAST(0x0000A3FF00000000 AS DateTime), CAST(0x0000A2D000000000 AS DateTime), 1, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (12, 56, 77, CAST(0x0000A3FF00317040 AS DateTime), CAST(0x0000A40700735B40 AS DateTime), 2, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (13, 57, 555, CAST(0x0000A3FF00A4CB80 AS DateTime), CAST(0x0000A40700C5C100 AS DateTime), 1, 3)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (14, 58, 555, CAST(0x0000A3FF0083D600 AS DateTime), CAST(0x0000A40700A4CB80 AS DateTime), 3, 1)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (21, 7, 50, CAST(0x0000A40000000000 AS DateTime), CAST(0x0000A3FF00000000 AS DateTime), 2, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (22, 7, 50, CAST(0x0000A3FF009450C0 AS DateTime), CAST(0x0000A3FF00C5C100 AS DateTime), 1, 1)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (24, 7, 8, CAST(0x0000A2DF00C5C100 AS DateTime), CAST(0x0000A2DF00F73140 AS DateTime), 1, 2)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (25, 52, 10, CAST(0x0000A3FF009450C0 AS DateTime), CAST(0x0000A3FF00C5C100 AS DateTime), 3, 10)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (26, 44, 25, CAST(0x0000A2E200C5C100 AS DateTime), CAST(0x0000A2E200F73140 AS DateTime), 5, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (27, 7, 22, CAST(0x0000A2E200A4CB80 AS DateTime), CAST(0x0000A2E200CDFE60 AS DateTime), 1, 1)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (28, 66, 40, CAST(0x0000A2E2009450C0 AS DateTime), CAST(0x0000A2E200BD83A0 AS DateTime), 0, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (29, 43, 11, CAST(0x0000A2E20083D600 AS DateTime), CAST(0x0000A2E200A4CB80 AS DateTime), 0, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (30, 52, 25, CAST(0x0000A2E2008C1360 AS DateTime), CAST(0x0000A2E200AD08E0 AS DateTime), 0, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (31, 8, 5, CAST(0x0000A2E200A4CB80 AS DateTime), CAST(0x0000A2E200C5C100 AS DateTime), 1, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (32, 7, 5, CAST(0x0000A2E200A4CB80 AS DateTime), CAST(0x0000A2E200C5C100 AS DateTime), 1, 0)
INSERT [dbo].[TimeTable] ([TimeTableID], [Section_ID], [Capacity], [StartTime], [EndTime], [Day], [Registered]) VALUES (33, 65, 15, CAST(0x0000A2E200C5C100 AS DateTime), CAST(0x0000A2E200F73140 AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
/****** Object:  Table [dbo].[Prerequisites]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prerequisites](
	[PRID] [int] IDENTITY(1,1) NOT NULL,
	[PRCode] [int] NULL,
 CONSTRAINT [PK_Prerequisites] PRIMARY KEY CLUSTERED 
(
	[PRID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 03/03/2014 14:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[CourseTime] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse_1] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 6, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 8, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 11, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 13, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 14, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 15, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 16, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 19, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 20, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 27, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 31, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 32, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (7, 41, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 8, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 13, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 14, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 15, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 16, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 19, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 28, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (8, 32, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (52, 11, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (57, 13, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (57, 15, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (57, 16, 5)
INSERT [dbo].[StudentCourse] ([CourseID], [StudentID], [CourseTime]) VALUES (58, 14, 5)
/****** Object:  ForeignKey [FK_TimeTable_Course]    Script Date: 03/03/2014 14:53:55 ******/
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Course] FOREIGN KEY([Section_ID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Course]
GO
/****** Object:  ForeignKey [FK_Prerequisites_Course]    Script Date: 03/03/2014 14:53:55 ******/
ALTER TABLE [dbo].[Prerequisites]  WITH CHECK ADD  CONSTRAINT [FK_Prerequisites_Course] FOREIGN KEY([PRCode])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Prerequisites] CHECK CONSTRAINT [FK_Prerequisites_Course]
GO
/****** Object:  ForeignKey [FK_StudentCourse_Course]    Script Date: 03/03/2014 14:53:55 ******/
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
/****** Object:  ForeignKey [FK_StudentCourse_Student]    Script Date: 03/03/2014 14:53:55 ******/
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
/****** Object:  ForeignKey [FK_StudentCourse_TimeTable]    Script Date: 03/03/2014 14:53:55 ******/
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_TimeTable] FOREIGN KEY([CourseTime])
REFERENCES [dbo].[TimeTable] ([TimeTableID])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_TimeTable]
GO
