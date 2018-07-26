USE DBMANGUAPEDIATRICO
GO

CREATE TABLE TrabajoSocialAdherencia(
idTrabajoSocialAdherencia INT PRIMARY KEY IDENTITY(1,1)
,idPaciente INT
,apoyoFamiliarEstable INT
,apoyoFamiliarInestable INT
,ausenciaApoyoFamiliar INT
,grupoFamiliarTrabajoEstable INT
,grupoFamiliarTrabajoInestable INT
,grupoFamiliarDesempleado INT
,comprendePlenamenteVIH INT
,comprendeParcialmenteVIH INT
,noComprendeGeneralidadesVIH INT
,aceptadoDiagnostico INT
,noAceptadoDiagnostico INT
,niegaDiagnostico INT
,nino INT
,adolescente INT
,ninoAdolescenteConflictivo INT
,RSAT INT
)
GO

ALTER TABLE TrabajoSocialAdherencia
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,fechaModificacion DATETIME

go

CREATE TRIGGER trgTrabajoSocialAdherencia
   ON  TrabajoSocialAdherencia
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM TrabajoSocialAdherencia a INNER JOIN Inserted b ON a.idTrabajoSocialAdherencia = b.idTrabajoSocialAdherencia
	 

END
GO

CREATE PROCEDURE SPTrabajoSocialAdherenciaIU 
@PidTrabajoSocialAdherencia INT
,@PidPaciente INT
,@PapoyoFamiliarEstable INT
,@PapoyoFamiliarInestable INT
,@PausenciaApoyoFamiliar INT
,@PgrupoFamiliarTrabajoEstable INT
,@PgrupoFamiliarTrabajoInestable INT
,@PgrupoFamiliarDesempleado INT
,@PcomprendePlenamenteVIH INT
,@PcomprendeParcialmenteVIH INT
,@PnoComprendeGeneralidadesVIH INT
,@PaceptadoDiagnostico INT
,@PnoAceptadoDiagnostico INT
,@PniegaDiagnostico INT
,@Pnino INT
,@Padolescente INT
,@PninoAdolescenteConflictivo INT
,@PRSAT INT
,@Pusuario VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS(SELECT  1 FROM TrabajoSocialAdherencia WHERE idPaciente = @PidPaciente)
	BEGIN
		INSERT TrabajoSocialAdherencia(
		idPaciente
		,apoyoFamiliarEstable
		,apoyoFamiliarInestable
		,ausenciaApoyoFamiliar
		,grupoFamiliarTrabajoEstable
		,grupoFamiliarTrabajoInestable
		,grupoFamiliarDesempleado
		,comprendePlenamenteVIH
		,comprendeParcialmenteVIH
		,noComprendeGeneralidadesVIH
		,aceptadoDiagnostico
		,noAceptadoDiagnostico
		,niegaDiagnostico
		,nino
		,adolescente
		,ninoAdolescenteConflictivo
		,RSAT
		,usuarioCreacion
		) VALUES(
		@PidPaciente
		,@PapoyoFamiliarEstable
		,@PapoyoFamiliarInestable
		,@PausenciaApoyoFamiliar
		,@PgrupoFamiliarTrabajoEstable
		,@PgrupoFamiliarTrabajoInestable
		,@PgrupoFamiliarDesempleado
		,@PcomprendePlenamenteVIH
		,@PcomprendeParcialmenteVIH
		,@PnoComprendeGeneralidadesVIH
		,@PaceptadoDiagnostico
		,@PnoAceptadoDiagnostico
		,@PniegaDiagnostico
		,@Pnino
		,@Padolescente
		,@PninoAdolescenteConflictivo
		,@PRSAT
		,@Pusuario 
		)
	END
	ELSE
	BEGIN
		UPDATE TrabajoSocialAdherencia
		SET 
		idPaciente=@PidPaciente
		,apoyoFamiliarEstable=@PapoyoFamiliarEstable
		,apoyoFamiliarInestable=@PapoyoFamiliarInestable
		,ausenciaApoyoFamiliar=@PausenciaApoyoFamiliar
		,grupoFamiliarTrabajoEstable=@PgrupoFamiliarTrabajoEstable
		,grupoFamiliarTrabajoInestable=@PgrupoFamiliarTrabajoInestable
		,grupoFamiliarDesempleado=@PgrupoFamiliarDesempleado
		,comprendePlenamenteVIH=@PcomprendePlenamenteVIH
		,comprendeParcialmenteVIH=@PcomprendeParcialmenteVIH
		,noComprendeGeneralidadesVIH=@PnoComprendeGeneralidadesVIH
		,aceptadoDiagnostico=@PaceptadoDiagnostico
		,noAceptadoDiagnostico=@PnoAceptadoDiagnostico
		,niegaDiagnostico=@PniegaDiagnostico
		,nino=@Pnino
		,adolescente=@Padolescente
		,ninoAdolescenteConflictivo=@PninoAdolescenteConflictivo
		,usuarioModificacion = @Pusuario
		,RSAT = @PRSAT
		WHERE idPaciente = @PidPaciente
	END
END
GO

CREATE PROCEDURE UPSTrabajoSocialAdherenciaPorID
@PidPaciente INT
AS
BEGIN
	SELECT  
	idTrabajoSocialAdherencia
	,idPaciente
	,apoyoFamiliarEstable
	,apoyoFamiliarInestable
	,ausenciaApoyoFamiliar
	,grupoFamiliarTrabajoEstable
	,grupoFamiliarTrabajoInestable
	,grupoFamiliarDesempleado
	,comprendePlenamenteVIH
	,comprendeParcialmenteVIH
	,noComprendeGeneralidadesVIH
	,aceptadoDiagnostico
	,noAceptadoDiagnostico
	,niegaDiagnostico
	,nino
	,adolescente
	,ninoAdolescenteConflictivo
	,RSAT
FROM TrabajoSocialAdherencia
	WHERE idPaciente=@PidPaciente
END

CREATE TABLE MRSAT(
id INT IDENTITY(1,1) PRIMARY KEY
,nombre VARCHAR(100)
)

INSERT MRSAT(nombre) VALUES
('SRS - No presenta riesgos sociales evidentes en cuanto a la adherencia al TARGA (8-10)')
,('RSI - Presenta leves riesgos sociales en cuanto a la adherencia al TARGA (5-7)')
,('RSG - Presenta graves riesgos sociales en cuanto a la adherencia al TARGA (<=4) ')