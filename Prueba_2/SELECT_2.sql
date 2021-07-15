SELECT [tipoDeLlamada], AVG([tiempoDialogo]) AS [Promedio]
  FROM [dbo].[logDial]
  WHERE [tipoDeLlamada] = 'Cel LD'
  AND MONTH([fechaDeLlamada]) = 2
  GROUP BY [tipoDeLlamada];