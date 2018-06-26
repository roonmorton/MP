using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsValidaAcceso
/// </summary>
/// 

public static class ClsValidaAcceso
{



    public static ClsAccesoStruc validarPantalla(int idUsuario, string nombrePantalla)
    {
        try
        {
            ClsAccesoStruc r = new ClsAccesoStruc();
            DataTable dt = new DataTable();
            ClsDb db = new ClsDb();
            dt = db.dataTableSP("SPValidarAcceso", null
                , db.parametro("@PidUsuario", idUsuario)
                , db.parametro("@PnombrePantalla", nombrePantalla)
                );
            if (dt.Rows.Count > 0)
            {
                r.idModoAcceso = int.Parse(dt.Rows[0]["idModoAcceso"].ToString());
                r.nombre = dt.Rows[0]["nombre"].ToString();
                r.crear = (Boolean)dt.Rows[0]["crear"];
                r.leer = (Boolean)dt.Rows[0]["leer"];
                r.actualizar = (Boolean)dt.Rows[0]["actualizar"];
                r.eliminar = (Boolean)dt.Rows[0]["eliminar"];
            }
            return r;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public static ClsUsuario login(string usuario, string contrasena)
    {
        try
        {
            ClsUsuario us = new ClsUsuario();
            DataTable dt = new DataTable();
            ClsDb db = new ClsDb();

            dt = db.dataTableSP("", null, db.parametro("@Pusuario", usuario), db.parametro("@Pcontrasena", contrasena));
            if (dt.Rows.Count > 0)
            {
                us.idUsuario = (int)dt.Rows[0]["idUsuario"];
                us.usuario = dt.Rows[0]["usuario"].ToString();
                us.nombreUsuario = dt.Rows[0]["nombreUsuario"].ToString();
                us.idRol = (int)dt.Rows[0]["idRol"];
            }
            return us;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}