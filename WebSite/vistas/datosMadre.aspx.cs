using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_datosMadre : System.Web.UI.Page
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
                    cargarDatosMadre();
                }
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, true);
        }

    }

    void cargarCombos()
    {
        try
        {
            confCombo(cboMadrePositiva, "MSiNo");
            confCombo(cboMomentoDx, "MMomentoDx");
            confCombo(cboSeguimiento, "MSiNo");
            confCombo(cboLugarSeguimiento, "M_Hospital");
            confCombo(cboControlPrenatal, "MSiNo");
            confCombo(cboLugarControlPrenatal, "M_Hospital");
            confCombo(cboTARGAEmbarazo, "MSiNo");
            confCombo(cboEsquemaTarga, "MEsquemaTargaMadre");
            confCombo(cboMomentoInicioTarga, "MMomentoInicioTarga");
            confCombo(cboInfecionOportunista, "MInfeccionesOportunistas");
            confCombo(cboClasificacionClinicaInmunologica, "MEstadio", " nombre NOT LIKE '%N%'");


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


    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (!(Boolean)ViewState["crear"])
        {
            clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
            return;
        }

        ClsPacMadre m = new ClsPacMadre();
        try
        {
            if (string.IsNullOrEmpty(txtFechaTomaDatos.Text))
            {
                clsHelper.mensaje("Ingrese fecha de toma de datos", this, clsHelper.tipoMensaje.alerta);
                txtFechaTomaDatos.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboMadrePositiva.SelectedValue.ToString()))
            {
                clsHelper.mensaje("Seleccione el diagnóstico de la madre", this, clsHelper.tipoMensaje.alerta);
                cboMadrePositiva.Focus();
                return;
            }
            if (!clsHelper.isDate(txtFechaTomaDatos.Text))
            {
                clsHelper.mensaje("Ingrese fecha válida", this, clsHelper.tipoMensaje.alerta);
                txtFechaTomaDatos.Focus();
                return;
            }

            if (Session["idPaciente"] == null)
            {
                clsHelper.mensaje("En este momento no se puede continuar, por favor reinicie el browser", this, clsHelper.tipoMensaje.alerta);
                return;
            }
            m.idPaciente =int.Parse(Session["idPaciente"].ToString());
            m.fechaTomaDatos = DateTime.Parse(txtFechaTomaDatos.Text);
            m.MadrePositiva = short.Parse(cboMadrePositiva.SelectedValue);
            m.NHC = txtNHC.Text;
            m.FechaDX = clsHelper.valDate(txtFechaDx.Text);
            m.MomentoDX = clsHelper.getValueI(cboMomentoDx);
            m.Seguimiento = clsHelper.getValueS(cboSeguimiento);
            m.LugarSeguimiento = clsHelper.getValueI(cboLugarSeguimiento);
            m.OtroLugarSeguimiento = txtOtroLugarSeguimiento.Text;
            m.ControlPrenatal = clsHelper.getValueS(cboControlPrenatal);
            m.lugarControlPrenatal = clsHelper.getValueI(cboLugarControlPrenatal);
            m.ComplicacionesEmbarazo = txtComplicacionEmbarazo.Text;
            m.infeccionOportunista = clsHelper.getValueI(cboInfecionOportunista);
            m.clasificacionClinicaInmunologica = clsHelper.getValueI(cboClasificacionClinicaInmunologica);
            m.TARGAEmbarazo = clsHelper.getValueS(cboTARGAEmbarazo);
            m.EsquemaTARGA = clsHelper.getValueI(cboEsquemaTarga);
            m.MomentoInicioTARGA = clsHelper.getValueI(cboMomentoInicioTarga);
            m.adherenciaTARGA = clsHelper.valI(txtAdherenciaTARGA.Text);
            m.UltimaCV = clsHelper.valD(txtUltimaCv.Text);
            m.UltimoCD4 = clsHelper.valD(txtUltimoCd4.Text);
            m.EdadGestacionalUltimaCVCD4 = clsHelper.valI(txtEdadGestacionalCVCD4.Text);
            m.usuario = Session["usuario"].ToString();
            m.grabar();
            clsHelper.mensaje("Proceso realizado exitosamente", this, clsHelper.tipoMensaje.informacion);
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnGrabar_Click", ex, this, true);
        }
    }

    private void cargarDatosMadre()
    {
        try
        {
            ClsPacMadre m = new ClsPacMadre();
            m = m.seleccionar(int.Parse(Session["idPaciente"].ToString()));
            txtFechaTomaDatos.Text = clsHelper.dateFormat(m.fechaTomaDatos.ToString());
            cboMadrePositiva.SelectedValue = m.MadrePositiva.ToString();
            txtNHC.Text = m.NHC;
            txtFechaDx.Text = clsHelper.dateFormat(m.FechaDX.ToString());
            cboMomentoDx.SelectedValue = m.MomentoDX.ToString();
            cboSeguimiento.SelectedValue = m.Seguimiento.ToString();
            cboLugarSeguimiento.SelectedValue = m.LugarSeguimiento.ToString();
            txtOtroLugarSeguimiento.Text = m.OtroLugarSeguimiento;
            cboControlPrenatal.SelectedValue = m.ControlPrenatal.ToString();
            cboLugarControlPrenatal.SelectedValue = m.lugarControlPrenatal.ToString();
            txtComplicacionEmbarazo.Text = m.ComplicacionesEmbarazo;
            cboInfecionOportunista.SelectedValue = m.infeccionOportunista.ToString();
            cboClasificacionClinicaInmunologica.SelectedValue = m.clasificacionClinicaInmunologica.ToString();
            cboTARGAEmbarazo.SelectedValue = m.TARGAEmbarazo.ToString();
            cboEsquemaTarga.SelectedValue = m.EsquemaTARGA.ToString();
            cboMomentoInicioTarga.SelectedValue = m.MomentoInicioTARGA.ToString();
            txtAdherenciaTARGA.Text = m.adherenciaTARGA.ToString();
            txtUltimaCv.Text = m.UltimaCV.ToString();
            txtUltimoCd4.Text = m.UltimoCD4.ToString();
            txtEdadGestacionalCVCD4.Text = m.EdadGestacionalUltimaCVCD4.ToString();
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
}