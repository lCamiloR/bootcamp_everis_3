
CREATE DATABASE [DeathStar]
USE [DeathStar]
GO
/****** Object:  Table [dbo].[HistoricoViagens]    Script Date: 12/11/2021 19:12:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoricoViagens](
	[his_nave_id] [int] NOT NULL,
	[his_piloto_id] [int] NOT NULL,
	[his_dt_saida] [datetime] NOT NULL,
	[his_dt_chegada] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Naves]    Script Date: 12/11/2021 19:12:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Naves](
	[nav_id] [int] NOT NULL,
	[nav_nome] [varchar](100) NOT NULL,
	[nav_modelo] [varchar](150) NOT NULL,
	[nav_passageiros] [int] NOT NULL,
	[nav_carga] [float] NOT NULL,
	[nav_classe] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Naves] PRIMARY KEY CLUSTERED 
(
	[nav_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pilotos]    Script Date: 12/11/2021 19:12:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilotos](
	[pil_id] [int] NOT NULL,
	[pil_nome] [varchar](200) NOT NULL,
	[pil_ano_nascimento] [varchar](10) NOT NULL,
	[pil_id_planeta] [int] NOT NULL,
 CONSTRAINT [PK_Pilotos] PRIMARY KEY CLUSTERED 
(
	[pil_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PilotosNaves]    Script Date: 12/11/2021 19:12:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PilotosNaves](
	[pln_piloto_id] [int] NOT NULL,
	[pln_nave_id] [int] NOT NULL,
	[pln_autorizado] [bit] NOT NULL,
 CONSTRAINT [PK_PilotosNaves] PRIMARY KEY CLUSTERED 
(
	[pln_piloto_id] ASC,
	[pln_nave_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planetas]    Script Date: 12/11/2021 19:12:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planetas](
	[pla_id] [int] NOT NULL,
	[pla_nome] [varchar](50) NOT NULL,
	[pla_rotacao] [float] NOT NULL,
	[pla_orbita] [float] NOT NULL,
	[pla_diametro] [float] NOT NULL,
	[pla_clima] [varchar](50) NOT NULL,
	[pla_populacao] [int] NOT NULL,
 CONSTRAINT [PK_Planets] PRIMARY KEY CLUSTERED 
(
	[pla_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PilotosNaves] ADD  CONSTRAINT [DF_PilotosNaves_Autorizado]  DEFAULT ((1)) FOR [pln_autorizado]
GO
ALTER TABLE [dbo].[HistoricoViagens]  WITH CHECK ADD  CONSTRAINT [FK_HISTORICO_VIAGENS_PILOTOS_NAVES] FOREIGN KEY([his_piloto_id], [his_nave_id])
REFERENCES [dbo].[PilotosNaves] ([pln_piloto_id], [pln_nave_id])
GO
ALTER TABLE [dbo].[HistoricoViagens] CHECK CONSTRAINT [FK_HISTORICO_VIAGENS_PILOTOS_NAVES]
GO
ALTER TABLE [dbo].[Pilotos]  WITH CHECK ADD  CONSTRAINT [FK_Pilotos_Planetas] FOREIGN KEY([pil_id_planeta])
REFERENCES [dbo].[Planetas] ([pla_id])
GO
ALTER TABLE [dbo].[Pilotos] CHECK CONSTRAINT [FK_Pilotos_Planetas]
GO
ALTER TABLE [dbo].[PilotosNaves]  WITH CHECK ADD  CONSTRAINT [FK_PilotosNaves_Naves] FOREIGN KEY([pln_nave_id])
REFERENCES [dbo].[Naves] ([nav_id])
GO
ALTER TABLE [dbo].[PilotosNaves] CHECK CONSTRAINT [FK_PilotosNaves_Naves]
GO
ALTER TABLE [dbo].[PilotosNaves]  WITH CHECK ADD  CONSTRAINT [FK_PilotosNaves_Pilotos] FOREIGN KEY([pln_piloto_id])
REFERENCES [dbo].[Planetas] ([pla_id])
GO
ALTER TABLE [dbo].[PilotosNaves] CHECK CONSTRAINT [FK_PilotosNaves_Pilotos]
GO
USE [master]
GO
ALTER DATABASE [DeathStar] SET  READ_WRITE 
GO
