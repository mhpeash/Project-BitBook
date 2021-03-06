USE [master]
GO
/****** Object:  Database [BitBook]    Script Date: 26-Jun-16 12:16:13 PM ******/
CREATE DATABASE [BitBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BitBook', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\BitBook.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BitBook_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\BitBook_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BitBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BitBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BitBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BitBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BitBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BitBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BitBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [BitBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BitBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BitBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BitBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BitBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BitBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BitBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BitBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BitBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BitBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BitBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BitBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BitBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BitBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BitBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BitBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BitBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BitBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BitBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BitBook] SET  MULTI_USER 
GO
ALTER DATABASE [BitBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BitBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BitBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BitBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BitBook]
GO
/****** Object:  Table [dbo].[AdditionalInfo]    Script Date: 26-Jun-16 12:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdditionalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProfilePhoto] [nvarchar](50) NULL,
	[CoverPhoto] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Education] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AdditionalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Friend]    Script Date: 26-Jun-16 12:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[UserId] [int] NULL,
	[FriendId] [int] NULL,
	[temp] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profile]    Script Date: 26-Jun-16 12:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 26-Jun-16 12:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstNale] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[ConfirmPassword] [varchar](50) NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdditionalInfo] ON 

INSERT [dbo].[AdditionalInfo] ([Id], [UserId], [ProfilePhoto], [CoverPhoto], [Gender], [Education], [Location]) VALUES (1, 1, N'Images/download.jpg', N'Images/nature-path-facebook-cover-photo.jpg', N'Male', N'B.Sc in CSE', N'Dhaka')
INSERT [dbo].[AdditionalInfo] ([Id], [UserId], [ProfilePhoto], [CoverPhoto], [Gender], [Education], [Location]) VALUES (2, 2, N'Images/nerd.png ', N'Images/Cover (1).jpg', N'Male', N'', N'')
INSERT [dbo].[AdditionalInfo] ([Id], [UserId], [ProfilePhoto], [CoverPhoto], [Gender], [Education], [Location]) VALUES (3, 1003, N'Images/nerd.png ', N'Images/Cover (1).jpg', N'Female', N'', N'')
INSERT [dbo].[AdditionalInfo] ([Id], [UserId], [ProfilePhoto], [CoverPhoto], [Gender], [Education], [Location]) VALUES (4, 1004, N'Images/nerd.png ', N'Images/Cover (1).jpg', N'Female', N'', N'')
SET IDENTITY_INSERT [dbo].[AdditionalInfo] OFF
SET IDENTITY_INSERT [dbo].[Profile] ON 

INSERT [dbo].[Profile] ([StatusId], [UserId], [Status]) VALUES (4, 1, N'Hello')
INSERT [dbo].[Profile] ([StatusId], [UserId], [Status]) VALUES (5, 2, N'Life.....')
INSERT [dbo].[Profile] ([StatusId], [UserId], [Status]) VALUES (6, 1, N'dsfsg dfdf')
INSERT [dbo].[Profile] ([StatusId], [UserId], [Status]) VALUES (7, 1003, N'Hello World.....')
SET IDENTITY_INSERT [dbo].[Profile] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([UserId], [FirstNale], [LastName], [Email], [UserName], [Password], [ConfirmPassword]) VALUES (1, N'Rohul Amin', N'Shuvo', N'rohul1392@live.com', N'shuvo', N'1234', N'1234')
INSERT [dbo].[UserAccount] ([UserId], [FirstNale], [LastName], [Email], [UserName], [Password], [ConfirmPassword]) VALUES (2, N'Mohibul ', N'Hasan', N'Hasan@erg.com', N'Hasan', N'123', N'123')
INSERT [dbo].[UserAccount] ([UserId], [FirstNale], [LastName], [Email], [UserName], [Password], [ConfirmPassword]) VALUES (1003, N'Arfina', N'sharlin', N'sharlin@gmail.com', N'sharlin', N'12345', N'12345')
INSERT [dbo].[UserAccount] ([UserId], [FirstNale], [LastName], [Email], [UserName], [Password], [ConfirmPassword]) VALUES (1004, N'mozammel', N'azad', N'azad@sala.com', N'azad', N'1111', N'1111')
INSERT [dbo].[UserAccount] ([UserId], [FirstNale], [LastName], [Email], [UserName], [Password], [ConfirmPassword]) VALUES (1005, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
USE [master]
GO
ALTER DATABASE [BitBook] SET  READ_WRITE 
GO
