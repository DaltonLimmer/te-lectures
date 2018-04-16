USE [LoginSampleDB]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 4/16/2018 5:05:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/16/2018 5:05:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](25) NOT NULL,
	[Password] [varchar](128) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersPermissions]    Script Date: 4/16/2018 5:05:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersPermissions](
	[userid] [int] NOT NULL,
	[permissionid] [int] NOT NULL
) ON [PRIMARY]
GO
