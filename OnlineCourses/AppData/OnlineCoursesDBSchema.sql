USE [master]
GO
/****** Object:  Database [OnlineCourses]    Script Date: 18/9/2020 9:34:21 πμ ******/
CREATE DATABASE [OnlineCourses]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineCourses', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineCourses.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineCourses_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineCourses_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineCourses] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineCourses].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineCourses] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineCourses] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineCourses] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineCourses] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineCourses] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineCourses] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineCourses] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineCourses] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineCourses] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineCourses] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineCourses] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineCourses] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineCourses] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineCourses] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineCourses] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineCourses] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineCourses] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineCourses] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineCourses] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineCourses] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineCourses] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineCourses] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineCourses] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineCourses] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineCourses] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineCourses] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineCourses] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineCourses] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineCourses] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineCourses] SET QUERY_STORE = OFF
GO
USE [OnlineCourses]
GO
/****** Object:  Table [dbo].[Auditing]    Script Date: 18/9/2020 9:34:21 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditing](
	[Id] [uniqueidentifier] NOT NULL,
	[Host] [nvarchar](max) NULL,
	[Headers] [nvarchar](max) NULL,
	[StatusCode] [nvarchar](50) NULL,
	[RequestBody] [nvarchar](max) NULL,
	[RequestedMethod] [nvarchar](50) NOT NULL,
	[UserHostAddress] [nvarchar](max) NULL,
	[Useragent] [nvarchar](max) NULL,
	[AbsoluteUri] [nvarchar](max) NULL,
	[RequestType] [nvarchar](50) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Auditing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[categoryId] [nvarchar](3) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[id] [int] NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[description] [text] NOT NULL,
	[rating] [numeric](18, 1) NOT NULL,
	[price] [numeric](18, 0) NOT NULL,
	[categoryId] [nvarchar](3) NOT NULL,
	[frameworkId] [nvarchar](5) NOT NULL,
	[instructorId] [int] NOT NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enrolls]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enrolls](
	[userId] [int] NOT NULL,
	[courseId] [int] NOT NULL,
	[comment] [text] NULL,
 CONSTRAINT [PK_enrolls] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[courseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errors]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Errors](
	[Id] [uniqueidentifier] NOT NULL,
	[Message] [text] NULL,
	[RequestMethod] [text] NULL,
	[RequestUri] [text] NULL,
	[TimeUtc] [datetime] NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[framework]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[framework](
	[frameworkId] [nvarchar](5) NOT NULL,
	[name] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_framework] PRIMARY KEY CLUSTERED 
(
	[frameworkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instructor]    Script Date: 18/9/2020 9:34:22 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[id] [int] NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[bio] [text] NOT NULL,
	[language] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_instructor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 18/9/2020 9:34:23 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[gender] [bit] NOT NULL,
	[job] [nvarchar](30) NOT NULL,
	[registerdate] [datetime] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([categoryId])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_category]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_framework] FOREIGN KEY([frameworkId])
REFERENCES [dbo].[framework] ([frameworkId])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_framework]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_instructor] FOREIGN KEY([instructorId])
REFERENCES [dbo].[instructor] ([id])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_instructor]
GO
ALTER TABLE [dbo].[enrolls]  WITH CHECK ADD  CONSTRAINT [FK_enrolls_course] FOREIGN KEY([courseId])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[enrolls] CHECK CONSTRAINT [FK_enrolls_course]
GO
ALTER TABLE [dbo].[enrolls]  WITH CHECK ADD  CONSTRAINT [FK_enrolls_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[enrolls] CHECK CONSTRAINT [FK_enrolls_users]
GO
USE [master]
GO
ALTER DATABASE [OnlineCourses] SET  READ_WRITE 
GO
