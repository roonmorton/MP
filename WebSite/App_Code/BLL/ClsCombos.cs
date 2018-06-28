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
    public DataTable fill(string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
	{
        DataTable dt = new DataTable();
        string consulta=string.Empty;
        try
        {
            if (seleccione) {
                consulta = "SELECT '' " + dataField +", 'Seleccione' "+ textField +" UNION ALL ";
            }
            consulta += "SELECT CONVERT(VARCHAR," + dataField +") " + dataField +","+ textField +" FROM " + tabla;
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