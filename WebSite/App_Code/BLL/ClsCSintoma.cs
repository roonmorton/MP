using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsCSintomas
/// </summary>
public class ClsCSintoma
{
    /*public int? idRol { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }*/
    //ClsDb db = new ClsDb();

    public ClsCSintoma()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    public DataTable CSelect(string pCriterio)
    {
        try
        {
                ClsDb db = new ClsDb();
                DataTable r = new DataTable();
                r = db.dataTableSP("SPS_CSINTOMA",null,
                    db.parametro("@pCriterio",pCriterio));
                return r;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable seleccionarTabs()
    {
        try
        {
            ClsDb db = new ClsDb();
            DataTable r = new DataTable();
            r = db.dataTableSP("SPS_TabSintomas", null);
            return r;

        }
        catch(Exception ex)
        {
            throw;
        }
    }

    public DataTable seleccionarSintomasSintomologia(string idSintomologia = "0")
    {
        try
        {
            ClsDb db = new ClsDb();
            DataTable r = new DataTable();
            r = db.dataTableSP("SPSSintomas", null,db.parametro("@idSintomologia",idSintomologia));
            return r;

        }catch(Exception ex)
        {
            throw ex;
        }
    }


    public DataTable seleccionarSintomaOtro(string idSintoma = "0", string idSintomatologia = "0")
    {
        try
        {
            ClsDb db = new ClsDb();
            DataTable r = new DataTable();
            r = db.dataTableSP("SPSSintomaOtro", null, db.parametro("@idSintoma", idSintoma), db.parametro("@idSintomatologia", idSintomatologia));
            return r;

        }catch(Exception ex)
        {
            throw ex;
        }
    }

  

}