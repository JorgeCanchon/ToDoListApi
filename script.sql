USE [master]
GO
CREATE DATABASE [ToDoList]
GO
USE [ToDoList]
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[UltimaFechaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Categorias] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO

CREATE TABLE [dbo].[Tareas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[FechaLimite] [datetime2](7) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[UltimaFechaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tareas] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO

ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Categorias_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categorias] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Categorias_CategoriaId]
GO

