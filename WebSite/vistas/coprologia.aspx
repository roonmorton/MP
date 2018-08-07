<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="coprologia.aspx.cs" Inherits="vistas_coprologia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de analítica(*)</label>
            <asp:TextBox runat="server" ID="txtFechaAnalitica" CssClass="fecha"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Sangre oculta</label>
            <asp:TextBox runat="server" ID="txtSangreOculta"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Azul de metileno heces</label>
            <asp:TextBox runat="server" ID="txtAzulMetilenoHeces"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Polimorfonucleares(%)</label>
            <asp:TextBox runat="server" ID="txtPolimorfonucleares" CssClass="numero"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Mononucleares(%)</label>
            <asp:TextBox runat="server" ID="txtMononucleares"  CssClass="numero"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Parásitos en heces</label>
            <asp:TextBox runat="server" ID="txtParásitosheces"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Azúcares reductores</label>
            <asp:TextBox runat="server" ID="txtAzucaresReductores"></asp:TextBox>
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
                  <asp:Label ID="lblIdCoprologia" runat="server" Text='<%# Bind("idCoprologia") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaAnalitica" DataFormatString="{0:d}"            
               HeaderText="Fecha" />
                <asp:BoundField DataField="sangreOculta"  HeaderText="Sangre oculta" />
                 <asp:BoundField DataField="azulMetilenoHeces"  HeaderText="Azul de metileno en heces" />
                 <asp:BoundField DataField="polimorfonucleares"   HeaderText="Polimorfonucleares(%)" />
                   <asp:BoundField DataField="mononucleares"   HeaderText="Mononucleares(%)" />
                     <asp:BoundField DataField="paracitosHeces"   HeaderText="Parásitos en heces" />
                       <asp:BoundField DataField="azucaresReductores" HeaderText="Azúcares reductores" />
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
