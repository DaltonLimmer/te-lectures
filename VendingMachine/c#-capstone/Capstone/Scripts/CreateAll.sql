USE [master]
GO

/****** Object:  Database [VendingMachine]    Script Date: 3/8/2018 10:16:58 AM ******/
DROP DATABASE [VendingMachine]
GO

/****** Object:  Database [VendingMachine]    Script Date: 3/8/2018 10:14:57 AM ******/
CREATE DATABASE [VendingMachine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VendingMachine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VendingMachine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VendingMachine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VendingMachine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VendingMachine] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VendingMachine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VendingMachine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VendingMachine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VendingMachine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VendingMachine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VendingMachine] SET ARITHABORT OFF 
GO
ALTER DATABASE [VendingMachine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VendingMachine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VendingMachine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VendingMachine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VendingMachine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VendingMachine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VendingMachine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VendingMachine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VendingMachine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VendingMachine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VendingMachine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VendingMachine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VendingMachine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VendingMachine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VendingMachine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VendingMachine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VendingMachine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VendingMachine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VendingMachine] SET  MULTI_USER 
GO
ALTER DATABASE [VendingMachine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VendingMachine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VendingMachine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VendingMachine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VendingMachine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VendingMachine] SET QUERY_STORE = OFF
GO
USE [VendingMachine]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [VendingMachine]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/8/2018 10:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Noise] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 3/8/2018 10:14:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Qty] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[Col] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/8/2018 10:14:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [real] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF_Inventory_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [VendingMachine] SET  READ_WRITE 
GO

USE [VendingMachine]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (2, N'Beverage', N'Glug, Glug, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (3, N'Candy', N'Munch, Munch, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (4, N'Chips', N'Crunch, Crunch, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (5, N'Gum', N'Chew, Chew, Yum!')
GO
INSERT [dbo].[Category] ([Id], [Name], [Noise]) VALUES (6, N'Nuts', N'Nibble, Nibble, Yum!')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (1, N'Sea Salt Kettle Style Potato Chips', 0.75, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (2, N'Jalepeno Kettle Stlye Potato Chips', 0.75, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (3, N'Nacho Cheesiest Tortilla Chips', 0.6, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (4, N'Cloud Popcorn', 0.85, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (5, N'Moonpie', 1.2, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (6, N'Peanut Carmel Nouget Bar', 0.9, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (7, N'Wonka Bar', 0.95, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (8, N'One Hundred Million Bar', 1, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (9, N'Roasted Salted Almonds', 1.25, 6)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (10, N'Mr. Forest''s Chocolate Chip Cookies', 1.5, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (11, N'Honey Mustard Pretzels', 0.65, 4)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (12, N'Raisin Chocolate Goodness', 1.1, 3)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (13, N'Cinnamon Hots Gum', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (14, N'Little League Chew', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (15, N'Sugarless Fruit Gum', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (16, N'Triplemint', 0.75, 5)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (17, N'Chillin'' Cola', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (18, N'Dr. Salt', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (19, N'Mountain Melter', 0.5, 2)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [CategoryId]) VALUES (20, N'Surge', 0.5, 2)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (2, 5, 1, 1, 1)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (3, 5, 1, 2, 2)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (4, 5, 1, 3, 3)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (5, 5, 1, 4, 4)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (6, 5, 2, 1, 5)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (7, 5, 2, 2, 6)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (8, 5, 2, 3, 7)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (9, 5, 2, 4, 8)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (10, 5, 3, 1, 9)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (11, 5, 3, 2, 10)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (12, 5, 3, 3, 11)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (13, 5, 3, 4, 12)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (14, 5, 4, 1, 13)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (15, 5, 4, 2, 14)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (16, 5, 4, 3, 15)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (17, 5, 4, 4, 16)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (18, 5, 5, 1, 17)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (19, 5, 5, 2, 18)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (20, 5, 5, 3, 19)
GO
INSERT [dbo].[Inventory] ([Id], [Qty], [Row], [Col], [ProductId]) VALUES (21, 5, 5, 4, 20)
GO
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
