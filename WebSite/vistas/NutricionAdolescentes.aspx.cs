using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_NutricionAdolescentes : System.Web.UI.Page
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
                    Response.Redirect("inicio.aspx");
                }
                else
                {
                    cargarDatosExistentes();
                }
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, true);
        }
    }
    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            limpiar();
            cargarDatosExistentes();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkNuevo_Click", ex, this, true);
        }
    }
    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkGuardar_Click", ex, this, true);
        }
    }
    protected void lnkCerrar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkCerrar_Click", ex, this, true);
        }
    }
    protected void lnkModificar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkModificar_Click", ex, this, true);
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

    void confCombo(DropDownList combo, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
        ClsCombos cbo = new ClsCombos();
        try
        {
            combo.DataSource = cbo.fill(tabla, condicion, seleccione);
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
            confCombo(cboDiagnosticoNutricionalPT, "MDiagnosticoNutricional1");
            confCombo(cboDiagnosticoNutricionalTE, "MDiagnosticoNutricional2");
            confCombo(cboDiagnosticoNutricionalPE, "MDiagnosticoNutricional3");
            confCombo(cboDiagnosticoNutricionalIMCZ, "MDiagnosticoNutricional3");
            confCombo(cboDieta, "MdietaNutricion");

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    void cargarDatosExistentes()
    {
        ClsNutricionMayores cnm = new ClsNutricionMayores();
        DataTable dt = new DataTable();
        dt = cnm.seleccionar(int.Parse(Session["idPaciente"].ToString()));
        grdExistentes.DataSource = dt;
        grdExistentes.DataBind();
    }

    void limpiar() {
        try
        {
            ViewState["idNutricionMayores"] = null;
            txtFechaVisita.Text = string.Empty;
            txtPesoLibras.Text = string.Empty;
            txtPesoOnzas.Text = string.Empty;
            txtTalla.Text = string.Empty;
            txtIMC.Text = string.Empty;
            txtPT.Text = string.Empty;
            cboDiagnosticoNutricionalPT.SelectedValue  = string.Empty;
            txtPe.Text   = string.Empty;
            cboDiagnosticoNutricionalPE.SelectedValue = string.Empty;
            txtTE.Text  = string.Empty;
            cboDiagnosticoNutricionalTE.SelectedValue = string.Empty;
            txtIMCZ.Text = string.Empty;
            cboDiagnosticoNutricionalIMCZ.SelectedValue = string.Empty;
            txtCMB.Text = string.Empty;
            txtCcintura.Text = string.Empty;
            txtCcadera.Text = string.Empty;
            txtCP.Text = string.Empty;
            rbGananciaPeso.SelectedValue = null;
            rbPerdidaPeso.SelectedValue = null;
            rbPerdidaApetito.SelectedValue = null;
            rbSindromeDesgaste.SelectedValue = null;
            rbDiarrea.SelectedValue = null;
            rbNausea.SelectedValue = null;
            rbVomito.SelectedValue = null;
            rbProblemasMetabolismoGrasas.SelectedValue = null;
            rbTrigliceridosElevados.SelectedValue = null;
            rbHdlElevado.SelectedValue = null;
            rbColesterolElevado.SelectedValue = null;
            rbLDLElevado.SelectedValue = null;
            rbResistenciaInsulina.SelectedValue = null;
            rbPResentaLipodistrofia.SelectedValue = null;
            rbLipoatrofia.SelectedValue = null;
            rbLipohipertrofia.SelectedValue = null;
            rbMixta.SelectedValue = null;

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }


}