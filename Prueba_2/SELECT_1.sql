SELECT TOP (1000) [idLlamada]
      ,[fechaDeLlamada]
      ,[tiempoDialogo]
      ,[telefono]
      ,[tipoDeLlamada]
  FROM [dbo].[logDial]
  WHERE [tipoDeLlamada] = 'Cel LD'
  AND MONTH([fechaDeLlamada]) = 2;