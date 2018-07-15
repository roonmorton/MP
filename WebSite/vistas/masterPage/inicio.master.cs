using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_masterPage_inicio : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClsUsuario us = new ClsUsuario();
            DataTable dt = new DataTable();
            if (Session["idusuario"] == null) { Response.Redirect("../Default.aspx"); }
            dt = us.datosInicio(Session["idusuario"].ToString());
            if (dt.Rows.Count < 1) { return; }
            avatarImg.ImageUrl = dt.Rows[0]["urlImagen"].ToString();
            avatarImage.ImageUrl = dt.Rows[0]["urlImagen"].ToString();
            nombreCorto.InnerText = dt.Rows[0]["usuario"].ToString();
            usuario.InnerText = dt.Rows[0]["nombreUsuario"].ToString();
            rol.InnerText = "Rol: " + dt.Rows[0]["rol"].ToString();

            Session["idPaciente"] = null;
            Session["nombrePaciente"] = null;
            Session["expedienteHR"] = null;
            Session["expedientePD"] = null;

            
        }
        catch (Exception)
        {
            
             
        }
    }
}
