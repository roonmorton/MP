using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_signosVitales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                asignarPermisos();
                cargarCombos();
                if (Session["idPaciente"] != null)
                {
                    cargarExistentes();
                }

            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Load", ex, this, true);
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

    void cargarCombos()
    {
        try
        {
            confCombo(cboTipoVisita, "MTipoVisita");
            confCombo(cboEstadío, "MEstadio");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            limpiar();
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
            ClsSignosVitales sv = new ClsSignosVitales();
            if (!(Boolean)ViewState["crear"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
                return;
            }
            if (!clsHelper.isDate(txtFechaVisita.Text))
            {
                clsHelper.mensaje("Debe ingresar una fecha correcta", this, clsHelper.tipoMensaje.alerta);
                txtFechaVisita.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cboTipoVisita.SelectedValue.ToString())) {
                clsHelper.mensaje("Seleccione un tipo de visita", this, clsHelper.tipoMensaje.alerta);
                cboTipoVisita.Focus();
                return;
            }

            if (clsHelper.isDate(txtFechaProximaVisita.Text))
            {
                if (clsHelper.valDate(txtFechaVisita.Text) > clsHelper.valDate(txtFechaProximaVisita.Text))
                {
                    clsHelper.mensaje("La  fecha de próxima visita debe ser mayor que la visita actual", this, clsHelper.tipoMensaje.alerta);
                    txtFechaVisita.Focus();
                    return;
                }
            }

            if(Session["idPaciente"] == null){
                clsHelper.mensaje("Ocurrió un inconveniente, por favor reinicie la aplicación",this,clsHelper.tipoMensaje.err,true);
            }

            if (ViewState["idSignosVitales"] != null)
            {
                sv.IdSignosVitales = int.Parse(ViewState["idSignosVitales"].ToString());
            }
            else
            {
                sv.IdSignosVitales = null;
            }
                   

            sv.IdPaciente = int.Parse(Session["idPaciente"].ToString());
            sv.FechaVisita =  clsHelper.valDate( txtFechaVisita.Text);
            sv.TipoVisita = clsHelper.valI(cboTipoVisita.SelectedValue);
            sv.FechaProximaVisita = clsHelper.valDate(txtFechaProximaVisita.Text);
            sv.PresionArterialSist = clsHelper.valI(txtPmHALeft.Text);
            sv.PresionArterialDiast = clsHelper.valI(txtPmHARight.Text);
            sv.Temperatura = clsHelper.valD(txtTc.Text);
            sv.FrecCardiaca = clsHelper.valI(txtFC.Text);
            sv.FrecRespiratoria = clsHelper.valI(txtFR.Text);
            sv.SaturacionOxigeno = clsHelper.valI(txtSat.Text);
            sv.Talla = clsHelper.valI(txtTalla.Text);
            sv.Peso = clsHelper.valD(txtPeso.Text);
            sv.IMC = clsHelper.valD(txtImc.Text);
            sv.EdadAnos = clsHelper.valI(txtEdadAnos.Text);
            sv.EdadMeses = clsHelper.valI(txtEdadMeses.Text);
            sv.EdadDias = clsHelper.valI(txtEdadDias.Text);
            sv.Estadio = clsHelper.valI(cboEstadío.SelectedValue);
            sv.observaciones = txtObservaciones.Text;
            sv.grabar();
            clsHelper.mensaje("Registro grabado correctamente", this, clsHelper.tipoMensaje.informacion, true);
            limpiar();
            cargarExistentes();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkGuardar_Click", ex, this, true);
        }
    }

    void limpiar()
    {
        try
        {
            txtFechaVisita.Text = string.Empty;
            cboTipoVisita.SelectedValue = string.Empty;
            txtFechaProximaVisita.Text = string.Empty;
            txtPmHALeft.Text = string.Empty;
            txtPmHARight.Text = string.Empty;
            txtTc.Text = string.Empty;
            txtFC.Text = string.Empty;
            txtFR.Text = string.Empty;
            txtSat.Text = string.Empty;
            txtTalla.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtImc.Text = string.Empty;
            txtEdadAnos.Text = string.Empty;
            txtEdadMeses.Text = string.Empty;
            txtEdadDias.Text = string.Empty;
            cboEstadío.SelectedValue = string.Empty;
            txtObservaciones.Text = string.Empty;
            ViewState["idSignosVitales"] = null;
            txtFechaVisita.Focus();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void lnkCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["idPaciente"] = null;
            Response.Redirect("inicio.aspx");
        }
        catch (Exception ex)
        {
            clsHelper.mostrarError("lnkCerrar_Click", ex, this, true);

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

    void cargarExistentes()
    {
        try
        {
            DataTable dt = new DataTable();
            ClsSignosVitales sv = new ClsSignosVitales();
            dt = sv.seleccionarTodos((int.Parse(Session["idPaciente"].ToString())));
            grdSignosVitales.DataSource = dt;
            grdSignosVitales.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}