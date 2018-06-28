USE DBMANGUAPEDIATRICO
GO
ALTER TABLE PAC_BAJA
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,--fechaModificacion DATETIME

go

CREATE TRIGGER trgPAC_BAJA
   ON  PAC_BAJA
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM PAC_BAJA a INNER JOIN Inserted b ON a.idPAciente = b.idPaciente
	 

END
GO