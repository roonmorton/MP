<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="NutricionAdolescentes.aspx.cs" Inherits="vistas_NutricionAdolescentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de visita(*)</label>
            <asp:TextBox runat="server" ID="txtFechaVisita" CssClass="fecha"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-8 col-md-8 col-sm-12">
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Antropométricos</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Peso (Lbs)</label>
                  <asp:TextBox runat="server" ID="txtPesoLibras" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Peso (Oz)</label>
                  <asp:TextBox runat="server" ID="txtPesoOnzas" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Talla</label>
                  <asp:TextBox runat="server" ID="txtTalla" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     IMC</label>
                  <asp:TextBox runat="server" ID="txtIMC" CssClass="numero" Enabled ="false"></asp:TextBox>
               </div>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  P/T z score</label>
               <asp:TextBox runat="server" ID="txtPT" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalPT" CssClass="numero">
               </asp:DropDownList>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  T/E z score</label>
               <asp:TextBox runat="server" ID="txtTE" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalTE" CssClass="numero">
               </asp:DropDownList>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  P/E Z score</label>
               <asp:TextBox runat="server" ID="txtPe" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalPE" CssClass="numero">
               </asp:DropDownList>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  IMC Z score</label>
               <asp:TextBox runat="server" ID="txtIMCZ" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalIMCZ" CssClass="numero">
               </asp:DropDownList>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="form-group">
               <label>
                  CMB (cms. %)</label>
               <asp:TextBox runat="server" ID="txtCMB" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="form-group">
               <label>
                  Ccintura (cms.)</label>
               <asp:TextBox runat="server" ID="txtCcintura" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="form-group">
               <label>
                  Ccadera (cms.)</label>
               <asp:TextBox runat="server" ID="txtCcadera" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="form-group">
               <label>
                  CP (cms.)</label>
               <asp:TextBox runat="server" ID="txtCP" CssClass="numero"></asp:TextBox>
            </div>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Clínicos</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Ganancia de peso</label>
                  <asp:RadioButtonList runat="server" ID="rbGananciaPeso" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Pérdida de peso</label>
                  <asp:RadioButtonList runat="server" ID="rbPerdidaPeso" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Pérdida de Apetito</label>
                  <asp:RadioButtonList runat="server" ID="rbPerdidaApetito" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Síndrome de desgaste</label>
                  <asp:RadioButtonList runat="server" ID="rbSindromeDesgaste" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Diarrea</label>
                  <asp:RadioButtonList runat="server" ID="rbDiarrea" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Náusea</label>
                  <asp:RadioButtonList runat="server" ID="rbNausea" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Vómitos</label>
                  <asp:RadioButtonList runat="server" ID="rbVomito" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Alteraciones Metabólicas</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Presenta problemas con metabolismo de las grasas</label>
                  <asp:RadioButtonList runat="server" ID="rbProblemasMetabolismoGrasas" RepeatDirection="Horizontal"
                     AutoPostBack="true">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Triglicéridos elevados</label>
                  <asp:RadioButtonList runat="server" ID="rbTrigliceridosElevados" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     HDL Elevado</label>
                  <asp:RadioButtonList runat="server" ID="rbHdlElevado" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Colesterol elevado</label>
                  <asp:RadioButtonList runat="server" ID="rbColesterolElevado" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     LDL elevado</label>
                  <asp:RadioButtonList runat="server" ID="rbLDLElevado" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Resistencia a insulina o diabetes</label>
                  <asp:RadioButtonList runat="server" ID="rbResistenciaInsulina" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Presenta lipodistrofia</label>
                  <asp:RadioButtonList runat="server" ID="rbPResentaLipodistrofia" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Lipoatrofia</label>
                  <asp:RadioButtonList runat="server" ID="rbLipoatrofia" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Lipohipertrofia</label>
                  <asp:RadioButtonList runat="server" ID="rbLipohipertrofia" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Mixta</label>
                  <asp:RadioButtonList runat="server" ID="rbMixta" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Dietéticos</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Dieta cubre requerimientos nutricionales</label>
                  <asp:RadioButtonList runat="server" ID="rbDietaCubreRequerimientos" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Hábitos alimentarios adecuados</label>
                  <asp:RadioButtonList runat="server" ID="rbHabitosAlimentariosAdecuados" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Realiza actividad física</label>
                  <asp:RadioButtonList runat="server" ID="rbRealizaActividadFisica" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Intervención nutricional</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Dieta</label>
                  <asp:DropDownList runat="server" ID="cboDieta" RepeatDirection="Horizontal">
                  </asp:DropDownList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Suplemento nutricional</label>
                  <asp:RadioButtonList runat="server" ID="rbSuplementoNutricional" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
                              <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Multivitamínico</label>
                  <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem  Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>

                              <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     EducacionNutricional</label>
                  <asp:RadioButtonList runat="server" ID="rbEducacionNutricional" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem  Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>

            </div>


      </div>
   </div>
   <div class="row">
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkNuevo" CssClass="btn btn-warning width100" OnClick="lnkNuevo_Click"
            >Nueva visita</asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkGuardar" CssClass="btn btn-primary width100" OnClick="lnkGuardar_Click"
            >Guardar</asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" CssClass="btn btn-danger width100" OnClick="lnkCerrar_Click"
           >Cerrar</asp:LinkButton>
      </div>
   </div>
   <div class="row">
      <asp:GridView runat="server" ID="grdExistentes" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdNutricionMayores" runat="server" Text='<%# Bind("idNutricionMayores") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaVisita" DataFormatString="{0:d}" HeaderText="Fecha" />
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server" OnClick="lnkModificar_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkEliminar" runat="server" OnClientClick="return confirmDelete(this);"
                    >  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
   </div>
   <script>
      function confirmDelete(sender) {
         if ($(sender).attr("confirmed") == "true") { return true; }

         bootbox.confirm("¿Confirma que desea continuar?, no podrá deshacer esta operación", function (confirmed) {
            if (confirmed) {
               $(sender).attr('confirmed', confirmed);
               sender.click();
            }
         });

         return false;
      }
   </script>
</asp:Content>
