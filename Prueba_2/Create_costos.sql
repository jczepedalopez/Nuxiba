SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[costos](	
	[tipoDeLlamada] [varchar](15) NOT NULL,
    [costo] [decimal](10,4) NOT NULL
) ON [PRIMARY]
GO