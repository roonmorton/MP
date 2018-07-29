CREATE TABLE LiquidosCorporales(
idLiquidosCorporales INT IDENTITY
,idPaciente INT
,FechaAnalitica DATE
,liquido VARCHAR(250)
,aspecto VARCHAR(250)
,volumen FLOAT
,sedimento VARCHAR(250)
,xantocromia VARCHAR(250)
,leucocitos FLOAT
,eritocitos FLOAT
,polimorfonucleares FLOAT
,mononucleares FLOAT
,linfocitos FLOAT
,liquidoQuimico VARCHAR(250)
,PH float
,glucosa float
,proteinas float
,albumina float
,LDH float
,amilasa float
,urea float
,acidoUrico float
,sodio float
,potasio float
,cloro float
,bicarbonato float
,IgG float
,CK float
,liquidoAntigenos VARCHAR(250)
,sifilisVDRL VARCHAR(150)
,sifilisTPHA VARCHAR(150)
,ecoli VARCHAR(150)
,dilucionVDRL VARCHAR(150)
,sifilisRPR VARCHAR(150)
,sifilisRPR1 VARCHAR(150)
,sifilisFTAABS VARCHAR(150)
,sPneumoniae  VARCHAR(150)
,hInfluenza VARCHAR(150)
,cryptococcus VARCHAR(150)
,dilucion1 VARCHAR(150)
,ADA VARCHAR(150)
)

GO
GO
ALTER TABLE LiquidosCorporales
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,fechaModificacion DATETIME

go

CREATE TRIGGER trgLiquidosCorporales
   ON  LiquidosCorporales
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM LiquidosCorporales a INNER JOIN Inserted b ON a.idLiquidosCorporales = b.idLiquidosCorporales
	 

END
GO

