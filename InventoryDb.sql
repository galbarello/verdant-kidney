USE [master]
GO

/****** Object:  Database [InventoryDb]    Script Date: 18/02/2016 09:41:35 p.m. ******/
CREATE DATABASE [InventoryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Inventory.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Inventory_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [InventoryDb] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [InventoryDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [InventoryDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [InventoryDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [InventoryDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [InventoryDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [InventoryDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [InventoryDb] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [InventoryDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [InventoryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [InventoryDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [InventoryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [InventoryDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [InventoryDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [InventoryDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [InventoryDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [InventoryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [InventoryDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [InventoryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [InventoryDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [InventoryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [InventoryDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [InventoryDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [InventoryDb] SET  MULTI_USER 
GO

ALTER DATABASE [InventoryDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [InventoryDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [InventoryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [InventoryDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [InventoryDb] SET  READ_WRITE 
GO
USE [InventoryDb]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 18/02/2016 09:37:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProductEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (1, 1, N'Mochila', CAST(15.00 AS Decimal(18, 2)), 1, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (2, 2, N'Mochila', CAST(40.00 AS Decimal(18, 2)), 2, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (3, 3, N'Martillo', CAST(40.00 AS Decimal(18, 2)), 2, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (4, 4, N'Mayonesa', CAST(20.00 AS Decimal(18, 2)), 2, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (5, 5, N'Puerta', CAST(20.00 AS Decimal(18, 2)), 2, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (6, 6, N'tornillo', CAST(20.00 AS Decimal(18, 2)), 2, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (7, 7, N'taza', CAST(20.00 AS Decimal(18, 2)), 22, 1)
GO
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Quantity], [IsActive]) VALUES (8, 8, N'taza', CAST(20.00 AS Decimal(18, 2)), 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
