using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                asignarPermisos();
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, true);
        }
    }
    protected void lnkNuevaVisita_Click(object sender, EventArgs e)
    {
        try
        {
           
            string idPaciente;
            GridViewRow fila = (GridViewRow)((Control)sender).Parent.Parent;
            idPaciente = ((Label)fila.FindControl("lblIdPaciente")).Text;
            if (!string.IsNullOrEmpty(idPaciente))
            {
                Session["idPaciente"] = idPaciente;
                Response.Redirect("signosVitales.aspx");
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkNuevaVisita_Click", ex, this, true);
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ClsInicioBusqueda inicioBusqueda = new ClsInicioBusqueda();
        try
        {
            //if (string.IsNullOrEmpty(txtBusqueda.Text))
            //{
            //    clsHelper.mensaje("Escriba un criterio de búsqueda", this, clsHelper.tipoMensaje.alerta, false);
            //    txtBusqueda.Focus();
            //    return;
            //}
            grdPacientes.DataSource = inicioBusqueda.buscar(txtBusqueda.Text.Trim());
            grdPacientes.DataBind();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("BtnBuscar_Click", ex, this, true);
        }
    }

    void asignarPermisos()
    {
        try
        {
            ClsAccesoStruc acc = new ClsAccesoStruc();
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            acc = ClsValidaAcceso.validarPantalla((int)Session["idUsuario"], Request.Url.Segments[Request.Url.Segments.Length - 1]);
            ViewState["leer"] = acc.leer;
            ViewState["crear"] = acc.crear;
            ViewState["actualizar"] = acc.actualizar;
            ViewState["eliminar"] = acc.eliminar;
            if (!(Boolean)ViewState["leer"]) {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void lnkVerPaciente_Click(object sender, EventArgs e)
    {
        try
        {
            string idPaciente;
            GridViewRow fila = (GridViewRow)((Control)sender).Parent.Parent;
            idPaciente = ((Label)fila.FindControl("lblIdPaciente")).Text;
            if (!string.IsNullOrEmpty(idPaciente))
            {
                Session["idPaciente"] = idPaciente;
                Response.Redirect("pacBasales.aspx");
            }
        }
        catch (Exception ex)
        {
            
             clsHelper.mostrarError("lnkVerPaciente_Click", ex, this, true);
        }
    }
    protected void lnkNuevoPaciente_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Boolean)ViewState["crear"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
                return;
            }
                Session["idPaciente"] = null;
                Response.Redirect("pacBasales.aspx");
        }
        catch (Exception ex)
        {
            
             clsHelper.mostrarError("lnkNuevoPaciente_Click", ex, this, true);
        }
    }
}