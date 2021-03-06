
/****** Object:  Database [BDAutoPartes]    Script Date: 09/30/2013 13:21:30 ******/
CREATE DATABASE [BDAutoPartes] 
GO
USE [BDAutoPartes] 
GO
ALTER DATABASE [BDAutoPartes] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BDAutoPartes] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BDAutoPartes] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BDAutoPartes] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BDAutoPartes] SET ARITHABORT OFF
GO
ALTER DATABASE [BDAutoPartes] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BDAutoPartes] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BDAutoPartes] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BDAutoPartes] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BDAutoPartes] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BDAutoPartes] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BDAutoPartes] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BDAutoPartes] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BDAutoPartes] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BDAutoPartes] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BDAutoPartes] SET  DISABLE_BROKER
GO
ALTER DATABASE [BDAutoPartes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BDAutoPartes] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BDAutoPartes] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BDAutoPartes] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BDAutoPartes] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BDAutoPartes] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BDAutoPartes] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BDAutoPartes] SET  READ_WRITE
GO
ALTER DATABASE [BDAutoPartes] SET RECOVERY FULL
GO
ALTER DATABASE [BDAutoPartes] SET  MULTI_USER
GO
ALTER DATABASE [BDAutoPartes] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BDAutoPartes] SET DB_CHAINING OFF
GO
USE [BDAutoPartes]
GO
/****** Object:  Table [dbo].[tblPais]    Script Date: 09/30/2013 13:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPais](
	[codPais] [varchar](5) NOT NULL,
	[desPais] [varchar](50) NULL,
 CONSTRAINT [PK_tblPais] PRIMARY KEY CLUSTERED 
(
	[codPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblPais] ([codPais], [desPais]) VALUES (N'1', N'Colombia')
INSERT [dbo].[tblPais] ([codPais], [desPais]) VALUES (N'2', N'Ecuador')
INSERT [dbo].[tblPais] ([codPais], [desPais]) VALUES (N'3', N'Argentina')
INSERT [dbo].[tblPais] ([codPais], [desPais]) VALUES (N'4', N'Chile')
/****** Object:  Table [dbo].[tblGenero]    Script Date: 09/30/2013 13:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGenero](
	[IdGenero] [tinyint] IDENTITY(1,1) NOT NULL,
	[DescripcionGenero] [varchar](5) NULL,
 CONSTRAINT [PK_tblGenero] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblGenero] ON
INSERT [dbo].[tblGenero] ([IdGenero], [DescripcionGenero]) VALUES (4, N'Otro')
INSERT [dbo].[tblGenero] ([IdGenero], [DescripcionGenero]) VALUES (11, N'M')
INSERT [dbo].[tblGenero] ([IdGenero], [DescripcionGenero]) VALUES (12, N'F')
SET IDENTITY_INSERT [dbo].[tblGenero] OFF
/****** Object:  Table [dbo].[tblDepartamento]    Script Date: 09/30/2013 13:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDepartamento](
	[IdDepartamento] [tinyint] IDENTITY(1,1) NOT NULL,
	[codPais] [varchar](5) NULL,
	[NombreDerpartamento] [varchar](45) NULL,
 CONSTRAINT [PK_tblDepartamento] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblDepartamento] ON
INSERT [dbo].[tblDepartamento] ([IdDepartamento], [codPais], [NombreDerpartamento]) VALUES (1, N'1', N'Antioquia')
INSERT [dbo].[tblDepartamento] ([IdDepartamento], [codPais], [NombreDerpartamento]) VALUES (2, N'1', N'Santander')
SET IDENTITY_INSERT [dbo].[tblDepartamento] OFF
/****** Object:  Table [dbo].[tblProveedor]    Script Date: 09/30/2013 13:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProveedor](
	[NitProveedor] [varchar](60) NOT NULL,
	[IdCiudadProveedor] [tinyint] NOT NULL,
	[NombreProveedor] [varchar](45) NULL,
	[ResponsableProveedor] [varchar](50) NULL,
 CONSTRAINT [PK_tblProveedor] PRIMARY KEY CLUSTERED 
(
	[NitProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'124235', 1, N'AUTECO', N'Pedro')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'211324', 4, N'APS LIGHTING & SAFETY PRODUCTS COMPANY', N'Felipe')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'24343543', 2, N'ORBIMOTOS', N'Andres')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'3425345', 3, N'INDUSTRIAS J.B. S.A.S.', N'Nicolas')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'352453', 1, N'MUNDO YAMAHA S.A.', N'Samuel')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'42334535', 2, N'ATMOPEL', N'Humberto')
INSERT [dbo].[tblProveedor] ([NitProveedor], [IdCiudadProveedor], [NombreProveedor], [ResponsableProveedor]) VALUES (N'45346546', 2, N'AUTOGERMANA S.A. BMW', N'Antoni')
/****** Object:  Table [dbo].[tblCategoria]    Script Date: 09/30/2013 13:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategoria](
	[IdCategoria] [tinyint] IDENTITY(1,1) NOT NULL,
	[NombreCategoria] [varchar](50) NULL,
 CONSTRAINT [PK_tblCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategoria] ON
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (1, N'Carros, Camionetas y Camionetas')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (2, N'Accesorios para Carros ')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (3, N'Coleccionables y Hobbies ')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (4, N'Servicios ')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (5, N'Otros Vehículos ')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (6, N'Otras categorías ')
INSERT [dbo].[tblCategoria] ([IdCategoria], [NombreCategoria]) VALUES (7, N'Herramientas para Vehículo')
SET IDENTITY_INSERT [dbo].[tblCategoria] OFF
/****** Object:  StoredProcedure [dbo].[sp_Genero]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Genero]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT [IdGenero]
      ,[DescripcionGenero]
  FROM [BDAutoPartes].[dbo].[tblGenero]
END
GO
/****** Object:  Table [dbo].[tblProducto]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProducto](
	[IdProducto] [tinyint] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [tinyint] NOT NULL,
	[NitProveedor] [varchar](60) NULL,
	[NombreProducto] [varchar](120) NULL,
	[DescripcionProducto] [varchar](120) NULL,
	[CodigoProducto] [varchar](15) NULL,
 CONSTRAINT [PK_tblProducto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblProducto] ON
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (8, 1, NULL, N'Alfombra Tapete ', N'Test', N'1')
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (9, 1, NULL, N'Partes De Suspensión Para Carros Chevrolet, Renault, ', NULL, NULL)
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (10, 2, NULL, N'Motoreductor De Traslacion: Cat 320 L/ Bl, ', NULL, NULL)
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (11, 3, NULL, N'Meguiar´s Restaurador De Partes Negras Y Grises ', NULL, NULL)
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (12, 3, NULL, N'Studebaker ', N'test', NULL)
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (13, 4, NULL, N'Kmatsu D65px-12, ', NULL, NULL)
INSERT [dbo].[tblProducto] ([IdProducto], [IdCategoria], [NitProveedor], [NombreProducto], [DescripcionProducto], [CodigoProducto]) VALUES (14, 5, NULL, N'Repuestos Subaru Mitsubishi ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblProducto] OFF
/****** Object:  Table [dbo].[tblCiudad]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCiudad](
	[IdCiudad] [tinyint] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [tinyint] NULL,
	[NombreCiudad] [varchar](45) NULL,
 CONSTRAINT [PK_tblCiudad] PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCiudad] ON
INSERT [dbo].[tblCiudad] ([IdCiudad], [IdDepartamento], [NombreCiudad]) VALUES (1, 1, N'Medellin')
INSERT [dbo].[tblCiudad] ([IdCiudad], [IdDepartamento], [NombreCiudad]) VALUES (2, 1, N'Bello')
INSERT [dbo].[tblCiudad] ([IdCiudad], [IdDepartamento], [NombreCiudad]) VALUES (3, 1, N'Itagüí')
INSERT [dbo].[tblCiudad] ([IdCiudad], [IdDepartamento], [NombreCiudad]) VALUES (4, 1, N'Envigado')
INSERT [dbo].[tblCiudad] ([IdCiudad], [IdDepartamento], [NombreCiudad]) VALUES (5, 1, N'Apartadó')
SET IDENTITY_INSERT [dbo].[tblCiudad] OFF
/****** Object:  Table [dbo].[tblCliente]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCliente](
	[IdCliente] [varchar](50) NOT NULL,
	[IdCiudadCliente] [tinyint] NOT NULL,
	[FechaNacCliente] [datetime] NULL,
	[NombreCliente] [varchar](45) NULL,
	[ApellidoCliente] [varchar](45) NULL,
	[TelefonoCliente] [varchar](20) NULL,
	[EmailCliente] [varchar](50) NULL,
	[IdGenero] [tinyint] NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCliente] ([IdCliente], [IdCiudadCliente], [FechaNacCliente], [NombreCliente], [ApellidoCliente], [TelefonoCliente], [EmailCliente], [IdGenero]) VALUES (N'1321', 1, CAST(0x0000A23600EEF3E0 AS DateTime), N'Daniel', N'Tabares', N'12243', N'd@com.co', 4)
INSERT [dbo].[tblCliente] ([IdCliente], [IdCiudadCliente], [FechaNacCliente], [NombreCliente], [ApellidoCliente], [TelefonoCliente], [EmailCliente], [IdGenero]) VALUES (N'21312', 1, CAST(0x0000A1D900000000 AS DateTime), N'Arley', N'Santana', N'afda', N'afas', 4)
INSERT [dbo].[tblCliente] ([IdCliente], [IdCiudadCliente], [FechaNacCliente], [NombreCliente], [ApellidoCliente], [TelefonoCliente], [EmailCliente], [IdGenero]) VALUES (N'21343242', 1, NULL, N'MORER', N' Martinez,QUIM', N'2423453', N' Martinez@c.co', 11)
INSERT [dbo].[tblCliente] ([IdCliente], [IdCiudadCliente], [FechaNacCliente], [NombreCliente], [ApellidoCliente], [TelefonoCliente], [EmailCliente], [IdGenero]) VALUES (N'242423', 1, CAST(0x0000A23400000000 AS DateTime), N'Pedro', N'tabares', N'12424', N'545345', 4)
INSERT [dbo].[tblCliente] ([IdCliente], [IdCiudadCliente], [FechaNacCliente], [NombreCliente], [ApellidoCliente], [TelefonoCliente], [EmailCliente], [IdGenero]) VALUES (N'45235243', 1, CAST(0x0000A1D900000000 AS DateTime), N'Robert', N'Sanchez', N'4234', N'4324', 4)
/****** Object:  Table [dbo].[tblEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmpleado](
	[IdEmpleado] [varchar](50) NOT NULL,
	[IdCiudadEmpleado] [tinyint] NOT NULL,
	[IdGeneroEmpleado] [tinyint] NOT NULL,
	[FechaNacEmpleado] [datetime] NOT NULL,
	[NombreEmpleado] [varchar](45) NULL,
	[ApellidoEmpleado] [varchar](45) NULL,
	[TelefonoEmpleado] [varchar](30) NULL,
	[EmailEmpleado] [varchar](50) NULL,
	[PorcentajeComisionEmpleado] [decimal](10, 2) NULL,
	[ComisionEmpleado] [decimal](10, 2) NULL,
 CONSTRAINT [PK_tblEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'111', 4, 11, CAST(0x0000A23C00000000 AS DateTime), N'Juan', N'A', N'123424', N'2342', NULL, NULL)
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'12', 1, 4, CAST(0x0000A23600000000 AS DateTime), N'alva', N'r', N'234', N'453', CAST(4.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'12234', 1, 11, CAST(0x0000A24300000000 AS DateTime), N'Jaime', N'tt', N'212324', N'd@com.co', CAST(11.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'123', 1, 11, CAST(0x0000A24400000000 AS DateTime), N'Juna', N'perez', N'12223', N'45345', CAST(11.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'12834', 1, 4, CAST(0x0000A23400000000 AS DateTime), N'Daniel', N'Tabares', N'34234', N'f@co.co', CAST(4.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'2343', 1, 4, CAST(0x0000A23400000000 AS DateTime), N'Armando', N'alvares', N'24234', N'd.co.q', CAST(1.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'43242', 1, 4, CAST(0x0000A23400000000 AS DateTime), N'Juan', N'Gomez', N'3423', N'd@co', CAST(22.00 AS Decimal(10, 2)), CAST(2946.24 AS Decimal(10, 2)))
INSERT [dbo].[tblEmpleado] ([IdEmpleado], [IdCiudadEmpleado], [IdGeneroEmpleado], [FechaNacEmpleado], [NombreEmpleado], [ApellidoEmpleado], [TelefonoEmpleado], [EmailEmpleado], [PorcentajeComisionEmpleado], [ComisionEmpleado]) VALUES (N'545646', 1, 4, CAST(0x0000A24900DB2D60 AS DateTime), N'ro', N'as', N'343', N'4545', CAST(14.00 AS Decimal(10, 2)), CAST(51.24 AS Decimal(10, 2)))
/****** Object:  StoredProcedure [dbo].[sp_Ciudad]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Ciudad]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [IdCiudad]
      ,[IdDepartamento]
      ,[NombreCiudad]
  FROM [BDAutoPartes].[dbo].[tblCiudad]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteProducto]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExisteProducto]
	-- Add the parameters for the stored procedure here
	@IdProducto int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [IdProducto]
      ,[IdCategoria]
      ,[NombreProducto]
      ,[DescripcionProducto]
      ,[CodigoProducto]
  FROM [BDAutoPartes].[dbo].[tblProducto]
  WHERE [IdProducto] = @IdProducto 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Producto]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Producto]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [IdProducto]
      ,[IdCategoria]
      ,[NombreProducto]
      ,[DescripcionProducto]
      ,[CodigoProducto]
  FROM [BDAutoPartes].[dbo].[tblProducto]

END
GO
/****** Object:  Table [dbo].[tblCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCabeceraCompra](
	[IdCabCompra] [int] NOT NULL,
	[FechaCompra] [date] NULL,
	[VlrCompra] [decimal](18, 0) NULL,
	[IdCliente] [varchar](50) NOT NULL,
	[IdEmpleado] [varchar](50) NOT NULL,
	[IvaCompra] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tblCabeceraCompra] PRIMARY KEY CLUSTERED 
(
	[IdCabCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (1, CAST(0x8F370B00 AS Date), CAST(423 AS Decimal(18, 0)), N'1321', N'2343', CAST(2423 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (2, CAST(0x92370B00 AS Date), CAST(231 AS Decimal(18, 0)), N'1321', N'2343', CAST(12312 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (3, CAST(0x96370B00 AS Date), CAST(4684 AS Decimal(18, 0)), N'1321', N'2343', CAST(468 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (4, CAST(0x96370B00 AS Date), CAST(4684 AS Decimal(18, 0)), N'1321', N'2343', CAST(468 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (5, CAST(0x96370B00 AS Date), CAST(4684 AS Decimal(18, 0)), N'1321', N'2343', CAST(468 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (11, CAST(0x97370B00 AS Date), CAST(69 AS Decimal(18, 0)), N'21312', N'2343', CAST(686 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (111, CAST(0xA2370B00 AS Date), CAST(1068 AS Decimal(18, 0)), N'21312', N'43242', CAST(10684 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (123, CAST(0x8F370B00 AS Date), CAST(2377 AS Decimal(18, 0)), N'1321', N'2343', CAST(23774 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (223, CAST(0xA4370B00 AS Date), CAST(47 AS Decimal(18, 0)), N'21343242', N'43242', CAST(465 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (323, CAST(0x97370B00 AS Date), CAST(1893 AS Decimal(18, 0)), N'21312', N'43242', CAST(18927 AS Decimal(18, 0)))
INSERT [dbo].[tblCabeceraCompra] ([IdCabCompra], [FechaCompra], [VlrCompra], [IdCliente], [IdEmpleado], [IvaCompra]) VALUES (3545345, CAST(0xA2370B00 AS Date), CAST(366 AS Decimal(18, 0)), N'21312', N'545646', CAST(3657 AS Decimal(18, 0)))
/****** Object:  StoredProcedure [dbo].[sp_InsertarEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertarEmpleado]
	-- Add the parameters for the stored procedure here
	@IdEmpleado  varchar(50),
    @IdCiudadEmpleado  tinyint,
           @IdGeneroEmpleado tinyint,
           @FechaNacEmpleado datetime,
           @NombreEmpleado  varchar(45),
           @ApellidoEmpleado varchar(45),
           @TelefonoEmpleado varchar(30),
           @EmailEmpleado varchar(50),
           @PorcentajeComisionEmpleado float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO [BDAutoPartes].[dbo].[tblEmpleado]
           ([IdEmpleado]
           ,[IdCiudadEmpleado]
           ,[IdGeneroEmpleado],
            [FechaNacEmpleado]
           ,[NombreEmpleado]
           ,[ApellidoEmpleado]
           ,[TelefonoEmpleado]
           ,[EmailEmpleado],
           [PorcentajeComisionEmpleado],
           [ComisionEmpleado]
           )
     VALUES
           (@IdEmpleado,@IdCiudadEmpleado,@IdGeneroEmpleado,@FechaNacEmpleado,@NombreEmpleado,@ApellidoEmpleado,@TelefonoEmpleado,@EmailEmpleado,@PorcentajeComisionEmpleado,0)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCliente]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertarCliente]
	-- Add the parameters for the stored procedure here
	 @IdCliente varchar(50) 
      ,@IdCiudadCliente  tinyint
      ,@FechaNacCliente datetime
      ,@NombreCliente  varchar(45)
      ,@ApellidoCliente  varchar(45)
      ,@TelefonoCliente varchar(20)
      ,@EmailCliente varchar(50)
      ,@IdGenero tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [BDAutoPartes].[dbo].[tblCliente]
           ([IdCliente]
           ,[IdCiudadCliente]
           ,[FechaNacCliente]
           ,[NombreCliente]
           ,[ApellidoCliente]
           ,[TelefonoCliente]
           ,[EmailCliente]
           ,[IdGenero])
     VALUES
           (	 @IdCliente 
      ,@IdCiudadCliente  
      ,@FechaNacCliente       ,@NombreCliente  
      ,@ApellidoCliente  
      ,@TelefonoCliente 
      ,@EmailCliente 
      ,@IdGenero )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Esteban Tabares Taborda>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExisteEmpleado]
	@IDEMPLEADO varchar(50)
AS
BEGIN
SELECT [IdEmpleado]
      ,[IdCiudadEmpleado]
      ,[IdGeneroEmpleado]
      ,[FechaNacEmpleado]
      ,[NombreEmpleado]
      ,[ApellidoEmpleado]
      ,[TelefonoEmpleado]
      ,[EmailEmpleado]
      ,[PorcentajeComisionEmpleado]
      ,[ComisionEmpleado]
  FROM [BDAutoPartes].[dbo].[tblEmpleado]
  	WHERE	[IdEmpleado] = @IDEMPLEADO
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Empleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Empleado]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [IdEmpleado]
      ,[IdCiudadEmpleado]
      ,[IdGeneroEmpleado]
      ,[FechaNacEmpleado]
      ,[NombreEmpleado]
      ,[ApellidoEmpleado]
      ,[TelefonoEmpleado]
      ,[EmailEmpleado]
  FROM [BDAutoPartes].[dbo].[tblEmpleado]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteCliente]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExisteCliente]
		@IdCliente varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with @IdClienteSELECT statements.
	SET NOCOUNT ON;
SELECT [IdCliente]
      ,[IdCiudadCliente]
      ,[FechaNacCliente]
      ,[NombreCliente]
      ,[ApellidoCliente]
      ,[TelefonoCliente]
      ,[EmailCliente]
      ,[IdGenero]
  FROM [BDAutoPartes].[dbo].[tblCliente]
  WHERE [IdCliente]= @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarComisionEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arley M<uricio Santana Vargas
-- Create date: 2013-09-28
-- Description:	Actualiza la comisión del empleado
-- =============================================
CREATE PROCEDURE [dbo].[sp_AgregarComisionEmpleado] 
	
	@IDEMPLEADO numeric(10,0),
	@VALCOM decimal (10,2)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE tblEmpleado
    SET ComisionEmpleado = ISNULL(ComisionEmpleado,0) + @VALCOM
    WHERE IdEmpleado = @IDEMPLEADO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_ActualizarEmpleado]
	-- Add the parameters for the stored procedure here
	@IdEmpleado  varchar(50),
    @IdCiudadEmpleado  tinyint,
           @IdGeneroEmpleado tinyint,
            @FechaNacEmpleado datetime,
           @NombreEmpleado  varchar(45),
           @ApellidoEmpleado varchar(45),
           @PorcentajeComisionEmpleado decimal ,   
           @TelefonoEmpleado varchar(30),
           @EmailEmpleado varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [BDAutoPartes].[dbo].[tblEmpleado]
   SET [IdCiudadEmpleado] = @IdCiudadEmpleado
      ,[IdGeneroEmpleado] = @IdGeneroEmpleado
      ,[FechaNacEmpleado] = @FechaNacEmpleado
      ,[NombreEmpleado] = @NombreEmpleado
      ,[ApellidoEmpleado] = @ApellidoEmpleado
      ,[TelefonoEmpleado] =@TelefonoEmpleado
      ,[EmailEmpleado] = @EmailEmpleado
      ,[PorcentajeComisionEmpleado] = @PorcentajeComisionEmpleado
 WHERE [IdEmpleado] = @IdEmpleado
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarComisionEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Arley M<uricio Santana Vargas
-- Create date: 2013-09-28
-- Description:	Consulta el porcentaje de comisión del empleado
-- =============================================
CREATE PROCEDURE [dbo].[sp_ConsultarComisionEmpleado] 
	
	@IDEMPLEADO numeric(10,0)

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT PorcentajeComisionEmpleado
    FROM tblEmpleado
    WHERE IdEmpleado = @IDEMPLEADO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Cliente]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Cliente]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [IdCliente]
      ,[IdCiudadCliente]
      ,[FechaNacCliente]
      ,[NombreCliente]
      ,[ApellidoCliente]
      ,[TelefonoCliente]
      ,[EmailCliente]
      ,[IdGenero]
  FROM [BDAutoPartes].[dbo].[tblCliente]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCliente]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ActualizarCliente] 
	-- Add the parameters for the stored procedure here
	    @IdCliente varchar(50) 
      ,@IdCiudadCliente  tinyint
      ,@FechaNacCliente datetime
      ,@NombreCliente  varchar(45)
      ,@ApellidoCliente  varchar(45)
      ,@TelefonoCliente varchar(20)
      ,@EmailCliente varchar(50)
      ,@IdGenero tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  UPDATE [BDAutoPartes].[dbo].[tblCliente]
   SET 
      [IdCiudadCliente] = @IdCiudadCliente
      ,[FechaNacCliente] = @FechaNacCliente
      ,[NombreCliente] = @NombreCliente
      ,[ApellidoCliente] = @ApellidoCliente
      ,[TelefonoCliente] = @TelefonoCliente
      ,[EmailCliente] = @EmailCliente
      ,[IdGenero] = @IdGenero
 WHERE  IdCliente = @IdCliente
END
GO
/****** Object:  Table [dbo].[tblDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDetalleCompra](
	[IdDetCompra] [tinyint] IDENTITY(1,1) NOT NULL,
	[IdCabCompra] [int] NOT NULL,
	[IdProducto] [tinyint] NULL,
	[UnidadesCompradas] [int] NULL,
	[VlrComprado] [float] NULL,
 CONSTRAINT [PK_tblDetalleCompra] PRIMARY KEY CLUSTERED 
(
	[IdDetCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblDetalleCompra] ON
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (5, 323, 8, 535, 3453)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (25, 323, 8, 535, 3453)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (26, 323, 8, 535, 3453)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (36, 111, 10, 324, 34)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (37, 111, 14, 3554, 656)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (40, 123, 12, 423, 23432)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (41, 123, 11, 324, 342)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (42, 111, 10, 324, 34)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (43, 111, 11, 234, 3242)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (44, 111, 11, 234, 3242)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (45, 111, 11, 234, 3242)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (46, 111, 10, 324, 34)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (47, 111, 10, 324, 34)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (48, 111, 12, 2342, 432)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (49, 111, 10, 3323, 234)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (50, 223, 9, 323, 232)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (51, 223, 11, 234, 233)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (52, 3545345, 10, 432, 234)
INSERT [dbo].[tblDetalleCompra] ([IdDetCompra], [IdCabCompra], [IdProducto], [UnidadesCompradas], [VlrComprado]) VALUES (53, 3545345, 8, 432, 3423)
SET IDENTITY_INSERT [dbo].[tblDetalleCompra] OFF
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ActualizarCabeceraCompra] 
	-- Add the parameters for the stored procedure here
	  @IdCabCompra int ,
	       @FechaCompra  date,
           @VlrCompra float
           ,@IdCliente varchar(50)
           ,@IdEmpleado varchar(50)
           ,@IvaCompra decimal 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
UPDATE [BDAutoPartes].[dbo].[tblCabeceraCompra]
   SET [FechaCompra] = @FechaCompra
      ,[VlrCompra] =@VlrCompra
      ,[IdCliente] = @IdCliente
      ,[IdEmpleado] = @IdEmpleado
      ,IvaCompra = @IvaCompra
 WHERE IdCabCompra =@IdCabCompra
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExisteCabeceraCompra]
	-- Add the parameters for the stored procedure here
		  @IdCabCompra int  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [IdCabCompra]
      ,[FechaCompra]
      ,[VlrCompra]
      ,[IdCliente]
      ,[IdEmpleado]
       ,[IvaCompra]
  FROM [BDAutoPartes].[dbo].[tblCabeceraCompra]
  WHERE [IdCabCompra] = @IdCabCompra
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertarCabeceraCompra]
	      @IdCabCompra int,
	      @FechaCompra  date,
           @IvaCompra decimal,
           
           @VlrCompra decimal
           ,@IdCliente varchar(50)
           ,@IdEmpleado varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [BDAutoPartes].[dbo].[tblCabeceraCompra]
           ([IdCabCompra] ,
           [FechaCompra]
           
           ,[VlrCompra]
           ,[IdCliente]
           ,[IdEmpleado],[IvaCompra])
     VALUES
           (@IdCabCompra ,  @FechaCompra  ,
            
           
           @VlrCompra 
           ,@IdCliente
           ,@IdEmpleado ,@IvaCompra)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LlenarCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LlenarCabeceraCompra]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.tblCabeceraCompra.IdCabCompra, dbo.tblCliente.IdCliente, dbo.tblCliente.NombreCliente + ' ' + dbo.tblCliente.ApellidoCliente AS [Nombre Cliente], 
                      dbo.tblEmpleado.NombreEmpleado + ' ' + dbo.tblEmpleado.ApellidoEmpleado AS [Nombre Empleado], dbo.tblCliente.TelefonoCliente AS Telefono, 
                      dbo.tblCabeceraCompra.FechaCompra AS [Fecha Compra], dbo.tblCabeceraCompra.VlrCompra AS [Valor Compra], dbo.tblCabeceraCompra.IvaCompra AS Iva
FROM         dbo.tblCabeceraCompra INNER JOIN
                      dbo.tblCliente ON dbo.tblCabeceraCompra.IdCliente = dbo.tblCliente.IdCliente INNER JOIN
                      dbo.tblEmpleado ON dbo.tblCabeceraCompra.IdEmpleado = dbo.tblEmpleado.IdEmpleado
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCabaceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_EliminarCabaceraCompra]
	-- Add the parameters for the stored procedure here
	@IdCabCompra int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [BDAutoPartes].[dbo].[tblCabeceraCompra]
      WHERE [tblCabeceraCompra].IdCabCompra = @IdCabCompra
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LlenarDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LlenarDetalleCompra]
	-- Add the parameters for the stored procedure here
	@IdCabCompra int
	--@IdProducto tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

    -- Insert statements for procedure here
    
   -- IF @IdProducto  IS NULL
	BEGIN
		SELECT       [tblDetalleCompra].[IdCabCompra] AS [IdCabecera]
      ,[tblDetalleCompra].IdProducto as [IdProducto]
      ,[tblDetalleCompra].[UnidadesCompradas] AS Cantidad
      ,[tblDetalleCompra].[VlrComprado] as Valor
  FROM [BDAutoPartes].[dbo].[tblDetalleCompra] 
  WHERE [IdCabCompra] = @IdCabCompra 

	END
	------ELSE
	--BEGIN
	
	--	SELECT  [IdDetCompra]
 --     ,[IdCabCompra]
 --     ,[IdProducto]
 --     ,[UnidadesCompradas]
 --     ,[VlrComprado]
 -- FROM [BDAutoPartes].[dbo].[tblDetalleCompra] 
 -- WHERE [IdDetCompra] = @IdCabCompra 
 -- and [IdProducto] =@IdProducto 

    
 --   END*--
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertarDetalleCompra]
	-- Add the parameters for the stored procedure here
		    @IdCabCompra int
           ,@IdProducto int
           ,@UnidadesCompradas int
           ,@VlrComprado  Decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [BDAutoPartes].[dbo].[tblDetalleCompra]
           ([IdCabCompra]
           ,[IdProducto]
           ,[UnidadesCompradas]
           ,[VlrComprado])
     VALUES
           (@IdCabCompra 
           ,@IdProducto 
           ,@UnidadesCompradas 
           ,@VlrComprado  )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExisteDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Daniel Esteban Tabares>
-- Create date: <30-09-2013>
-- Description:	<Verifica si existe detalle>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ExisteDetalleCompra]
	-- Add the parameters for the stored procedure here
	@IdCabCompra int,
	@IdProducto int,
	@UnidadesCompradas int,
	@VlrComprado float
AS
BEGIN
	
	SET NOCOUNT ON

    -- Insert statements for procedure here
    
    IF @IdProducto  = 0
	BEGIN
		SELECT  [IdDetCompra]
      ,[IdCabCompra]
      ,[IdProducto]
      ,[UnidadesCompradas]
      ,[VlrComprado]
  FROM [BDAutoPartes].[dbo].[tblDetalleCompra] 
  WHERE [IdCabCompra] = @IdCabCompra 

	END
	ELSE
	BEGIN
	
		SELECT  [IdDetCompra]
      ,[IdCabCompra]
      ,[IdProducto]
      ,[UnidadesCompradas]
      ,[VlrComprado]
  FROM [BDAutoPartes].[dbo].[tblDetalleCompra] 
  WHERE [IdCabCompra] = @IdCabCompra 
  and [IdProducto] =@IdProducto 
  and [UnidadesCompradas] = @UnidadesCompradas
  and [VlrComprado] =@VlrComprado
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_EliminarDetalleCompra]
	-- Add the parameters for the stored procedure here
	 @IdCabCompra int
       ,@IdProducto int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  
    IF @IdProducto  IS NULL
	BEGIN
			DELETE FROM [BDAutoPartes].[dbo].[tblDetalleCompra]
      WHERE [IdCabCompra]= @IdCabCompra 

	END
	ELSE
	BEGIN
			DELETE FROM [BDAutoPartes].[dbo].[tblDetalleCompra]
      WHERE [IdCabCompra]= @IdCabCompra AND IdProducto = @IdProducto
    
    END
    -- Insert statements for procedure here

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDetalleCompra]    Script Date: 09/30/2013 13:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ActualizarDetalleCompra]
	-- Add the parameters for the stored procedure here
	 @IdCabCompra int
           ,@IdProducto int 
           , @UnidadesCompradas int
           ,@VlrComprado  float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   IF @IdProducto  = 0
	BEGIN
    -- Insert statements for procedure here
	UPDATE [BDAutoPartes].[dbo].[tblDetalleCompra]
   SET 
      [IdProducto] = @IdProducto
      ,[UnidadesCompradas] = @UnidadesCompradas
      ,[VlrComprado] = @VlrComprado
 WHERE   [IdCabCompra] = @IdCabCompra 

 END
	ELSE
	BEGIN
 	UPDATE [BDAutoPartes].[dbo].[tblDetalleCompra]
   SET 
      [IdProducto] = @IdProducto
      ,[UnidadesCompradas] = @UnidadesCompradas
      ,[VlrComprado] = @VlrComprado
 WHERE   [IdCabCompra] = @IdCabCompra 
  and [IdProducto] =@IdProducto 
	
	 END
END
GO
/****** Object:  ForeignKey [FK_tblProducto_tblCategoria]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblProducto]  WITH CHECK ADD  CONSTRAINT [FK_tblProducto_tblCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tblCategoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[tblProducto] CHECK CONSTRAINT [FK_tblProducto_tblCategoria]
GO
/****** Object:  ForeignKey [FK_tblProducto_tblProveedor]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblProducto]  WITH CHECK ADD  CONSTRAINT [FK_tblProducto_tblProveedor] FOREIGN KEY([NitProveedor])
REFERENCES [dbo].[tblProveedor] ([NitProveedor])
GO
ALTER TABLE [dbo].[tblProducto] CHECK CONSTRAINT [FK_tblProducto_tblProveedor]
GO
/****** Object:  ForeignKey [FK_tblCiudad_tblDepartamento]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblCiudad]  WITH CHECK ADD  CONSTRAINT [FK_tblCiudad_tblDepartamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[tblDepartamento] ([IdDepartamento])
GO
ALTER TABLE [dbo].[tblCiudad] CHECK CONSTRAINT [FK_tblCiudad_tblDepartamento]
GO
/****** Object:  ForeignKey [FK_tblCliente_tblCiudad]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblCiudad] FOREIGN KEY([IdCiudadCliente])
REFERENCES [dbo].[tblCiudad] ([IdCiudad])
GO
ALTER TABLE [dbo].[tblCliente] CHECK CONSTRAINT [FK_tblCliente_tblCiudad]
GO
/****** Object:  ForeignKey [FK_tblCliente_tblGenero]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblGenero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[tblGenero] ([IdGenero])
GO
ALTER TABLE [dbo].[tblCliente] CHECK CONSTRAINT [FK_tblCliente_tblGenero]
GO
/****** Object:  ForeignKey [FK_tblEmpleado_tblCiudad]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpleado_tblCiudad] FOREIGN KEY([IdCiudadEmpleado])
REFERENCES [dbo].[tblCiudad] ([IdCiudad])
GO
ALTER TABLE [dbo].[tblEmpleado] CHECK CONSTRAINT [FK_tblEmpleado_tblCiudad]
GO
/****** Object:  ForeignKey [FK_tblEmpleado_tblGenero]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpleado_tblGenero] FOREIGN KEY([IdGeneroEmpleado])
REFERENCES [dbo].[tblGenero] ([IdGenero])
GO
ALTER TABLE [dbo].[tblEmpleado] CHECK CONSTRAINT [FK_tblEmpleado_tblGenero]
GO
/****** Object:  ForeignKey [FK_tblCabeceraCompra_tblCliente]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblCabeceraCompra]  WITH CHECK ADD  CONSTRAINT [FK_tblCabeceraCompra_tblCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[tblCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[tblCabeceraCompra] CHECK CONSTRAINT [FK_tblCabeceraCompra_tblCliente]
GO
/****** Object:  ForeignKey [FK_tblCabeceraCompra_tblEmpleado]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblCabeceraCompra]  WITH CHECK ADD  CONSTRAINT [FK_tblCabeceraCompra_tblEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tblEmpleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[tblCabeceraCompra] CHECK CONSTRAINT [FK_tblCabeceraCompra_tblEmpleado]
GO
/****** Object:  ForeignKey [FK_tblDetalleCompra_tblCabeceraCompra]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblDetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_tblDetalleCompra_tblCabeceraCompra] FOREIGN KEY([IdCabCompra])
REFERENCES [dbo].[tblCabeceraCompra] ([IdCabCompra])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblDetalleCompra] CHECK CONSTRAINT [FK_tblDetalleCompra_tblCabeceraCompra]
GO
/****** Object:  ForeignKey [FK_tblDetalleCompra_tblProducto]    Script Date: 09/30/2013 13:21:44 ******/
ALTER TABLE [dbo].[tblDetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_tblDetalleCompra_tblProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[tblProducto] ([IdProducto])
GO
ALTER TABLE [dbo].[tblDetalleCompra] CHECK CONSTRAINT [FK_tblDetalleCompra_tblProducto]
GO
