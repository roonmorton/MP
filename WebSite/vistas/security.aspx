<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/masterPage/inicio.master" AutoEventWireup="true" CodeFile="security.aspx.cs" Inherits="vistas_security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  

    <ul class="nav nav-tabs">
        <li id="lnkRoles" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_rolesTab">Roles</a></li>
        <li id="lnkAccesos" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_accesosTab">Acceso a Pantallas</a></li>
        <li id="lnkUsuarios" runat="server"><a data-toggle="tab" href="#ctl00_ContentPlaceHolder1_usuariosTab">Usuarios</a></li>
    </ul>

    <div class="tab-content">
        <div id="usuariosTab" runat="server" class="tab-pane fade">
            <h3>Usuarios
            </h3>
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nombre de la persona (*)</label>
                        <asp:TextBox runat="server" ID="txtNombrePersona" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Usuario (*)</label>
                        <asp:TextBox runat="server" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Contraseña(*)</label>
                        <asp:TextBox runat="server" ID="txtPassword" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Repita Contraseña(*)</label>
                        <asp:TextBox runat="server" ID="txtPassword2" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Rol (*)</label>
                        <asp:DropDownList runat="server" ID="cboRolUsuario"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Activo</label>
                        <asp:CheckBox runat="server" ID="chkActivo"></asp:CheckBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12">
                    <div class="form-group">
                        <label>Cambiar contraseña</label>
                        <asp:CheckBox runat="server" ID="chkReiniciarPassword"></asp:CheckBox>
                    </div>
                </div>
              </div>

            <div class="row">
                  <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Fotografía</label>
                        <asp:FileUpload CssClass="file" runat="server" ID="imagenLoad"></asp:FileUpload>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12">

                    <asp:Image  runat="server" ID="imgUsuario" CssClass="img-responsive img-circle" alt="imagen de usuario" style="width:128px;height:128px; margin:auto; position:relative;float:none; text-align:center;"/>
                </div>
            </div>

            <div class="row">

                <div class="col-lg-1 col-md-1 col-sm-12">
                    <asp:LinkButton runat="server" ID="btnGrabarUsuarios" CssClass="btn btn-primary" OnClick="btnGrabarUsuarios_Click">Grabar&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                </div>
                  <div class="col-lg-1 col-md-1 col-sm-12">
                    <asp:LinkButton runat="server" ID="btnNuevoUsuario" CssClass="btn btn-info" OnClick="btnNuevoUsuario_Click">Nuevo&nbsp;<i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                </div>

            </div>


            <div class="row">
                <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped">
                    <Columns>
                        <asp:BoundField DataField="idUsuario" HeaderText="idusuario" />
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre" />
                          <asp:BoundField DataField="rol" HeaderText="Rol" />
                        <asp:BoundField DataField="Activo" HeaderText="Activo" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditUsuario" runat="server" OnClick="lnkEditUsuario_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp;Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>


        </div>


        <div id="rolesTab" class="tab-pane fade" runat="server">
            <h3>Roles</h3>
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-12">
                    <div class="form-group">
                        <label>Nombre Rol  (*)</label>
                        <asp:TextBox runat="server" ID="txtNombreRol" placeholder="NombreRol"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="form-group">
                        <label>Descripcion</label>
                        <asp:TextBox runat="server" ID="txtDescripcionRol" Style="width: 100%;" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-1 col-md-1 col-sm-12">
                    <asp:LinkButton runat="server" ID="btnGrabarRoles" CssClass="btn btn-primary" OnClick="btnGrabarRoles_Click">Grabar&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                </div>
                <div class="col-lg-1 col-md-1 col-sm-12">
                    <asp:LinkButton runat="server" ID="btnNuevoRol" CssClass="btn btn-info" OnClick="btnNuevoRol_Click">Nuevo&nbsp;<i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                </div>


            </div>

            <div class="row">
                <asp:GridView ID="grdRoles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped">
                    <Columns>
                        <asp:TemplateField HeaderText="idRol">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idRol") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIdrol" runat="server" Text='<%# Bind("idRol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditRol" runat="server" OnClick="lnkEditRol_Click"><i class="fa fa-pencil" aria-hidden="true"></i> &nbsp;Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="accesosTab" runat="server" class="tab-pane fade">
            <h3>Acceso a Pantallas</h3>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Rol (*)</label>
                        <asp:DropDownList runat="server" ID="cboRolAcceso" AutoPostBack="True" OnSelectedIndexChanged="cboRolAcceso_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12">
                    <div class="form-group">
                        <label>Modo de acceso (*)</label>
                        <asp:DropDownList runat="server" ID="cboNivelDeAcceso"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-12 centrar">
                    <div class="form-group">
                        <label class="text-center">Pantallas no asignadas</label>
                        <asp:GridView ID="grdNoAsignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped">
                            <Columns>
                                <asp:BoundField DataField="idPantalla" HeaderText="idPantalla" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Etiqueta" HeaderText="Etiqueta" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPantalla" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-1 col-md-1 col-sm-12 centrar">
                    <asp:LinkButton runat="server" ID="btnGrabarAccesos" CssClass="btn btn-primary" OnClick="btnGrabarAccesos_Click">Grabar&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 centrar">
                    <div class="form-group">
                        <label class="centrar">Pantallas Asignadas</label>
                        <asp:GridView ID="grdAsignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped">
                            <Columns>
                                <asp:BoundField DataField="idPantalla" HeaderText="idPantalla" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Etiqueta" HeaderText="Etiqueta" />
                                <asp:BoundField DataField="idModoAcceso" HeaderText="idModoAcceso" />
                                <asp:BoundField DataField="NombreModoAcceso" HeaderText="Modo Acceso" />
                                <asp:BoundField DataField="leer" HeaderText="Leer" />
                                <asp:BoundField DataField="crear" HeaderText="Crear" />
                                <asp:BoundField DataField="actualizar" HeaderText="Actualizar" />
                                <asp:BoundField DataField="eliminar" HeaderText="Eliminar" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEliminarAcceso" runat="server" OnClientClick="return confirmDelete(this);" OnClick="lnkEliminarAcceso_Click"> <i class="fa fa-trash" aria-hidden="true"></i>&nbsp; Eliminar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

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
    <script src="../js/fileinput.min.js"></script>
    <script>        $(".file").fileinput({
            showUpload: false, fileType: "pdf", language: 'es', allowedFileExtensions: ['jpg', 'png'], showPreview: true
        });
    </script>
</asp:Content>

