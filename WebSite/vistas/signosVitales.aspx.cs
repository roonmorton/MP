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

            if (!string.IsNullOrEmpty(Request.Params["__EVENTTARGET"]))
            {
                validFields(Request.Params["__EVENTTARGET"]);
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

            if (string.IsNullOrEmpty(cboTipoVisita.SelectedValue.ToString()))
            {
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

            if (Session["idPaciente"] == null)
            {
                clsHelper.mensaje("Ocurrió un inconveniente, por favor reinicie la aplicación", this, clsHelper.tipoMensaje.err, true);
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
            sv.FechaVisita = clsHelper.valDate(txtFechaVisita.Text);
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
    protected void lnkModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Boolean)ViewState["actualizar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }
          
            int idSignosVitales;
            GridViewRow r = (GridViewRow)((Control)(sender)).Parent.Parent;
            idSignosVitales = int.Parse(((Label)r.FindControl("lblIdSignosVitales")).Text);
            ViewState["idSignosVitales"] = idSignosVitales;
            ClsSignosVitales sv = new ClsSignosVitales();
            sv = sv.seleccionarPorId(idSignosVitales);
            txtFechaVisita.Text = clsHelper.dateFormat(sv.FechaVisita.ToString());
            cboTipoVisita.SelectedValue = sv.TipoVisita.ToString();
            txtFechaProximaVisita.Text = clsHelper.dateFormat(sv.FechaProximaVisita.ToString());
            txtPmHALeft.Text = sv.PresionArterialSist.ToString();
            txtPmHARight.Text = sv.PresionArterialDiast.ToString();
            txtTc.Text = sv.Temperatura.ToString();
            txtFC.Text = sv.FrecCardiaca.ToString();
            txtFR.Text = sv.FrecRespiratoria.ToString();
            txtSat.Text = sv.SaturacionOxigeno.ToString();
            txtTalla.Text = sv.Talla.ToString();
            txtPeso.Text = sv.Peso.ToString();
            txtImc.Text = sv.IMC.ToString();
            txtEdadAnos.Text = sv.EdadAnos.ToString();
            txtEdadMeses.Text = sv.EdadMeses.ToString();
            txtEdadDias.Text = sv.EdadDias.ToString();
            cboEstadío.SelectedValue = sv.Estadio.ToString();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkModificar_Click", ex, this, true);
        }
    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Boolean)ViewState["eliminar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            int idSignosVitales;
            GridViewRow r = (GridViewRow)((Control)(sender)).Parent.Parent;
            idSignosVitales = int.Parse(((Label)r.FindControl("lblIdSignosVitales")).Text);
            ClsSignosVitales sv = new ClsSignosVitales();
            sv.eliminar(idSignosVitales);
            limpiar();
            cargarExistentes();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkModificar_Click", ex, this, true);
        }
    }

    void validFields(string idControl)
    {
        try
        {
            switch (idControl)
            {
                case "txtFechaVisita":
                    calcularEdad();
                    break;
                case "imc":
                    calcularIMC();
                    break;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void calcularEdad() {
        try
        {
            if (clsHelper.isDate(txtFechaVisita.Text)) {
                if (Session["idPaciente"] != null) {
                    DataTable d = new DataTable();
                    ClsSignosVitales sv = new ClsSignosVitales();
                    
                    d = sv.calcularEdad(int.Parse(Session["idPaciente"].ToString()), DateTime.Parse(txtFechaVisita.Text));
                    if (d.Rows.Count > 0) {
                        txtEdadAnos.Text = d.Rows[0]["anios"].ToString();
                        txtEdadMeses.Text = d.Rows[0]["meses"].ToString();
                        txtEdadDias.Text = d.Rows[0]["dias"].ToString();
                    
}
                }
            }
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    void calcularIMC()
    {
        double? imc;
        if (!string.IsNullOrEmpty(txtPeso.Text) && !string.IsNullOrEmpty(txtTalla.Text))
        {
            imc = (clsHelper.valD(txtPeso.Text) / 2.2) / Math.Pow(double.Parse(txtTalla.Text), 2);
            txtImc .Text = String.Format("{0:0.00}", imc);
        }
    }

   
}