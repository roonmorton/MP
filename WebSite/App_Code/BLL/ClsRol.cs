using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsRol
/// </summary>
public class ClsRol
{
    public int? idRol { get; set; }
    public string nombre { get; set; }
    public string  descripcion { get; set; }
    ClsDb db = new ClsDb();
    public ClsRol()
    {

    }

    public void grabar()
    {
        try
        {
            db.ejecutarSP("SProlIU", null
                , db.parametro("@Pidrol", this.idRol)
                , db.parametro("@Pnombre", this.nombre)
                , db.parametro("@Pdescripcion", this.descripcion)
                );
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

   public  DataTable getData() {
        DataTable r = new DataTable();
        try
        {
            r = db.dataTableSP("SPRolSelect", null);
            return r;    
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
}