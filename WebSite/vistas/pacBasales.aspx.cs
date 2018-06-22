using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;

public partial class vistas_pacBasales : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = "Ardani";
        Session["idPaciente"] = "3";
        try
        {
            if (!IsPostBack)
            {
                cargarcombos();
                if (Session["idPaciente"] != null)
                {
                    cargarDatosPaciente(Session["idPaciente"].ToString());
                }
            }

            if (!string.IsNullOrEmpty(Request.Params["__EVENTTARGET"]))
            {
                validFields(Request.Params["__EVENTTARGET"]);
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("load", ex, this, true);
        }
    }


    protected void btnGrabar_Click(object sender, EventArgs e)
    {

        try
        {
            ClsPacBasales pac = new ClsPacBasales();
            //valida Obligatorios
            if (!validarObligatorios())
            {
                return;
            }

            if (Session["idPaciente"] == null)
            {
                pac.IdPaciente = null;
            }
            else
            {
                pac.IdPaciente = int.Parse(Session["idPaciente"].ToString());
            }

            pac.ExpedienteHR = txtExpedienteHR.Text.Trim();
            pac.ExpedientePD = txtExpedientePD.Text.Trim();
            pac.PrimerNombre = txtPrimerNombre.Text.Trim();
            pac.SegundoNombre = txtSegundoNombre.Text.Trim();
            pac.PrimerApellido = txtPrimerApellido.Text.Trim();
            pac.SegundoApellido = txtSegundoApellido.Text.Trim();
            pac.IdGenero = rbGenero.SelectedValue;
            pac.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            pac.PaisResidencia = getValueI(cboPaisresidencia);
            pac.Direccion = txtDireccion.Text.Trim();
            pac.Telefono = txtTelefono.Text.Trim();
            pac.DepartamentoResidencia = getValueI(cboDepartamentoResidencia);
            pac.MunicipioResidencia = getValueI(cboDepartamentoResidencia);
            pac.Etnia = getValueI(cboEtnia);
            pac.NivelEducativo = getValueI(cboEscolaridad);
            pac.Fecha1Visita = Convert.ToDateTime(txtFechaPrimeraVisita.Text);
            pac.FechaModificacion = null;
            pac.PositivoConfirmado = getValueI(cboPositivoConfirmado);
            pac.TrasladoDe = getValueI(cboReferidoDe);
            pac.ComunidadLinguistica = getValueI(cboIdioma);
            pac.AtendidoEn = getValueI(cboAtendidoEn);
            pac.NacimientoPor = getValueI(cboNacimientoPor);
            pac.AZTIVMadre = getValueS(cboAztMadre);
            pac.PesoAlNacerLbs = clsHelper.valI(TxtPesoLibras.Text);
            pac.PesoAlNacerOz = clsHelper.valI(txtPEsoOnzas.Text);
            pac.edadGestacional = clsHelper.valI(txtEdadGestacional.Text);
            pac.TallaAlNacer = clsHelper.valD(txtTallaAlNacer.Text);
            pac.APGAR = txtAPGAR.Text;
            pac.CC = txtCC.Text;
            pac.crecimientoIntrauterino = txtCrecimientoIntrauterino.Text;
            pac.AEG = txtAEG.Text;
            pac.PEG = txtPEG.Text;
            pac.CEG = txtGEG.Text;
            pac.PatologiaNeonatal = getValueI(cboPatologiaNeonatal);
            pac.ProfilaxisETMH = getValueS(cboProfilaxisETMH);
            pac.cualProfilaxisETMH = getValueI(cboCualProfilaxis);
            pac.OtroProfilaxisETMH = null;
            pac.DosisProfilaxis = txtDosisProfilaxis.Text;
            pac.PorcentajeAderenciaProfilaxis = clsHelper.valI(txtAdherenciaProfilaxis.Text);
            pac.EfectosSecundarios = txtEfectosSecundarios.Text.Trim();
            pac.OtrosMedicamentos = getValueS(cboOtrosMedicamentos);
            pac.OtrosMedicamentosCual = txtOtrosMedicamentos.Text.Trim();
            pac.LactanciaMaterna = getValueS(cboLactanciaMaterna);
            pac.tiempoLM = clsHelper.valD(txtTiempoLM.Text);
            pac.FechaPositivoConfirmado = clsHelper.valDate(txtFechaPositivoConfirmado.Text);
            pac.MetodoDX = getValueI(cboMetodoDx);
            pac.ViaInfeccion = getValueI(cboViaInfeccion);
            pac.TARGAPrevio = getValueS(cboTargaPrevio);
            pac.CualTARGAPREVIO = txtCualTargaPrevio.Text.Trim();
            pac.FechaInicio = clsHelper.valDate(txtFechaInicioTarga.Text);
            pac.Suspendido = getValueS(cboTARGASuspendido);
            pac.MotivoSuspension = txtMotivoSuspension.Text.Trim();
            pac.VidaSexual = getValueS(cboVidaSexual);
            pac.PacienteConoceDiagnostico = getValueS(cboPacienteConoceDiagnostico);
            pac.CrecimientoDesarrollo = txtCrecimientoyDesarrollo.Text.Trim();
            pac.Medicos = txtMedicos.Text.Trim();
            pac.Quirurgicos = txtQuirurgicos.Text.Trim();
            pac.Traumaticos = txtTraumaticos.Text.Trim();
            pac.Alergicos = txtAlergicos.Text.Trim();
            pac.RevisionPorSistemas = txtRevisionPorSistemas.Text.Trim();
            pac.RiesgoExpuesto = getValueS(cboRiesgoExpuesto);
            pac.Usuario = Session["Usuario"].ToString();
            pac.NombreMadreEncargada = txtNombreMadreEncargada.Text.Trim();
            pac.NombrePadreEncargado = txtNombrePadreEncargado.Text.Trim();
            pac.condicionSocial = getValueI(cboCondicionSocial);
            pac.Nacionalidad = getValueI(cboNacionalidad);

            //graba / modifica
            string id = pac.grabar();
            if (!string.IsNullOrEmpty(id))
            {
                Session["idPaciente"] = id;
            }
            clsHelper.mensaje("¡Datos grabados correctamente!", this, clsHelper.tipoMensaje.informacion);
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnGrabar_Click", ex, this, true);
        }
    }

    Nullable<int> getValueI(DropDownList cbo)
    {
        int? r;
        try
        {
            if (clsHelper.IsNumeric(cbo.SelectedValue.ToString()))
            {
                r = Convert.ToInt32(cbo.SelectedValue.ToString());
            }
            else
            {
                r = null;
            }
            return r;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    Nullable<short> getValueS(DropDownList cbo)
    {
        short? r;
        try
        {
            if (clsHelper.IsNumeric(cbo.SelectedValue.ToString()))
            {
                r = short.Parse(cbo.SelectedValue.ToString());
            }
            else
            {
                r = null;
            }
            return r;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


    void cargarcombos()
    {

        try
        {
            //Referido de
            confCombo(cboReferidoDe, "M_HOSPITAL");
            //PaisResidencia
            confCombo(cboPaisresidencia, "PAC_M_PAIS");
            //DepartamentoResidencia
            confCombo(cboDepartamentoResidencia, "M_DEPARTAMENTO");
            //Municipio residencia
            confCombo(cboMunicipioResidencia, "M_MUNICIPIO");
            //condicion social
            confCombo(cboCondicionSocial, "MCondicionSocial");
            //escolaridad
            confCombo(cboEscolaridad, "MNivelEducativo");
            //comunidad linguistica
            confCombo(cboIdioma, "M_COMUNIDAD_LINGUISTICA");
            //etnia
            confCombo(cboEtnia, "PAC_M_ETNIA");

            //Atendido en 
            confCombo(cboAtendidoEn, "M_HOSPITAL");
            //nacimiento por
            confCombo(cboNacimientoPor, "MNacimientoPor");
            //azt madre
            confCombo(cboAztMadre, "MSiNO");
            //patologia neonatal
            confCombo(cboPatologiaNeonatal, "MPatologiaNeonatal");
            //profilaxis etmh
            confCombo(cboProfilaxisETMH, "MSiNo");
            //esquema profilaxis
            confCombo(cboCualProfilaxis, "MCualProfilaxisMTMH");
            //otros medicamentos sino
            confCombo(cboOtrosMedicamentos, "MSiNo");
            //lactancia materna
            confCombo(cboLactanciaMaterna, "MLactanciaMaterna");


            confCombo(cboPositivoConfirmado, "MSiNo");
            //método dx
            confCombo(cboMetodoDx, "MMetodoDX");
            //Via Infeccion
            confCombo(cboViaInfeccion, "MViaInfeccion");
            //TARGA Previo
            confCombo(cboTargaPrevio, "MSiNo");
            //targa suspendido
            confCombo(cboTARGASuspendido, "MSiNo");
            //vida sexual
            confCombo(cboVidaSexual, "MSiNo");
            //conoce dx
            confCombo(cboPacienteConoceDiagnostico, "MSiNo");
            //Riesgo expuesto PAra pacientes expuestos
            confCombo(cboRiesgoExpuesto, "MRiesgoExpuesto");
            //NAcionalidad
            confCombo(cboNacionalidad, "PAC_M_PAIS");


        }



        catch (Exception ex)
        {

            clsHelper.mostrarError("cargarCombos", ex, this, true);
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
    protected void cboDepartamentoResidencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            confCombo(cboMunicipioResidencia, "M_MUNICIPIO", " departamento=" + cboDepartamentoResidencia.SelectedValue.ToString());
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboDepartamentoResidencia_SelectedIndexChanged", ex, this, true);
        }
    }

    protected void cboProfilaxisETMH_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboProfilaxisETMH.SelectedValue.ToString().Equals("1"))
            {
                cboCualProfilaxis.Enabled = true;
                txtDosisProfilaxis.Enabled = true;
                txtAdherenciaProfilaxis.Enabled = true;
                txtEfectosSecundarios.Enabled = true;

            }
            else
            {
                cboCualProfilaxis.Enabled = false;
                txtDosisProfilaxis.Enabled = false;
                txtAdherenciaProfilaxis.Enabled = false;
                txtEfectosSecundarios.Enabled = false;
            }
            cboCualProfilaxis.SelectedValue = string.Empty;
            txtDosisProfilaxis.Text = string.Empty;
            txtAdherenciaProfilaxis.Text = string.Empty;
            txtEfectosSecundarios.Text = string.Empty;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboProfilaxisETMH_SelectedIndexChanged", ex, this, true);
        }
    }
    protected void cboOtrosMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboOtrosMedicamentos.SelectedValue.ToString().Equals("1"))
            {
                txtOtrosMedicamentos.Enabled = true;

            }
            else
            {
                txtOtrosMedicamentos.Enabled = false;

            }
            txtOtrosMedicamentos.Text = string.Empty;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboOtrosMedicamentos_SelectedIndexChanged", ex, this, true);
        }
    }
    protected void cboPositivoConfirmado_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboPositivoConfirmado.SelectedValue.ToString().Equals("1"))
            {
                txtFechaPositivoConfirmado.Enabled = true;
                cboMetodoDx.Enabled = true;
                cboViaInfeccion.Enabled = true;
                cboRiesgoExpuesto.Enabled = false;

            }
            else if (cboPositivoConfirmado.SelectedValue.ToString().Equals("0"))
            {
                txtFechaPositivoConfirmado.Enabled = false;
                cboMetodoDx.Enabled = false;
                cboViaInfeccion.Enabled = false;
                cboRiesgoExpuesto.Enabled = true;

            }
            else
            {
                txtFechaPositivoConfirmado.Enabled = false;
                cboMetodoDx.Enabled = false;
                cboViaInfeccion.Enabled = false;
                cboRiesgoExpuesto.Enabled = false;

            }
            txtFechaPositivoConfirmado.Text = string.Empty;
            cboMetodoDx.SelectedValue = string.Empty;
            cboViaInfeccion.SelectedValue = string.Empty;
            cboRiesgoExpuesto.SelectedValue = string.Empty;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboPositivoConfirmado_SelectedIndexChanged", ex, this, true);
        }
    }
    protected void cboTargaPrevio_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboTargaPrevio.SelectedValue.ToString().Equals("1"))
            {
                txtCualTargaPrevio.Enabled = true;
                txtFechaInicioTarga.Enabled = true;
                cboTARGASuspendido.Enabled = true;

            }
            else
            {
                txtCualTargaPrevio.Enabled = false;
                txtFechaInicioTarga.Enabled = false;
                cboTARGASuspendido.Enabled = false;

            }
            txtCualTargaPrevio.Text = string.Empty;
            txtFechaInicioTarga.Text = string.Empty;
            cboTARGASuspendido.SelectedValue = string.Empty;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboTargaPrevio_SelectedIndexChanged", ex, this, true);
        }
    }

    protected void cboTARGASuspendido_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboTARGASuspendido.SelectedValue.ToString().Equals("1"))
            {
                txtMotivoSuspension.Enabled = true;

            }
            else
            {
                txtMotivoSuspension.Enabled = false;

            }
            txtMotivoSuspension.Text = string.Empty;
            txtMotivoSuspension.Focus();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboTARGASuspendido_SelectedIndexChanged", ex, this, true);
        }
    }

    void calcularEdad()
    {
        object edad = 0;
        try
        {
            if (clsHelper.isDate(txtFechaNacimiento.Text))
            {
                edad = (DateTime.Now.Date - Convert.ToDateTime(txtFechaNacimiento.Text)).TotalDays;
                edad = Convert.ToDouble(edad) / 365.25;
                edad = Math.Floor(Convert.ToDouble(edad));
                txtEdad.Text = edad.ToString();
            }
            else
            {
                txtEdad.Text = string.Empty;

            }

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("calcular edad", ex, this, true);
        }
    }

    void validFields(string idControl)
    {
        try
        {
            switch (idControl)
            {
                case "txtFechaNacimiento":
                    calcularEdad();
                    break;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    Boolean validarObligatorios()
    {
        Boolean r = true;
        try
        {
            if (string.IsNullOrEmpty(txtExpedienteHR.Text))
            {
                clsHelper.mensaje("Ingrese El No. Expediente HR", this, clsHelper.tipoMensaje.alerta);
                txtExpedienteHR.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtExpedientePD.Text))
            {
                clsHelper.mensaje("Ingrese el No. Expediente PD", this, clsHelper.tipoMensaje.alerta);
                txtExpedientePD.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPrimerNombre.Text))
            {
                clsHelper.mensaje("Ingrese el primer nombre", this, clsHelper.tipoMensaje.alerta);
                txtPrimerNombre.Focus();
                return false;

            }

            if (string.IsNullOrEmpty(txtPrimerApellido.Text))
            {
                clsHelper.mensaje("Ingrese el primer Apellido", this, clsHelper.tipoMensaje.alerta);
                txtPrimerApellido.Focus();
                return false;
            }

            if (!clsHelper.isDate(txtFechaNacimiento.Text))
            {
                clsHelper.mensaje("Ingrese una fecha de nacimiento válida", this, clsHelper.tipoMensaje.alerta);
                txtFechaNacimiento.Focus();
                return false;
            }

            if (!rbGenero.SelectedValue.ToString().Equals("M") && !rbGenero.SelectedValue.ToString().Equals("F"))
            {
                clsHelper.mensaje("Selccione género del paciente", this, clsHelper.tipoMensaje.alerta);
                rbGenero.Focus();
                return false;
            }

            if (!clsHelper.isDate(txtFechaPrimeraVisita.Text))
            {
                clsHelper.mensaje("Ingrese una fecha de primera visita", this, clsHelper.tipoMensaje.alerta);
                txtFechaPrimeraVisita.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cboPositivoConfirmado.SelectedValue.ToString()))
            {
                clsHelper.mensaje("Seleccione si el paciente es positivo", this, clsHelper.tipoMensaje.alerta);
                cboPositivoConfirmado.Focus();
                return false;
            }

            if (cboPositivoConfirmado.SelectedValue.ToString().Equals("0"))
            {
                if (string.IsNullOrEmpty(cboRiesgoExpuesto.SelectedValue.ToString()))
                {
                    clsHelper.mensaje("Marque el riesgo del paciente expuesto", this, clsHelper.tipoMensaje.alerta);
                    txtFechaNacimiento.Focus();
                    return false;
                }
            }
            return r;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void cargarDatosPaciente(string idPaciente) {
        ClsPacBasales pb = new ClsPacBasales();
     
        try
        {
            DataTable dt = new DataTable();
            dt = pb.getData(idPaciente);
            if (dt.Rows.Count < 1) {
                return;
            }
            txtExpedienteHR.Text = dt.Rows[0]["ExpedienteHR"].ToString();
            txtExpedientePD.Text = dt.Rows[0]["ExpedientePD"].ToString();
            txtPrimerNombre.Text = dt.Rows[0]["PrimerNombre"].ToString();
            txtSegundoNombre.Text = dt.Rows[0]["SegundoNombre"].ToString();
            txtPrimerApellido.Text = dt.Rows[0]["PrimerApellido"].ToString();
            txtSegundoApellido.Text = dt.Rows[0]["SegundoApellido"].ToString();
            txtFechaNacimiento.Text = dt.Rows[0]["FechaNacimiento"].ToString();
            calcularEdad();
            rbGenero.SelectedValue = dt.Rows[0]["idGenero"].ToString();
            cboPaisresidencia.SelectedValue  = dt.Rows[0]["PaisResidencia"].ToString();
            cboDepartamentoResidencia.SelectedValue = dt.Rows[0]["DepartamentoResidencia"].ToString();
            cboMunicipioResidencia.SelectedValue = dt.Rows[0]["MunicipioResidencia"].ToString();
            txtDireccion.Text = dt.Rows[0]["Direccion"].ToString();
            txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
            txtNombreMadreEncargada.Text = dt.Rows[0]["NombreMadreEncargada"].ToString();
            txtNombrePadreEncargado.Text = dt.Rows[0]["NombrePadreEncargado"].ToString();
            cboCondicionSocial.SelectedValue = dt.Rows[0]["condicionSocial"].ToString();
            cboEscolaridad.SelectedValue = dt.Rows[0]["NivelEducativo"].ToString();
            cboIdioma.SelectedValue = dt.Rows[0]["ComunidadLinguistica"].ToString();
            cboEtnia.SelectedValue = dt.Rows[0]["Etnia"].ToString();
            txtFechaPrimeraVisita.Text =   dt.Rows[0]["Fecha1Visita"].ToString();
            cboAtendidoEn.SelectedValue = dt.Rows[0]["AtendidoEn"].ToString();
            cboNacimientoPor.SelectedValue = dt.Rows[0]["NacimientoPor"].ToString();
            cboAztMadre.SelectedValue = dt.Rows[0]["AZTIVMadre"].ToString();
            TxtPesoLibras.Text = dt.Rows[0]["PesoAlNacerLbs"].ToString();
            txtPEsoOnzas.Text = dt.Rows[0]["PesoAlNacerOz"].ToString();
            txtAPGAR.Text = dt.Rows[0]["APGAR"].ToString();
            txtEdadGestacional.Text =  dt.Rows[0]["EdadGestacional"].ToString();
            txtTallaAlNacer.Text = dt.Rows[0]["TallaAlNacer"].ToString();
            txtCC.Text = dt.Rows[0]["CC"].ToString();
            txtCrecimientoIntrauterino.Text = dt.Rows[0]["CrecimientoIntrauterino"].ToString();
            txtAEG.Text = dt.Rows[0]["AEG"].ToString();
            txtPEG.Text = dt.Rows[0]["PEG"].ToString();
            txtGEG.Text = dt.Rows[0]["CEG"].ToString();
            cboPatologiaNeonatal.SelectedValue = dt.Rows[0]["PatologiaNeonatal"].ToString();
            cboProfilaxisETMH.SelectedValue = dt.Rows[0]["ProfilaxisETMH"].ToString();
            cboCualProfilaxis.SelectedValue = dt.Rows[0]["cualProfilaxisETMH"].ToString();
            txtDosisProfilaxis.Text = dt.Rows[0]["DosisProfilaxis"].ToString();
            txtAdherenciaProfilaxis.Text = dt.Rows[0]["PorcentajeAderenciaProfilaxis"].ToString();
            txtEfectosSecundarios.Text = dt.Rows[0]["EfectosSecundarios"].ToString();
            cboOtrosMedicamentos.SelectedValue = dt.Rows[0]["OtrosMedicamentos"].ToString();
            txtOtrosMedicamentos.Text = dt.Rows[0]["OtrosMedicamentosCual"].ToString();
            cboLactanciaMaterna.SelectedValue = dt.Rows[0]["LactanciaMaterna"].ToString();
            txtTiempoLM.Text = dt.Rows[0]["tiempoLM"].ToString();
            //campos condicionales
            if (dt.Rows[0]["ProfilaxisETMH"].ToString().Equals("1"))
            {
                cboCualProfilaxis.Enabled = true;
                txtDosisProfilaxis.Enabled = true;
                txtEfectosSecundarios.Enabled = true;
                txtAdherenciaProfilaxis.Enabled = true;

            }
            else {
                cboCualProfilaxis.Enabled = false;
                txtDosisProfilaxis.Enabled = false;
                txtEfectosSecundarios.Enabled = false;
                txtAdherenciaProfilaxis.Enabled = false;
            }

            if (dt.Rows[0]["OtrosMedicamentos"].ToString().Equals("1"))
            {
                txtOtrosMedicamentos.Enabled = true;
                
            }
            else
            {
                txtOtrosMedicamentos.Enabled = false;
            }

            cboPositivoConfirmado.SelectedValue = dt.Rows[0]["PositivoConfirmado"].ToString();
            txtFechaPositivoConfirmado.Text = dt.Rows[0]["FechaPositivoConfirmado"].ToString();
            cboMetodoDx.SelectedValue = dt.Rows[0]["MetodoDX"].ToString();
            cboViaInfeccion.SelectedValue = dt.Rows[0]["ViaInfeccion"].ToString();
            cboTargaPrevio.SelectedValue = dt.Rows[0]["TARGAPrevio"].ToString();
            txtCualTargaPrevio.Text = dt.Rows[0]["CualTARGAPREVIO"].ToString();
            txtFechaInicioTarga.Text = dt.Rows[0]["FechaInicio"].ToString();
            cboTARGASuspendido.SelectedValue = dt.Rows[0]["Suspendido"].ToString();
            txtMotivoSuspension.Text = dt.Rows[0]["MotivoSuspension"].ToString();
            cboVidaSexual.SelectedValue = dt.Rows[0]["VidaSexual"].ToString();
            cboPacienteConoceDiagnostico.SelectedValue = dt.Rows[0]["PacienteConoceDiagnostico"].ToString();
            cboRiesgoExpuesto.SelectedValue = dt.Rows[0]["RiesgoExpuesto"].ToString();

            //Campos condicionales
            if (dt.Rows[0]["PositivoConfirmado"].ToString().Equals("1"))
            {
                txtFechaPositivoConfirmado.Enabled = true;
                cboMetodoDx.Enabled = true;
                cboViaInfeccion.Enabled = true;
                cboTargaPrevio.Enabled = true;
                cboRiesgoExpuesto.Enabled = false;
            }
            else
            {
                txtFechaPositivoConfirmado.Enabled = false;
                cboMetodoDx.Enabled = false;
                cboViaInfeccion.Enabled = false;
                cboTargaPrevio.Enabled = false;
                cboRiesgoExpuesto.Enabled = true;
            }

            if (dt.Rows[0]["TARGAPrevio"].ToString().Equals("1"))
            {
                txtCualTargaPrevio.Enabled = true;
                txtFechaInicioTarga.Enabled = true;
                cboTARGASuspendido.Enabled = true;
                txtMotivoSuspension.Enabled = true;
                
            }
            else
            {
                txtCualTargaPrevio.Enabled = false;
                txtFechaInicioTarga.Enabled = false;
                cboTARGASuspendido.Enabled = false;
                txtMotivoSuspension.Enabled = false;
            }
            if (dt.Rows[0]["Suspendido"].ToString().Equals("1"))
            {
                txtMotivoSuspension.Enabled = true;

            }
            else
            {
                txtMotivoSuspension.Enabled = false;

            }

            txtCrecimientoyDesarrollo.Text = dt.Rows[0]["CrecimientoDesarrollo"].ToString();
            txtMedicos.Text = dt.Rows[0]["Medicos"].ToString();
            txtQuirurgicos.Text = dt.Rows[0]["Quirurgicos"].ToString();
            txtTraumaticos.Text = dt.Rows[0]["Traumaticos"].ToString();
            txtAlergicos.Text = dt.Rows[0]["Alergicos"].ToString();
            txtRevisionPorSistemas.Text= dt.Rows[0]["RevisionPorSistemas"].ToString();

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }


}