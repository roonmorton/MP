USE DBMANGUAPEDIATRICO
DECLARE 
@PNombreTabla VARCHAR(100) = N'SignosVitales'
,@POpcion TINYINT=2 /*1-SP, 2-CLASS */
BEGIN
	DECLARE @Vout VARCHAR(MAX)
	DECLARE @VTblColumns TABLE(columna VARCHAR(200),tipo Varchar(100),longitud int,precision int,escala int,pk bit, nulable bit)
	DECLARE @Vcolumna VARCHAR(200),@Vtipo Varchar(100),@Vlongitud int,@Vprecision int,@Vescala int,@Vpk bit,@Vnulable bit
	DECLARE @VKey VARCHAR(200)

	INSERT @VTblColumns(columna,tipo,longitud,precision,escala,pk,nulable)
	SELECT a.name columna,c.name tipo,a.max_length longitud ,a.precision,a.scale escala,a.is_identity,a.is_nullable   
	FROM SYS.COLUMNS a INNER JOIN SYS.TABLES b ON a.object_id = b.object_id
	INNER JOIN SYS.types c ON a.system_type_id = c.system_type_id
	WHERE b.name=@PNombreTabla
	AND a.Name NOT IN('fechaCreacion','fechaModificacion','usuarioCreacion','usuarioModificacion')
	ORDER BY a.column_id

	SET @VKey = (SELECT columna FROM @VTblColumns WHERE pk = 1)

	--SPs
	IF @POpcion =  1 
	BEGIN
		SET @Vout = N'CREATE PROCEDURE SPIU '+CHAR(13)+CHAR(10)			
	

		DECLARE Ccol CURSOR FOR 
		SELECT columna,tipo,longitud,precision,escala,pk,nulable
		FROM @VTblColumns
		OPEN Ccol
		FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
		WHILE @@FETCH_STATUS=0
		BEGIN
			--Inicio del Recorrido
			SET @Vout += N'@P'+@Vcolumna + ' ' +  UPPER(@Vtipo)
			IF @Vtipo = 'Varchar'
			BEGIN
				SET @Vout+= N'(' + CASE WHEN @Vlongitud <> -1 THEN CONVERT(VARCHAR,@Vlongitud) ELSE 'MAX' END + ')'
			END
			ELSE IF @Vtipo = 'decimal'
			BEGIN
				SET @Vout+= N'('+CONVERT(VARCHAR,@Vprecision)+','+CONVERT(VARCHAR,@Vescala)+')'
			END
			SET @Vout += CHAR(13)+CHAR(10) + ','
			
			--Final del recorrido
		FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
		END
		CLOSE Ccol
		DEALLOCATE Ccol
		--Quita última coma
		SET @Vout = SUBSTRING(@Vout,1,LEN(@Vout)-1)	

		SET @Vout+='AS'+CHAR(13)+CHAR(10) 
		SET @Vout+='BEGIN'+CHAR(13)+CHAR(10)+CHAR(9)
			SET @Vout+='IF NOT EXISTS(SELECT  1 FROM '+ @PNombreTabla + ' WHERE ' + @VKey +' = @P'+ @Vkey +')'+CHAR(13)+CHAR(10)+CHAR(9)
			SET @Vout+='BEGIN'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
				SET @Vout+='INSERT ' + @PNombreTabla + '('+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)	
				DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
					IF @VKey <> @Vcolumna
					BEGIN
						SET @Vout += @Vcolumna 					
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+ ','		
					END	
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
				--Quita última coma
				SET @Vout = SUBSTRING(@Vout,1,LEN(@Vout)-1)	
				SET @Vout += ') VALUES('+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
				--VALORES VALUES con formato @P
				DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
					IF @VKey <> @Vcolumna
					BEGIN
						SET @Vout += N'@P'+@Vcolumna 					
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+ ','	
					END		
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
				--Quita última coma
				SET @Vout = SUBSTRING(@Vout,1,LEN(@Vout)-1)	
				SET @Vout +=')'
		SET @Vout+=CHAR(13)+CHAR(10)+CHAR(9)+'END'--END INSERT
		SET @Vout+=CHAR(13)+CHAR(10)+CHAR(9)+'ELSE'
		SET @Vout+=CHAR(13)+CHAR(10)+CHAR(9)+'BEGIN'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='UPDATE ' + @PNombreTabla +CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='SET ' +CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		DECLARE Ccol CURSOR FOR 
		SELECT columna,tipo,longitud,precision,escala,pk,nulable
		FROM @VTblColumns
		OPEN Ccol
		FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
		WHILE @@FETCH_STATUS=0
		BEGIN
			--Inicio del Recorrido
			IF @VKey <> @Vcolumna
			BEGIN
				SET @Vout += @Vcolumna +'='+ N'@P'+@Vcolumna 					
				SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+ ','	
			END		
			--Final del recorrido
		FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
		END
		CLOSE Ccol
		DEALLOCATE Ccol
		--Quita última coma
		SET @Vout = SUBSTRING(@Vout,1,LEN(@Vout)-1)	
		SET @Vout += 'WHERE ' + @VKey + ' = ' + '@P'+@VKey

		SET @Vout+=CHAR(13)+CHAR(10)+CHAR(9)+'END'--END UPDATE

		SET @Vout+=CHAR(13)+CHAR(10)+'END'--END Principal

		--UP DELETE
		Set @Vout +=CHAR(13)+CHAR(10)+'GO'+CHAR(13)+CHAR(10)
		SET @Vout +='CREATE PROCEDURE UPD'+CHAR(13)+CHAR(10)
		SET @Vout +='@P'+@VKey + ' INT'+CHAR(13)+CHAR(10)
		SET @Vout +='AS'+CHAR(13)+CHAR(10)
		SET @Vout +='BEGIN'+CHAR(13)+CHAR(10)+CHAR(9)
		SET @Vout +='DELETE ' + @PNombreTabla + ' WHERE ' + @VKey +'=@P'+@VKey +CHAR(13)+CHAR(10)
		SET @Vout +='END'+CHAR(13)+CHAR(10)

		--UP SELECT POR ID
		Set @Vout +=CHAR(13)+CHAR(10)+'GO'+CHAR(13)+CHAR(10)
		SET @Vout +='CREATE PROCEDURE UPSPorID'+CHAR(13)+CHAR(10)
		SET @Vout +='@P'+@VKey + ' INT'+CHAR(13)+CHAR(10)
		SET @Vout +='AS'+CHAR(13)+CHAR(10)
		SET @Vout +='BEGIN'+CHAR(13)+CHAR(10)+CHAR(9)
		SET @Vout +='SELECT  ' +CHAR(13)+CHAR(10)+CHAR(9)
		DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
					SET @Vout +=@Vcolumna
					SET @Vout +=CHAR(13)+CHAR(10)+','
					
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
				--Quita última coma
				SET @Vout = SUBSTRING(@Vout,1,LEN(@Vout)-1)	
		SET @Vout +='FROM ' +  @PNombreTabla +CHAR(13)+CHAR(10)+CHAR(9)
		SET @Vout +='WHERE ' + @VKey +'=@P'+@VKey +CHAR(13)+CHAR(10)
		SET @Vout +='END'+CHAR(13)+CHAR(10)


	END
	--OPCION CLASE
	ELSE IF @POpcion =  2 
	BEGIN
		SET @Vout = N'public class Cls'+@PNombreTabla+'{'+CHAR(13)+CHAR(10)+CHAR(9)
		
		DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
						SET @Vout+='public ' +CASE @Vtipo
											 WHEN 'int' THEN 'int'
											 WHEN 'varchar' THEN 'string'
											 WHEN 'char' THEN 'string'
											 WHEN 'date' THEN 'DateTime'
											 WHEN 'datetime' THEN 'DateTime'
											 WHEN 'decimal' THEN 'Double'
											  WHEN 'float' THEN 'Double'
											 WHEN 'bit' THEN 'Boolean'
											 WHEN 'tinyint' THEN 'short'
											 END
											 +'? '+ @Vcolumna + ' {get; set;}'		
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)	
					
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
				
				SET @Vout +='private ClsDb db = new ClsDb();'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)	
				--método grabar
				SET @Vout +='public void grabar(){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)
				SET @Vout+='try{'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
				SET @Vout +='db.ejecutarSP("[NOMBRESP]", null'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)+CHAR(9)
				DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
						SET @Vout+=', db.parametro("@P' + @Vcolumna + '", this.'+ @Vcolumna +')'	
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)						
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
				SET @Vout +=');'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)
			
		SET @Vout+='}catch(Exception ex){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)--end try / begin catch
		SET @Vout+='throw ex;'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='}'+CHAR(13)+CHAR(10)+CHAR(9)--End catch
		SET @Vout +='}'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9) -- END void grabar

		--Método eliminar

		SET @Vout +='public void eliminar(int ' +@VKey +'){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='try{'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='db.ejecutarSP("NombreUP", null, db.parametro("@P'+@VKey+'", ' + @VKey+'));'

		SET @Vout+='}catch(Exception ex){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)--end try/ begin catch
		SET @Vout+='throw ex;'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='}'+CHAR(13)+CHAR(10)+CHAR(9)--End catch
		SET @Vout +='}'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9) -- END void eliminar

		--Método seleccionar por id
		SET @Vout +='public void seleccionarPorId(int ' +@VKey +'){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='try{'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='Cls'+@PNombreTabla + ' r = new Cls'+@PNombreTabla+'();'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='DataTable dt = new DataTable();'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='dt = db.dataTableSP("SPSELECT", null, db.parametro("@P' +@VKey + '", '+ @VKey +'));'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
        SET @Vout+='if (dt.Rows.Count > 0)' +CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)
        SET @Vout+='{'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)+CHAR(9)+CHAR(9) --inicio si hay registros
				DECLARE Ccol CURSOR FOR 
				SELECT columna,tipo,longitud,precision,escala,pk,nulable
				FROM @VTblColumns
				OPEN Ccol
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				WHILE @@FETCH_STATUS=0
				BEGIN
					--Inicio del Recorrido
					IF @Vtipo IN('varchar','char','nvarchar') 
					BEGIN
						SET @Vout+='r.' + @Vcolumna + ' = dt.Rows[0]["'+@Vcolumna+'"].ToString();'
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
					END
					ELSE
					BEGIN
						SET @Vout+='r.' + @Vcolumna + '=('+   +CASE @Vtipo
											 WHEN 'int' THEN 'int'
											 WHEN 'varchar' THEN 'string'
											 WHEN 'char' THEN 'string'
											 WHEN 'date' THEN 'DateTime'
											 WHEN 'datetime' THEN 'DateTime'
											 WHEN 'decimal' THEN 'Double'
											 WHEN 'bit' THEN 'Boolean'
											 WHEN 'tinyint' THEN 'short'
											 END + ')dt.Rows[0]["'+@Vcolumna+'"];'	
						SET @Vout += CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)	
					END
					--Final del recorrido
				FETCH Ccol INTO @Vcolumna,@Vtipo,@Vlongitud,@Vprecision,@Vescala,@Vpk,@Vnulable
				END
				CLOSE Ccol
				DEALLOCATE Ccol
		
		SET @Vout+='}'++CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9) --fin del if
        SET @Vout+='return r;'
		SET @Vout+='}catch(Exception ex){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)--end try/ begin catch
		SET @Vout+='throw ex;'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='}'+CHAR(13)+CHAR(10)+CHAR(9)--End catch
		SET @Vout +='}'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9) -- END void seleccionar por id

		--Método seleccionar
		SET @Vout +='public DataTable seleccionarPorId(int ' +@VKey +'){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='try{'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout +='DataTable dt = new DataTable();'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='dt = db.dataTableSP("SPSELECT", null, db.parametro("@P'+ @VKey+'", '+ @VKey +'));'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='return dt;'
		SET @Vout+='}catch(Exception ex){'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)--end try/ begin catch
		SET @Vout+='throw ex;'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9)
		SET @Vout+='}'+CHAR(13)+CHAR(10)+CHAR(9)--End catch
		SET @Vout +='}'+CHAR(13)+CHAR(10)+CHAR(9)+CHAR(9) -- END void seleccionar 


		SET @Vout+='}'--END CLASS


	END

	--Imprime salida
		PRINT @Vout
END