using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsCombos
/// </summary>
public class ClsCombos
{
    ClsDb db = new ClsDb();
	public DataTable fill(string tabla,string condicion="",Boolean seleccione=true)
	{
        DataTable dt = new DataTable();
        string consulta=string.Empty;
        try
        {
            if (seleccione) {
                consulta = "SELECT '' id, 'Seleccione' nombre UNION ALL ";
            }
            consulta += "SELECT CONVERT(VARCHAR,id) id,nombre FROM " + tabla;
            if(!string.IsNullOrEmpty(condicion) ){
                consulta +=" WHERE " + condicion;
            }
            dt = db.consultarTabla(consulta);
            return dt;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
	}
}