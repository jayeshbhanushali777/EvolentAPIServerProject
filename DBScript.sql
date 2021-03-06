/****** Object:  Table [dbo].[Contacts]    Script Date: 16-07-2018 13:40:23 ******/
DROP TABLE [dbo].[Contacts]
GO
/****** Object:  User [BUILTIN\Users]    Script Date: 16-07-2018 13:40:23 ******/
DROP USER [BUILTIN\Users]
GO
/****** Object:  User [FPS\jayesh.damani]    Script Date: 16-07-2018 13:40:23 ******/
DROP USER [FPS\jayesh.damani]
GO
/****** Object:  User [ntpc02293\Administrator]    Script Date: 16-07-2018 13:40:23 ******/
DROP USER [ntpc02293\Administrator]
GO
/****** Object:  Database [Evolent]    Script Date: 16-07-2018 13:40:23 ******/
DROP DATABASE [Evolent]
GO
/****** Object:  Database [Evolent]    Script Date: 16-07-2018 13:40:23 ******/
CREATE DATABASE [Evolent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Evolent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Evolent.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Evolent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Evolent_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Evolent] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Evolent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Evolent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Evolent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Evolent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Evolent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Evolent] SET ARITHABORT OFF 
GO
ALTER DATABASE [Evolent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Evolent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Evolent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Evolent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Evolent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Evolent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Evolent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Evolent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Evolent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Evolent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Evolent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Evolent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Evolent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Evolent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Evolent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Evolent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Evolent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Evolent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Evolent] SET  MULTI_USER 
GO
ALTER DATABASE [Evolent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Evolent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Evolent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Evolent] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Evolent] SET DELAYED_DURABILITY = DISABLED 
GO
/****** Object:  User [ntpc02293\Administrator]    Script Date: 16-07-2018 13:40:23 ******/
CREATE USER [ntpc02293\Administrator] FOR LOGIN [ntpc02293\Administrator] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [FPS\jayesh.damani]    Script Date: 16-07-2018 13:40:23 ******/
CREATE USER [FPS\jayesh.damani] FOR LOGIN [FPS\jayesh.damani] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [BUILTIN\Users]    Script Date: 16-07-2018 13:40:23 ******/
CREATE USER [BUILTIN\Users] FOR LOGIN [BUILTIN\Users]
GO
ALTER ROLE [db_owner] ADD MEMBER [ntpc02293\Administrator]
GO
ALTER ROLE [db_owner] ADD MEMBER [FPS\jayesh.damani]
GO
ALTER ROLE [db_owner] ADD MEMBER [BUILTIN\Users]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 16-07-2018 13:40:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ID], [FirstName], [LastName], [Address], [Email], [PhoneNumber], [Status]) VALUES (1, N'Mark', N'Styphen', N'Pune', N'markstyphen@test.com', N'0112233445', N'0')
INSERT [dbo].[Contacts] ([ID], [FirstName], [LastName], [Address], [Email], [PhoneNumber], [Status]) VALUES (2, N'Henry', N'John', N'Mumbai', N'henryjohn@test.com', N'0998877665', N'1')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
ALTER DATABASE [Evolent] SET  READ_WRITE 
GO
