CREATE TABLE BiologiaMolecular(
idBiologiaMolecular INT PRIMARY KEY IDENTITY(1,1)
,idPaciente INT
,fechaMuestra DATE
,fechaAnalisis DATE
,muestra DECIMAL(18,2)
,PCRMycobacteriumTuberculosis DECIMAL(18,2)
,PCRHistoplasmaCapsulatum DECIMAL(18,2)
)

GO
ALTER TABLE BiologiaMolecular
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,fechaModificacion DATETIME

go

CREATE TRIGGER trgBiologiaMolecular
   ON  BiologiaMolecular
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM BiologiaMolecular a INNER JOIN Inserted b ON a.idBiologiaMolecular = b.idBiologiaMolecular
	 

END
GO

CREATE PROCEDURE SPBiologiaMolecularIU 
@PidBiologiaMolecular INT
,@PidPaciente INT
,@PfechaMuestra DATE
,@PfechaAnalisis DATE
,@Pmuestra DECIMAL(18,2)
,@PPCRMycobacteriumTuberculosis DECIMAL(18,2)
,@PPCRHistoplasmaCapsulatum DECIMAL(18,2)
,@Pusuario VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS(SELECT  1 FROM BiologiaMolecular WHERE idBiologiaMolecular = @PidBiologiaMolecular)
	BEGIN
		INSERT BiologiaMolecular(
		idPaciente
		,fechaMuestra
		,fechaAnalisis
		,muestra
		,PCRMycobacteriumTuberculosis
		,PCRHistoplasmaCapsulatum
		,usuarioCreacion
		) VALUES(
		@PidPaciente
		,@PfechaMuestra
		,@PfechaAnalisis
		,@Pmuestra
		,@PPCRMycobacteriumTuberculosis
		,@PPCRHistoplasmaCapsulatum
		,@Pusuario
		)
	END
	ELSE
	BEGIN
		UPDATE BiologiaMolecular
		SET 
		idPaciente=@PidPaciente
		,fechaMuestra=@PfechaMuestra
		,fechaAnalisis=@PfechaAnalisis
		,muestra=@Pmuestra
		,PCRMycobacteriumTuberculosis=@PPCRMycobacteriumTuberculosis
		,PCRHistoplasmaCapsulatum=@PPCRHistoplasmaCapsulatum
		,usuarioModificacion = @Pusuario
		WHERE idBiologiaMolecular = @PidBiologiaMolecular
	END
END
GO
CREATE PROCEDURE SPBiologiaMolecularD
@PidBiologiaMolecular INT
AS
BEGIN
	DELETE BiologiaMolecular WHERE idBiologiaMolecular=@PidBiologiaMolecular
END

GO
CREATE PROCEDURE SPSBiologiaMolecularPorID
@PidBiologiaMolecular INT
AS
BEGIN
	SELECT  
	idBiologiaMolecular
	,idPaciente
	,fechaMuestra
	,fechaAnalisis
	,muestra
	,PCRMycobacteriumTuberculosis
	,PCRHistoplasmaCapsulatum
FROM BiologiaMolecular
	WHERE idBiologiaMolecular=@PidBiologiaMolecular
END

GO
CREATE PROCEDURE SPSBiologiaMolecularTodos
@PidPaciente INT
AS
BEGIN
	SELECT  
	idBiologiaMolecular
	,idPaciente
	,fechaMuestra
	,fechaAnalisis
	,muestra
	,PCRMycobacteriumTuberculosis
	,PCRHistoplasmaCapsulatum
FROM BiologiaMolecular
	WHERE idpaciente = @PidPaciente
END
