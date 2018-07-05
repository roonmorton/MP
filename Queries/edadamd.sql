DECLARE @PIdPaciente int = 3

DECLARE @Vanios int=0,@Vmeses int=0,@Vdias int=0
DECLARE @VFechaNacimiento DATE = (SELECT FechaNacimiento FROM PAC_BASALES WHERE IdPaciente = @PIdPaciente);
SELECT @VFechaNacimiento = '31/01/1987'
DECLARE @VDiaNacimiento INT = DAY(@VFechaNacimiento)
DECLARE @VMesNacimiento INT = MONTH(@VFechaNacimiento)
DECLARE @VAnioNacimiento INT = YEAR(@VFechaNacimiento)


--SELECT DATEDIFF(YEAR,@VFechaNacimiento,getdate()) "edadyy",
--DATEDIFF(MONTH,@VFechaNacimiento,getdate())%12 "edadmm",
--DATEPART(DAY, getdate()) - DATEPART(DAY, @VFechaNacimiento) "edaddd"






SET @Vanios=FLOOR(CONVERT(FLOAT,DATEDIFF(DAY,@VFechaNacimiento,GETDATE()))/365.25)
IF MONTH(GETDATE()) <> MONTH(@VFechaNacimiento)
BEGIN
	SET @Vmeses = DATEDIFF(MONTH,@VFechaNacimiento,GETDATE())%12
	IF DAY(@VFechaNacimiento)>DAY(GETDATE())
	BEGIN
		SET @Vmeses-=1
		SET @Vdias =DATEDIFF(DAY
							, CAST(CAST(DAY(@VFechaNacimiento) AS varchar)+'/'+  CAST(MONTH(GETDATE())-1 AS varchar) +'/'+  CAST(YEAR(GETDATE()) AS varchar) AS DATETIME) 
							,GETDATE())
	END
	ELSE
	BEGIN
		SET @Vdias =DATEDIFF(DAY
							, CAST(CAST(DAY(@VFechaNacimiento) AS varchar)+'/'+  CAST(MONTH(GETDATE()) AS varchar) +'/'+  CAST(YEAR(GETDATE()) AS varchar) AS DATETIME) 
							,GETDATE())
	END
END

SELECT CAST(CAST(DAY(@VFechaNacimiento) AS varchar)+'/'+  CAST(MONTH(GETDATE())-1 AS varchar) +'/'+  CAST(YEAR(GETDATE()) AS varchar) AS DATETIME)new


SELECT @VFechaNacimiento,@Vanios anios,@Vmeses meses,@Vdias dias


