<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="psicologiaMenores.aspx.cs" Inherits="vistas_psicologiaMenores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de visita (*)</label>
            <asp:TextBox ID="txtFechaVisita" CssClass="fecha" runat="server" onblur="javascript:if(this.value!='') __doPostBack('txtFechaVisita','')"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="panel panel-primary">
      <div class="panel-heading">
         Desarrollo de habilidades y capacidades</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Edad de desarrollo</label>
                  <asp:TextBox ID="txtEdadDesarrollo" runat="server"></asp:TextBox>
               </div>
            </div>
               <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                  Area motora gruesa</label>
                  <asp:TextBox ID="txtAreaMotoraGruesa" runat="server"></asp:TextBox>
               </div>
            </div>
               <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Area de lenguaje</label>
                  <asp:TextBox ID="txtAreaDeLenguaje" runat="server"></asp:TextBox>
               </div>
            </div>
         </div>

          <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Area motorofina</label>
                  <asp:TextBox ID="txtAreaMotorofina" runat="server"></asp:TextBox>
               </div>
            </div>

                <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Area social afectiva</label>
                  <asp:TextBox ID="txtAreaSocialAfectiva" runat="server"></asp:TextBox>
               </div>
            </div>

                <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Area cognoscitiva</label>
                  <asp:TextBox ID="txtAreaCognoscitiva" runat="server"></asp:TextBox>
               </div>
            </div>

      </div>


        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                     Area hábitos de salud e higiene</label>
                  <asp:TextBox ID="txtAraHabitosSaludHigiene" runat="server"></asp:TextBox>
               </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                    Aprendizaje</label>
                     <asp:RadioButtonList runat="server" ID="rbAprendizaje" 
                     RepeatDirection="Horizontal" AutoPostBack="True" 
                     onselectedindexchanged="rbAprendizaje_SelectedIndexChanged">
                     <asp:ListItem Value="1">Sí</asp:ListItem>
                     <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
               </div>
            </div>

                 <div class="col-lg-4 col-md-4 col-sm-12">
               <div class="form-group">
                  <label>
                    Tipo de problema</label>
                  <asp:DropDownList ID="cboTipoProblema" runat="server" Enabled="False"></asp:DropDownList>
               </div>
            </div>

            </div>   
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Finalización del proceso</label>
            <asp:TextBox ID="txtFinalizacionProceso" CssClass="fecha" runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
        <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12">
         <div class="form-group">
            <label>
               Observaciones</label>
            <asp:TextBox ID="txtObservaciones" CssClass="width100"  runat="server" TextMode="MultiLine"></asp:TextBox>
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
                  <asp:Label ID="lblIdPsicologiaMenores" runat="server" Text='<%# Bind("idPsicologiaMenores") %>'></asp:Label>
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
