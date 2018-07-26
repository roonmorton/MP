CREATE TABLE Coprologia(
idCoprologia INT PRIMARY KEY IDENTITY(1,1)
,idPaciente INT
,fechaAnalitica DATE
,sangreOculta FLOAT
,azulMetilenoHeces FLOAT
,polimorfonucleares FLOAT
,mononucleares FLOAT
,paracitosHeces FLOAT
,azucaresReductores FLOAT
)
GO
ALTER TABLE Coprologia
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,fechaModificacion DATETIME

go
CREATE TRIGGER trgCoprologia
   ON  Coprologia
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM Coprologia a INNER JOIN Inserted b ON a.idCoprologia = b.idCoprologia
	 

END

CREATE PROCEDURE SPCoprologiaIU 
@PidCoprologia INT
,@PidPaciente INT
,@PfechaAnalitica DATE
,@PsangreOculta FLOAT
,@PazulMetilenoHeces FLOAT
,@Ppolimorfonucleares FLOAT
,@Pmononucleares FLOAT
,@PparacitosHeces FLOAT
,@PazucaresReductores FLOAT
,@Pusuario VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS(SELECT  1 FROM coprologia WHERE idCoprologia = @PidCoprologia)
	BEGIN
		INSERT coprologia(
		idPaciente
		,fechaAnalitica
		,sangreOculta
		,azulMetilenoHeces
		,polimorfonucleares
		,mononucleares
		,paracitosHeces
		,azucaresReductores
		,usuarioCreacion
		) VALUES(
		@PidPaciente
		,@PfechaAnalitica
		,@PsangreOculta
		,@PazulMetilenoHeces
		,@Ppolimorfonucleares
		,@Pmononucleares
		,@PparacitosHeces
		,@PazucaresReductores
		,@Pusuario
		)
	END
	ELSE
	BEGIN
		UPDATE coprologia
		SET 
		idPaciente=@PidPaciente
		,fechaAnalitica=@PfechaAnalitica
		,sangreOculta=@PsangreOculta
		,azulMetilenoHeces=@PazulMetilenoHeces
		,polimorfonucleares=@Ppolimorfonucleares
		,mononucleares=@Pmononucleares
		,paracitosHeces=@PparacitosHeces
		,azucaresReductores=@PazucaresReductores
		,usuarioModificacion = @Pusuario
		WHERE idCoprologia = @PidCoprologia
	END
END

GO
CREATE PROCEDURE UPCoprologiaD
@PidCoprologia INT
AS
BEGIN
	DELETE coprologia WHERE idCoprologia=@PidCoprologia
END

CREATE PROCEDURE UPSCoprologiaPorID
@PidCoprologia INT
AS
BEGIN
	SELECT  
	idCoprologia
	,idPaciente
	,fechaAnalitica
	,sangreOculta
	,azulMetilenoHeces
	,polimorfonucleares
	,mononucleares
	,paracitosHeces
	,azucaresReductores
FROM coprologia
	WHERE idCoprologia=@PidCoprologia
END
GO

CREATE PROCEDURE SPCoprologiaTodos
@PidPaciente INT
AS
BEGIN
	SELECT  
	idCoprologia
	,idPaciente
	,fechaAnalitica
	,sangreOculta
	,azulMetilenoHeces
	,polimorfonucleares
	,mononucleares
	,paracitosHeces
	,azucaresReductores
FROM coprologia
	WHERE idPaciente=@PidPaciente
END


