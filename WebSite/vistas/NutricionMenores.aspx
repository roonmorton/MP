<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="NutricionMenores.aspx.cs" Inherits="vistas_NutricionMenores" %>

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
                     Peso (Lbs o Kg)</label>
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
                     Circunferencia cefálica cms.</label>
                  <asp:TextBox runat="server" ID="txtCircunferenciaCefalica" CssClass="numero"></asp:TextBox>
               </div>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  P/L z score</label>
               <asp:TextBox runat="server" ID="txtPl" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalPL" CssClass="numero">
               </asp:DropDownList>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
               <label>
                  L/E z score</label>
               <asp:TextBox runat="server" ID="txtLe" CssClass="numero"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalLE" CssClass="numero">
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
                  CC/E Z score</label>
               <asp:TextBox runat="server" ID="txtCCE" CssClass="numero"></asp:TextBox>
            </div>
         </div>
          <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="form-group">
               <label>
                  Diagnóstico nutricional</label>
               <asp:DropDownList runat="server" ID="cboDiagnosticoNutricionalCCE" CssClass="numero">
               </asp:DropDownList>
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
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Pérdida de peso</label>
                  <asp:RadioButtonList runat="server" ID="rbPerdidaPeso" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Vómitos</label>
                  <asp:RadioButtonList runat="server" ID="tbVomito" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
            </div>
         </div>
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Diarrea</label>
                  <asp:RadioButtonList runat="server" ID="rbDiarrea" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Estreñimiento</label>
                  <asp:RadioButtonList runat="server" ID="rbEstreñmiento" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Reflujo</label>
                  <asp:RadioButtonList runat="server" ID="rbReflujo" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Cólicos</label>
                  <asp:RadioButtonList runat="server" ID="rbColicos" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
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
                     Opción de alimentación elegida</label>
                  <asp:DropDownList runat="server" ID="cboOpcionAlimentacion">
                  </asp:DropDownList>
               </div>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-12">
            </div>
         </div>
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Lactancia materna</label>
                  <asp:DropDownList runat="server" ID="cboLactanciaMaterna">
                  </asp:DropDownList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Tiempo lactancia materna (meses)</label>
                  <asp:TextBox runat="server" ID="txtTiempoLactancia">
                  </asp:TextBox>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Preparación</label>
                  <asp:DropDownList runat="server" ID="cboPreparacion">
                  </asp:DropDownList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     ¿Cómo la obtienen?</label>
                  <asp:DropDownList runat="server" ID="cboComoLaObtienen">
                  </asp:DropDownList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     ¿Leche adecuada para la edad?</label>
                  <asp:RadioButtonList runat="server" ID="rbLecheAdecuada" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Ofrece otros líquidos/alimentos</label>
                  <asp:RadioButtonList runat="server" ID="tbOfreceLiquidosAlimentos" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Lactancia mixta</label>
                  <asp:RadioButtonList runat="server" ID="rbLactanciaMixta" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     Alimentación complementaria</label>
                  <asp:RadioButtonList runat="server" ID="rbAlimentacionComplementaria" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="row">
               <div class="col-lg-3 col-md-3 col-sm-12">
                  <div class="form-group">
                     <label>
                        Edad de ablación</label>
                     <asp:TextBox runat="server" ID="txtEdadAblacion"></asp:TextBox>
                  </div>
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
                    Educación nutricional</label>
                  <asp:RadioButtonList runat="server" ID="rbEducacionNutricional" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>

                    <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                    Multivitamínico</label>
                  <asp:RadioButtonList runat="server" ID="rbMultivitaminico" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>

                    <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                    Fórmula recuperación nutricional</label>
                  <asp:RadioButtonList runat="server" ID="rbFormulaRecuperacion" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
      </div>
   </div>
    <div class="row">
    <div class="col-lg-2">
      <asp:LinkButton runat="server" id="lnkNuevo" CssClass="btn btn-warning width100" onclick="lnkNuevo_Click" 
         >Nueva visita</asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
       <asp:LinkButton runat="server" ID="lnkGuardar" 
            CssClass="btn btn-primary width100" onclick="lnkGuardar_Click"  >Guardar</asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" 
            CssClass="btn btn-danger width100" onclick="lnkCerrar_Click" >Cerrar</asp:LinkButton>
      </div>
   </div>
   <div class="row">
      <asp:GridView runat="server" ID="grdExistentes" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" 
                     Text=""></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdNutricionMenores" runat="server" Text='<%# Bind("idNutricionMenores") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaVisita" DataFormatString="{0:d}" 
               HeaderText="Fecha" />
              <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server" onclick="lnkModificar_Click" ><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkEliminar" runat="server" 
                     OnClientClick="return confirmDelete(this);" onclick="lnkEliminar_Click">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
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
