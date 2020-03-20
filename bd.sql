USE [journal]
GO
ALTER TABLE [dbo].[workers] DROP CONSTRAINT [FK_worker_sector]
GO
ALTER TABLE [dbo].[shows] DROP CONSTRAINT [FK_shows_workers]
GO
ALTER TABLE [dbo].[shows] DROP CONSTRAINT [FK_shows_check]
GO
ALTER TABLE [dbo].[Sectors] DROP CONSTRAINT [FK_sector_subunit]
GO
ALTER TABLE [dbo].[events] DROP CONSTRAINT [FK_events_report_worker]
GO
ALTER TABLE [dbo].[events] DROP CONSTRAINT [FK_events_developer]
GO
ALTER TABLE [dbo].[events] DROP CONSTRAINT [FK_events_delete_worker]
GO
ALTER TABLE [dbo].[events] DROP CONSTRAINT [FK_events_check]
GO
ALTER TABLE [dbo].[check] DROP CONSTRAINT [FK_reg_worker]
GO
ALTER TABLE [dbo].[check] DROP CONSTRAINT [FK_delete_worker]
GO
ALTER TABLE [dbo].[check] DROP CONSTRAINT [FK_check_sector]
GO
ALTER TABLE [dbo].[Sectors] DROP CONSTRAINT [DF_Sectors_is_main]
GO
/****** Object:  Table [dbo].[workers]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[workers]
GO
/****** Object:  Table [dbo].[Subunits]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[Subunits]
GO
/****** Object:  Table [dbo].[shows]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[shows]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[Sectors]
GO
/****** Object:  Table [dbo].[events]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[events]
GO
/****** Object:  Table [dbo].[check]    Script Date: 20.03.2020 18:47:04 ******/
DROP TABLE [dbo].[check]
GO
USE [master]
GO
/****** Object:  Database [journal]    Script Date: 20.03.2020 18:47:04 ******/
DROP DATABASE [journal]
GO
/****** Object:  Database [journal]    Script Date: 20.03.2020 18:47:04 ******/
CREATE DATABASE [journal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'journal', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\journal.mdf' , SIZE = 6080KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'journal_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\journal_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [journal] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [journal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [journal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [journal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [journal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [journal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [journal] SET ARITHABORT OFF 
GO
ALTER DATABASE [journal] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [journal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [journal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [journal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [journal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [journal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [journal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [journal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [journal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [journal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [journal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [journal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [journal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [journal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [journal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [journal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [journal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [journal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [journal] SET  MULTI_USER 
GO
ALTER DATABASE [journal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [journal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [journal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [journal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [journal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [journal]
GO
/****** Object:  Table [dbo].[check]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[check](
	[id] [int] NOT NULL,
	[reg_worker] [int] NOT NULL,
	[delete_worker] [int] NULL,
	[sector_id] [int] NOT NULL,
	[reg_date] [datetime] NOT NULL,
	[check_date] [datetime] NOT NULL,
	[check_worker] [varchar](50) NOT NULL,
	[td_kd] [varchar](50) NOT NULL,
	[control_indicator] [varchar](255) NOT NULL,
	[count_operations] [int] NOT NULL,
	[fail_count] [varchar](11) NOT NULL,
	[fail_description] [varchar](255) NOT NULL,
	[isActive] [bit] NOT NULL,
	[isCorrect] [bit] NOT NULL,
	[delete_date] [datetime] NULL,
	[isFail] [bit] NOT NULL,
 CONSTRAINT [PK_check] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[events]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_id] [int] NOT NULL,
	[developer] [int] NOT NULL,
	[report_worker] [int] NULL,
	[delete_worker] [int] NULL,
	[fail_reason] [varchar](255) NULL,
	[description] [varchar](255) NOT NULL,
	[respons_worker] [varchar](100) NOT NULL,
	[due_date] [date] NOT NULL,
	[develop_date] [datetime] NOT NULL,
	[report] [varchar](15) NULL,
	[proof_inf] [varchar](255) NULL,
	[report_date] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isCorrect] [bit] NOT NULL,
	[delete_date] [datetime] NULL,
 CONSTRAINT [PK_events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sectors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subunit_id] [int] NOT NULL,
	[sector] [varchar](50) NOT NULL,
	[is_main] [bit] NOT NULL,
 CONSTRAINT [PK_Sectors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shows]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shows](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[worker_id] [int] NOT NULL,
 CONSTRAINT [PK_shows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subunits]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subunits](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Subunits] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[workers]    Script Date: 20.03.2020 18:47:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sector_id] [int] NOT NULL,
	[family] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[otch] [varchar](20) NOT NULL,
	[post] [varchar](100) NOT NULL,
	[is_first_login] [bit] NOT NULL,
	[AccessFailedCount] [int] NULL,
	[ConcurrencyStamp] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[EmailConfirmed] [bit] NULL,
	[LockoutEnabled] [bit] NULL,
	[LockoutEnd] [varchar](255) NULL,
	[NormalizedEmail] [varchar](255) NULL,
	[NormalizedUserName] [varchar](255) NULL,
	[PasswordHash] [varchar](255) NULL,
	[PhoneNumber] [varchar](255) NULL,
	[PhoneNumberConfirmed] [bit] NULL,
	[SecurityStamp] [varchar](255) NULL,
	[TwoFactorEnabled] [bit] NULL,
	[UserName] [varchar](255) NULL,
 CONSTRAINT [PK_workers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sectors] ADD  CONSTRAINT [DF_Sectors_is_main]  DEFAULT ((0)) FOR [is_main]
GO
ALTER TABLE [dbo].[check]  WITH CHECK ADD  CONSTRAINT [FK_check_sector] FOREIGN KEY([sector_id])
REFERENCES [dbo].[Sectors] ([id])
GO
ALTER TABLE [dbo].[check] CHECK CONSTRAINT [FK_check_sector]
GO
ALTER TABLE [dbo].[check]  WITH CHECK ADD  CONSTRAINT [FK_delete_worker] FOREIGN KEY([delete_worker])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[check] CHECK CONSTRAINT [FK_delete_worker]
GO
ALTER TABLE [dbo].[check]  WITH CHECK ADD  CONSTRAINT [FK_reg_worker] FOREIGN KEY([reg_worker])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[check] CHECK CONSTRAINT [FK_reg_worker]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_check] FOREIGN KEY([check_id])
REFERENCES [dbo].[check] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_check]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_delete_worker] FOREIGN KEY([delete_worker])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_delete_worker]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_developer] FOREIGN KEY([developer])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_developer]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_report_worker] FOREIGN KEY([report_worker])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_report_worker]
GO
ALTER TABLE [dbo].[Sectors]  WITH CHECK ADD  CONSTRAINT [FK_sector_subunit] FOREIGN KEY([subunit_id])
REFERENCES [dbo].[Subunits] ([id])
GO
ALTER TABLE [dbo].[Sectors] CHECK CONSTRAINT [FK_sector_subunit]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_check] FOREIGN KEY([check_id])
REFERENCES [dbo].[check] ([id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_check]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_workers] FOREIGN KEY([worker_id])
REFERENCES [dbo].[workers] ([id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_workers]
GO
ALTER TABLE [dbo].[workers]  WITH CHECK ADD  CONSTRAINT [FK_worker_sector] FOREIGN KEY([sector_id])
REFERENCES [dbo].[Sectors] ([id])
GO
ALTER TABLE [dbo].[workers] CHECK CONSTRAINT [FK_worker_sector]
GO
USE [master]
GO
ALTER DATABASE [journal] SET  READ_WRITE 
GO
