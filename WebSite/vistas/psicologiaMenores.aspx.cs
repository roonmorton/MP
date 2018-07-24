using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_psicologiaMenores : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack)
      {
         ViewState["idPsicologiaMenores"] = null;
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


         if (!(Boolean)ViewState["crear"])
         {
            Response.Redirect("../Default.aspx");
         }

         if (string.IsNullOrEmpty(txtFechaVisita.Text))
         {
            clsHelper.mensaje("Ingrese una fecha", this, clsHelper.tipoMensaje.alerta);
            return;
         }

         if (!clsHelper.isDate(txtFechaVisita.Text))
         {
            clsHelper.mensaje("Ingrese una fecha válida", this, clsHelper.tipoMensaje.alerta);
            return;
         }
         //

         ClsPsicologiaMenores pm = new ClsPsicologiaMenores();
         if (ViewState["idPsicologiaMenores"] != null)
         {
            pm.idPsicologiaMenores = int.Parse(ViewState["idPsicologiaMenores"].ToString());
         }
         else
         {
            pm.idPsicologiaMenores = null;
         }
         if (Session["idPaciente"] != null)
         {
            pm.idPaciente = int.Parse(Session["idPaciente"].ToString());
         }
         else
         {
            clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
            return;
         }
         pm.fechaVisita = clsHelper.valDate(txtFechaVisita.Text);
         pm.edadDesarrollo = txtEdadDesarrollo.Text;
         pm.areaMotoraGruesa = txtAreaMotoraGruesa.Text;
         pm.areaLenguaje = txtAreaDeLenguaje.Text;
         pm.areaMotoraFina = txtAreaMotorofina.Text;
         pm.areaSocialAfectiva = txtAreaSocialAfectiva.Text;
         pm.areaCognoscitiva = txtAreaCognoscitiva.Text;
         pm.areaHabitosSaludHigiene = txtAraHabitosSaludHigiene.Text;
         pm.aprendizaje = clsHelper.valB(rbAprendizaje.SelectedValue.ToString());
         pm.tipoProblema = clsHelper.getValueI(cboTipoProblema);
         pm.finalizacionProceso = clsHelper.valDate(txtFinalizacionProceso.Text);
         pm.observaciones = txtObservaciones.Text;
         pm.grabar();
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
         limpiar();
         cargarDatosExistentes();
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("lnkGrabar_Click", ex, this, true);
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
            Response.Redirect("../Default.aspx");
         }
         GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idPsicologiaMenores;
         idPsicologiaMenores = int.Parse(((Label)gr.FindControl("lblidPsicologiaMenores")).Text);
         ClsPsicologiaMenores nm = new ClsPsicologiaMenores();
         nm = nm.seleccionarPorId(idPsicologiaMenores);
         if (nm.idPsicologiaMenores != null)
         {
            ViewState["idPsicologiaMenores"] = nm.idPsicologiaMenores;

         }
         else
         {
            ViewState["idPsicologiaMenores"] = null;
         }

         txtFechaVisita.Text = clsHelper.dateFormat(nm.fechaVisita.ToString());
         txtEdadDesarrollo.Text = nm.edadDesarrollo.ToString();
         txtAreaMotoraGruesa.Text = nm.areaMotoraGruesa.ToString();
         txtAreaDeLenguaje.Text = nm.areaLenguaje.ToString();
         txtAreaMotorofina.Text = nm.areaMotoraFina.ToString();
         txtAreaSocialAfectiva.Text = nm.areaSocialAfectiva.ToString();
         txtAreaCognoscitiva.Text = nm.areaCognoscitiva.ToString();
         txtAraHabitosSaludHigiene.Text = nm.areaHabitosSaludHigiene.ToString();
         clsHelper.booleanRb(rbAprendizaje, nm.aprendizaje);
         cboTipoProblema.SelectedValue = nm.tipoProblema.ToString();
         txtFinalizacionProceso.Text = clsHelper.dateFormat(nm.finalizacionProceso.ToString());
         txtObservaciones.Text = nm.observaciones.ToString();

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
            Response.Redirect("../Default.aspx");
         }
         GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idPsicologiaMenores;
         idPsicologiaMenores = int.Parse(((Label)gr.FindControl("lblidPsicologiaMenores")).Text);
         ClsPsicologiaMenores pm = new ClsPsicologiaMenores();
         pm.eliminar(idPsicologiaMenores);
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
         limpiar();
         cargarDatosExistentes();
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
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
         confCombo(cboTipoProblema, "MTipoProblemaPsicologia");

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
         ClsPsicologiaMenores cnm = new ClsPsicologiaMenores();
         DataTable dt = new DataTable();
         dt = cnm.seleccionarTodos(int.Parse(Session["idPaciente"].ToString()));
         grdExistentes.DataSource = dt;
         grdExistentes.DataBind();
      }
      catch (Exception ex)
      {

         throw ex;
      }

   }

   void limpiar()
   {
      ViewState["idPsicologiaMenores"] = null;
      txtFechaVisita.Text = string.Empty;
      txtEdadDesarrollo.Text = string.Empty;
      txtAreaMotoraGruesa.Text = string.Empty;
      txtAreaDeLenguaje.Text = string.Empty;
      txtAreaMotorofina.Text = string.Empty;
      txtAreaSocialAfectiva.Text = string.Empty;
      txtAreaCognoscitiva.Text = string.Empty;
      txtAraHabitosSaludHigiene.Text = string.Empty;
      rbAprendizaje.SelectedValue = null;
      cboTipoProblema.SelectedValue = string.Empty;
      txtFinalizacionProceso.Text = string.Empty;
      txtObservaciones.Text = string.Empty;

   }

   protected void rbAprendizaje_SelectedIndexChanged(object sender, EventArgs e)
   {
      try
      {
         if (rbAprendizaje.SelectedValue.ToString() == "1")
         {
            cboTipoProblema.Enabled = true;
         }
         else {
            cboTipoProblema.Enabled = false;
         }
         cboTipoProblema.SelectedValue = "";
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("rbAprendizaje_SelectedIndexChanged",ex,this,true);
      }
   }
}