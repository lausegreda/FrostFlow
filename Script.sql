USE [master]
GO
/****** Object:  Database [FrostFlow]    Script Date: 7/6/2024 03:20:50 ******/
CREATE DATABASE [FrostFlow]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FrostFlow', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FrostFlow.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FrostFlow_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FrostFlow_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FrostFlow] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FrostFlow].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FrostFlow] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FrostFlow] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FrostFlow] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FrostFlow] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FrostFlow] SET ARITHABORT OFF 
GO
ALTER DATABASE [FrostFlow] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FrostFlow] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FrostFlow] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FrostFlow] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FrostFlow] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FrostFlow] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FrostFlow] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FrostFlow] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FrostFlow] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FrostFlow] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FrostFlow] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FrostFlow] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FrostFlow] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FrostFlow] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FrostFlow] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FrostFlow] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FrostFlow] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FrostFlow] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FrostFlow] SET  MULTI_USER 
GO
ALTER DATABASE [FrostFlow] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FrostFlow] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FrostFlow] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FrostFlow] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FrostFlow] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FrostFlow] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FrostFlow] SET QUERY_STORE = ON
GO
ALTER DATABASE [FrostFlow] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FrostFlow]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[identificacion] [varchar](50) NULL,
	[direccion] [varchar](255) NULL,
	[telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[id_cotizacion] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_producto] [int] NULL,
	[fecha] [date] NULL,
	[total] [decimal](10, 2) NULL,
	[estado] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[puesto] [varchar](100) NULL,
	[salario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_producto] [int] NULL,
	[total] [decimal](10, 2) NULL,
	[estado] [varchar](50) NULL,
	[id_cotizacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenTrabajo]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenTrabajo](
	[id_orden] [int] IDENTITY(1,1) NOT NULL,
	[id_cotizacion] [int] NULL,
	[id_servicio] [int] NULL,
	[estado] [varchar](50) NULL,
	[fecha] [date] NULL,
	[id_empleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](100) NULL,
	[contrasenna] [varchar](25) NULL,
	[id_Rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([id_Rol], [nombre]) VALUES (1, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([id_Usuario], [nombreUsuario], [contrasenna], [id_Rol]) VALUES (1, N'lsegreda', N'Lau1234', 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([id_cotizacion])
REFERENCES [dbo].[Cotizacion] ([id_cotizacion])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD FOREIGN KEY([id_cotizacion])
REFERENCES [dbo].[Cotizacion] ([id_cotizacion])
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Empleado] ([id_empleado])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([id_Rol])
REFERENCES [dbo].[Rol] ([id_Rol])
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 7/6/2024 03:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Procedimiento almacenado para iniciar sesión
-- =============================================
CREATE   PROCEDURE [dbo].[IniciarSesion]

@nombreUsuario VARCHAR(100),
@contrasenna VARCHAR(25)

AS
BEGIN
	
	SELECT us.nombreUsuario, rol.nombre nombreRol
	FROM Usuario us
	INNER JOIN Rol rol
	ON us.id_Rol = rol.id_Rol
	WHERE nombreUsuario = @nombreUsuario
	AND contrasenna = @contrasenna

END
GO
USE [master]
GO
ALTER DATABASE [FrostFlow] SET  READ_WRITE 
GO
