using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_diagnosticoVIH : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         if (!IsPostBack)
         {
            ViewState["idDiagnosticoVIH"] = null;
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
         if (!string.IsNullOrEmpty(Request.Params["__EVENTTARGET"]))
         {
            validFields(Request.Params["__EVENTTARGET"]);
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
         if (!(Boolean)ViewState["crear"])
         {
            Response.Redirect("../Default.aspx");
         }

         if (string.IsNullOrEmpty(txtFechaDiagnóstico.Text))
         {
            clsHelper.mensaje("Ingrese una fecha", this, clsHelper.tipoMensaje.alerta);
            return;
         }

         if (!clsHelper.isDate(txtFechaDiagnóstico.Text))
         {
            clsHelper.mensaje("Ingrese una fecha válida", this, clsHelper.tipoMensaje.alerta);
            return;
         }
         //

         ClsDiagnosticoVIH d = new ClsDiagnosticoVIH();
         if (ViewState["idDiagnosticoVIH"] != null)
         {
            d.idDiagnosticoVIH = int.Parse(ViewState["idDiagnosticoVIH"].ToString());
         }
         else
         {
            d.idDiagnosticoVIH = null;
         }
         if (Session["idPaciente"] != null)
         {
            d.idPaciente = int.Parse(Session["idPaciente"].ToString());
         }
         else
         {
            clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
            return;
         }

         //recolecta datos

         d.fechaDiagnostico = clsHelper.valDate(txtFechaDiagnóstico.Text);
         d.edadAnos = clsHelper.valI(txtEdadAnos.Text);
         d.edadMeses = clsHelper.valI(txtEdadMes.Text);
         d.edadDias = clsHelper.valI(txtEdadDias.Text);
         d.idrangoEdad = clsHelper.getValueI(cboRangoEdad);
         d.idGrupoTransmision = clsHelper.getValueI(cboGrupoTransmision);
         d.idMotivoPrueba = clsHelper.getValueI(cboMotivoDeLaPrueba);
         d.anticuerpos = clsHelper.valB(chkAnticuerpos.Checked.ToString());
         d.valorAnticuerpos = txtAnticuerpos.Text;
         d.DNAProviral = clsHelper.valB(chkDNAProviral.Checked.ToString());
         d.valorDNAProviral = txtDnaProviral.Text;
         d.vihCargaViralRNA = clsHelper.valB(chkVIHCargaViralRNA.Checked.ToString());
         d.valorVihCargaViralRNA = txtVIHCargaViralRNA.Text;
         d.CV = txtCV.Text;
         d.VIHCVLOG10 = txtVIHCargarViralLog10.Text;
         d.idTipoPrueba = clsHelper.getValueI(cboTipoPrueba);
         d.usuario = Session["usuario"].ToString();
         d.grabar();
         limpiar();
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
   protected void lnkModificar_Click(object sender, EventArgs e)
   {
      try
      {
         if (!(Boolean)ViewState["actualizar"])
         {
            Response.Redirect("../Default.aspx");
         }
         GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idDiagnosticoVIH;
         idDiagnosticoVIH = int.Parse(((Label)gr.FindControl("lblIdDiagnosticoVIH")).Text);
         ClsDiagnosticoVIH d = new ClsDiagnosticoVIH();
         d = d.seleccionarPorId(idDiagnosticoVIH);
         if (d.idDiagnosticoVIH != null)
         {
            ViewState["idDiagnosticoVIH"] = d.idDiagnosticoVIH;
            txtFechaDiagnóstico.Text = clsHelper.dateFormat(d.fechaDiagnostico.ToString());
            txtEdadAnos.Text = d.edadAnos.ToString();
            txtEdadMes.Text = d.edadMeses.ToString();
            txtEdadDias.Text = d.edadDias.ToString();
            cargarMotivoPruebaRangoEdad();
            cboRangoEdad.SelectedValue = d.idrangoEdad.ToString();
            cboGrupoTransmision.SelectedValue = d.idGrupoTransmision.ToString();
            cboMotivoDeLaPrueba.SelectedValue = d.idMotivoPrueba.ToString();
            chkAnticuerpos.Checked = (bool)d.anticuerpos;
            chkDNAProviral.Checked = (bool)d.DNAProviral;
            chkVIHCargaViralRNA.Checked = (bool)d.vihCargaViralRNA;
            txtAnticuerpos.Text = d.valorAnticuerpos;
            txtDnaProviral.Text = d.valorDNAProviral;
            txtVIHCargaViralRNA.Text = d.valorVihCargaViralRNA;
            txtCV.Text = d.CV;
            txtVIHCargarViralLog10.Text = d.VIHCVLOG10;
            cboTipoPrueba.SelectedValue = d.idTipoPrueba.ToString();

            txtAnticuerpos.Enabled = chkAnticuerpos.Checked;
            txtDnaProviral.Enabled = chkDNAProviral.Checked;
            txtVIHCargaViralRNA.Enabled = chkVIHCargaViralRNA.Checked;
            txtVIHCargarViralLog10.Enabled = chkVIHCargaViralRNA.Checked;
            txtCV.Enabled = chkVIHCargaViralRNA.Checked;

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
            Response.Redirect("../Default.aspx");
         }
         GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idDiagnosticoVIH;
         idDiagnosticoVIH = int.Parse(((Label)gr.FindControl("lblIdDiagnosticoVIH")).Text);
         ClsBiologiaMolecular d = new ClsBiologiaMolecular();
         d.eliminar(idDiagnosticoVIH);
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

   void cargarDatosExistentes()
   {
      try
      {
         ClsDiagnosticoVIH d = new ClsDiagnosticoVIH();
         DataTable dt = new DataTable();
         dt = d.seleccionarTodos(int.Parse(Session["idPaciente"].ToString()));
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
      ViewState["idDiagnosticoVIH"] = null;
      txtFechaDiagnóstico.Text = string.Empty;
      txtEdadAnos.Text = string.Empty;
      txtEdadMes.Text = string.Empty;
      txtEdadDias.Text = string.Empty;
      cboRangoEdad.SelectedValue = string.Empty;
      cboGrupoTransmision.SelectedValue = string.Empty;
      cboMotivoDeLaPrueba.SelectedValue = string.Empty;
      chkAnticuerpos.Checked = false;
      txtAnticuerpos.Text = string.Empty;
      txtAnticuerpos.Enabled = false;
      chkDNAProviral.Checked = false;
      txtDnaProviral.Text = string.Empty;
      txtDnaProviral.Enabled = false;
      chkVIHCargaViralRNA.Checked = false;
      txtVIHCargaViralRNA.Text = string.Empty;
      txtCV.Text = string.Empty;
      txtCV.Enabled = false;
      txtVIHCargarViralLog10.Text = string.Empty;
      txtVIHCargarViralLog10.Enabled = false;
      cboTipoPrueba.SelectedValue = string.Empty;
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
         cargarMotivoPruebaRangoEdad();
         confCombo(cboMotivoDeLaPrueba, "MmotivoPrueba");
         confCombo(cboGrupoTransmision, "MgrupoTransmision");
         confCombo(cboTipoPrueba, "MtipoPruebaVIH");


      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   void cargarMotivoPruebaRangoEdad()
   {
      try
      {
         int edad;
         if (clsHelper.IsNumeric(txtEdadAnos.Text))
         {
            edad = int.Parse(txtEdadAnos.Text);
         }
         else { edad = 0; }
        
         if (edad >= 0 && edad < 3)
         {
            confCombo(cboRangoEdad, "MmotivoPrueba", " grupo = 1 ", true, "id", "nombre");
         }
         else {
            confCombo(cboRangoEdad, "MmotivoPrueba", " grupo = 2 ", true, "id", "nombre");
         }

         /*Rango de edades*/
         if (edad >= -100 && edad < 1)
         {
            cboRangoEdad.SelectedValue = "1";
         }
         else if (edad >= 1 && edad <= 2)
         {
            cboRangoEdad.SelectedValue = "2";
         }
         else if (edad >= 3 && edad <= 4)
         {
            cboRangoEdad.SelectedValue = "3";
         }
         else if (edad >= 5 && edad <= 9)
         {
            cboRangoEdad.SelectedValue = "4";
         }
         else if (edad >= 10 && edad <= 14)
         {
            cboRangoEdad.SelectedValue = "5";
         }
         else if (edad >= 15 && edad <= 18)
         {
            cboRangoEdad.SelectedValue = "6";
         }
         else if (edad >= 19 && edad <= 24)
         {
            cboRangoEdad.SelectedValue = "7";
         }
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   void validFields(string idControl)
   {
      try
      {
         switch (idControl)
         {
            case "fecha":
               calcularEdad();
               cargarMotivoPruebaRangoEdad();
               break;
         }
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   void calcularEdad()
   {
      try
      {
         if (clsHelper.isDate(txtFechaDiagnóstico.Text))
         {
            if (Session["idPaciente"] != null)
            {
               DataTable d = new DataTable();
               ClsSignosVitales sv = new ClsSignosVitales();

               d = sv.calcularEdad(int.Parse(Session["idPaciente"].ToString()), DateTime.Parse(txtFechaDiagnóstico.Text));
               if (d.Rows.Count > 0)
               {
                  txtEdadAnos.Text = d.Rows[0]["anios"].ToString();
                  txtEdadMes.Text = d.Rows[0]["meses"].ToString();
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

   protected void chkAnticuerpos_CheckedChanged(object sender, EventArgs e)
   {
      txtAnticuerpos.Enabled = chkAnticuerpos.Checked;
      txtAnticuerpos.Text = string.Empty ;

   }
   protected void chkDNAProviral_CheckedChanged(object sender, EventArgs e)
   {
      txtDnaProviral.Enabled= chkDNAProviral.Checked ;
      txtDnaProviral.Text = string.Empty;
   }
   protected void chkVIHCargaViralRNA_CheckedChanged(object sender, EventArgs e)
   {
      txtVIHCargaViralRNA.Enabled = chkVIHCargaViralRNA.Checked;
      txtVIHCargarViralLog10.Enabled = chkVIHCargaViralRNA.Checked;
      txtCV.Enabled = chkVIHCargaViralRNA.Checked;

      txtVIHCargaViralRNA.Text = string.Empty;
      txtVIHCargarViralLog10.Text = string.Empty;
      txtCV.Text = string.Empty;

   }
}