<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="cd4cd8cv.aspx.cs" Inherits="vistas_cd4cd8cv" %>

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
   <div class="panel panel-primary">
      <div class="panel-heading">
         CD4 y CD8</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD4(cel/µl)</label>
                  <asp:TextBox runat="server" ID="txtCD4" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD8(cel/µl)</label>
                  <asp:TextBox runat="server" ID="txtCD8" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD3(cel/µl)</label>
                  <asp:TextBox runat="server" ID="txtCD3" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD4/CD8</label>
                  <asp:TextBox runat="server" ID="txtCd4Cd8" CssClass="numero"></asp:TextBox>
               </div>
            </div>
         </div>

          <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD4(%)</label>
                  <asp:TextBox runat="server" ID="txtCD4P" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-12">
               <div class="form-group">
                  <label>
                     CD8(%)</label>
                  <asp:TextBox runat="server" ID="txtCD8P" CssClass="numero"></asp:TextBox>
               </div>
            </div>

      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Carga Viral</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     VIH Carga viral RNA(copias/ml)</label>
                  <asp:TextBox runat="server" ID="txtCVRNA" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     VIH Carga Viral (Log 10)</label>
                  <asp:TextBox runat="server" ID="txtCVLog10" CssClass="numero"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     CV(copias/ml)</label>
                  <asp:TextBox runat="server" ID="txtCV" CssClass="numero"></asp:TextBox>
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
   <div class="col-lg-12 col-md-12 col-sm-12">
      <asp:GridView runat="server" ID="grdExistentes" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdCd4cd8cv" runat="server" Text='<%# Bind("idCD4CD8CV") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaAnalitica" DataFormatString="{0:d}" HeaderText="Fecha analítica" />
            <asp:BoundField DataField="cd4" DataFormatString="{0:F}" HeaderText="CD4(cel/µl)" />
            <asp:BoundField DataField="CV" DataFormatString="{0:F}" HeaderText="CV" />
            <asp:BoundField DataField="cd8" DataFormatString="{0:F}" HeaderText="CD8(cel/µl)" />
            <asp:BoundField DataField="cd3" DataFormatString="{0:F}" HeaderText="CD3(cel/µl)" />
            <asp:BoundField DataField="cd4cd8" DataFormatString="{0:F}" HeaderText="CD4/CD8" />
            <asp:BoundField DataField="CVRNA" DataFormatString="{0:F}" HeaderText="CV RNA" />
            <asp:BoundField DataField="CVLog10" DataFormatString="{0:F}" HeaderText="CV Log10" />
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server" OnClick="lnkModificar_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkEliminar" runat="server" OnClientClick="return confirmDelete(this);"
                     OnClick="lnkEliminar_Click">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
      </div>
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
