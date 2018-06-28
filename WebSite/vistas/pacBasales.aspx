<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="pacBasales.aspx.cs" Inherits="vistas_pacBasales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary">
        <div class="panel-heading">DATOS DEL PACIENTE</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Expediente No. HR (*)</label>
                        <asp:TextBox runat="server" ID="txtExpedienteHR" placeholder="Expediente No. HR"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Expediente No. PD  (*)</label>
                        <asp:TextBox runat="server" ID="txtExpedientePD" placeholder="Expediente No. PD"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Referido de</label>
                        <asp:DropDownList runat="server" ID="cboReferidoDe"></asp:DropDownList>
                    </div>
                </div>


                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Primer Nombre  (*)</label>
                        <asp:TextBox runat="server" ID="txtPrimerNombre" placeholder="Primer Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Segundo Nombre</label>
                        <asp:TextBox runat="server" ID="txtSegundoNombre" placeholder="Segundo Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Primer Apellido  (*)</label>
                        <asp:TextBox runat="server" ID="txtPrimerApellido" placeholder="Primer Apellido"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Segundo Apellido</label>
                        <asp:TextBox runat="server" ID="txtSegundoApellido" placeholder="Segundo Apellido"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Fecha de Nacimiento  (*)</label>
                        <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="fecha"  onblur="javascript:if(this.value!='') __doPostBack('txtFechaNacimiento','')"></asp:TextBox>
                    </div>
                </div>
                   <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Edad</label>
                        <asp:TextBox runat="server" ID="txtEdad" CssClass="numero" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Género (*)</label>
                        <asp:RadioButtonList runat="server" ID="rbGenero" RepeatDirection="Horizontal">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Pais Residencia</label>
                        <asp:DropDownList runat="server" ID="cboPaisresidencia" placeholder="Pais Residencia"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Departamento Residencia</label>
                        <asp:DropDownList runat="server" ID="cboDepartamentoResidencia" AutoPostBack="True" OnSelectedIndexChanged="cboDepartamentoResidencia_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Municipio Residencia</label>
                        <asp:DropDownList runat="server" ID="cboMunicipioResidencia"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Dirección</label>
                        <asp:TextBox runat="server" ID="txtDireccion" placeholder="Dirección"></asp:TextBox>
                    </div>
                </div>


                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Teléfono</label>
                        <asp:TextBox runat="server" ID="txtTelefono" CssClass=""></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nombre Madre/Encargada</label>
                        <asp:TextBox runat="server" ID="txtNombreMadreEncargada" CssClass=""></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nombre Padre/Encargado</label>
                        <asp:TextBox runat="server" ID="txtNombrePadreEncargado" CssClass=""></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Condición Social</label>
                        <asp:DropDownList runat="server" ID="cboCondicionSocial"></asp:DropDownList>
                    </div>
                </div>
                     <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nacionalidad</label>
                        <asp:DropDownList runat="server" ID="cboNacionalidad"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Escolaridad</label>
                        <asp:DropDownList runat="server" ID="cboEscolaridad"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Idioma</label>
                        <asp:DropDownList runat="server" ID="cboIdioma"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Etnia</label>
                        <asp:DropDownList runat="server" ID="cboEtnia"></asp:DropDownList>
                    </div>
                </div>
                 
                                 
                 <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Fecha Primera Visita (*)</label>
                        <asp:TextBox runat="server" ID="txtFechaPrimeraVisita" CssClass="fecha"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="panel panel-warning">
      <div class="panel-heading">DATOS DEL RECIÉN NACIDO</div>
      <div class="panel-body">
          <div class="row">
                   <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Atendido en</label>
                        <asp:DropDownList runat="server" ID="cboAtendidoEn"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nacimiento Por</label>
                        <asp:DropDownList runat="server" ID="cboNacimientoPor"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>AZT Madre</label>
                        <asp:DropDownList runat="server" ID="cboAztMadre"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Peso al nacer Lbs.</label>
                        <asp:TextBox runat="server" ID="TxtPesoLibras" CssClass="numero"></asp:TextBox>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Onzas</label>
                        <asp:TextBox runat="server" ID="txtPEsoOnzas" CssClass="numero"></asp:TextBox>
                    </div>
                </div>
                          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>APGAR</label>
                        <asp:TextBox runat="server" ID="txtAPGAR" ></asp:TextBox>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Edad Gestacional</label>
                        <asp:TextBox runat="server" ID="txtEdadGestacional" CssClass="numero"></asp:TextBox>
                    </div>
                </div>
                          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Talla al Nacer</label>
                        <asp:TextBox runat="server" ID="txtTallaAlNacer" CssClass="numero"></asp:TextBox>
                    </div>
                </div>

                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>CC</label>
                        <asp:TextBox runat="server" ID="txtCC"></asp:TextBox>
                    </div>
                </div>
                      <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Crecimiento Intrauterino</label>
                        <asp:TextBox runat="server" ID="txtCrecimientoIntrauterino"></asp:TextBox>
                    </div>
                </div>
                      <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>AEG</label>
                        <asp:TextBox runat="server" ID="txtAEG"></asp:TextBox>
                    </div>
                </div>
                      <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>PEG</label>
                        <asp:TextBox runat="server" ID="txtPEG"></asp:TextBox>
                    </div>
                </div>
                      <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>GEG</label>
                        <asp:TextBox runat="server" ID="txtGEG"></asp:TextBox>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Patología Neonatal</label>
                        <asp:DropDownList runat="server" ID="cboPatologiaNeonatal"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Profilaxis ETMH</label>
                        <asp:DropDownList runat="server" ID="cboProfilaxisETMH" AutoPostBack="True" OnSelectedIndexChanged="cboProfilaxisETMH_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Esquema Profilaxis</label>
                        <asp:DropDownList runat="server" ID="cboCualProfilaxis" Enabled="False"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Dosis/Frecuencia</label>
                        <asp:TextBox runat="server" ID="txtDosisProfilaxis" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Adherencia profilaxis</label>
                        <asp:TextBox runat="server" ID="txtAdherenciaProfilaxis" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Efectos Secundarios</label>
                        <asp:TextBox runat="server" ID="txtEfectosSecundarios" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Otros Medicamentos</label>
                        <asp:DropDownList runat="server" ID="cboOtrosMedicamentos" AutoPostBack="True" OnSelectedIndexChanged="cboOtrosMedicamentos_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>¿Cuáles otros medicamentos?</label>
                        <asp:TextBox runat="server" ID="txtOtrosMedicamentos" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Lactancia Materna</label>
                        <asp:DropDownList runat="server" ID="cboLactanciaMaterna"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Tiempo LM</label>
                        <asp:TextBox runat="server" ID="txtTiempoLM" CssClass="numero"></asp:TextBox>
                    </div>
                </div>

          </div>
      </div>
    </div>

     <div class="panel panel-info">
      <div class="panel-heading">ESTADO VIH</div>
      <div class="panel-body">
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Positivo Confirmado (*)</label>
                        <asp:DropDownList runat="server" ID="cboPositivoConfirmado" AutoPostBack="True" OnSelectedIndexChanged="cboPositivoConfirmado_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Fecha Diagnóstico</label>
                        <asp:TextBox runat="server" ID="txtFechaPositivoConfirmado" Enabled="False" CssClass="fecha"></asp:TextBox>
                    </div>
                </div>

           <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Método diagnóstico</label>
                        <asp:DropDownList runat="server" ID="cboMetodoDx" Enabled="False"></asp:DropDownList>
                    </div>
                </div>

          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Vía de Infección</label>
                        <asp:DropDownList runat="server" ID="cboViaInfeccion" Enabled="False"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>TARGA Previo</label>
                        <asp:DropDownList runat="server" ID="cboTargaPrevio" AutoPostBack="True" OnSelectedIndexChanged="cboTargaPrevio_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Cuál</label>
                        <asp:TextBox runat="server" ID="txtCualTargaPrevio" Enabled="False"></asp:TextBox>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Fecha Inicio TARGA</label>
                        <asp:TextBox runat="server" ID="txtFechaInicioTarga" CssClass="fecha" Enabled="False"></asp:TextBox>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Suspendido</label>
                        <asp:DropDownList runat="server" ID="cboTARGASuspendido" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="cboTARGASuspendido_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Motivo Suspensión</label>
                        <asp:TextBox runat="server" ID="txtMotivoSuspension" Enabled="False"></asp:TextBox>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Vida Sexual</label>
                        <asp:DropDownList runat="server" ID="cboVidaSexual"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Paciente conoce su diagnóstico</label>
                        <asp:DropDownList runat="server" ID="cboPacienteConoceDiagnostico"></asp:DropDownList>
                    </div>
                </div>
          <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Riesgo Expuesto</label>
                        <asp:DropDownList runat="server" ID="cboRiesgoExpuesto" Enabled="False"></asp:DropDownList>
                    </div>
                </div>

      </div>
    </div>

    
    <div class="panel panel-success">
      <div class="panel-heading">ANTECEDENTES</div>
      <div class="panel-body">
          <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label><strong>Fisiológicos</strong><br />A. Crecimiento y desarrollo</label>
                        <asp:TextBox runat="server" ID="txtCrecimientoyDesarrollo" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                  <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label><strong>Patológicos</strong><br />A. Médicos</label>
                        <asp:TextBox runat="server" ID="txtMedicos" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                  <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label>B. Quirúrgicos </label>
                        <asp:TextBox runat="server" ID="txtQuirurgicos" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                  <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label>C. Traumáticos</label>
                        <asp:TextBox runat="server" ID="txtTraumaticos" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                  <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label>D. Alérgicos</label>
                        <asp:TextBox runat="server" ID="txtAlergicos" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
               <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label>Revisión Por sistemas</label>
                        <asp:TextBox runat="server" ID="txtRevisionPorSistemas" TextMode="MultiLine" style="width:100%"></asp:TextBox>
                    </div>
                </div>
          </div>
      </div>
    </div>

    <div class="row">
        <div class="col-lg-2">
            <div class="form-group">
                <label>&nbsp;</label><br />
                <asp:LinkButton runat="server" ID="btnGrabar" CssClass="btn btn-primary" OnClick="btnGrabar_Click">Grabar &nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
            </div>

        </div>
    </div>
    <div class="col-lg-6 centrar row">
        <div class="col-lg-12 ">

            

        </div>
    </div>
</asp:Content>

