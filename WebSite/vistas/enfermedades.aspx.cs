using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_enfermedades : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         asignarPermisos();
         if (!IsPostBack)
         {
            cargarCombos();
            if (Session["idPaciente"] == null)
            {
               Response.Redirect("inicio.aspx");
            }
            else
            {
               //cargar existentes
               cargarExistentes();
            }
         }
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("Load", ex, this, true);
      }
   }

   void cargarCombos()
   {
      try
      {
         confChk(rbTipoEnfermedad, "MtipoEnfermedad", "", false, "id", "nombre");
         confCombo(cboTratada, "[MSiNo]");
         confCombo(cboEstadoEnfermedad, "MestadoEnfermedad");
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
         combo.DataSource = cbo.fill(tabla, condicion, seleccione, dataField, textField);
         combo.DataValueField = dataField;
         combo.DataTextField = textField;
         combo.DataBind();

      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   void confChk(RadioButtonList rbl, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
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
   protected void chkTipoEnfermedad_SelectedIndexChanged(object sender, EventArgs e)
   {
      try
      {
         string tipoEnfermedad = rbTipoEnfermedad.SelectedValue.ToString();
         if (!string.IsNullOrEmpty(tipoEnfermedad))
         {
            confCombo(cboEnfermedad, "Menfermedad", " tipoEnfermedad = " + tipoEnfermedad, true, "idEnfermedad", "nombre");
            string script = " $('#ctl00_ContentPlaceHolder1_cboEnfermedad').select2();";
            ClientScript.RegisterStartupScript(this.GetType(), "cboEnf", script, true);
            cboEnfermedad.Style.Add("width", "100%!important");
         }
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("chk_CheckedChanged", ex, this, true);
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

          if(string.IsNullOrEmpty(txtFechaEnfermedad.Text)){
            clsHelper.mensaje("Ingrese fecha de enfermedad", this, clsHelper.tipoMensaje.alerta);
             txtFechaEnfermedad.Focus();
             return;
          }

          
          if(!clsHelper.isDate(txtFechaEnfermedad.Text)){
            clsHelper.mensaje("La fecha es inválida", this, clsHelper.tipoMensaje.alerta);
             txtFechaEnfermedad.Focus();
             return;
          }

          if(string.IsNullOrEmpty(rbTipoEnfermedad.SelectedValue.ToString())){
            clsHelper.mensaje("Seleccione tipo de enfermedad", this, clsHelper.tipoMensaje.alerta);
             rbTipoEnfermedad.Focus();
             return;
          }
          if(string.IsNullOrEmpty(cboEnfermedad.SelectedValue.ToString())){
            clsHelper.mensaje("Seleccione tipo una enfermedad", this, clsHelper.tipoMensaje.alerta);
             cboEnfermedad.Focus();
             return;
          }

          if(string.IsNullOrEmpty(cboTratada.SelectedValue.ToString())){
            clsHelper.mensaje("Seleccione si fue tratada", this, clsHelper.tipoMensaje.alerta);
             cboTratada.Focus();
             return;
          }

          if(string.IsNullOrEmpty(cboEstadoEnfermedad.SelectedValue.ToString())){
            clsHelper.mensaje("Seleccione estado de enfermedad", this, clsHelper.tipoMensaje.alerta);
             cboEstadoEnfermedad.Focus();
             return;
          }

          ClsEenfermedadPac enf = new ClsEenfermedadPac();
          if (Session["idPaciente"] ==null){
            clsHelper.mensaje("Por favor reinicie la aplicación",this,clsHelper.tipoMensaje.msgbx);
             return;
          }else{
            enf.IdPaciente = int.Parse(Session["idPaciente"].ToString());
          }

          if(ViewState["idEnfermedadPaciente"] !=null){
            enf.IdEnfermedadPaciente = int.Parse(ViewState["idEnfermedadPaciente"].ToString());
             }else{
           enf.IdEnfermedadPaciente = null;
          }
          enf.FechaEnfermedad = clsHelper.valDate(txtFechaEnfermedad.Text);
          enf.TipoEnfermedad = int.Parse(rbTipoEnfermedad.SelectedValue.ToString());
          enf.Enfermedad = cboEnfermedad.SelectedValue.ToString();
          enf.Tratada = clsHelper.valB(cboTratada.SelectedValue.ToString());
          enf.estado = clsHelper.getValueI(cboEstadoEnfermedad);
          enf.usuario = Session["usuario"].ToString();
          enf.grabar();
          clsHelper.mensaje("Proceso exitoso",this,clsHelper.tipoMensaje.informacion);
          limpiar();
          cargarExistentes();
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
         Response.Redirect("inicio.aspx");
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
         int idEnfermedadPaciente;
         idEnfermedadPaciente = int.Parse(((Label)gr.FindControl("lblIdEnfermedadPaciente")).Text);
         ClsEenfermedadPac enf = new ClsEenfermedadPac();
         enf = enf.seleccionarPorId(idEnfermedadPaciente);
         if (enf.IdEnfermedadPaciente != null)
         {
            txtFechaEnfermedad.Text = clsHelper.dateFormat(enf.FechaEnfermedad.ToString());
            rbTipoEnfermedad.SelectedValue = enf.TipoEnfermedad.ToString();
            chkTipoEnfermedad_SelectedIndexChanged(sender, e);
            cboEnfermedad.SelectedValue = enf.Enfermedad.ToString();
            cboTratada.SelectedValue = enf.Tratada ==true?"1":"0";
            cboEstadoEnfermedad.SelectedValue = enf.estado.ToString();
            ViewState["idEnfermedadPaciente"] = enf.IdEnfermedadPaciente;
         }
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("lnkModificar_Click", ex, this,true);
      }
   }

   void limpiar()
   {
      try
      {
         ViewState["idEnfermedadPaciente"] = null;
         txtFechaEnfermedad.Text = string.Empty;
         rbTipoEnfermedad.SelectedValue = null;
         cboEnfermedad.SelectedValue = string.Empty;
         cboTratada.SelectedValue = string.Empty;
         cboEstadoEnfermedad.SelectedValue = string.Empty;
         txtFechaEnfermedad.Focus();
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }
   protected void lnkEliminar_Click(object sender, EventArgs e)
   {
      if (!(Boolean)ViewState["eliminar"])
      {
         clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
         return;
      }
      GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idEnfermedadPaciente;
         idEnfermedadPaciente = int.Parse(((Label)gr.FindControl("lblIdEnfermedadPaciente")).Text);
         ClsEenfermedadPac enf = new ClsEenfermedadPac();
         enf.eliminar(idEnfermedadPaciente);
         cargarExistentes();
   }

   void cargarExistentes()
   {
      try
      {
         DataTable dt = new DataTable();
         ClsEenfermedadPac enf = new ClsEenfermedadPac();
         dt = enf.seleccionar(int.Parse(Session["idPaciente"].ToString()));
         grdEnfermedades.DataSource = dt;
         grdEnfermedades.DataBind();
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }
}