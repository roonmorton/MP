

CREATE TABLE [dbo].[ANA_HEMATOLOGIA](
	[IdAnaliticaHematologia] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NULL,
	[FechaAnalitica] date NULL,
	[Eritrocitos] [float] NULL,
	[Hemoglobina] [float] NULL,
	[Hematocrito] [float] NULL,
	[VCM] [float] NULL,
	[MCH] [float] NULL,
	[CHCM] [float] NULL,
	[RDW] [float] NULL,
	[Leucocitos] [float] NULL,
	[Linfocitos] [float] NULL,
	linfocitosPorcentaje FLOAT NULL,
	[Neutrofilos] [float] NULL,
	[Monocitos] [float] NULL,
	MonocitosPorcentaje FLOAT NULL,
	[Eosinofilos] [float] NULL,
	EosinofilosPorcentaje FLOAT NULL,
	Granulocitos FLOAT NULL,
	GranulocitosPorcentaje FLOAT NULL,
	[Basofilos] [float] NULL,
	BasofilosPorcentaje FLOAT NULL,
	[Plaquetas] [float] NULL,
	[Cayados] [float] NULL,
	[Protombina] [float] NULL,
	[Tromboplastina] [float] NULL,
	[Fibrinogeno] [float] NULL,
	[Reticulocitos] [float] NULL,
	[Sangre] [float] NULL,
	[Eosinofilosmocos] [float] NULL,
	VSE FLOAT NULL
	,ClasificacionAnemias VARCHAR(250)
	,GotaGruesa VARCHAR(250)
	,DescrcipcionGeneral VARCHAR(250)
	,SerieGranulocitaLinfocita VARCHAR(250)
	,SerieMegaCariocitica VARCHAR(250)
	,SeriePlaquetaria VARCHAR(250)
	,ImpresionClinica VARCHAR(MAX)

 CONSTRAINT [aaaaaANA_HEMATOLOGIA_PK] PRIMARY KEY NONCLUSTERED 
(
	[IdAnaliticaHematologia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ANA_HEMATOLOGIA]  WITH CHECK ADD  CONSTRAINT [ANA_HEMATOLOGIA_FK00] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[PAC_BASALES] ([IdPaciente])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ANA_HEMATOLOGIA] CHECK CONSTRAINT [ANA_HEMATOLOGIA_FK00]
GO

ALTER TABLE ANA_HEMATOLOGIA
ADD usuarioCreacion VARCHAR(100)
, fechaCreacion DATETIME DEFAULT(GETDATE())
,usuarioModificacion VARCHAR(100)
,fechaModificacion DATETIME

go
CREATE TRIGGER trgANA_HEMATOLOGIA
   ON  ANA_HEMATOLOGIA
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE a
	SET a.FechaModificacion = GETDATE()   
	FROM ANA_HEMATOLOGIA a INNER JOIN Inserted b ON a.IdAnaliticaHematologia = b.IdAnaliticaHematologia
	 

END
GO


CREATE PROCEDURE SPANA_HEMATOLOGIAIU 
@PIdAnaliticaHematologia INT
,@PIdPaciente INT
,@PFechaAnalitica DATE
,@PEritrocitos FLOAT
,@PHemoglobina FLOAT
,@PHematocrito FLOAT
,@PVCM FLOAT
,@PMCH FLOAT
,@PCHCM FLOAT
,@PRDW FLOAT
,@PLeucocitos FLOAT
,@PLinfocitos FLOAT
,@PlinfocitosPorcentaje FLOAT
,@PNeutrofilos FLOAT
,@PMonocitos FLOAT
,@PMonocitosPorcentaje FLOAT
,@PEosinofilos FLOAT
,@PEosinofilosPorcentaje FLOAT
,@PGranulocitos FLOAT
,@PGranulocitosPorcentaje FLOAT
,@PBasofilos FLOAT
,@PBasofilosPorcentaje FLOAT
,@PPlaquetas FLOAT
,@PCayados FLOAT
,@PProtombina FLOAT
,@PTromboplastina FLOAT
,@PFibrinogeno FLOAT
,@PReticulocitos FLOAT
,@PSangre FLOAT
,@PEosinofilosmocos FLOAT
,@PVSE FLOAT
,@PClasificacionAnemias VARCHAR(250)
,@PGotaGruesa VARCHAR(250)
,@PDescrcipcionGeneral VARCHAR(250)
,@PSerieGranulocitaLinfocita VARCHAR(250)
,@PSerieMegaCariocitica VARCHAR(250)
,@PSeriePlaquetaria VARCHAR(250)
,@PImpresionClinica VARCHAR(MAX)
,@Pusuario VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS(SELECT  1 FROM ANA_HEMATOLOGIA WHERE IdAnaliticaHematologia = @PIdAnaliticaHematologia)
	BEGIN
		INSERT ANA_HEMATOLOGIA(
		IdPaciente
		,FechaAnalitica
		,Eritrocitos
		,Hemoglobina
		,Hematocrito
		,VCM
		,MCH
		,CHCM
		,RDW
		,Leucocitos
		,Linfocitos
		,linfocitosPorcentaje
		,Neutrofilos
		,Monocitos
		,MonocitosPorcentaje
		,Eosinofilos
		,EosinofilosPorcentaje
		,Granulocitos
		,GranulocitosPorcentaje
		,Basofilos
		,BasofilosPorcentaje
		,Plaquetas
		,Cayados
		,Protombina
		,Tromboplastina
		,Fibrinogeno
		,Reticulocitos
		,Sangre
		,Eosinofilosmocos
		,VSE
		,ClasificacionAnemias
		,GotaGruesa
		,DescrcipcionGeneral
		,SerieGranulocitaLinfocita
		,SerieMegaCariocitica
		,SeriePlaquetaria
		,ImpresionClinica
		,usuarioCreacion
		) VALUES(
		@PIdPaciente
		,@PFechaAnalitica
		,@PEritrocitos
		,@PHemoglobina
		,@PHematocrito
		,@PVCM
		,@PMCH
		,@PCHCM
		,@PRDW
		,@PLeucocitos
		,@PLinfocitos
		,@PlinfocitosPorcentaje
		,@PNeutrofilos
		,@PMonocitos
		,@PMonocitosPorcentaje
		,@PEosinofilos
		,@PEosinofilosPorcentaje
		,@PGranulocitos
		,@PGranulocitosPorcentaje
		,@PBasofilos
		,@PBasofilosPorcentaje
		,@PPlaquetas
		,@PCayados
		,@PProtombina
		,@PTromboplastina
		,@PFibrinogeno
		,@PReticulocitos
		,@PSangre
		,@PEosinofilosmocos
		,@PVSE
		,@PClasificacionAnemias
		,@PGotaGruesa
		,@PDescrcipcionGeneral
		,@PSerieGranulocitaLinfocita
		,@PSerieMegaCariocitica
		,@PSeriePlaquetaria
		,@PImpresionClinica
		,@Pusuario
		)
	END
	ELSE
	BEGIN
		UPDATE ANA_HEMATOLOGIA
		SET 
		IdPaciente=@PIdPaciente
		,FechaAnalitica=@PFechaAnalitica
		,Eritrocitos=@PEritrocitos
		,Hemoglobina=@PHemoglobina
		,Hematocrito=@PHematocrito
		,VCM=@PVCM
		,MCH=@PMCH
		,CHCM=@PCHCM
		,RDW=@PRDW
		,Leucocitos=@PLeucocitos
		,Linfocitos=@PLinfocitos
		,linfocitosPorcentaje=@PlinfocitosPorcentaje
		,Neutrofilos=@PNeutrofilos
		,Monocitos=@PMonocitos
		,MonocitosPorcentaje=@PMonocitosPorcentaje
		,Eosinofilos=@PEosinofilos
		,EosinofilosPorcentaje=@PEosinofilosPorcentaje
		,Granulocitos=@PGranulocitos
		,GranulocitosPorcentaje=@PGranulocitosPorcentaje
		,Basofilos=@PBasofilos
		,BasofilosPorcentaje=@PBasofilosPorcentaje
		,Plaquetas=@PPlaquetas
		,Cayados=@PCayados
		,Protombina=@PProtombina
		,Tromboplastina=@PTromboplastina
		,Fibrinogeno=@PFibrinogeno
		,Reticulocitos=@PReticulocitos
		,Sangre=@PSangre
		,Eosinofilosmocos=@PEosinofilosmocos
		,VSE=@PVSE
		,ClasificacionAnemias=@PClasificacionAnemias
		,GotaGruesa=@PGotaGruesa
		,DescrcipcionGeneral=@PDescrcipcionGeneral
		,SerieGranulocitaLinfocita=@PSerieGranulocitaLinfocita
		,SerieMegaCariocitica=@PSerieMegaCariocitica
		,SeriePlaquetaria=@PSeriePlaquetaria
		,ImpresionClinica=@PImpresionClinica
		,usuarioModificacion = @Pusuario
		WHERE IdAnaliticaHematologia = @PIdAnaliticaHematologia
	END
END
GO
CREATE PROCEDURE SPANA_HEMATOLOGIAD
@PIdAnaliticaHematologia INT
AS
BEGIN
	DELETE ANA_HEMATOLOGIA WHERE IdAnaliticaHematologia=@PIdAnaliticaHematologia
END

GO
CREATE PROCEDURE SPSANA_HEMATOLOGIAPorID
@PIdAnaliticaHematologia INT
AS
BEGIN
	SELECT  
	IdAnaliticaHematologia
	,IdPaciente
	,FechaAnalitica
	,Eritrocitos
	,Hemoglobina
	,Hematocrito
	,VCM
	,MCH
	,CHCM
	,RDW
	,Leucocitos
	,Linfocitos
	,linfocitosPorcentaje
	,Neutrofilos
	,Monocitos
	,MonocitosPorcentaje
	,Eosinofilos
	,EosinofilosPorcentaje
	,Granulocitos
	,GranulocitosPorcentaje
	,Basofilos
	,BasofilosPorcentaje
	,Plaquetas
	,Cayados
	,Protombina
	,Tromboplastina
	,Fibrinogeno
	,Reticulocitos
	,Sangre
	,Eosinofilosmocos
	,VSE
	,ClasificacionAnemias
	,GotaGruesa
	,DescrcipcionGeneral
	,SerieGranulocitaLinfocita
	,SerieMegaCariocitica
	,SeriePlaquetaria
	,ImpresionClinica
FROM ANA_HEMATOLOGIA
	WHERE IdAnaliticaHematologia=@PIdAnaliticaHematologia
END
GO
CREATE PROCEDURE SPSANA_HEMATOLOGIAPorPaciente
@PIdPaciente INT
AS
BEGIN
	SELECT  
	IdAnaliticaHematologia
	,FechaAnalitica
	,Hemoglobina Hb
	,Hematocrito Hto
	,VCM
	,Leucocitos Leuco
	,Neutrofilos Neutrof
	,Linfocitos Linfs
	,Plaquetas Plaqs
	,Protombina TP
	,Tromboplastina TTPA
	,VSE	
FROM ANA_HEMATOLOGIA
	WHERE IdAnaliticaHematologia=@PIdPaciente
END