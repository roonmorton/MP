<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="imagenes.aspx.cs" Inherits="vistas_imagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-4">
         <div class="form-group">
            <label>
               Fecha imagen (*)</label>
            <asp:TextBox runat="server" ID="txtFechaImagen" CssClass="fecha"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4">
         <div class="form-group">
            <label>
               Tipo de imagen (*)</label>
            <asp:DropDownList runat="server" ID="cboTipoImagen" AutoPostBack="True" 
               onselectedindexchanged="cboTipoImagen_SelectedIndexChanged">
            </asp:DropDownList>
         </div>
      </div>
      <div class="col-lg-4">
         <div class="form-group">
            <label>
               ¿Cuál?</label>
            <asp:TextBox runat="server" ID="txtCual" Enabled="False"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
   <div class="col-lg-12">
         <div class="form-group">
            <label>
               Resultado (*)</label>
            <asp:RadioButtonList runat="server" ID="chkListResultado" 
               RepeatDirection="Horizontal">
            </asp:RadioButtonList>
         </div>
      </div>
   </div>

   <div class="row">
      <div class="col-lg-12">
         <div class="form-group">
            <label>
               Alteraciones</label>
            <asp:TextBox runat="server" ID="txtAlteraciones" TextMode="MultiLine" CssClass="width100"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
    <div class="col-lg-2">
      <asp:LinkButton runat="server" id="lnkNuevo" CssClass="btn btn-warning width100" 
          onclick="lnkNuevo_Click">Nueva imagen</asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
       <asp:LinkButton runat="server" ID="lnkGuardar" 
            CssClass="btn btn-primary width100" onclick="lnkGuardar_Click" >Guardar</asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" 
            CssClass="btn btn-danger width100" onclick="lnkCerrar_Click">Cerrar</asp:LinkButton>
      </div>
   </div>
   <div class="row">
      <asp:GridView runat="server" ID="grdExistentes" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" 
                     Text='<%# Bind("idImagenPaciente") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdImagenPaciente" runat="server" Text='<%# Bind("idImagenPaciente") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaImagen" DataFormatString="{0:d}" 
               HeaderText="Fecha" />
            <asp:BoundField DataField="TipoImagen"  
               HeaderText="Tipo" />
            <asp:BoundField DataField="CualOtra" HeaderText="Cual otra" />
            <asp:BoundField DataField="ValorImagen" HeaderText="Valor Imagen" />
            <asp:BoundField DataField="Alteracion" HeaderText="Alteración" />
              <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server" onclick="lnkModificar_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
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
