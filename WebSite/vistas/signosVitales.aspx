<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
   AutoEventWireup="true" CodeFile="signosVitales.aspx.cs" Inherits="vistas_signosVitales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Fecha de visita (*)</label>
            <asp:TextBox ID="txtFechaVisita" CssClass="fecha" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Tipo de visita</label>
            <asp:DropDownList runat="server" ID="cboTipoVisita">
            </asp:DropDownList>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Fecha próxima visita</label>
            <asp:TextBox ID="txtFechaProximaVisita" CssClass="fecha" runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               PA (mmHg)</label>
            <asp:TextBox ID="txtPmHALeft" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               PA (mmHg)</label>
            <asp:TextBox ID="txtPmHARight" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               T(°C)</label>
            <asp:TextBox ID="txtTc" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               FC(lpm)</label>
            <asp:TextBox ID="txtFC" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               FR(rpm)</label>
            <asp:TextBox ID="txtFR" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-2 col-md-2 col-sm-12">
         <div class="form-group">
            <label>
               Sat O2(%)</label>
            <asp:TextBox ID="txtSat" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Talla (cms)</label>
            <asp:TextBox ID="txtTalla" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Peso</label>
            <asp:TextBox ID="txtPeso" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               IMC</label>
            <asp:TextBox Enabled="false" ID="txtImc" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Edad (Años)</label>
            <asp:TextBox ID="txtEdadAnos" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Edad (Meses)</label>
            <asp:TextBox ID="txtEdadMeses" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12">
         <div class="form-group">
            <label>
               Edad (Días)</label>
            <asp:TextBox ID="txtEdadDias" CssClass="numero" runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12">
         <div class="form-group">
            <label>
               Estadío CDC</label>
            <asp:DropDownList ID="cboEstadío" Style="width: auto !important;" runat="server">
            </asp:DropDownList>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12">
         <div class="form-group">
            <label>
               Observaciones</label>
            <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Style="width: 100%!important;"
               runat="server"></asp:TextBox>
         </div>
      </div>
   </div>
   <div class="row">
      <div class="col-lg-2">
      <asp:LinkButton runat="server" id="lnkNuevo" CssClass="btn btn-warning width100">Nueva Visita</asp:LinkButton>
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
      </div>
      <div class="col-lg-2">
       <asp:LinkButton runat="server" ID="lnkGuardar" CssClass="btn btn-primary width100" >Guardar</asp:LinkButton>
      </div>
      <div class="col-lg-2">
         <asp:LinkButton runat="server" ID="lnkCerrar" CssClass="btn btn-danger width100">Cerrar</asp:LinkButton>
      </div>
   </div>
   <div class="row">
      <asp:GridView runat="server" ID="grdSignosVitales" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover width100">
         <Columns>
            <asp:BoundField DataField="IDSignosVitales" HeaderText="ID" />
            <asp:BoundField HeaderText="Fecha de visita" />
            <asp:BoundField HeaderText="Tipo de Visita" />
            <asp:BoundField HeaderText="Peso" />
            <asp:BoundField HeaderText="Estadío" />
            <asp:BoundField HeaderText="IMC" />
            <asp:BoundField HeaderText="Próxima visita" />
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkModificar" runat="server"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:LinkButton ID="lnkEliminar" runat="server" OnClientClick="return confirmDelete(this);">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
   </div>
</asp:Content>
