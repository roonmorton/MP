using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Form.DefaultButton = this.btnLogin.UniqueID ;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, false);
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if(string.IsNullOrEmpty(txtUsuario.Text)){
                clsHelper.mensaje("Debe ingresar usuario", this, clsHelper.tipoMensaje.alerta, true);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                clsHelper.mensaje("Debe ingresar la contraseña", this, clsHelper.tipoMensaje.alerta, true);
                txtContrasena.Focus();
                return;
            }

            ClsUsuario us = new ClsUsuario();

            us = ClsValidaAcceso.login(txtUsuario.Text.Trim(), txtContrasena.Text.Trim());
            if (us.idUsuario == null) {
                clsHelper.mensaje("Usuario o contraseña incorrectos", this, clsHelper.tipoMensaje.alerta, false);
                txtUsuario.Focus();
                return;
            }
            
            Session["idUsuario"] = us.idUsuario;
            Session["usuario"] = us.usuario;
            Session["nombreUsuario"] = us.nombreUsuario;
            Session["idRol"] = us.idRol;
            Response.Redirect("vistas/inicio.aspx");
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnLogin_Click", ex, this, false);
        }
    }
}