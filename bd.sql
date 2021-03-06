USE [master]
GO
/****** Object:  Database [journal]    Script Date: 21.03.2020 21:04:07 ******/
CREATE DATABASE [journal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'journal', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\journal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
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
USE [journal]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21.03.2020 21:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 21.03.2020 21:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21.03.2020 21:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21.03.2020 21:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21.03.2020 21:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21.03.2020 21:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 21.03.2020 21:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[check]    Script Date: 21.03.2020 21:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[check](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[events]    Script Date: 21.03.2020 21:04:09 ******/
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
/****** Object:  Table [dbo].[sectors]    Script Date: 21.03.2020 21:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sectors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subunit_id] [int] NOT NULL,
	[sector] [varchar](50) NOT NULL,
	[is_main] [bit] NOT NULL,
 CONSTRAINT [PK_sectors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shows]    Script Date: 21.03.2020 21:04:09 ******/
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
/****** Object:  Table [dbo].[Subunits]    Script Date: 21.03.2020 21:04:09 ******/
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
/****** Object:  Table [dbo].[workers]    Script Date: 21.03.2020 21:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[sector_id] [int] NOT NULL,
	[family] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[otch] [varchar](20) NOT NULL,
	[post] [varchar](100) NOT NULL,
	[is_first_login] [bit] NOT NULL,
 CONSTRAINT [PK_workers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 21.03.2020 21:04:09 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_check_delete_worker]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_check_delete_worker] ON [dbo].[check]
(
	[delete_worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_check_reg_worker]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_check_reg_worker] ON [dbo].[check]
(
	[reg_worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_check_sector_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_check_sector_id] ON [dbo].[check]
(
	[sector_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_events_check_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_events_check_id] ON [dbo].[events]
(
	[check_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_events_delete_worker]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_events_delete_worker] ON [dbo].[events]
(
	[delete_worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_events_developer]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_events_developer] ON [dbo].[events]
(
	[developer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_events_report_worker]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_events_report_worker] ON [dbo].[events]
(
	[report_worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sectors_subunit_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_sectors_subunit_id] ON [dbo].[sectors]
(
	[subunit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_shows_check_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_shows_check_id] ON [dbo].[shows]
(
	[check_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_shows_worker_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_shows_worker_id] ON [dbo].[shows]
(
	[worker_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[workers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_workers_sector_id]    Script Date: 21.03.2020 21:04:09 ******/
CREATE NONCLUSTERED INDEX [IX_workers_sector_id] ON [dbo].[workers]
(
	[sector_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 21.03.2020 21:04:09 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[workers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_workers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[workers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_workers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_workers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[workers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_workers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_workers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[workers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_workers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_workers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[workers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_workers_UserId]
GO
ALTER TABLE [dbo].[check]  WITH CHECK ADD  CONSTRAINT [FK_check_sector] FOREIGN KEY([sector_id])
REFERENCES [dbo].[sectors] ([id])
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
ALTER TABLE [dbo].[sectors]  WITH CHECK ADD  CONSTRAINT [FK_sector_subunit] FOREIGN KEY([subunit_id])
REFERENCES [dbo].[Subunits] ([id])
GO
ALTER TABLE [dbo].[sectors] CHECK CONSTRAINT [FK_sector_subunit]
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
REFERENCES [dbo].[sectors] ([id])
GO
ALTER TABLE [dbo].[workers] CHECK CONSTRAINT [FK_worker_sector]
GO
USE [master]
GO
ALTER DATABASE [journal] SET  READ_WRITE 
GO
