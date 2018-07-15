using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsUsuario
/// </summary>
public class ClsUsuario
{
    public int? idUsuario { get; set; }
    public string usuario { get; set; }
    public string contrasena { get; set; }
    public int idRol { get; set; }
    public string nombreUsuario { get; set; }
    public Boolean activo { get; set; }
    public Boolean reiniciarContrasena { get; set; }
    public string usuarioOpera { get; set; }
    public string urlImagen { get; set; }

	public ClsUsuario()
	{
		 
	}

    public void grabar() {
        try
        {
            ClsDb db = new ClsDb();
            db.ejecutarSP("SPUSuarioIU", null
                , db.parametro("@PIdUsuario", this.idUsuario)
                , db.parametro("@Pusuario", this.usuario)
                , db.parametro("@Pcontrasena", this.contrasena)
                , db.parametro("@PidRol", this.idRol)
                , db.parametro("@PnombreUsuario", this.nombreUsuario)
                , db.parametro("@PActivo", this.activo)
                , db.parametro("@PusuarioOpera", this.usuarioOpera)
                , db.parametro("@PReiniciarContrasena", this.reiniciarContrasena)
                , db.parametro("@PurlImagen", this.urlImagen)
                );
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public ClsUsuario getById(int id) {
        try
        {
            ClsUsuario r = null;
            ClsDb db = new ClsDb();
            DataTable dt = new DataTable();
            dt = db.dataTableSP("SPUsuarioGetByID", null, db.parametro("@PidUsuario", id));
            if (dt.Rows.Count > 0) {
                r = new ClsUsuario();
                r.idUsuario = (int)dt.Rows[0]["idUsuario"];
                r.usuario = dt.Rows[0]["usuario"].ToString();
                r.nombreUsuario = dt.Rows[0]["nombreUsuario"].ToString() ;
                r.contrasena = dt.Rows[0]["contrasena"].ToString();
                r.idRol = (int)dt.Rows[0]["idRol"];
                r.nombreUsuario = dt.Rows[0]["nombreUsuario"].ToString();
                r.activo = (Boolean)dt.Rows[0]["activo"];
                r.urlImagen = dt.Rows[0]["urlImagen"].ToString();
            }
            return r;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public DataTable select() {
        try
        {
            ClsDb db =  new ClsDb();
            DataTable r = new DataTable();
            r = db.dataTableSP("SPUsuarioSelect");
            return r;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public DataTable datosInicio(string idUsuario) { 
     try
        {
            DataTable dt = new DataTable();
            ClsDb db = new ClsDb();
            dt = db.dataTableSP("[SPDatosUsuario]", null, db.parametro("@PidUsuario", idUsuario));
            return dt ;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

}