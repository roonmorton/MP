<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="sintomas.aspx.cs" Inherits="vistas_sintomas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-success">
        <div class="panel-heading">Paciente</div>
        <table class="table">
            <thead>
                <tr>
                    <th>Nombre:</th>
                     <th>NHC:</th>
                     <th>Status:</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><asp:Label ID="lblNombrePaciente" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblNHC" runat="server" Text=""></asp:Label></td>
                    <td>* Definiciones</td>
            </tbody>
        </table>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">Síntomas</div>
        <div class="panel-body">
            <div class="row container">
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Fecha Sintomologia (*)</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" CssClass="fecha" ID="txtFechaSintomologia" placeholder="" required ></asp:TextBox>
                    </div>
                </div>

            </div>
            <ul class="nav nav-tabs">
                <li class="active" id="lnkGeneral" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_generalTab">General</a></li>
                <li id="lnkCardioPulmonar" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_cardioPulmonarTab">Cardio-Pulmonar</a></li>
                <li id="lnkNeurologico" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_neurologicoTab">Neurológico</a></li>
                <li id="lnkMusculoEsqueletico" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_musculoEsqueleticoTab">Músculo-Esquelético</a></li>
                <li id="lnkGastrointestinal" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_gastrointestinalTab">GastroIntestinal</a></li>
                <li id="lnkGenitourinario" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_genitourinarioTab">Genitourinario</a></li>
                <li id="lnkOrganosSentidos" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_organosSentidosTab">Órganos de los sentidos</a></li>
            </ul>

            <div class="tab-content">
                <div id="generalTab" runat="server" class="tab-pane active">

                    <br />
                    <asp:CheckBoxList ID="cBoxListGeneral" runat="server" OnSelectedIndexChanged="cBoxListGeneral_SelectedIndexChanged">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroGeneral" runat="server" ></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="cardioPulmonarTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cBoxListPulmonar" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroCardioPulmonar" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="neurologicoTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cBoxListNeurologico" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroNeurologico" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="musculoEsqueleticoTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cBoxListMusculoEsqueletico" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroMusculoEsqueletico" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="gastrointestinalTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cboxListGastrointestinal" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroGastroIntestinal" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="genitourinarioTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cBoxListGenitoUrinario" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroGenitoUnirnario" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <div id="organosSentidosTab" runat="server" class="tab-pane fade">
                    <br />
                    <asp:CheckBoxList ID="cBoxListOrganosSentidos" runat="server">
                    </asp:CheckBoxList>
                    <div class="row container">
                <div class="form-group row">
                    
                    <div class="col-sm-3">
                         <asp:TextBox ID="txtOtroOrganosSentidos" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
                    <br />
                </div>
                <hr />
                <p>(*) Campo requerido</p>
            </div>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">Historico</div>
        <div class="panel-body">
            
        

            <div class="row container">
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Ordenar Historico por</label>
                    <div class="col-sm-3">
                         <asp:TextBox ID="textHistorico" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>


            <br />
            <asp:GridView ID="gridHistoricoSintomologia" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped" >
                 <Columns>
                        <asp:BoundField DataField="idSintomatologia" Visible="True" HeaderText="ID Sintomatologia"/>
                        <asp:BoundField DataField="FechaSintomatologia" HeaderText="Fecha Sintomatología" />
                        <asp:BoundField DataField="sintomas" HeaderText="Síntomas" />
                        <asp:BoundField DataField="Otros" HeaderText="Otros Sintomas" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditSintomatologia" runat="server"  OnClick="lnkEditSintomatologia_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp;Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
        </div>
    </div>

    <br />
    <asp:Button ID="btnNuevaSintomologia" runat="server" Text="Nueva Sintomologia" CssClass="btn btn-success" OnClick="btnNuevaSintomologia_Click" />
    <asp:Button ID="btnGuardarSintomologia" runat="server" Text="Guardar" CssClass="btn btn-info " OnClick="btnGuardarSintomologia_Click"  />
    <asp:Button ID="btnCancelarSintomolia" runat="server" Text="Cerrar" CssClass="btn btn-danger" OnClick="btnCancelarSintomolia_Click" />

    <hr />

</asp:Content>