CREATE PROCEDURE SPLiquidoscorporalesIU 
@PidLiquidosCorporales INT
,@PidPaciente INT
,@PFechaAnalitica DATE
,@Pliquido VARCHAR(250)
,@Paspecto VARCHAR(250)
,@Pvolumen FLOAT
,@Psedimento VARCHAR(250)
,@Pxantocromia VARCHAR(250)
,@Pleucocitos FLOAT
,@Peritocitos FLOAT
,@Ppolimorfonucleares FLOAT
,@Pmononucleares FLOAT
,@Plinfocitos FLOAT
,@PliquidoQuimico VARCHAR(250)
,@PPH FLOAT
,@Pglucosa FLOAT
,@Pproteinas FLOAT
,@Palbumina FLOAT
,@PLDH FLOAT
,@Pamilasa FLOAT
,@Purea FLOAT
,@PacidoUrico FLOAT
,@Psodio FLOAT
,@Ppotasio FLOAT
,@Pcloro FLOAT
,@Pbicarbonato FLOAT
,@PIgG FLOAT
,@PCK FLOAT
,@PliquidoAntigenos VARCHAR(250)
,@PsifilisVDRL VARCHAR(150)
,@PsifilisTPHA VARCHAR(150)
,@Pecoli VARCHAR(150)
,@PdilucionVDRL VARCHAR(150)
,@PsifilisRPR VARCHAR(150)
,@PsifilisRPR1 VARCHAR(150)
,@PsifilisFTAABS VARCHAR(150)
,@PsPneumoniae VARCHAR(150)
,@PhInfluenza VARCHAR(150)
,@Pcryptococcus VARCHAR(150)
,@Pdilucion1 VARCHAR(150)
,@PADA VARCHAR(150)
,@Pusuario VARCHAr(100)
AS
BEGIN
	IF NOT EXISTS(SELECT  1 FROM LiquidosCorporales WHERE idLiquidosCorporales = @PidLiquidosCorporales)
	BEGIN
		INSERT LiquidosCorporales(
		idPaciente
		,FechaAnalitica
		,liquido
		,aspecto
		,volumen
		,sedimento
		,xantocromia
		,leucocitos
		,eritocitos
		,polimorfonucleares
		,mononucleares
		,linfocitos
		,liquidoQuimico
		,PH
		,glucosa
		,proteinas
		,albumina
		,LDH
		,amilasa
		,urea
		,acidoUrico
		,sodio
		,potasio
		,cloro
		,bicarbonato
		,IgG
		,CK
		,liquidoAntigenos
		,sifilisVDRL
		,sifilisTPHA
		,ecoli
		,dilucionVDRL
		,sifilisRPR
		,sifilisRPR1
		,sifilisFTAABS
		,sPneumoniae
		,hInfluenza
		,cryptococcus
		,dilucion1
		,ADA
		,usuarioCreacion
		) VALUES(
		@PidPaciente
		,@PFechaAnalitica
		,@Pliquido
		,@Paspecto
		,@Pvolumen
		,@Psedimento
		,@Pxantocromia
		,@Pleucocitos
		,@Peritocitos
		,@Ppolimorfonucleares
		,@Pmononucleares
		,@Plinfocitos
		,@PliquidoQuimico
		,@PPH
		,@Pglucosa
		,@Pproteinas
		,@Palbumina
		,@PLDH
		,@Pamilasa
		,@Purea
		,@PacidoUrico
		,@Psodio
		,@Ppotasio
		,@Pcloro
		,@Pbicarbonato
		,@PIgG
		,@PCK
		,@PliquidoAntigenos
		,@PsifilisVDRL
		,@PsifilisTPHA
		,@Pecoli
		,@PdilucionVDRL
		,@PsifilisRPR
		,@PsifilisRPR1
		,@PsifilisFTAABS
		,@PsPneumoniae
		,@PhInfluenza
		,@Pcryptococcus
		,@Pdilucion1
		,@PADA
		,@Pusuario
		)
	END
	ELSE
	BEGIN
		UPDATE LiquidosCorporales
		SET 
		idPaciente=@PidPaciente
		,FechaAnalitica=@PFechaAnalitica
		,liquido=@Pliquido
		,aspecto=@Paspecto
		,volumen=@Pvolumen
		,sedimento=@Psedimento
		,xantocromia=@Pxantocromia
		,leucocitos=@Pleucocitos
		,eritocitos=@Peritocitos
		,polimorfonucleares=@Ppolimorfonucleares
		,mononucleares=@Pmononucleares
		,linfocitos=@Plinfocitos
		,liquidoQuimico=@PliquidoQuimico
		,PH=@PPH
		,glucosa=@Pglucosa
		,proteinas=@Pproteinas
		,albumina=@Palbumina
		,LDH=@PLDH
		,amilasa=@Pamilasa
		,urea=@Purea
		,acidoUrico=@PacidoUrico
		,sodio=@Psodio
		,potasio=@Ppotasio
		,cloro=@Pcloro
		,bicarbonato=@Pbicarbonato
		,IgG=@PIgG
		,CK=@PCK
		,liquidoAntigenos=@PliquidoAntigenos
		,sifilisVDRL=@PsifilisVDRL
		,sifilisTPHA=@PsifilisTPHA
		,ecoli=@Pecoli
		,dilucionVDRL=@PdilucionVDRL
		,sifilisRPR=@PsifilisRPR
		,sifilisRPR1=@PsifilisRPR1
		,sifilisFTAABS=@PsifilisFTAABS
		,sPneumoniae=@PsPneumoniae
		,hInfluenza=@PhInfluenza
		,cryptococcus=@Pcryptococcus
		,dilucion1=@Pdilucion1
		,ADA=@PADA
		,usuarioModificacion =@Pusuario
		WHERE idLiquidosCorporales = @PidLiquidosCorporales
	END
END
GO
CREATE PROCEDURE SPLiquidosCorporalesD
@PidLiquidosCorporales INT
AS
BEGIN
	DELETE LiquidosCorporales WHERE idLiquidosCorporales=@PidLiquidosCorporales
END

GO
CREATE PROCEDURE SPSLiquidosCorporalesPorID
@PidLiquidosCorporales INT
AS
BEGIN
	SELECT  
	idLiquidosCorporales
	,idPaciente
	,FechaAnalitica
	,liquido
	,aspecto
	,volumen
	,sedimento
	,xantocromia
	,leucocitos
	,eritocitos
	,polimorfonucleares
	,mononucleares
	,linfocitos
	,liquidoQuimico
	,PH
	,glucosa
	,proteinas
	,albumina
	,LDH
	,amilasa
	,urea
	,acidoUrico
	,sodio
	,potasio
	,cloro
	,bicarbonato
	,IgG
	,CK
	,liquidoAntigenos
	,sifilisVDRL
	,sifilisTPHA
	,ecoli
	,dilucionVDRL
	,sifilisRPR
	,sifilisRPR1
	,sifilisFTAABS
	,sPneumoniae
	,hInfluenza
	,cryptococcus
	,dilucion1
	,ADA
FROM LiquidosCorporales
	WHERE idLiquidosCorporales=@PidLiquidosCorporales
END


GO
CREATe PROCEDURE SPLiquidosCorporalesPaciente
@PidPaciente INT
AS
BEGIN
	SELECT idLiquidosCorporales, fechaAnalitica
	FROM LiquidosCorporales
	WHERE idPAciente = @PidPaciente
END