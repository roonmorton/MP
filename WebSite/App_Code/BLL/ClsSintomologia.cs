using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsSintomologia
/// </summary>
public class ClsSintomologia
{
    

    public ClsSintomologia()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    public void grabar(
        string fechaSintomologia, 
        string idSintomologia = "0", 
        string idPaciente = "0", 
        List<DataTable> dtSintomas = null)
    {
        try
        {
            ClsDb db = new ClsDb();
            //Nombres de cada TPV que se enviara
            string[] nombreTPV = { "@PtpvSintomas", "@PtpvOtros" };
            db.ejecutarSPTPV("SPIuSintomatologia",
                null,
                dtSintomas, 
                nombreTPV,
                db.parametro("PidSintomatologia",idSintomologia),
                db.parametro("@PFechaSintomologia",fechaSintomologia),
                db.parametro("@pidPaciente",idPaciente)
                );

        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public DataTable seleccionarSintomatologiasPaciente(string idPaciente = "0")
    {
        try
        {
            ClsDb db = new ClsDb();
            DataTable dt = new DataTable();
            dt = db.dataTableSP("SPSSintomatologiaPaciente", null, db.parametro("@PidPaciente", idPaciente));
            return dt;
        }catch(Exception ex)
        {
            throw ex;
        }

    }
}