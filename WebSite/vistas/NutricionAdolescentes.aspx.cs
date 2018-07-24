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
         //Validaciones
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

         ClsNutricionMayores nm = new ClsNutricionMayores();
         if (ViewState["idNutricionMayores"] != null)
         {
            nm.idNutricionMayores = int.Parse(ViewState["idNutricionMayores"].ToString());
         }
         else
         {
            nm.idNutricionMayores = null;
         }
         if (Session["idPaciente"] != null)
         {
            nm.idPaciente = int.Parse(Session["idPaciente"].ToString());
         }
         else
         {
            clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
            return;
         }

         //recolecta datos

         nm.fechaVisita = clsHelper.valDate(txtFechaVisita.Text);
         nm.pesoLibras = clsHelper.valD(txtPesoLibras.Text);
         nm.talla = clsHelper.valD(txtTalla.Text);
         nm.imc = clsHelper.valD(txtIMC.Text);
         nm.pt = txtPT.Text;
         nm.diagnosticoPt = clsHelper.valI(cboDiagnosticoNutricionalPT.SelectedValue);
         nm.pe = txtPe.Text; 
         nm.diagnosticoPe = clsHelper.valI( cboDiagnosticoNutricionalPE.SelectedValue.ToString()) ;
         nm.te = txtTE.Text;
         nm.diagnosticoTe = clsHelper.valI(cboDiagnosticoNutricionalTE.SelectedValue);
         nm.imcZcore = txtIMCZ.Text;
         nm.diagnosticoImcZscore = clsHelper.valI(cboDiagnosticoNutricionalIMCZ.SelectedValue);
         nm.cmb = clsHelper.valD(txtCMB.Text);
         nm.ccintura = clsHelper.valD(txtCcintura.Text);
         nm.ccadera = clsHelper.valD(txtCcadera.Text);
         nm.cp = clsHelper.valD(txtCP.Text);
         nm.gananciaPeso = clsHelper.valB(rbGananciaPeso.SelectedValue.ToString());
         nm.perdidaPeso = clsHelper.valB(rbPerdidaPeso.SelectedValue.ToString());
         nm.perdidaApetito = clsHelper.valB(rbPerdidaApetito.SelectedValue.ToString());
         nm.sindromeDesgaste = clsHelper.valB(rbSindromeDesgaste.SelectedValue.ToString());
         nm.diarrea = clsHelper.valB(rbDiarrea.SelectedValue.ToString());
         nm.nausea = clsHelper.valB(rbNausea.SelectedValue.ToString());
         nm.vomitos = clsHelper.valB(rbVomito.SelectedValue.ToString());
         nm.presentaProblemaMetabolismoGrasas = clsHelper.valB(rbProblemasMetabolismoGrasas.SelectedValue.ToString());
         nm.trigliceridosElevados = clsHelper.valB(rbTrigliceridosElevados.SelectedValue.ToString());
         nm.hdlElevado = clsHelper.valB(rbHdlElevado.SelectedValue.ToString());
         nm.colesterolElevado = clsHelper.valB(rbColesterolElevado.SelectedValue.ToString());
         nm.ldlElevado = clsHelper.valB(rbLDLElevado.SelectedValue.ToString());
         nm.presentaResistenciaInsulina = clsHelper.valB(rbResistenciaInsulina.SelectedValue.ToString());
         nm.presentaLipodistrofia = clsHelper.valB(rbPResentaLipodistrofia.SelectedValue.ToString());
         nm.lipoAtrofia = clsHelper.valB(rbLipoatrofia.SelectedValue.ToString());
         nm.lipoHipertrofia = clsHelper.valB(rbLipohipertrofia.SelectedValue.ToString());
         nm.mixta = clsHelper.valB(rbMixta.SelectedValue.ToString());
         nm.dietaCubreRequerimientosNutricionales = clsHelper.valB(rbDietaCubreRequerimientos.SelectedValue.ToString());
         nm.habitosAlimentariosAdecuados = clsHelper.valB(rbHabitosAlimentariosAdecuados.SelectedValue.ToString());
         nm.realizaActividadFisica = clsHelper.valB(rbRealizaActividadFisica.SelectedValue.ToString());
         nm.dieta = clsHelper.valI(cboDieta.SelectedValue.ToString());
         nm.suplementoNutricional = clsHelper.valB(rbSuplementoNutricional.SelectedValue.ToString());
         nm.multivitaminico = clsHelper.valB(rbMultivitaminico.SelectedValue.ToString());
         nm.educacionNutricional = clsHelper.valB(rbEducacionNutricional.SelectedValue.ToString());
         nm.grabar();
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
         limpiar();
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
         int idNutricionMayores;
         idNutricionMayores = int.Parse(((Label)gr.FindControl("lblidNutricionMayores")).Text);
         ClsNutricionMayores nm = new ClsNutricionMayores();
         nm = nm.seleccionarPorId(idNutricionMayores);
         if (nm.idNutricionMayores != null)
         {


            ViewState["idNutricionMayores"] = nm.idNutricionMayores;
            txtFechaVisita.Text = clsHelper.dateFormat(nm.fechaVisita.ToString());
            txtPesoLibras.Text = nm.pesoLibras.ToString();
            txtTalla.Text = nm.talla.ToString();
            txtIMC.Text = nm.imc.ToString();
            txtPT.Text = nm.pt.ToString();
            cboDiagnosticoNutricionalPT.SelectedValue = nm.diagnosticoPt.ToString();
            txtPe.Text = nm.pe.ToString();
            cboDiagnosticoNutricionalPE.SelectedValue = nm.diagnosticoPe.ToString();
            txtTE.Text = nm.te;
            cboDiagnosticoNutricionalTE.SelectedValue = nm.diagnosticoTe.ToString();
            txtIMCZ.Text = nm.imcZcore.ToString();
            cboDiagnosticoNutricionalIMCZ.SelectedValue = nm.diagnosticoImcZscore.ToString();
            txtCMB.Text = nm.cmb.ToString();
            txtCcintura.Text = nm.ccintura.ToString();
            txtCcadera.Text = nm.ccadera.ToString();
            txtCP.Text = nm.cp.ToString();
            clsHelper.booleanRb(rbGananciaPeso, nm.gananciaPeso);
            clsHelper.booleanRb(rbPerdidaPeso, nm.perdidaPeso);
            clsHelper.booleanRb(rbPerdidaApetito, nm.perdidaPeso);
            clsHelper.booleanRb(rbSindromeDesgaste, nm.sindromeDesgaste);
            clsHelper.booleanRb(rbDiarrea, nm.diarrea);
            clsHelper.booleanRb(rbNausea, nm.nausea);
            clsHelper.booleanRb(rbVomito, nm.vomitos);
            clsHelper.booleanRb(rbProblemasMetabolismoGrasas, nm.presentaProblemaMetabolismoGrasas);
            clsHelper.booleanRb(rbTrigliceridosElevados, nm.trigliceridosElevados);
            clsHelper.booleanRb(rbHdlElevado, nm.hdlElevado);
            clsHelper.booleanRb(rbColesterolElevado, nm.colesterolElevado);
            clsHelper.booleanRb(rbLDLElevado, nm.ldlElevado);
            clsHelper.booleanRb(rbResistenciaInsulina, nm.presentaResistenciaInsulina);
            clsHelper.booleanRb(rbPResentaLipodistrofia, nm.presentaLipodistrofia);
            clsHelper.booleanRb(rbLipoatrofia, nm.lipoAtrofia);
            clsHelper.booleanRb(rbLipohipertrofia, nm.lipoHipertrofia);
            clsHelper.booleanRb(rbMixta, nm.mixta);
            clsHelper.booleanRb(rbDietaCubreRequerimientos, nm.dietaCubreRequerimientosNutricionales);
            clsHelper.booleanRb(rbHabitosAlimentariosAdecuados, nm.habitosAlimentariosAdecuados);
            clsHelper.booleanRb(rbRealizaActividadFisica, nm.realizaActividadFisica);
            cboDieta.SelectedValue = nm.dieta.ToString();
            clsHelper.booleanRb(rbSuplementoNutricional, nm.suplementoNutricional);
            clsHelper.booleanRb(rbMultivitaminico, nm.multivitaminico);
            clsHelper.booleanRb(rbEducacionNutricional, nm.educacionNutricional);
         }
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

   void limpiar()
   {
      try
      {
         ViewState["idNutricionMayores"] = null;
         txtFechaVisita.Text = string.Empty;
         txtPesoLibras.Text = string.Empty;
         txtTalla.Text = string.Empty;
         txtIMC.Text = string.Empty;
         txtPT.Text = string.Empty;
         cboDiagnosticoNutricionalPT.SelectedValue = string.Empty;
         txtPe.Text = string.Empty;
         cboDiagnosticoNutricionalPE.SelectedValue = string.Empty;
         txtTE.Text = string.Empty;
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
         rbDietaCubreRequerimientos.SelectedValue = null;
         rbHabitosAlimentariosAdecuados.SelectedValue = null;
         rbRealizaActividadFisica.SelectedValue = null;
         cboDieta.SelectedValue = string.Empty;
         rbSuplementoNutricional.SelectedValue = null;
         rbMultivitaminico.SelectedValue = null;
         rbEducacionNutricional.SelectedValue = null;

      }
      catch (Exception ex)
      {

         throw ex;
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
         int idNutricionMayores;
         idNutricionMayores = int.Parse(((Label)gr.FindControl("lblidNutricionMayores")).Text);
         ClsNutricionMayores im = new ClsNutricionMayores();
         im.eliminar(idNutricionMayores);
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
         limpiar();
         cargarDatosExistentes();
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
      }
   }

   void calcularIMC() {
      double? imc;
      if (!string.IsNullOrEmpty(txtPesoLibras.Text) && !string.IsNullOrEmpty(txtTalla.Text)) {
         imc =(clsHelper.valD( txtPesoLibras.Text)/2.2)/Math.Pow(double.Parse(txtTalla.Text),2);
         txtIMC.Text = String.Format("{0:0.00}",imc );  
      }
   }

   void validFields(string idControl)
   {
      try
      {
         switch (idControl)
         {
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

}