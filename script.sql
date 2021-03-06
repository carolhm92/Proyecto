
USE [ProyectoCarol]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] NOT NULL,
	[Controlador] [varchar](50) NOT NULL,
	[Metodo] [varchar](50) NOT NULL,
	[Mensaje] [varchar](max) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Canton]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Canton](
	[Provincia] [char](1) NOT NULL,
	[Canton] [char](2) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Provincia] ASC,
	[Canton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[IdCita] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdTratamiento] [int] NOT NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[IdCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[IdTipoIdentificacion] [int] NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Provincia] [char](1) NOT NULL,
	[Canton] [char](2) NOT NULL,
	[Distrito] [char](2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Distrito](
	[Provincia] [char](1) NOT NULL,
	[Canton] [char](2) NOT NULL,
	[Distrito] [char](2) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Provincia] ASC,
	[Canton] ASC,
	[Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Institucion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInstitucion] [int] NOT NULL,
	[Institucion] [varchar](50) NOT NULL,
	[IdTipoIdentitifcacion] [int] NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Direccion] [varchar](500) NULL,
 CONSTRAINT [PK_Institucion] PRIMARY KEY CLUSTERED 
(
	[IdInstitucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mascota](
	[IdMascota] [int] NOT NULL,
	[NombreMascota] [varchar](50) NOT NULL,
	[Especie] [varchar](50) NULL,
	[Raza] [varchar](50) NULL,
	[IdCliente] [int] NOT NULL,
	[Peso] [float] NULL,
	[Identificacion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED 
(
	[IdMascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Sexo] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[ApellidoP] [varchar](26) NOT NULL,
	[ApellidoM] [varchar](26) NOT NULL,
	[Direccion] [varchar](6) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[CostoProducto] [float] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] NOT NULL,
	[NombreProveedor] [varchar](50) NOT NULL,
	[Provincia] [char](1) NOT NULL,
	[Canton] [char](1) NOT NULL,
	[Distrito] [char](1) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[Correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[Cod] [char](1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoIdentificacion](
	[IdTipoIdentificacion] [int] NOT NULL,
	[TipoIdentificacion] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoIdentificacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tratamiento](
	[IdTratamiento] [int] NOT NULL,
	[NombreTratamiento] [varchar](50) NOT NULL,
	[Costo] [float] NOT NULL,
	[IdMascota] [int] NOT NULL,
 CONSTRAINT [PK_Tratamiento] PRIMARY KEY CLUSTERED 
(
	[IdTratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[IdUsuarioRol] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venta]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[IdProducto] [int] NULL,
	[IdCita] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Bitacora] ADD  CONSTRAINT [DF_Bitacora_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD FOREIGN KEY([Provincia])
REFERENCES [dbo].[Provincia] ([Cod])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TipoIdentificacion] FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [dbo].[TipoIdentificacion] ([IdTipoIdentificacion])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TipoIdentificacion]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD FOREIGN KEY([Provincia], [Canton])
REFERENCES [dbo].[Canton] ([Provincia], [Canton])
GO
ALTER TABLE [dbo].[Institucion]  WITH CHECK ADD  CONSTRAINT [FK_Institucion_TipoIdentificacion] FOREIGN KEY([IdTipoIdentitifcacion])
REFERENCES [dbo].[TipoIdentificacion] ([IdTipoIdentificacion])
GO
ALTER TABLE [dbo].[Institucion] CHECK CONSTRAINT [FK_Institucion_TipoIdentificacion]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ActualizarCliente]
@IdCliente as int,
@IdTipoIdentificacion as int,
@Identificacion as varchar(20),
@Nombre as varchar(50),
@Apellido1 as varchar(50),
@Apellido2 as varchar(50),
@Correo as varchar(50),
@Telefono as varchar(15),
@Provincia as char(1),
@Canton as char(2),
@Distrito as char(2),
@Estado as bit
AS
BEGIN

UPDATE [dbo].[Cliente]
   SET [IdTipoIdentificacion] = @IdTipoIdentificacion
      ,[Identificacion] = @Identificacion
      ,[Nombre] = @Nombre
      ,[Apellido1] = @Apellido1
      ,[Apellido2] = @Apellido2
      ,[Correo] = @Correo
      ,[Telefono] = @Telefono
      ,[Provincia] = @Provincia
      ,[Canton] = @Canton
      ,[Distrito] = @Distrito
      ,[Estado] = @Estado

 WHERE IdCliente=@IdCliente
END


GO
/****** Object:  StoredProcedure [dbo].[ActualizarInstitucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarInstitucion]
@IdInstitucion int,
@Institucion varchar(50),
@IdTipoIdentitifcacion int,
@Identitifcacion varchar(20),
@Telefono varchar(15),
@Direccion varchar(500)=null
AS
BEGIN

	Update [dbo].[Institucion] SET
          IdTipoIdentitifcacion=@IdTipoIdentitifcacion,
		  Identificacion=@Identitifcacion,
		  Telefono=@Telefono,
		  Direccion=@Direccion
		   where IdInstitucion=@IdInstitucion
END


GO
/****** Object:  StoredProcedure [dbo].[ActualizarMascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarMascota]
@IdMascota as int,
@NombreMascota as varchar(50),
@Especie as varchar(50),
@Raza as varchar(50),
@IdCliente as int
AS
BEGIN

UPDATE [dbo].[Mascota]
   SET [IdMascota] = @IdMascota
      ,[Identificacion] = @NombreMascota
      ,[Especie] = @Especie
      ,[Raza] = @Raza
      ,[IdCliente] = @IdCliente
      

 WHERE IdMascota=@IdMascota
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarProducto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarProducto]
@IdProducto as int,
@NombreProducto as varchar(50),
@CostoProducto as float,
@IdProveedor as int,
@Cantidad as int
AS
BEGIN

UPDATE [dbo].[Producto]
   SET [IdProducto] = @IdProducto
      ,[NombreProducto] = @NombreProducto
      ,[CostoProducto] = @CostoProducto
      ,[IdProveedor] = @IdProveedor
      ,[Cantidad]=@Cantidad

 WHERE IdProducto=@IdProducto
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarProveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarProveedor]
@IdProveedor as int,
@NombreProveedor as varchar(50),
@Provincia as char(1),
@Canton as char(2),
@Distrito as char(2),
@Correo as varchar(50),
@Telefono as varchar(15)
AS
BEGIN

UPDATE [dbo].[Proveedor]
       SET  [IdProveedor] = @IdProveedor
           ,[NombreProveedor] = @NombreProveedor
		   ,[Provincia] = @Provincia
           ,[Canton] = @Canton
           ,[Distrito] = @Distrito
           ,[Correo] = @Correo
           ,[Telefono] =  @Telefono
             

 WHERE IdProveedor=@IdProveedor
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarTipoIdentificacion]
@IdTipoIdentificacion as int,
@TipoIdentificacion as varchar(50),
@Estado as bit
AS
BEGIN



UPDATE [dbo].[TipoIdentificacion]
   SET [TipoIdentificacion] = @TipoIdentificacion
      ,[Estado] = @Estado
 WHERE IdTipoIdentificacion=@IdTipoIdentificacion
END			


GO
/****** Object:  StoredProcedure [dbo].[ActualizarTratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ActualizarTratamiento]
@IdTratamiento as int,
@NombreTratamiento as varchar(50),
@Costo as float

AS
BEGIN

UPDATE [dbo].[Tratamiento]
   SET [IdTratamiento] = @IdTratamiento
      ,[NombreTratamiento] = @NombreTratamiento
      ,[Costo] = @Costo

 WHERE IdTratamiento=@IdTratamiento
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarCliente]
@IdTipoIdentificacion as int,
@Identificacion as varchar(20),
@Nombre as varchar(50),
@Apellido1 as varchar(50),
@Apellido2 as varchar(50),
@Correo as varchar(50),
@Telefono as varchar(15),
@Provincia as char(1),
@Canton as char(2),
@Distrito as char(2),
@Estado as bit
AS
BEGIN


Declare @Codigo int

Select @Codigo=isnull(MAX(IdCliente),0)+1 from Cliente

INSERT INTO [dbo].[Cliente]
           ([IdCliente]
           ,[IdTipoIdentificacion]
           ,[Identificacion]
           ,[Nombre]
           ,[Apellido1]
           ,[Apellido2]
           ,[Correo]
           ,[Telefono]
           ,[Provincia]
           ,[Canton]
           ,[Distrito]
           ,[Estado])
     VALUES
           (@Codigo
           ,@IdTipoIdentificacion
           ,@Identificacion
           ,@Nombre
           ,@Apellido1
           ,@Apellido2
           ,@Correo
           ,@Telefono
           ,@Provincia
           ,@Canton
           ,@Distrito
           ,@Estado)
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarInstitucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarInstitucion]
@IdInstitucion int,
@Institucion varchar(50),
@IdTipoIdentitifcacion int,
@Identitifcacion varchar(20),
@Telefono varchar(15),
@Direccion varchar(500)=null
AS
BEGIN

Declare @Codigo int

Select @Codigo=isnull(MAX(IdInstitucion),0)+1 from Institucion

	INSERT INTO [dbo].[Institucion]
           ([IdInstitucion]
           ,[Institucion]
           ,[IdTipoIdentitifcacion]
           ,[Identificacion]
           ,[Telefono]
           ,[Direccion])
     VALUES
           (@Codigo
		   ,@Institucion
           ,@IdTipoIdentitifcacion
		   ,@Identitifcacion
		   ,@Telefono
		   ,@Direccion)

	Select @Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarMascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarMascota]
@NombreMascota as varchar(50),
@Especie as varchar(50),
@Raza as varchar(50),
@IdCliente as int
AS
BEGIN


Declare @Codigo int

Select @Codigo=isnull(MAX(IdMascota),0)+1 from Mascota

INSERT INTO [dbo].[Mascota]
           ([IdMascota]
           ,[NombreMascota]
           ,[Especie]
           ,[Raza]
           ,[IdCliente]
               )
     VALUES
           (@Codigo
           ,@NombreMascota
           ,@Especie
           ,@Raza
           ,@IdCliente
           )
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarPersona]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarPersona]
@Cedula varchar(10),
@Sexo int,
@Nombre varchar(30),
@ApellidoP varchar(26),
@ApellidoM varchar(26),
@Direccion varchar(6)

AS
BEGIN
	
	Declare @Codigo int;

	if exists (SELECT * from Persona where Cedula=@Cedula)
	Begin
		update persona set
			sexo=@Sexo,
			Nombre=@Nombre,
			ApellidoP=@ApellidoP,
			ApellidoM=@ApellidoM,
			Direccion=@Direccion
		where Cedula=@Cedula
	end else
	Begin
		
		Select @Codigo=isnull(MAX(IdPersona),0)+1 from Persona
		
		insert INTO Persona (IdPersona,Cedula,Sexo,Nombre,ApellidoP,ApellidoM,Direccion) 
		values (@Codigo,@Cedula,@Sexo,@Nombre,@ApellidoP,@ApellidoM,@Direccion)
	End
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarProducto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarProducto]
@IdProducto as int,
@NombreProducto as varchar(50),
@CostoProducto as float,
@IdProveedor as int,
@Cantidad as int
AS
BEGIN


Declare @Codigo int

Select @Codigo=isnull(MAX(IdProducto),0)+1 from Producto

INSERT INTO [dbo].[Producto](
      [NombreProducto]
      ,[CostoProducto] 
      ,[IdProveedor]
	  ,[Cantidad] 
               )
     VALUES
           (@NombreProducto
           ,@CostoProducto
           ,@IdProveedor
           ,@Cantidad
           )
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarProveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarProveedor]
@IdProveedor as int,
@NombreProveedor as varchar(50),
@Provincia as char(1),
@Canton as char(2),
@Distrito as char(2),
@Correo as varchar(50),
@Telefono as varchar(15)

AS
BEGIN


Declare @Codigo int

Select @Codigo=isnull(MAX(IdProveedor),0)+1 from Proveedor

INSERT INTO [dbo].[Proveedor]
           ([IdProveedor]
           ,[NombreProveedor]
		   ,[Provincia]
           ,[Canton]
           ,[Distrito]
           ,[Correo]
           ,[Telefono]
             )
     VALUES
           (@Codigo
           ,@NombreProveedor
           ,@Provincia
           ,@Canton
           ,@Distrito
           ,@Correo
           ,@Telefono)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarTipoIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarTipoIdentificacion]
@TipoIdentificacion as varchar(50),
@Estado as bit
AS
BEGIN

Declare @Codigo int

Select @Codigo=isnull(MAX(IdTipoIdentificacion),0)+1 from TipoIdentificacion

INSERT INTO [dbo].[TipoIdentificacion]
           ([IdTipoIdentificacion]
           ,[TipoIdentificacion]
           ,[Estado])
     VALUES
           (@Codigo
           ,@TipoIdentificacion
           ,@Estado)
END			


GO
/****** Object:  StoredProcedure [dbo].[AgregarTratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarTratamiento]
@IdTratamiento as int,
@NombreTratamiento as varchar(50),
@Costo as float
AS
BEGIN


Declare @Codigo int

Select @Codigo=isnull(MAX(IdTratamiento),0)+1 from Tratamiento

INSERT INTO [dbo].[Tratamiento]
           ([IdTratamiento]
           ,[NombreTratamiento]
           ,[Costo])
     VALUES
           (@Codigo
           ,@NombreTratamiento
           ,@Costo
          )
END
GO
/****** Object:  StoredProcedure [dbo].[Cantones]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Cantones]
@Provincia as char(1)
AS
BEGIN

    -- Insert statements for procedure here
	SELECT * from Canton where Provincia=@Provincia order by Provincia,Canton 
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultaCliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ConsultaCliente]
@IdCliente as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Cliente where IdCliente=@IdCliente
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultaInstitucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultaInstitucion]
@IdInstitucion int
AS
BEGIN
	Select * from Institucion where IdInstitucion=@IdInstitucion
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultaMascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ConsultaMascota]
@IdMascota as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Mascota where IdMascota=@IdMascota
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultaPersona]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultaPersona]
@Cedula varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Persona where Cedula=@Cedula
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultaProducto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultaProducto]
@IdProducto as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Producto where IdProducto=@IdProducto
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultaProveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultaProveedor]
@IdProveedor as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Proveedor where IdProveedor=@IdProveedor
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ConsultarCliente]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Cliente
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultarInstitucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarInstitucion]
AS
BEGIN
	Select * from Institucion
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultarMascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ConsultarMascota]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Mascota
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProducto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultarProducto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Producto
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultarProveedor]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Proveedor
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarTiposIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarTiposIdentificacion]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from TipoIdentificacion
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultarTratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultarTratamiento]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Tratamiento
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultaTiposIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultaTiposIdentificacion]
@TipoIdentificacion as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from TipoIdentificacion where TipoIdentificacion=@TipoIdentificacion
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultaTratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ConsultaTratamiento]
@IdTratamiento as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Tratamiento where IdTratamiento=@IdTratamiento
END
GO
/****** Object:  StoredProcedure [dbo].[Distritos]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Distritos]
@Provincia as char(1),
@Canton as char(2)
AS
BEGIN

    -- Insert statements for procedure here
	SELECT * from Distrito where Provincia=@Provincia and Canton=@Canton order by Provincia,Canton,Distrito
END


GO
/****** Object:  StoredProcedure [dbo].[EliminaCliente]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[EliminaCliente]
@IdCliente as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Cliente where IdCliente=@IdCliente
END


GO
/****** Object:  StoredProcedure [dbo].[EliminaInstitucion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminaInstitucion]
@IdInstitucion int
AS
BEGIN
	Delete Institucion where IdInstitucion=@IdInstitucion
END


GO
/****** Object:  StoredProcedure [dbo].[EliminaMascota]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EliminaMascota]
@IdMascota as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Mascota where IdMascota=@IdMascota
END

GO
/****** Object:  StoredProcedure [dbo].[EliminaProducto]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[EliminaProducto]
@IdProducto as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Producto where IdProducto=@IdProducto
END

GO
/****** Object:  StoredProcedure [dbo].[EliminaProveedor]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EliminaProveedor]
@IdProveedor as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Proveedor where IdProveedor=@IdProveedor
END

GO
/****** Object:  StoredProcedure [dbo].[EliminaTiposIdentificacion]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminaTiposIdentificacion]
@TipoIdentificacion as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete TipoIdentificacion where TipoIdentificacion=@TipoIdentificacion
END


GO
/****** Object:  StoredProcedure [dbo].[EliminaTratamiento]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[EliminaTratamiento]
@IdTratamiento as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Tratamiento where IdTratamiento=@IdTratamiento
END

GO
/****** Object:  StoredProcedure [dbo].[ExisteUsuario]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExisteUsuario]
@Usuario as varchar(50),
@Clave as varchar(50)
AS
BEGIN

    -- Insert statements for procedure here
	SELECT * from Usuario where Usuario=@Usuario and Clave=@Clave
END


GO
/****** Object:  StoredProcedure [dbo].[Provincias]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Provincias]
AS
BEGIN

    -- Insert statements for procedure here
	SELECT * from Provincia order by Cod
END


GO
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 4/6/2020 4:13:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarBitacora]
@Controlador varchar(50),
@Metodo varchar(50),
@Mensaje varchar(MAX),
@Usuario varchar(50),
@Tipo int
AS
BEGIN

Declare @Codigo int

Select @Codigo=isnull(MAX(IdBitacora),0)+1 from Bitacora

INSERT INTO [dbo].[Bitacora]
           ([IdBitacora]
           ,[Controlador]
           ,[Metodo]
           ,[Mensaje]
           ,[Usuario]
		   ,[Tipo])
     VALUES
           (@Codigo
           ,@Controlador
           ,@Metodo
           ,@Mensaje
           ,@Usuario
		   ,@Tipo)
END


GO
USE [master]
GO
ALTER DATABASE [ProyectoCarol] SET  READ_WRITE 
GO
