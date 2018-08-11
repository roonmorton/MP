<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/MasterPage.master"
    AutoEventWireup="true" CodeFile="LiquidosCorporales.aspx.cs" Inherits="vistas_LiquidosCorporales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-12">
            <div class="form-group">
                <label>
                    Fecha de Analitica (*)</label>
                <asp:TextBox ID="txtFechaAalitica" CssClass="fecha" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>

    <div class="container">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#AnaFisico">Analisis Fisico</a></li>
            <li><a data-toggle="tab" href="#AnaQuimico">Analisis Quimico</a></li>
            <li><a data-toggle="tab" href="#AnaLiquidos">Analisis en Liquidos</a></li>
        </ul>

        <div class="tab-content">
            <div id="AnaFisico" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Liquido</label>
                            <asp:TextBox ID="txtLiquidoFisico" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Aspecto</label>
                            <asp:TextBox ID="txtAspecto" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Volumen (mL)</label>
                            <asp:TextBox ID="txtVolumen" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sedimiento</label>
                            <asp:TextBox ID="txtSedimiento" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Xantocromía</label>
                            <asp:TextBox ID="txtXantocromia" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Leucocitos (cel/mm3)</label>
                            <asp:TextBox ID="txtLeucocitos" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Eritocitos (cel/mm3)</label>
                            <asp:TextBox ID="txtEritocitos" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Polimorfonucleares (%)</label>
                            <asp:TextBox ID="txtPolimorfonucleares" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Mononucleares (%)</label>
                            <asp:TextBox ID="txtMononucleares" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Linfocitos (%)</label>
                            <asp:TextBox ID="txtLinfocitos" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
            <div id="AnaQuimico" class="tab-pane fade">
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Liquido</label>
                            <asp:TextBox ID="txtLiquidoQuimico" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                pH</label>
                            <asp:TextBox ID="txtpH" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Glucosa (mg/dL)</label>
                            <asp:TextBox ID="txtGlocosa" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Proteinas (g/dL)</label>
                            <asp:TextBox ID="txtProteinas" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Albumina (g/dL)</label>
                            <asp:TextBox ID="txtAlbumina" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                LDH (U/l)</label>
                            <asp:TextBox ID="txtLDH" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Amilasia (mg/dL)</label>
                            <asp:TextBox ID="txtAmilasia" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Urea (mg/dL)</label>
                            <asp:TextBox ID="txtUrea" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Acido Úrico (mg/dL)</label>
                            <asp:TextBox ID="txtAcidoUrico" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sodio (mmoI/L)</label>
                            <asp:TextBox ID="txtSodio" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Potasio (mmoI/L)</label>
                            <asp:TextBox ID="txtPotasio" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>


                </div>
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Cloro (mEq/L)</label>
                            <asp:TextBox ID="txtCloro" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Bicarbonato (mmoI/L)</label>
                            <asp:TextBox ID="txtBicarbonato" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                IgG (mg/L)</label>
                            <asp:TextBox ID="txtIgG" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                CK (U/L)</label>
                            <asp:TextBox ID="txtCK" CssClass="numero" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div id="AnaLiquidos" class="tab-pane fade">
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Liquido</label>
                            <asp:TextBox ID="txtLiquidoAntigenos" CssClass="texto" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sifilis (VDRL)</label>
                            <asp:TextBox ID="txtSifilisVDRL" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Dilucion (VDRL) 1/</label>
                            <asp:TextBox ID="txtDilucionVDRL" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sifilis (RPR)</label>
                            <asp:TextBox ID="txtSifilisRPR" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sifilis (RPR) 1/</label>
                            <asp:TextBox ID="txtSifilisRPR1" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sifilis (TPHA)</label>
                            <asp:TextBox ID="txtSifilisTPHA" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Sifilis (FTA-ABS)</label>
                            <asp:TextBox ID="txtSifilisFTAABS" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                S. pneumoniae Ag</label>
                            <asp:TextBox ID="txtsPneumoniae" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                H. Influenza Ag</label>
                            <asp:TextBox ID="txthInfluenza" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                E. Coli Ag</label>
                            <asp:TextBox ID="txteColi" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Cryptococcus Ag</label>
                            <asp:TextBox ID="txtCryptococcus" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>


                </div>
                <div class="row">
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                Dilución 1/</label>
                            <asp:TextBox ID="txtDilucion1" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12">
                        <div class="form-group">
                            <label>
                                ADA (U/L)</label>
                            <asp:TextBox ID="txtAda" CssClass="texto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-2">
            <asp:LinkButton runat="server" ID="lnkNuevo" CssClass="btn btn-warning width100" OnClick="lnkNuevo_Click">Nueva Muestra</asp:LinkButton>
        </div>
        <div class="col-lg-2">
        </div>
        <div class="col-lg-2">
        </div>
        <div class="col-lg-2">
        </div>
        <div class="col-lg-2">
            <asp:LinkButton runat="server" ID="lnkGuardar" CssClass="btn btn-primary width100" OnClick="lnkGuardar_Click">Guardar</asp:LinkButton>
        </div>
        <div class="col-lg-2">
            <asp:LinkButton runat="server" ID="lnkCerrar" CssClass="btn btn-danger width100" OnClick="lnkCerrar_Click">Cerrar</asp:LinkButton>
        </div>
    </div>

    <div class="row">
        <asp:GridView runat="server" ID="grdLiquidosCorporales" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover width100">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idLiquidosCorporales") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblidLiquidosCorporales" runat="server" Text='<%# Bind("idLiquidosCorporales") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Fecha Analitica" DataField="FechaAnalitica" DataFormatString="{0:d}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" OnClick="lnkModificar_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp; Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" OnClientClick="return confirmDelete(this);" OnClick="lnkEliminar_Click">  <i class="fa fa-trash" aria-hidden="true"></i>  Eliminar</asp:LinkButton>
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

