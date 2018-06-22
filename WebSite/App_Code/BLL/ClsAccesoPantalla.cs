using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descripción breve de ClsAccesoPantalla
/// </summary>
public class ClsAccesoPantalla
{
    ClsDb db = new ClsDb();
	public ClsAccesoPantalla()
	{
		
	}

    public DataTable listaPantallas(int idRol, short asignadas) {
        DataTable r = new DataTable();
        try
        {
            r = db.dataTableSP("SPAccesoPantallaSelect", null
                , db.parametro("@PidRol", idRol)
                , db.parametro("@PAsignadas", asignadas)
                );
            return r;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public void grabar(int idRol, int idPantalla, int idModoAcceso) {
        try
        {
            db.dataTableSP("SPAccesoPantallas", null
                            , db.parametro("@PidRol", idRol)
                            , db.parametro("@PidPantalla", idPantalla )
                            , db.parametro("@PidModoAcceso", idModoAcceso )

                            );
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public void eliminar(int idRol, int idPantalla, int idModoAcceso)
    {
        try
        {
            db.dataTableSP("SPAccesoPantallasDelete", null
                            , db.parametro("@PidRol", idRol)
                            , db.parametro("@PidPantalla", idPantalla )
                            , db.parametro("@PidModoAcceso", idModoAcceso )

                            );
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}