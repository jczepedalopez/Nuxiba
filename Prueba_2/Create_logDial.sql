SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logDial](
	[idLlamada] [varchar](10) NOT NULL,
	[fechaDeLlamada] [datetime] NOT NULL,
	[tiempoDialogo] [smallint] NOT NULL,
	[telefono] [varchar](10) NOT NULL,
	[tipoDeLlamada] [varchar](15) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[idLlamada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
