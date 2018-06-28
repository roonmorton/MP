<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="inicio.aspx.cs" Inherits="vistas_inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-6 centrar row">
            <div class="col-lg-8 ">
                <div class="form-group">
                    <label>Criterio de búsqueda (NHC HR, NHC PD, Nombres, Apellidos)</label>
                    <asp:TextBox runat="server" ID="txtBusqueda" placeholder="Buscar"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>&nbsp;</label><br />
                    <asp:LinkButton runat="server" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click">Buscar &nbsp;<i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                </div>

            </div>
              
            <div class="col-lg-2">
                <div class="form-group">
                    <label>&nbsp;</label><br />
                    <asp:LinkButton runat="server" ID="lnkNuevoPaciente" CssClass="btn btn-primary" OnClick="lnkNuevoPaciente_Click" >Nuevo Paciente &nbsp;<i class="fa fa-wheelchair" aria-hidden="true"></i></asp:LinkButton>
                </div>

            </div>
        </div>
    </div>
    <div class="col-lg-6 centrar row">
        <div class="col-lg-12 ">

            <asp:GridView ID="grdPacientes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed table-hover table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="IdPaciente" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idPaciente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblIdPaciente" runat="server" Text='<%# Bind("idPaciente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ExpedienteHR" HeaderText="Expediente HR" />
                    <asp:BoundField DataField="ExpedientePD" HeaderText="Expediente PD" />
                    <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                    <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                    <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="Baja" HeaderText="Baja" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkNuevaVisita" runat="server" OnClick="lnkNuevaVisita_Click">Nueva visita &nbsp; <i class="fa fa-plus-circle" aria-hidden="true"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkVerPaciente" runat="server" OnClick="lnkVerPaciente_Click">Ver Paciente &nbsp; <i class="fa fa-binoculars" aria-hidden="true"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>

