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

    }
    protected void lnkNuevaVisita_Click(object sender, EventArgs e)
    {
        try
        {
            string idPaciente;
            GridViewRow fila = (GridViewRow)((Control)sender).Parent.Parent;
            idPaciente = ((Label)fila.FindControl("lblIdPaciente")).Text;
            if (!string.IsNullOrEmpty(idPaciente)) {
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
            if (string.IsNullOrEmpty(txtBusqueda.Text)) {
                clsHelper.mensaje("Escriba un criterio de búsqueda",this,clsHelper.tipoMensaje.alerta,false);
                txtBusqueda.Focus();
                return;
            }
            grdPacientes.DataSource = inicioBusqueda.buscar(txtBusqueda.Text.Trim());
            grdPacientes.DataBind();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("BtnBuscar_Click", ex, this, true);
        }
    }
}