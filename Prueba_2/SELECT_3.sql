SELECT TOP (1000) [idLlamada]
      ,[fechaDeLlamada]
      ,[tiempoDialogo]
      ,[telefono]
      ,[logDial].[tipoDeLlamada]
      ,[logDial].[tiempoDialogo] * [costo].[costo] as [Costo]
  FROM [dbo].[logDial] logDial
    JOIN [dbo].[costos] costo ON [logDial].[tipoDeLlamada] = [costo].[tipoDeLlamada]
  WHERE MONTH([fechaDeLlamada]) = 1;