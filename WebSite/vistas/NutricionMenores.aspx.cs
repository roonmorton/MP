using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_NutricionMenores : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         if (!IsPostBack)
         {
            ViewState["idNutricionMenores"] = null;
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

   void cargarCbo()
   {
      try
      {
         confCombo(cboDiagnosticoNutricionalPL, "MDiagnosticoNutricional1");
         confCombo(cboDiagnosticoNutricionalLE, "MDiagnosticoNutricional2");
         confCombo(cboDiagnosticoNutricionalPE, "MDiagnosticoNutricional1");
         confCombo(cboDiagnosticoNutricionalCCE, "MDiagnosticoNutricional3");
         confCombo(cboOpcionAlimentacion, "MOpcionAlimentacionElegida");
         confCombo(cboLactanciaMaterna, "MLactanciaMaternaNutricion");
         confCombo(cboPreparacion, "MPreparacionNutricion");
         confCombo(cboComoLaObtienen, "MComoLaObtienenNutricion");
      }
      catch (Exception ex)
      {

         throw ex;
      }
   }

   void cargarDatosExistentes()
   {
      ClsNutricionMenores cnm = new ClsNutricionMenores();
      DataTable dt = new DataTable();
      dt = cnm.seleccionarTodos(int.Parse(Session["idPaciente"].ToString()));
      grdExistentes.DataSource = dt;
      grdExistentes.DataBind();
   }

   void limpiar()
   {
      ViewState["idNutricionMenores"] = null;
      txtFechaVisita.Text = string.Empty;
      txtPesoLibras.Text = string.Empty;
      txtPesoOnzas.Text = string.Empty;
      txtTalla.Text = string.Empty;
      txtCircunferenciaCefalica.Text = string.Empty;
      txtPl.Text = string.Empty;
      txtLe.Text = string.Empty;
      txtPe.Text = string.Empty;
      txtCCE.Text = string.Empty;
      cboDiagnosticoNutricionalPL.SelectedValue = null;
      cboDiagnosticoNutricionalPE.SelectedValue = null;
      cboDiagnosticoNutricionalLE.SelectedValue = null;
      cboDiagnosticoNutricionalCCE.SelectedValue = null;
      rbGananciaPeso.SelectedValue = null;
      rbPerdidaPeso.SelectedValue = null;
      tbVomito.SelectedValue = null;
      rbDiarrea.SelectedValue = null;
      rbEstreñmiento.SelectedValue = null;
      rbReflujo.SelectedValue = null;
      rbColicos.SelectedValue = null;
      cboOpcionAlimentacion.SelectedValue = null;
      cboLactanciaMaterna.SelectedValue = null;
      txtTiempoLactancia.Text = string.Empty;
      cboPreparacion.SelectedValue = null;
      cboComoLaObtienen.SelectedValue = null;
      rbLecheAdecuada.SelectedValue = null;
      tbOfreceLiquidosAlimentos.SelectedValue = null;
      rbLactanciaMixta.SelectedValue = null;
      rbAlimentacionComplementaria.SelectedValue = null;
      txtEdadAblacion.Text = string.Empty;
      rbEducacionNutricional.SelectedValue = null;
      rbMultivitaminico.SelectedValue = null;
      rbFormulaRecuperacion.SelectedValue = null;

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

         ClsNutricionMenores nm = new ClsNutricionMenores();
         if (ViewState["idNutricionMenores"] != null)
         {
            nm.idNutricionMenores = int.Parse(ViewState["idNutricionMenores"].ToString());
         }
         else
         {
            nm.idNutricionMenores = null;
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
         nm.pesoOnzas = clsHelper.valD(txtPesoOnzas.Text);
         nm.talla = clsHelper.valD(txtTalla.Text);
         nm.circunferenciaCefalica = clsHelper.valD(txtCircunferenciaCefalica.Text);
         nm.pl = txtPl.Text;
         nm.diagnosticoPl = clsHelper.getValueI(cboDiagnosticoNutricionalPL);
         nm.pe = txtPe.Text;
         nm.diagnosticoPe = clsHelper.getValueI(cboDiagnosticoNutricionalPE);
         nm.le = txtLe.Text;
         nm.diagnosticoLe = clsHelper.getValueI(cboDiagnosticoNutricionalLE);
         nm.cce = txtCCE.Text;
         nm.diagnosticoCce = clsHelper.getValueI(cboDiagnosticoNutricionalCCE);
         nm.gananciaPeso = clsHelper.valB(rbGananciaPeso.SelectedValue.ToString());
         nm.perdidaPeso = clsHelper.valB(rbPerdidaPeso.SelectedValue.ToString());
         nm.vomitos = clsHelper.valB(tbVomito.SelectedValue.ToString());
         nm.diarrea = clsHelper.valB(rbDiarrea.SelectedValue.ToString());
         nm.estrenimiento = clsHelper.valB(rbEstreñmiento.SelectedValue.ToString());
         nm.reflujo = clsHelper.valB(rbReflujo.SelectedValue.ToString());
         nm.colicos = clsHelper.valB(rbColicos.SelectedValue.ToString());
         nm.opcionAlimentacion = clsHelper.getValueI(cboOpcionAlimentacion);
         nm.lactanciaMaterna = clsHelper.getValueI(cboLactanciaMaterna);
         nm.tiempoLactanciaMaterna = clsHelper.valI(txtTiempoLactancia.Text);
         nm.preparacion = clsHelper.getValueI(cboPreparacion);
         nm.comoLaObtienen = clsHelper.getValueI (cboComoLaObtienen);
         nm.lecheAdecuadaEdad = clsHelper.valB(rbLecheAdecuada.SelectedValue.ToString());
         nm.ofreceOtrosLiquidos = clsHelper.valB(tbOfreceLiquidosAlimentos.SelectedValue.ToString());
         nm.lactanciaMixta = clsHelper.valB(rbLactanciaMixta.SelectedValue.ToString());
         nm.alimentacionComplementaria = clsHelper.valB(rbAlimentacionComplementaria.SelectedValue.ToString());
         nm.edadAblacion = clsHelper.valI(txtEdadAblacion.Text);
         nm.educacionNutricional = clsHelper.valB(rbEducacionNutricional.SelectedValue.ToString());
         nm.multivitaminico = clsHelper.valB(rbMultivitaminico.SelectedValue.ToString());
         nm.formulaRecuperacionNutricional = clsHelper.valB(rbFormulaRecuperacion.SelectedValue.ToString());
         nm.usuario = Session["usuario"].ToString();
         nm.grabar();
         clsHelper.mensaje("Proceso exitoso",this,clsHelper.tipoMensaje.informacion);
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
         int idNutricionMenores;
         idNutricionMenores = int.Parse(((Label)gr.FindControl("lblidNutricionMenores")).Text);
         ClsNutricionMenores nm = new ClsNutricionMenores();
         nm = nm.seleccionarPorId(idNutricionMenores);
         if (nm.idNutricionMenores != null)
         {
            ViewState["idNutricionMenores"] = nm.idNutricionMenores;
            txtFechaVisita.Text = clsHelper.dateFormat(nm.fechaVisita.ToString());
            txtPesoLibras.Text = nm.pesoLibras.ToString();
            txtPesoOnzas.Text = nm.pesoOnzas.ToString();
            txtTalla.Text = nm.talla.ToString();
            txtCircunferenciaCefalica.Text = nm.circunferenciaCefalica.ToString();
            txtPl.Text = nm.pl.ToString();
            cboDiagnosticoNutricionalPL.SelectedValue = nm.diagnosticoPl.ToString();
            txtLe.Text = nm.le.ToString();
            cboDiagnosticoNutricionalLE.SelectedValue = nm.diagnosticoLe.ToString();
            txtPe.Text = nm.pe.ToString();
            cboDiagnosticoNutricionalPE.SelectedValue = nm.diagnosticoPe.ToString();
            txtCCE.Text = nm.cce.ToString();
            cboDiagnosticoNutricionalCCE.SelectedValue = nm.diagnosticoCce.ToString();
            clsHelper.booleanRb(rbGananciaPeso , nm.gananciaPeso);
            clsHelper.booleanRb(rbPerdidaPeso, nm.perdidaPeso);
            clsHelper.booleanRb(tbVomito, nm.vomitos);
            clsHelper.booleanRb(rbDiarrea , nm.diarrea );
            clsHelper.booleanRb(rbEstreñmiento , nm.estrenimiento);
            clsHelper.booleanRb(rbReflujo , nm.reflujo  );
            clsHelper.booleanRb(rbColicos, nm.colicos);
            cboOpcionAlimentacion.SelectedValue = nm.opcionAlimentacion.ToString();
            cboLactanciaMaterna.SelectedValue = nm.lactanciaMaterna.ToString();
            txtTiempoLactancia.Text = nm.tiempoLactanciaMaterna.ToString();
            cboPreparacion.SelectedValue = nm.preparacion.ToString();
            cboComoLaObtienen.SelectedValue = nm.comoLaObtienen.ToString();
            clsHelper.booleanRb(rbLecheAdecuada , nm.lecheAdecuadaEdad);
            clsHelper.booleanRb(tbOfreceLiquidosAlimentos, nm.ofreceOtrosLiquidos);
            clsHelper.booleanRb(rbLactanciaMixta , nm.lactanciaMixta);
            clsHelper.booleanRb(rbAlimentacionComplementaria , nm.alimentacionComplementaria);
            txtEdadAblacion.Text = nm.edadAblacion.ToString();
            clsHelper.booleanRb(rbEducacionNutricional , nm.educacionNutricional);
            clsHelper.booleanRb(rbMultivitaminico, nm.multivitaminico);
            clsHelper.booleanRb(rbFormulaRecuperacion , nm.formulaRecuperacionNutricional);

         }
         else {
            ViewState["idNutricionMenores"] = null;
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
         int idNutricionMenores;
         idNutricionMenores = int.Parse(((Label)gr.FindControl("lblidNutricionMenores")).Text);
         ClsNutricionMenores im = new ClsNutricionMenores();
         im.eliminar(idNutricionMenores);
         clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
         limpiar();
         cargarDatosExistentes();
      }
      catch (Exception ex)
      {

         clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
      }
   }
}