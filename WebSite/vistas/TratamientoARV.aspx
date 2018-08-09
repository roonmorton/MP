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
                        <label>ARV(*)</label>
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
                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>UnidadesEntregadas</label>
                       <asp:TextBox runat="server" ID="txtUnidadesEntregadas" CssClass="numero"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Unidades devueltas</label>
                        <asp:TextBox runat="server" ID="txtUnidadesDevueltas"  CssClass="numero"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>&nbsp;</label>
                         <asp:LinkButton runat="server" CssClass="btn btn-success width100" ID="btnCalcularAdherencia" OnClick="btnCalcularAdherencia_Click">Calcular adherencia</asp:LinkButton>
                    </div>
                    
                </div>

                    <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Adherencia</label>
                         <asp:DropDownList runat="server" ID="cboAdherencia" ></asp:DropDownList>
                    </div>
                    
                </div>

            </div>

            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
<asp:LinkButton runat="server"  ID="btnComprobarEsquema" CssClass="btn btn-default width100" >Comprobar esquema</asp:LinkButton>
                </div>
                 
                 <div class="col-lg-2 col-md-2 col-sm-12">
                     <asp:LinkButton runat="server"  ID="btnFinalizarTTM" CssClass="btn btn-default width100">Finalizar TTM</asp:LinkButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-12">
                     <asp:LinkButton runat="server"  ID="btnEfectosSecundarios" CssClass="btn btn-default width100">Efectos secundarios</asp:LinkButton>
                </div>

                 <div class="col-lg-1 col-md-1 col-sm-12">

                </div>
                 <div class="col-lg-2 col-md-2 col-sm-12">
                     
                     <asp:LinkButton runat="server"  ID="BtnGrabar"  CssClass="btn btn-primary width100">Aceptar</asp:LinkButton>
               
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-12">
                      
                     <asp:LinkButton runat="server"  ID="btnCancelar"  CssClass="btn btn-default width100">cancelar</asp:LinkButton>
               
                </div>

            </div>

        </div>
    </div>
    <br />
    <h3>Esquema Actual</h3>
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
                  <asp:Label ID="lblIdArvActual" runat="server" Text='<%# Bind("idCoprologia") %>'></asp:Label>
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
                  <asp:LinkButton ID="lnkEliminarActual" runat="server" 
                     OnClientClick="return confirmDelete(this);" onclick="lnkEliminarActual_Click">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
            </div> 
        
    </div>

    <br />
    <h3>Esquemas Anteriores</h3>
    <div class="row">
        
            <div class="col-lg-12 col-md-12 col-sm-12">
                      <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField Visible="False">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" 
                     Text=""></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                  <asp:Label ID="lblIdArvAnterior" runat="server" Text='<%# Bind("idCoprologia") %>'></asp:Label>
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
                  <asp:LinkButton ID="lnkEliminar" runat="server" 
                     OnClientClick="return confirmDelete(this);" onclick="lnkEliminar_Click">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
            </div> 
        
    </div>

</asp:Content>

