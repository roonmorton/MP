<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="psicologiaAcompanante.aspx.cs" Inherits="vistas_psicologiaAcompanante" %>

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
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Edad</label>
            <asp:TextBox runat="server" ID="txtEdad" CssClass="numero"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Relación con el niño</label>
            <asp:DropDownList runat="server" ID="cboRelacionConNino">
            </asp:DropDownList>
         </div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Proceso</label>
            <asp:RadioButtonList runat="server" ID="rbProceso">
            </asp:RadioButtonList>
         </div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Tipo intervención</label>
            <asp:DropDownList runat="server" ID="cboIntervencion">
            </asp:DropDownList>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Adherencia</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     ¿Es adherente?</label>
                  <asp:RadioButtonList runat="server" ID="rbEsAdherente">
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Comprensión de información VIH según la edad</label>
                  <asp:RadioButtonList runat="server" ID="rbComprensionVIHSegunEdad">
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Afrontamiento de la enfermedad</label>
                  <asp:RadioButtonList runat="server" ID="rbAfrontamientoEnfermedad">
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Alertas afectivas</label>
                  <asp:RadioButtonList runat="server" ID="rbAlertasAfectivas">
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Tipo de alerta afectiva</label>
                  <asp:DropDownList runat="server" ID="cboTipoAlertaAfectiva">
                  </asp:DropDownList>
               </div>
            </div>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Test aplicados</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
               <div class="form-group">
                  <label>
                     Minimental</label>
                  <asp:RadioButtonList runat="server" ID="rbMinimental">
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
               <div class="form-group">
                  <label>
                     Depresión</label>
                  <asp:RadioButtonList runat="server" ID="rbDepresion">
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
               <div class="form-group">
                  <label>
                     Ansiedad</label>
                  <asp:RadioButtonList runat="server" ID="rbAnsiedad">
                  </asp:RadioButtonList>
               </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
               <div class="form-group">
                  <label>
                     Autoestima</label>
                  <asp:RadioButtonList runat="server" ID="rbAutoestima">
                  </asp:RadioButtonList>
               </div>
            </div>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkNuevo" CssClass="btn btn-warning width100"
            OnClick="lnkNuevo_Click">Nueva visita</asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkGuardar" CssClass="btn btn-primary width100"
            OnClick="lnkGuardar_Click">Guardar</asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" CssClass="btn btn-danger width100"
            OnClick="lnkCerrar_Click">Cerrar</asp:LinkButton>
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
                  <asp:Label ID="lblIdpsicologiaAcompanante" runat="server" Text='<%# Bind("idNutricionMenores") %>'></asp:Label>
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
