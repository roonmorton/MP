<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="trabajoSocialAdherencia.aspx.cs" Inherits="vistas_trabajoSocialAdherencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="panel panel-primary">
      <div class="panel-heading">
         A. Situación familiar</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Apoyo familiar estable sin episodios de violencia ni riesgos sociales evidentes
                  (8-10)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtApoyoFamiliarEstable"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Apoyo familiar inestable, al menos un episodio de violencia y/o un riesgo social (5-7)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtApoyoFamiliarInestable"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Ausencia de apoyo familiar, frecuentes episodios de violencia y/o varios riesgos sociales
                  (<4)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtAusenciaApoyoFamiliar"></asp:TextBox>
            </div>
         </div>

      </div>
      </div>

         <div class="panel panel-primary">
      <div class="panel-heading">
         B. Economía</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                 Grupo familiar con trabajo estable, presencia de superávit
                  (8-10)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtGrupoFamiliarTrabajoEstable"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Grupo familiar con trabajo inestable, egresos iguales o similares a ingresos (5-7)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtGrupoFamiliarTrabajoInestable"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                Grupo familiar con trabajo inestable o desempleado, presencia de déficit
                  (<4)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtGrupoFamiliarDesempleado"></asp:TextBox>
            </div>
         </div>

      </div>
      </div>

         <div class="panel panel-primary">
      <div class="panel-heading">
         C. Conocimiento del VIH e importancia de TARGA</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                 Comprende plenamente las generalidades del VIH y la importancia del TARGA
                  (8-10)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtComprendePlenamenteVIH"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Comprende parcialmente las generalidades del VIH y la importancia del TARGA (5-7)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtComprendeParcialmenteVIH"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  No comprende las generalidades del VIH y la importancia del TARGA
                  (<4)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtNoComprendeVIH"></asp:TextBox>
            </div>
         </div>

      </div>
      </div>

               <div class="panel panel-primary">
      <div class="panel-heading">
         D. Aceptación del diagnóstico</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                Ha aceptado su diagnóstico y adaptado su estilo de vida
                  (8-10)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtAceptadoDiagnostico"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                 No ha aceptado plenamente su diagnóstico ni adaptado todo su estilo de vida (5-7)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtNoAceptadoDiagnostico"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-4 col-sm-12">
               <label>
                  
                Aún niega su diagnóstico (<4)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtNiegaDiagnostico"></asp:TextBox>
            </div>
         </div>

      </div>
      </div>
               <div class="panel panel-primary">
      <div class="panel-heading">
         E. Paciente</div>
      <div class="panel-body">
         <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                 Niño
                  (8-10)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtNino"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Adolescente (5-7)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtAdolescente"></asp:TextBox>
            </div>
         </div>
            <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
               <label>
                  Niño/adolescente conflictivo
                  (<4)</label>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-12">
               <asp:TextBox CssClass="numero" runat="server" ID="txtNinoAdolescenteConflictivo"></asp:TextBox>
            </div>
         </div>

      </div>
      </div>
      <div class="row">
       <div class="col-lg-2 col-md-2,col-sm-12">
       <div class="form-group">
         <label>&nbsp;&nbsp;</label><br />
         <asp:LinkButton runat="server" ID="btnCalcularRSAT" class="btn btn-success" 
             onclick="btnCalcularRSAT_Click">Calcular RSAT</asp:LinkButton>
       </div>
       </div>
      <div class="col-lg-8 col-md-12,col-sm-12">
         <div class="form-group">
         <label>CLASIFICACIÓN DE RIESGOS SOCIALES PARA ADHERENCIA AL TARGA (RSAT)</label>
         <asp:DropDownList runat="server" ID="cboRSAT"></asp:DropDownList>
         </div>
      </div>
      </div>

       <div class="row">
      <div class="col-lg-2">
         
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
   <script>
      $(document).ready(function () { 
          
      });      
      
   </script>
</asp:Content>
