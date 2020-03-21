USE [journal]
GO
SET IDENTITY_INSERT [dbo].[Subunits] ON 

INSERT [dbo].[Subunits] ([id], [name]) VALUES (1, N'ОГИ')
INSERT [dbo].[Subunits] ([id], [name]) VALUES (2, N'ОГТ')
INSERT [dbo].[Subunits] ([id], [name]) VALUES (3, N'ОК')
INSERT [dbo].[Subunits] ([id], [name]) VALUES (4, N'ОП')
INSERT [dbo].[Subunits] ([id], [name]) VALUES (5, N'ПДО')
INSERT [dbo].[Subunits] ([id], [name]) VALUES (6, N'Цех')
SET IDENTITY_INSERT [dbo].[Subunits] OFF
SET IDENTITY_INSERT [dbo].[sectors] ON 

INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (1, 1, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (2, 2, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (3, 3, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (4, 3, N'ГВК', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (5, 3, N'ГТК', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (6, 4, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (7, 4, N'СККС', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (8, 5, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (9, 5, N'СК', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (10, 6, N'-', 1)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (11, 6, N'Группа жгутового ремонт', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (12, 6, N'Заготовительный участок', 0)
INSERT [dbo].[sectors] ([id], [subunit_id], [sector], [is_main]) VALUES (13, 6, N'Группа запуска', 0)
SET IDENTITY_INSERT [dbo].[sectors] OFF
SET IDENTITY_INSERT [dbo].[workers] ON 

INSERT [dbo].[workers] ([id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [sector_id], [family], [name], [otch], [post], [is_first_login]) VALUES (1, N'user1', N'USER1', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBS3MwS2NUn6se8GXcxUZiqZCbG5IVwJOSGS7dkcE5SSnw4YW34duBhnLZ4pmPpmLg==', N'TODZL7SUD3HXW2IGL3EADP7R6NDNLW3X', N'1a1e6c9d-8a7c-491b-b8a7-7ecc9b08e2b2', NULL, 0, 0, NULL, 1, 0, 1, N'Иванов', N'Иван', N'Иванович', N'Главный инженер', 1)
SET IDENTITY_INSERT [dbo].[workers] OFF
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'ADMIN', N'ADMIN', N'f5c5e960-2190-4c10-a8bf-5235a4a96bed')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'CHECK_DETAIL', N'CHECK_DETAIL', N'1dbacd5e-d41b-48e1-8280-81dc3c44c355')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'EVENT_DETAIL', N'EVENT_DETAIL', N'0b85ea0f-207b-4811-8b46-7c3228433087')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'SUBSHOW', N'SUBSHOW', N'edb0b465-524d-4a74-9b22-e00b9eaa1e04')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (5, N'DEVEL', N'DEVEL', N'a1234e90-d573-4742-bde5-2842f79d24c4')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (6, N'REPORT', N'REPORT', N'3d4e85e5-b1e4-464a-b321-c0b965ab0cbd')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (7, N'REPORT_SHOW', N'REPORT_SHOW', N'f3b87506-e05f-497c-9d51-cc2f8d7d8a98')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (8, N'CONTROL', N'CONTROL', N'35752bfd-0813-4fc0-98ba-db6276db806a')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (9, N'REG', N'REG', N'7611803f-34f2-49f2-a995-98011c117139')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 8)
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200321115218_identity-migr', N'3.1.2')
