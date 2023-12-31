USE [master]
GO
/****** Object:  Database [pruebademo]    Script Date: 22/06/2023 20:43:07 ******/
CREATE DATABASE [pruebademo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pruebademo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pruebademo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pruebademo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pruebademo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pruebademo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pruebademo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pruebademo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pruebademo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pruebademo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pruebademo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pruebademo] SET ARITHABORT OFF 
GO
ALTER DATABASE [pruebademo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pruebademo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pruebademo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pruebademo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pruebademo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pruebademo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pruebademo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pruebademo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pruebademo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pruebademo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pruebademo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pruebademo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pruebademo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pruebademo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pruebademo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pruebademo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pruebademo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pruebademo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pruebademo] SET  MULTI_USER 
GO
ALTER DATABASE [pruebademo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pruebademo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pruebademo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pruebademo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pruebademo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pruebademo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [pruebademo] SET QUERY_STORE = OFF
GO
USE [pruebademo]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 22/06/2023 20:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](255) NOT NULL,
	[Telefono] [varchar](255) NULL,
	[Correo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 22/06/2023 20:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Precio] [float] NULL,
	[Categoria] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 22/06/2023 20:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventasitems]    Script Date: 22/06/2023 20:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventasitems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDVenta] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[PrecioUnitario] [float] NULL,
	[Cantidad] [float] NULL,
	[PrecioTotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([ID], [Cliente], [Telefono], [Correo]) VALUES (3010, N'Pablo', N'4835412', N'pablo@hotmail.com')
INSERT [dbo].[clientes] ([ID], [Cliente], [Telefono], [Correo]) VALUES (3011, N'Ricardo', N'4856215', N'ricardo@hotmail.com')
INSERT [dbo].[clientes] ([ID], [Cliente], [Telefono], [Correo]) VALUES (3012, N'Federico', N'15448775', N'federico@hotmail.com')
INSERT [dbo].[clientes] ([ID], [Cliente], [Telefono], [Correo]) VALUES (3013, N'Jose', N'15478542', N'jose@hotmail.com')
INSERT [dbo].[clientes] ([ID], [Cliente], [Telefono], [Correo]) VALUES (3014, N'Nahuel', N'4865374', N'nahuel@hotmail.com')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3029, N'Coca Cola 2L', 450, N'Gaseosas')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3030, N'Pepsi 2L', 399.99, N'Gaseosas')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3031, N'Computadora', 20000, N'Tecnologia')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3032, N'Lavandina', 549.99, N'Limpieza')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3033, N'Auriculares', 4999.99, N'Audio')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3034, N'Parlantes', 800, N'Audio')
INSERT [dbo].[productos] ([ID], [Nombre], [Precio], [Categoria]) VALUES (3035, N'Placa de Video', 55499.99, N'Tecnologia')
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([ID], [IDCliente], [Fecha], [Total]) VALUES (2037, 3010, CAST(N'2023-06-22T20:14:15.000' AS DateTime), 13049.98)
INSERT [dbo].[ventas] ([ID], [IDCliente], [Fecha], [Total]) VALUES (2038, 3014, CAST(N'2023-06-22T20:14:28.000' AS DateTime), 22699.98)
INSERT [dbo].[ventas] ([ID], [IDCliente], [Fecha], [Total]) VALUES (2039, 3010, CAST(N'2023-06-22T20:14:44.000' AS DateTime), 255499.99)
INSERT [dbo].[ventas] ([ID], [IDCliente], [Fecha], [Total]) VALUES (2040, 3010, CAST(N'2023-06-22T20:15:01.000' AS DateTime), 12000)
INSERT [dbo].[ventas] ([ID], [IDCliente], [Fecha], [Total]) VALUES (2041, 3013, CAST(N'2023-06-22T20:15:13.000' AS DateTime), 16499.7)
SET IDENTITY_INSERT [dbo].[ventas] OFF
GO
SET IDENTITY_INSERT [dbo].[ventasitems] ON 

INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2042, 2037, 3029, 450, 5, 2250)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2043, 2037, 3033, 4999.99, 2, 9999.98)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2044, 2037, 3034, 800, 1, 800)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2045, 2038, 3032, 549.99, 2, 1099.98)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2046, 2038, 3034, 800, 2, 1600)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2047, 2038, 3031, 20000, 1, 20000)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2048, 2039, 3035, 55499.99, 1, 55499.99)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2049, 2039, 3031, 20000, 10, 200000)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2050, 2040, 3034, 800, 15, 12000)
INSERT [dbo].[ventasitems] ([ID], [IDVenta], [IDProducto], [PrecioUnitario], [Cantidad], [PrecioTotal]) VALUES (2051, 2041, 3032, 549.99, 30, 16499.7)
SET IDENTITY_INSERT [dbo].[ventasitems] OFF
GO
USE [master]
GO
ALTER DATABASE [pruebademo] SET  READ_WRITE 
GO
