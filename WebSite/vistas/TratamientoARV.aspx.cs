using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_tratamientoARV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
{
        try
        {
            if (!IsPostBack)
            {
                ViewState["idNutricionMayores"] = null;
                asignarPermisos();
                cargarCbo();
                if (Session["idPaciente"] == null)
                {
                    Response.Redirect("/vistas/inicio.aspx");
                }
                else
                {
                    cargarCbo();
                }
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, true);
        }
    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void lnkEliminarActual_Click(object sender, EventArgs e)
    {

    }

    void confCombo(DropDownList combo, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
        ClsCombos cbo = new ClsCombos();
        try
        {
            combo.DataSource = cbo.fill(tabla, condicion, seleccione,dataField , textField );
            combo.DataValueField = dataField;
            combo.DataTextField = textField;
            combo.DataBind();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void cargarCbo()
    {
        try
        {
            confCombo(cboArv, "TTM_M_ARV","",true,"IdARV","NomARV");
            confCombo(cboPresentacion, "TTM_M_PRESENTACION_ARV");
            confCombo(cboViaAdministracion, "TTM_M_VIAADMINISTRACION");
            confCombo(cboFrecuencia, "TTM_M_FRECUENCIA", "", true, "IdFrecuencia", "NomFrecuencia");
            confCombo(cboProveedor, "TTM_M_PROVEEDOR");
            confCombo(cboGenerico, "MSiNo");
            confCombo(cboAdherencia, "TTM_M_ADHERENCIA");
        }
        catch (Exception ex)
        {

            throw ex;
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
            if (!(Boolean)ViewState["leer"])
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

        void CalculaAdherencia(string unidadesEnt, string unidadesDev)  {
        int adherencia=0 ;
        int IdAdherencia=0;
        int unidadesEntregadas = 0;
            int unidadesDevueltas = 0;
            try
            {
                if (!string.IsNullOrEmpty(unidadesEnt) && !string.IsNullOrEmpty(unidadesDev))
                {
                    unidadesEntregadas = int.Parse(unidadesEnt);
                    unidadesDevueltas = int.Parse(unidadesDev);

                    if (unidadesDevueltas > unidadesEntregadas)
                    {
                        clsHelper.mensaje("Las unidades devueltas no pueden ser mayor que las entregadas", this, clsHelper.tipoMensaje.alerta, true);
                        return;
                    }

                    if (unidadesEntregadas > 0)
                    {
                        adherencia = ((unidadesEntregadas - unidadesDevueltas) * 100) / unidadesEntregadas;

                        if (adherencia < 80)
                        {
                            IdAdherencia = 4;
                        }
                        else if (adherencia >= 80 && adherencia <= 89)
                        {
                            IdAdherencia = 3;
                        }
                        else if (adherencia >= 90 && adherencia <= 94)
                        {
                            IdAdherencia = 3;
                        }
                        else if (adherencia >= 95)
                        {
                            IdAdherencia = 1;
                        }
                        else
                        {
                            IdAdherencia = 99;
                        }

                        cboAdherencia.SelectedValue = IdAdherencia.ToString();
                    }

                }
                else
                {
                    clsHelper.mensaje("Para calcular la adherencia, debe indicar unidades entregadas y unidades devueltas", this, clsHelper.tipoMensaje.alerta, true);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        protected void btnCalcularAdherencia_Click(object sender, EventArgs e)
        {
            try
            {
                CalculaAdherencia(txtUnidadesEntregadas.Text, txtUnidadesDevueltas.Text);
            }
            catch (Exception ex)
            {

                clsHelper.mostrarError("btnCalcularAdherencia_Click", ex, this, true);
            }
        }
}