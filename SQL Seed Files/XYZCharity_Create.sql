USE [XYZCharity]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VolunteerAssignment]') AND type in (N'U'))
ALTER TABLE [dbo].[VolunteerAssignment] DROP CONSTRAINT [FKVolunteerA201962]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VolunteerAssignment]') AND type in (N'U'))
ALTER TABLE [dbo].[VolunteerAssignment] DROP CONSTRAINT [FKVolunteerA171722]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogIn]') AND type in (N'U'))
ALTER TABLE [dbo].[LogIn] DROP CONSTRAINT [FKLogIn882434]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gift]') AND type in (N'U'))
ALTER TABLE [dbo].[Gift] DROP CONSTRAINT [FKGift430584]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FKAccount371406]
GO
/****** Object:  Table [dbo].[VolunteerProgram]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[VolunteerProgram]
GO
/****** Object:  Table [dbo].[VolunteerAssignment]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[VolunteerAssignment]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[LogIn]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[LogIn]
GO
/****** Object:  Table [dbo].[Gift]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[Gift]
GO
/****** Object:  Table [dbo].[ConstituencyType]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[ConstituencyType]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP TABLE IF EXISTS [dbo].[Account]
GO

USE [master]
GO
/****** Object:  Database [XYZCharity]    Script Date: 2020-05-27 6:20:09 PM ******/
DROP DATABASE IF EXISTS [XYZCharity]
GO
/****** Object:  Database [XYZCharity]    Script Date: 2020-05-27 6:20:09 PM ******/
CREATE DATABASE [XYZCharity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XYZCharity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\XYZCharity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'XYZCharity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\XYZCharity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [XYZCharity] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XYZCharity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XYZCharity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XYZCharity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XYZCharity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XYZCharity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XYZCharity] SET ARITHABORT OFF 
GO
ALTER DATABASE [XYZCharity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XYZCharity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XYZCharity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XYZCharity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XYZCharity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XYZCharity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XYZCharity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XYZCharity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XYZCharity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XYZCharity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XYZCharity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XYZCharity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XYZCharity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XYZCharity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XYZCharity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XYZCharity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XYZCharity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XYZCharity] SET RECOVERY FULL 
GO
ALTER DATABASE [XYZCharity] SET  MULTI_USER 
GO
ALTER DATABASE [XYZCharity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XYZCharity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XYZCharity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XYZCharity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [XYZCharity] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'XYZCharity', N'ON'
GO
ALTER DATABASE [XYZCharity] SET QUERY_STORE = OFF
GO
USE [XYZCharity]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [char](5) NULL,
	[FirstName] [varchar](50)  NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[OrganizationName] [varchar](100) NULL,
	[Suffix] [char](5) NULL,
	[StreetAddress] [varchar](100) NOT NULL,
	[Gender] [char](20) NULL,
	[Email] [varchar](255) NULL,
	[BirthDate] [date] NOT NULL,
	[PhoneNumber] [char](20) NULL,
	[ConstituencyTypeId] [int] NOT NULL,
	[IsInactive] [bit] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Province] [char](5) NOT NULL,
	[Country] [char](20) NOT NULL,
	[PostalCode] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConstituencyType]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstituencyType](
	[ConstituencyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ConstituencyTypeName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConstituencyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gift]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gift](
	[GiftId] [int] IDENTITY(1,1) NOT NULL,
	[GiftDate] [datetime] NOT NULL,
	[ReceivedAmount] [money] NOT NULL,
	[GiftNote] [varchar](255) NULL,
	[GiftType] [varchar](50) NOT NULL,
	[Approach] [varchar](50) NOT NULL,
	[Campaign] [varchar](50) NOT NULL,
	[Fund] [varchar](50) NOT NULL,
	[AccountId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogIn]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogIn](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AccountId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VolunteerAssignment]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerAssignment](
	[ProgramId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[HoursCompleted] [real] NOT NULL,
	[HoursSignedUp] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VolunteerProgram]    Script Date: 2020-05-27 6:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProgram](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[ProgramName] [varchar](50) NOT NULL,
	[ProgramDescription] [varchar](255) NULL,
	[ProgramStartDate] [datetime] NOT NULL,
	[ProgramEndDate] [date] NOT NULL,
	[TargetHeadCount] [int] NULL,
	[TargetFund] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [affliationId] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('') FOR [OrganizationName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('=Canada') FOR [Country]
GO
ALTER TABLE [dbo].[Gift] ADD  DEFAULT ((0)) FOR [ReceivedAmount]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FKAccount371406] FOREIGN KEY([ConstituencyTypeId])
REFERENCES [dbo].[ConstituencyType] ([ConstituencyTypeId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FKAccount371406]
GO
ALTER TABLE [dbo].[Gift]  WITH CHECK ADD  CONSTRAINT [FKGift430584] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Gift] CHECK CONSTRAINT [FKGift430584]
GO
ALTER TABLE [dbo].[LogIn]  WITH CHECK ADD  CONSTRAINT [FKLogIn882434] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LogIn] CHECK CONSTRAINT [FKLogIn882434]
GO
ALTER TABLE [dbo].[VolunteerAssignment]  WITH CHECK ADD  CONSTRAINT [FKVolunteerA171722] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[VolunteerProgram] ([ProgramId])
GO
ALTER TABLE [dbo].[VolunteerAssignment] CHECK CONSTRAINT [FKVolunteerA171722]
GO
ALTER TABLE [dbo].[VolunteerAssignment]  WITH CHECK ADD  CONSTRAINT [FKVolunteerA201962] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[VolunteerAssignment] CHECK CONSTRAINT [FKVolunteerA201962]
GO
USE [master]
GO
ALTER DATABASE [XYZCharity] SET  READ_WRITE 
GO
