<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="diagnosticoVIH.aspx.cs" Inherits="vistas_diagnosticoVIH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de diagnóstico(*)</label>
            <asp:TextBox runat="server" ID="txtFechaDiagnóstico" CssClass="fecha" onblur="javascript:if(this.value!='') __doPostBack('fecha','')"></asp:TextBox>
         </div>
      </div>
   </div>

     <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Edad años</label>
            <asp:TextBox runat="server" ID="txtEdadAnos" CssClass="numero" Enabled="false"></asp:TextBox>
         </div>
      </div>
         <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Edad meses</label>
            <asp:TextBox runat="server" ID="txtEdadMes" CssClass="numero" Enabled="false"></asp:TextBox>
         </div>
      </div>
         <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Edad dias</label>
            <asp:TextBox runat="server" ID="txtEdadDias" CssClass="numero" Enabled="false"></asp:TextBox>
         </div>
      </div>
       <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Rango edad</label>
            <asp:DropDownList runat="server" ID="cboRangoEdad" CssClass="numero" Enabled="false"></asp:DropDownList>
         </div>
      </div>
   </div>

    <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
               Grupo transmisión</label>
            <asp:DropDownList runat="server" ID="cboGrupoTransmision" ></asp:DropDownList>
         </div>
      </div>
       <div class="col-lg-3 col-md-3 col-sm-12">
         <div class="form-group">
            <label>
              Motivo de la prueba</label>
           <asp:DropDownList runat="server" ID="cboMotivoDeLaPrueba" ></asp:DropDownList>
         </div>
      </div>
   </div>
    <div class="panel panel-primary">
      <div class="panel-heading">
        Prueba realizada</div>
      <div class="panel-body">
      <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
        <div class="col-lg-4 col-md-4">
            <asp:CheckBox Text="Anticuerpos" runat="server" ID="chkAnticuerpos" 
               Checked="false" AutoPostBack="True" 
               oncheckedchanged="chkAnticuerpos_CheckedChanged" />
        </div>
        <div class="col-lg-8 col-md-8">
        <asp:TextBox runat="server" ID="txtAnticuerpos" Enabled="False"></asp:TextBox>
        </div>
      </div>

      <div class="col-lg-4 col-md-4 col-sm-12">
        <div class="col-lg-4 col-md-4">
            <asp:CheckBox Text="DNA Proviral" runat="server" ID="chkDNAProviral" 
               Checked="false" AutoPostBack="True" 
               oncheckedchanged="chkDNAProviral_CheckedChanged" />
        </div>
        <div class="col-lg-8 col-md-8">
        <asp:TextBox runat="server" ID="txtDnaProviral" Enabled="False"></asp:TextBox>
        </div>
      </div>

      <div class="col-lg-4 col-md-4 col-sm-12">
        <div class="col-lg-4 col-md-4">
            <asp:CheckBox Text="VIH Carga Viral RNA" runat="server" 
               ID="chkVIHCargaViralRNA" Checked="false" AutoPostBack="True" 
               oncheckedchanged="chkVIHCargaViralRNA_CheckedChanged" />
        </div>
        <div class="col-lg-8 col-md-8">
        <asp:TextBox runat="server" ID="txtVIHCargaViralRNA" Enabled="False"></asp:TextBox>
        </div>
      </div>
   
   </div>
   <div class="row">
      <div class="col-md-3 col-lg-3 col-sm-12">
      <div class="form-group">
            <label>
             Tipo de prueba</label>
          <asp:DropDownList runat="server" ID="cboTipoPrueba" ></asp:DropDownList>
          </div>
      </div>

       <div class="col-md-3 col-lg-3 col-sm-12">
         
      </div>

       <div class="col-md-3 col-lg-3 col-sm-12">
           <div class="form-group">
            <label>
              CV</label>
           <asp:TextBox runat="server" ID="txtCV" Enabled="False" ></asp:TextBox>
         </div>
      </div>
       <div class="col-md-3 col-lg-3 col-sm-12">
          <div class="form-group">
            <label>
              VIH Carga Viral Log 10</label>
           <asp:TextBox runat="server" ID="txtVIHCargarViralLog10" Enabled="False" ></asp:TextBox>
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
            CssClass="btn btn-danger width100" onclick="lnkCerrar_Click"  >Cerrar</asp:LinkButton>
      </div>
   </div>

   <div class="row">
   <div class="col-lg-12 col-md-12 col-sm-12">
      <asp:GridView runat="server" ID="grdExistentes" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" 
                     Text=""></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdDiagnosticoVih" runat="server" Text='<%# Bind("idDiagnosticoVih") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" 
               HeaderText="Fecha diagnóstico" />

                <asp:BoundField DataField="edad" HeaderText="Edad" />
                 <asp:BoundField DataField="rangoEdad" HeaderText="Rango edad" />
                  <asp:BoundField DataField="motivoPrueba" HeaderText="Motivo Prueba" />
                   <asp:BoundField DataField="anticuerpos" HeaderText="Anticuerpos" />
                    <asp:BoundField DataField="tipoPrueba" HeaderText="Tipo de Prueba" />
                     <asp:BoundField DataField="DNAProviral" HeaderText="DNA Proviral" />
                      <asp:BoundField DataField="VIHCargaViralRNA" HeaderText="VIH CV (copias ml)" />
                       <asp:BoundField DataField="VIHCargaViralLog10" HeaderText="VIH CV Log 10" />

              <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server" onclick="lnkModificar_Click"  ><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkEliminar" runat="server" 
                     OnClientClick="return confirmDelete(this);" onclick="lnkEliminar_Click" >  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
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

