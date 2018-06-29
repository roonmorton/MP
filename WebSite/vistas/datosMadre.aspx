<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="datosMadre.aspx.cs" Inherits="vistas_datosMadre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Madre positiva</label>
                <asp:DropDownList runat="server" ID="cboMadrePositiva"></asp:DropDownList>
            </div>
         </div>
                <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>NHC</label>
              <asp:TextBox runat="server" ID="txtNHC"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Fecha DX</label>
                <asp:TextBox runat="server" CssClass="fecha" ID="txtFechaDx"></asp:TextBox>
            </div>
         </div>
 
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Momento DX</label>
                <asp:DropDownList runat="server" ID="cboMomentoDx"></asp:DropDownList>
            </div>
         </div>

    </div>
      <div class="row">
        <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Seguimiento</label>
                <asp:DropDownList runat="server" ID="cboSeguimiento" AutoPostBack="true"></asp:DropDownList>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Lugar seguimiento</label>
                <asp:DropDownList runat="server" ID="cboLugarSeguimiento"></asp:DropDownList>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Otro lugar seguimiento</label>
                <asp:TextBox runat="server" ID="txtOtroLugarSeguimiento"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Control prenatal</label>
                <asp:DropDownList runat="server" ID="cboControlPrenatal"></asp:DropDownList>
            </div>
         </div>

    </div>
      <div class="row">
        <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Lugar control prenatal</label>
                <asp:DropDownList runat="server" ID="cboLugarControlPrenatal"></asp:DropDownList>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Complicación embarazo</label>
                <asp:TextBox runat="server" ID="txtComplicacionEmbarazo"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>TARGA Embarazo</label>
                <asp:DropDownList runat="server" ID="cboTARGAEmbarazo"></asp:DropDownList>
            </div>
         </div>
           <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Esquema TARGA</label>
                <asp:DropDownList runat="server" ID="cboEsquemaTarga"></asp:DropDownList>
            </div>
         </div>
     

    </div>
      <div class="row">
           <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Inicio TARGA</label>
                <asp:DropDownList runat="server" ID="cboMomentoInicioTarga"></asp:DropDownList>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Última CV</label>
                <asp:TextBox runat="server" CssClass="numero" ID="txtUltimaCv"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>Último CD4</label>
                  <asp:TextBox runat="server" CssClass="numero" ID="txtUltimoCd4"></asp:TextBox>
            </div>
         </div>
         <div class="col-lg-3 col-md-3 col-s-12">
            <div class="form-group">
                <label>EG al momento CV CD4</label>
                <asp:TextBox runat="server" CssClass="numero" ID="txtEdadGestacionalCVCD4"></asp:TextBox>
            </div>
         </div>

    </div>
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-12 width100">
            <asp:LinkButton CssClass="btn btn-primary" runat="server">Grabar &nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
        </div>

    </div>
</asp:Content>

