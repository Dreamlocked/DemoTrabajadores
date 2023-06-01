USE [master]
GO
/****** Object:  Database [DemoTrabajadores]    Script Date: 31/05/2023 19:30:43 ******/
CREATE DATABASE [DemoTrabajadores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DemoTrabajadores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoTrabajadores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DemoTrabajadores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoTrabajadores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DemoTrabajadores] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoTrabajadores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DemoTrabajadores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoTrabajadores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DemoTrabajadores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DemoTrabajadores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoTrabajadores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET RECOVERY FULL 
GO
ALTER DATABASE [DemoTrabajadores] SET  MULTI_USER 
GO
ALTER DATABASE [DemoTrabajadores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DemoTrabajadores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DemoTrabajadores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DemoTrabajadores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DemoTrabajadores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DemoTrabajadores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DemoTrabajadores', N'ON'
GO
ALTER DATABASE [DemoTrabajadores] SET QUERY_STORE = OFF
GO
USE [DemoTrabajadores]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 31/05/2023 19:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepartamento] [int] NOT NULL,
	[NombreDepartamento] [varchar](350) NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 31/05/2023 19:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[IdDistrito] [int] NOT NULL,
	[IdProvincia] [int] NOT NULL,
	[NombreDistrito] [varchar](350) NULL,
 CONSTRAINT [PK_Distrito_1] PRIMARY KEY CLUSTERED 
(
	[IdDistrito] ASC,
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 31/05/2023 19:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [int] NOT NULL,
	[IdDepartamento] [int] NOT NULL,
	[NombreProvincia] [varchar](350) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC,
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 31/05/2023 19:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajador](
	[IdTrabajador] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [varchar](3) NULL,
	[NroDocumento] [varchar](50) NULL,
	[Nombres] [varchar](250) NULL,
	[Sexo] [varchar](1) NULL,
	[IdDistrito] [int] NULL,
 CONSTRAINT [PK_Trabajador] PRIMARY KEY CLUSTERED 
(
	[IdTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Departamento] ([IdDepartamento], [NombreDepartamento]) VALUES (1, N'Lima')
GO
INSERT [dbo].[Departamento] ([IdDepartamento], [NombreDepartamento]) VALUES (2, N'Ica')
GO
INSERT [dbo].[Departamento] ([IdDepartamento], [NombreDepartamento]) VALUES (3, N'Cajamarca')
GO
INSERT [dbo].[Distrito] ([IdDistrito], [IdProvincia], [NombreDistrito]) VALUES (1, 1, N'Jesus Maria')
GO
INSERT [dbo].[Distrito] ([IdDistrito], [IdProvincia], [NombreDistrito]) VALUES (2, 2, N'Ica')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [IdDepartamento], [NombreProvincia]) VALUES (1, 1, N'Lima')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [IdDepartamento], [NombreProvincia]) VALUES (2, 1, N'Cañete')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [IdDepartamento], [NombreProvincia]) VALUES (3, 2, N'Ica')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [IdDepartamento], [NombreProvincia]) VALUES (4, 2, N'Nazca')
GO
SET IDENTITY_INSERT [dbo].[Trabajador] ON 
GO
INSERT [dbo].[Trabajador] ([IdTrabajador], [TipoDocumento], [NroDocumento], [Nombres], [Sexo], [IdDistrito]) VALUES (23, N'RUC', N'1111111', N'Francia', N'F', 2)
GO
SET IDENTITY_INSERT [dbo].[Trabajador] OFF
GO
/****** Object:  Index [UQ_Distrito]    Script Date: 31/05/2023 19:30:43 ******/
ALTER TABLE [dbo].[Distrito] ADD  CONSTRAINT [UQ_Distrito] UNIQUE NONCLUSTERED 
(
	[IdDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Provincia]    Script Date: 31/05/2023 19:30:43 ******/
ALTER TABLE [dbo].[Provincia] ADD  CONSTRAINT [UQ_Provincia] UNIQUE NONCLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([IdProvincia])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Provincia]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Departamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Departamento]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Distrito] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distrito] ([IdDistrito])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Distrito]
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TRABAJADORES]    Script Date: 31/05/2023 19:30:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- STORED PROCEDURE
CREATE PROC [dbo].[SP_LISTAR_TRABAJADORES] 
AS
SELECT t.IdTrabajador, t.TipoDocumento, t.NroDocumento, t.Nombres, t.Sexo, d.NombreDistrito Distrito, p.NombreProvincia Provincia, o.NombreDepartamento Departamento FROM dbo.Trabajador t
JOIN dbo.Distrito d ON d.IdDistrito = t.IdDistrito
JOIN dbo.Provincia p ON p.IdProvincia = d.IdProvincia
JOIN dbo.Departamento o ON o.IdDepartamento = p.IdProvincia
GO
USE [master]
GO
ALTER DATABASE [DemoTrabajadores] SET  READ_WRITE 
GO
