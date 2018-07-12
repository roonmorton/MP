<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="enfermedades.aspx.cs" Inherits="vistas_enfermedades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-3">
         <div class="form-group">
            <label>
               Fecha de enfermedad (*)</label>
            <asp:TextBox ID="txtFechaEnfermedad" CssClass="fecha" runat="server">
            </asp:TextBox>
         </div>
      </div>
      <div class="col-lg-9 col-md-9 col-sm-9">
         <div class="form-group">
            <label>
               Tipo de enfermedad (*)</label>
            <asp:RadioButtonList ID="rbTipoEnfermedad" runat="server" AutoPostBack="True" 
               onselectedindexchanged="chkTipoEnfermedad_SelectedIndexChanged" 
               RepeatDirection="Horizontal">
            </asp:RadioButtonList>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12">
         <div class="form-group">
            <label>
               Enfermedad (*)</label>
            <asp:DropDownList ID="cboEnfermedad" runat="server">
            </asp:DropDownList>
         </div>
      </div>
   </div>
   <div class="row">
   </div>
   <div class="row">
      <div class="col-lg-2 col-md-12 col-sm-2">
         <div class="form-group">
            <label>
               Tratada(*)</label>
            <asp:DropDownList ID="cboTratada" runat="server">
            </asp:DropDownList>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-4">
         <div class="form-group">
            <label>
               Estado de la enfermedad(*)</label>
            <asp:DropDownList ID="cboEstadoEnfermedad" runat="server">
            </asp:DropDownList>
         </div>
      </div>
      <div class="col-lg-6 col-md-6 col-sm-6">
      </div>
   </div>
   <div class="row">
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkNuevo" 
            CssClass="btn btn-warning width100" onclick="lnkNuevo_Click">Nueva Enfermedad &nbsp;<i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkGuardar" 
            CssClass="btn btn-primary width100" onclick="lnkGuardar_Click">Guardar&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" 
            CssClass="btn btn-danger width100" onclick="lnkCerrar_Click">Cerrar &nbsp; <i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
      </div>
   </div>
   <div class="row">
      <asp:GridView runat="server" ID="grdEnfermedades" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover width100">
         <Columns>
            <asp:TemplateField HeaderText="ID" Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IDEnfermedadPaciente") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdEnfermedadPaciente" runat="server" Text='<%# Bind("IDEnfermedadPaciente") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Fecha de enfermedad" DataField="fechaEnfermedad" DataFormatString="{0:d}" />
            <asp:BoundField HeaderText="Enfermedad" DataField="Enfermedad" />
            <asp:BoundField HeaderText="Tipo de Enfermedad" DataField="TipoEnfermedad" />
            <asp:BoundField HeaderText="Tratada" DataField="Tratada" />
            <asp:BoundField HeaderText="Estado Enfermedad" DataField="Estado" />
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
