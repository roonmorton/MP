using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Descripción breve de ClsInicioBusqueda
/// </summary>
public class ClsInicioBusqueda
{

    ClsDb db = new ClsDb();

    public DataTable buscar(string criterio)
    {
        DataTable dt = new DataTable();
        try
        {
            dt= db.dataTableSP("SPBUSQUEDAINICIO",null,db.parametro("@PCriterio",criterio));
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }


}