using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_trabajoSocialAdherencia : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         if (!IsPostBack)
         {
            ViewState["idTrabajoSocialAdherencia"] = null;
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
   protected void lnkGuardar_Click(object sender, EventArgs e)
   {
      try
      {
         if (!(Boolean)ViewState["crear"])
         {
            Response.Redirect("../Default.aspx");
         }

         if (!validarCampos()) { return; }
         if (string.IsNullOrEmpty(cboRSAT.SelectedValue)) {
            clsHelper.mensaje("Debe seleccionar el valor RSAT", this, clsHelper.tipoMensaje.msgbx, true);
            return;
         }

         ClsTrabajoSocialAdherencia  ts = new ClsTrabajoSocialAdherencia();
         if (ViewState["idTrabajoSocialAdherencia"] != null)
         {
            ts.idTrabajoSocialAdherencia  = int.Parse(ViewState["idTrabajoSocialAdherencia"].ToString());
         }
         else
         {
            ts.idTrabajoSocialAdherencia  = null;
         }
         if (Session["idPaciente"] != null)
         {
            ts.idPaciente = int.Parse(Session["idPaciente"].ToString());
         }
         else
         {
            clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
            return;
         }

         ts.apoyoFamiliarEstable = clsHelper.valI(txtApoyoFamiliarEstable.Text);
         ts.apoyoFamiliarInestable = clsHelper.valI(txtApoyoFamiliarInestable.Text);
         ts.ausenciaApoyoFamiliar = clsHelper.valI(txtAusenciaApoyoFamiliar.Text);

         ts.grupoFamiliarTrabajoEstable = clsHelper.valI(txtGrupoFamiliarTrabajoEstable.Text);
         ts.grupoFamiliarTrabajoInestable =  clsHelper.valI(txtGrupoFamiliarTrabajoInestable.Text);
         ts.grupoFamiliarDesempleado = clsHelper.valI(txtGrupoFamiliarDesempleado.Text);

         ts.comprendePlenamenteVIH = clsHelper.valI(txtComprendePlenamenteVIH.Text);
         ts.comprendeParcialmenteVIH = clsHelper.valI(txtComprendeParcialmenteVIH.Text);
         ts.noComprendeGeneralidadesVIH = clsHelper.valI(txtNoComprendeVIH.Text);

         ts.aceptadoDiagnostico = clsHelper.valI(txtAceptadoDiagnostico.Text);
         ts.noAceptadoDiagnostico  = clsHelper.valI(txtNoAceptadoDiagnostico.Text );
         ts.niegaDiagnostico = clsHelper.valI(txtNiegaDiagnostico.Text);

         ts.nino = clsHelper.valI(txtNino.Text);
         ts.adolescente = clsHelper.valI(txtAdolescente.Text);
         ts.ninoAdolescenteConflictivo = clsHelper.valI(txtNinoAdolescenteConflictivo.Text);

         ts.RSAT = clsHelper.getValueI(cboRSAT);
         ts.usuario = Session["usuario"].ToString();
         ts.grabar();
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion, true);
         cargarDatosExistentes();
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
         confCombo(cboRSAT, "MRSAT");

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
         ClsTrabajoSocialAdherencia ts = new ClsTrabajoSocialAdherencia();
         ts = ts.seleccionarPorId(int.Parse(Session["idPaciente"].ToString()));
         if (ts.idTrabajoSocialAdherencia != null)
         {
            ViewState["idTrabajoSocialAdherencia"] = ts.idTrabajoSocialAdherencia;
            txtApoyoFamiliarEstable.Text = ts.apoyoFamiliarEstable.ToString();
            txtApoyoFamiliarInestable.Text = ts.apoyoFamiliarInestable.ToString();
            txtAusenciaApoyoFamiliar.Text = ts.ausenciaApoyoFamiliar.ToString();
            txtGrupoFamiliarTrabajoEstable.Text = ts.grupoFamiliarTrabajoEstable.ToString();
            txtGrupoFamiliarTrabajoInestable.Text = ts.grupoFamiliarTrabajoInestable.ToString();
            txtGrupoFamiliarDesempleado.Text = ts.grupoFamiliarDesempleado.ToString();
            txtComprendePlenamenteVIH.Text = ts.comprendePlenamenteVIH.ToString();
            txtComprendeParcialmenteVIH.Text = ts.comprendeParcialmenteVIH.ToString();
            txtNoComprendeVIH.Text = ts.noComprendeGeneralidadesVIH.ToString();
            txtAceptadoDiagnostico.Text = ts.aceptadoDiagnostico.ToString();
            txtNoAceptadoDiagnostico.Text = ts.noAceptadoDiagnostico.ToString();
            txtNiegaDiagnostico.Text = ts.niegaDiagnostico.ToString();
            txtNino.Text = ts.nino.ToString();
            txtAdolescente.Text = ts.adolescente.ToString();
            txtNinoAdolescenteConflictivo.Text = ts.ninoAdolescenteConflictivo.ToString();
            cboRSAT.SelectedValue = ts.RSAT.ToString();
         }
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   protected void btnCalcularRSAT_Click(object sender, EventArgs e)
   {
      try
      {
         if (!validarCampos()) {
            return;
         }

         Double? res = 0;
         res += clsHelper.val(txtApoyoFamiliarEstable.Text);
         res += clsHelper.val(txtApoyoFamiliarInestable.Text);
         res += clsHelper.val(txtAusenciaApoyoFamiliar.Text);
         res += clsHelper.val(txtGrupoFamiliarTrabajoEstable.Text);
         res += clsHelper.val(txtGrupoFamiliarTrabajoInestable.Text);
         res += clsHelper.val(txtGrupoFamiliarDesempleado.Text);
         res += clsHelper.val(txtComprendePlenamenteVIH.Text);
         res += clsHelper.val(txtComprendeParcialmenteVIH.Text);
         res += clsHelper.val(txtNoComprendeVIH.Text);
         res += clsHelper.val(txtAceptadoDiagnostico.Text);
         res += clsHelper.val(txtNoAceptadoDiagnostico.Text);
         res += clsHelper.val(txtNiegaDiagnostico.Text);
         res += clsHelper.val(txtNino.Text);
         res += clsHelper.val(txtAdolescente.Text);
         res += clsHelper.val(txtNinoAdolescenteConflictivo.Text);
         res = res / 5;
         if (res < 1)
         {
            clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos", this, clsHelper.tipoMensaje.msgbx, true);
            return;
         }
         else if (res > 10)
         {
            clsHelper.mensaje("Al parecer ha ingresado datos incorrectos, por favor verifique", this, clsHelper.tipoMensaje.msgbx, true);
            return;
         }
         else if (res >= 8 && res <= 10)
         {
            cboRSAT.SelectedValue = "1";
         }
         else if (res >= 5 && res <= 7) {
            cboRSAT.SelectedValue = "2";
         }
         else if (res<=4)
         {
            cboRSAT.SelectedValue = "3";
         }

      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("btnCalcularRSAT_Click", ex, this, true);
      }
   }

   bool validarCampos()
   {
      bool r = true;
      if (string.IsNullOrEmpty(txtApoyoFamiliarEstable.Text.Trim()) && string.IsNullOrEmpty(txtApoyoFamiliarInestable.Text.Trim()) && string.IsNullOrEmpty(txtAusenciaApoyoFamiliar.Text.Trim()))
      {
         clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos de situación familiar", this, clsHelper.tipoMensaje.msgbx, true);
         return false;
      }

      if (string.IsNullOrEmpty(txtGrupoFamiliarTrabajoEstable.Text.Trim()) && string.IsNullOrEmpty(txtGrupoFamiliarTrabajoInestable.Text.Trim()) && string.IsNullOrEmpty(txtGrupoFamiliarDesempleado.Text.Trim()))
      {
         clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos de economía", this, clsHelper.tipoMensaje.msgbx, true);
         return false;
      }

      if (string.IsNullOrEmpty(txtComprendePlenamenteVIH.Text.Trim()) && string.IsNullOrEmpty(txtComprendeParcialmenteVIH.Text.Trim()) && string.IsNullOrEmpty(txtNoComprendeVIH.Text.Trim()))
      {
         clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos de conocimiento del VIH", this, clsHelper.tipoMensaje.msgbx, true);
         return false;
      }

      if (string.IsNullOrEmpty(txtAceptadoDiagnostico.Text.Trim()) && string.IsNullOrEmpty(txtNoAceptadoDiagnostico.Text.Trim()) && string.IsNullOrEmpty(txtNiegaDiagnostico.Text.Trim()))
      {
         clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos de aceptación del diagnóstico", this, clsHelper.tipoMensaje.msgbx, true);
         return false;
      }

      if (string.IsNullOrEmpty(txtNino.Text.Trim()) && string.IsNullOrEmpty(txtAdolescente.Text.Trim()) && string.IsNullOrEmpty(txtNinoAdolescenteConflictivo.Text.Trim()))
      {
         clsHelper.mensaje("Al parecer no ha ingresado datos en todos los campos de paciente", this, clsHelper.tipoMensaje.msgbx, true);
         return false;
      }
      return r;

   }
        
}