using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_imagenes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       try
       {
          if (!IsPostBack)
          {
             ViewState["idImagenPaciente"] = null;
             asignarPermisos();
             cargarCbo();
             if (Session["idPaciente"] == null) {
                Response.Redirect("inicio.aspx");
             }else 
             {
                cargarDatosExistentes();
             }
          }
       }
       catch (Exception ex) {
          clsHelper.mostrarError("load", ex, this, true);
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

    void confRb(RadioButtonList  rbl, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
       ClsCombos cbo = new ClsCombos();
       try
       {
          rbl.DataSource = cbo.fill(tabla, condicion, seleccione);
          rbl.DataValueField = dataField;
          rbl.DataTextField = textField;
          rbl.DataBind();

       }
       catch (Exception ex)
       {

          throw ex;
       }
    }

    private void cargarCbo()
    {
       try
       {
            confCombo(cboTipoImagen,"MtipoImagen");
            confRb(chkListResultado, "MNANR","",false,"id","nombre");
       }
       catch (Exception ex)
       {
          
          throw ex;
       }
    }

    void cargarDatosExistentes()
    {
       try
       {
          ClsImagenPaciente im = new ClsImagenPaciente();
          DataTable dt = new DataTable();
          dt = im.seleccionar(int.Parse(Session["idPaciente"].ToString()));
          grdExistentes.DataSource = dt;
          grdExistentes.DataBind();
       }
       catch (Exception ex)
       {

          throw ex;
       }
    }

    void limpiar() {
       try
       {
          ViewState["idImagenPaciente"] = null;
          cboTipoImagen.SelectedValue = string.Empty;
          txtCual.Text = string.Empty;
          txtCual.Enabled = false;
          chkListResultado.SelectedValue = null;
          txtAlteraciones.Text = string.Empty;
          txtFechaImagen.Text = string.Empty;
          txtFechaImagen.Focus();
       }
       catch (Exception ex) {
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
          if (!(Boolean)ViewState["crear"])
          {
             clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
             return;
          }

          if (string.IsNullOrEmpty(txtFechaImagen.Text))
          {
             clsHelper.mensaje("Debe ingresar la fecha de la imagen", this, clsHelper.tipoMensaje.alerta);
             txtFechaImagen.Focus();
             return;
          }
          if (!clsHelper.isDate(txtFechaImagen.Text)) {
             clsHelper.mensaje("La fecha es inválida", this, clsHelper.tipoMensaje.alerta);
             txtFechaImagen.Focus();
             return;
          }

          if (string.IsNullOrEmpty(cboTipoImagen.SelectedValue.ToString()))
          {
             clsHelper.mensaje("Seleccione el tipo de imagen", this, clsHelper.tipoMensaje.alerta);
             cboTipoImagen.Focus();
             return;
          }

          if (string.IsNullOrEmpty(chkListResultado.SelectedValue.ToString()))
          {
             clsHelper.mensaje("Seleccione el resultado de la imagen", this, clsHelper.tipoMensaje.alerta);
             cboTipoImagen.Focus();
             return;
          }

          ClsImagenPaciente im = new ClsImagenPaciente();
          if (ViewState["idImagenPaciente"] != null) {
             im.IdImagenPaciente = int.Parse(ViewState["idImagenPaciente"].ToString());
          }
          im.FechaImagen = clsHelper.valDate(txtFechaImagen.Text);
          im.TipoImagen = clsHelper.getValueI(cboTipoImagen);
          im.ValorImagen = int.Parse(chkListResultado.SelectedValue.ToString());
          im.CualOtra = txtCual.Text;
          im.IdPaciente = int.Parse(Session["idPaciente"].ToString());
          im.Alteracion = txtAlteraciones.Text;
          im.usuario = Session["usuario"].ToString();
          im.grabar();
          clsHelper.mensaje("Proceso ejecutado correctamente", this, clsHelper.tipoMensaje.informacion);
          limpiar();
          cargarDatosExistentes();
       }
       catch (Exception ex)
       {
          Session["idPaciente"] = null;
           clsHelper.mostrarError("lnkGuardar_Click", ex, this, true);
       }
    }
    protected void lnkCerrar_Click(object sender, EventArgs e)
    {
       try
       {
          Response.Redirect("inicio,aspx");
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
          if (!(Boolean)ViewState["actualizar"])
          {
             clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
             return;
          }
          GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
          int idImagenPaciente;
          idImagenPaciente = int.Parse(((Label)gr.FindControl("lblIdImagenPaciente")).Text);
          ClsImagenPaciente im = new ClsImagenPaciente();
          im = im.seleccionarPorId(idImagenPaciente);
          if (im.IdImagenPaciente != null)
          {
             ViewState["idImagenPaciente"] = im.IdImagenPaciente;
             txtFechaImagen.Text = clsHelper.valDate(im.FechaImagen.ToString()).ToString();
             cboTipoImagen.SelectedValue = im.TipoImagen.ToString();
             txtCual.Text = im.CualOtra.ToString();
             chkListResultado.SelectedValue = im.ValorImagen.ToString();
             txtAlteraciones.Text = im.Alteracion.ToString();
             if (cboTipoImagen.SelectedValue.ToString().Equals("7"))
             {
                txtCual.Enabled = true;
             }
             else {
                txtCual.Enabled = false;
             }
             
          }
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
             clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
             return;
          }
          GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
          int idImagenPaciente;
          idImagenPaciente = int.Parse(((Label)gr.FindControl("lblIdImagenPaciente")).Text);
          ClsImagenPaciente im = new ClsImagenPaciente();
          im.eliminar(idImagenPaciente);
          clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
          cargarDatosExistentes();
       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
       }
    }
    protected void cboTipoImagen_SelectedIndexChanged(object sender, EventArgs e)
    {
       if (cboTipoImagen.SelectedValue.ToString().Equals("7"))
       {
          txtCual.Text = string.Empty;
          txtCual.Enabled = true;
       }
       else {
          txtCual.Text = string.Empty;
          txtCual.Enabled = false;
       }
    }
}