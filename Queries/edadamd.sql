CREATE PROCEDURE SPObtenerEdad 
@PIdPaciente int  
,@PFechaVisita DATE   
AS
BEGIN
	DECLARE @Vanios int=0,@Vmeses int=0,@Vdias int=0
	DECLARE @VFechaNacimiento DATE = (SELECT FechaNacimiento FROM PAC_BASALES WHERE IdPaciente = @PIdPaciente);
	--SELECT @VFechaNacimiento = '31/01/1987'
	DECLARE @VDiaNacimiento INT = DAY(@VFechaNacimiento)


	SET @Vanios=FLOOR(CONVERT(FLOAT,DATEDIFF(DAY,@VFechaNacimiento,@PFechaVisita))/365.25)
	IF MONTH(@PFechaVisita) <> MONTH(@VFechaNacimiento)
	BEGIN
		SET @Vmeses = DATEDIFF(MONTH,@VFechaNacimiento,@PFechaVisita)%12
		/*Si el día de nacimiento  es mayor que el ultimo dia del mes a evaluar, por ejemplo dia 31 en feb*/
		DECLARE @VultimodiaMes INT  = DAY(DATEADD(month, ((YEAR(@PFechaVisita)  - 1900) * 12) + (MONTH(@PFechaVisita)-1), -1))
		IF @VultimodiaMes < DAY(@VFechaNacimiento)
		BEGIN			
			SET	@VDiaNacimiento = @VultimodiaMes	
		END

		IF DAY(@VFechaNacimiento)>DAY(@PFechaVisita)
		BEGIN
			SET @Vmeses-=1
												
			SET @Vdias =DATEDIFF(DAY
							, CAST(CAST(@VDiaNacimiento AS varchar)+'/'+  CAST(MONTH(@PFechaVisita)-1 AS varchar) +'/'+  CAST(YEAR(@PFechaVisita) AS varchar) AS DATETIME) 
							,@PFechaVisita)
				
		END
		ELSE
		BEGIN
			SET @Vdias =DATEDIFF(DAY
								, CAST(CAST(@VDiaNacimiento AS varchar)+'/'+  CAST(MONTH(GETDATE()) AS varchar) +'/'+  CAST(YEAR(GETDATE()) AS varchar) AS DATETIME) 
								,GETDATE())
		END
	END


	SELECT @Vanios anios,@Vmeses meses,@Vdias dias
END