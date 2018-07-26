<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="biologiaMolecular.aspx.cs" Inherits="vistas_biologiaMolecular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de muestra(*)</label>
            <asp:TextBox runat="server" ID="txtFechaMuestra" CssClass="fecha"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-12">
          <div class="form-group">
            <label>
               Fecha de análisis(*)</label>
            <asp:TextBox runat="server" ID="txtFechaAnalisis" CssClass="fecha"></asp:TextBox>
         </div>
      </div>
   </div>
      <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Muestra</label>
            <asp:TextBox runat="server" ID="txtMuestra" CssClass="numero"></asp:TextBox>
         </div>
      </div>
  
   </div>
         <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               PCR Mycobacterium tuberculosis</label>
            <asp:TextBox runat="server" ID="txtPCRMycobacterium" CssClass="numero"></asp:TextBox>
         </div>
      </div>
  
   </div>
    <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               PCR Histoplasma capsulatum</label>
            <asp:TextBox runat="server" ID="txtPCRHistoplasma" CssClass="numero"></asp:TextBox>
         </div>
      </div>
  
   </div>

       <div class="row">
    <div class="col-lg-2">
      <asp:LinkButton runat="server" id="lnkNuevo" CssClass="btn btn-warning width100" onclick="lnkNuevo_Click" 
         >Nueva</asp:LinkButton>
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
                  <asp:Label ID="lblIdBiologiaMolecular" runat="server" Text='<%# Bind("idBiologiaMolecular") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaMuestra" DataFormatString="{0:d}" 
               HeaderText="Fecha de muestra" />
               <asp:BoundField DataField="FechaAnalisis" DataFormatString="{0:d}" 
               HeaderText="Fecha de análisis" />
               <asp:BoundField DataField="muestra" DataFormatString="{0:F}" 
               HeaderText="muestra" />
                <asp:BoundField DataField="PCRMycobacteriumTuberculosis" DataFormatString="{0:F}" 
               HeaderText="PCR Mycobacterium Tuberculosis" />
                <asp:BoundField DataField="PCRHistoplasmaCapsulatum" DataFormatString="{0:F}" 
               HeaderText="PCR Histoplasma Capsulatum" />
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

