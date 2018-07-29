<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="tratamientoARV.aspx.cs" Inherits="vistas_tratamientoARV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Esquema Actual
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Fecha Inicio(*)</label>
                        <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="fecha"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>ARV</label>
                        <asp:DropDownList runat="server" ID="cboArv" ></asp:DropDownList>
                    </div>
                    
                </div>

                 <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Tipo</label>
                        <asp:TextBox runat="server" ID="txtTipo" Enabled="false"></asp:TextBox>
                    </div>
                    
                </div>

            </div>

             <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Dosis (mg)</label>
                        <asp:TextBox runat="server" ID="txtDosis" CssClass="numero"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Presentación</label>
                        <asp:DropDownList runat="server" ID="cboPresentacion" ></asp:DropDownList>
                    </div>
                    
                </div>

                 <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Vía de administración</label>
                         <asp:DropDownList runat="server" ID="cboViaAdministracion" ></asp:DropDownList>
                    </div>
                    
                </div>

            </div>


             <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Frecuencia</label>
                       <asp:DropDownList runat="server" ID="cboFrecuencia" ></asp:DropDownList>
                    </div>
                    
                </div>

                 <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Proveedor</label>
                        <asp:DropDownList runat="server" ID="cboProveedor" ></asp:DropDownList>
                    </div>
                    
                </div>

                 <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Genérico</label>
                         <asp:DropDownList runat="server" ID="cboGenerico" ></asp:DropDownList>
                    </div>
                    
                </div>

            </div>

                <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>UnidadesEntregadas</label>
                       <asp:TextBox runat="server" ID="txtUnidadesEntregadas" CssClass="numero"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Unidades devueltas</label>
                        <asp:TextBox runat="server" ID="txtUnidadesDevueltas"  CssClass="numero"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>&nbsp;</label>
                         <asp:LinkButton runat="server" CssClass="btn" btn-primary" ID="btnCalcularAdherencia">CAlcular adherencia</asp:LinkButton>
                    </div>
                    
                </div>

                    <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Adherencia</label>
                         <asp:DropDownList runat="server" ID="cboAdherencia" ></asp:DropDownList>
                    </div>
                    
                </div>

            </div>

            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
<asp:LinkButton runat="server"  ID="btnComprobarEsquema">Comprobar esquema</asp:LinkButton>
                </div>
                 
                 <div class="col-lg-2 col-md-2 col-sm-12">
                     <asp:LinkButton runat="server"  ID="btnFinalizarTTM">Finalizar TTM</asp:LinkButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-12">
                     <asp:LinkButton runat="server"  ID="btnEfectosSecundarios">Efectos secundarios</asp:LinkButton>
                </div>

                 <div class="col-lg-1 col-md-1 col-sm-12">

                </div>
                 <div class="col-lg-2 col-md-2 col-sm-12">
                     <div class="col-lg-2 col-md-2 col-sm-12">
                     <asp:LinkButton runat="server"  ID="BtnGrabar">Aceptar</asp:LinkButton>
                </div>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-12">

                </div>

            </div>

        </div>
    </div>

</asp:Content>

