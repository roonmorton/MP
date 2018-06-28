using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_security : System.Web.UI.Page
{
    ClsRol crol = new ClsRol();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            asignarPermisos();
            Session["Usuario"] = "Ardani";
            crol.idRol = null;
            ViewState["idRol"] = null;
            ViewState["idUsuario"] = null;
            ViewState["modoGrabarUsuario"] = "N";
            cargarUsuarios();
            limpiarUsuario();
            cargarRoles();
            limpiarRol();
            cargarComboRolUsuario();
            cargarComboRolacceso();
            cargarComboNivelAcceso();
            //lnkUsuarios.Attributes.Add("class", "active");
            //usuariosTab.Attributes.Add("class", "tab-pane fade in active");
        }

    }
    protected void lnkEditRol_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Boolean)ViewState["actualizar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }
            visualizarTabs("rolesTab");

            int idRol;
            GridViewRow r = (GridViewRow)((Control)(sender)).Parent.Parent;
            idRol = int.Parse(((Label)r.FindControl("lblIdRol")).Text);
            ViewState["idRol"] = idRol;
            txtNombreRol.Text = r.Cells[1].Text;
            txtDescripcionRol.Text = r.Cells[2].Text;
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnGrabarRoles_Click", ex, this, true);
        }
    }
    protected void btnGrabarRoles_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("rolesTab");

            if (!(Boolean)ViewState["crear"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            if (string.IsNullOrEmpty(txtNombreRol.Text.Trim()))
            {
                clsHelper.mensaje("Ingrese el nombre del rol", this, clsHelper.tipoMensaje.alerta, true);
                return;
            }
            if (ViewState["idRol"] == null)
            {
                crol.idRol = null;
            }
            else
            {
                crol.idRol = int.Parse(ViewState["idRol"].ToString());
            }

            crol.nombre = txtNombreRol.Text.Trim();
            crol.descripcion = txtDescripcionRol.Text.Trim();
            crol.grabar();
            clsHelper.mensaje("Rol grabado correctamente", this, clsHelper.tipoMensaje.informacion);
            cargarRoles();
            limpiarRol();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnGrabarRoles_Click", ex, this, true);
        }
    }

    void cargarRoles()
    {
        try
        {
            visualizarTabs("rolesTab");

            grdRoles.DataSource = crol.getData();
            grdRoles.DataBind();
            txtNombreRol.Focus();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void limpiarRol()
    {
        try
        {
            txtNombreRol.Text = string.Empty;
            txtDescripcionRol.Text = string.Empty;
            crol.idRol = null;
            ViewState["idRol"] = null;
        }
        catch (Exception)
        {


        }
    }
    protected void btnNuevoRol_Click(object sender, EventArgs e)
    {
        try
        {
            limpiarRol();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnNuevoRol_Click", ex, this, true);
        }
    }

    //**************************************************************Accesos
    void cargarComboRolacceso()
    {
        try
        {
            confCombo(cboRolAcceso, "TblSecRol", "", true, "idRol", "nombre");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void cargarComboNivelAcceso()
    {
        try
        {
            confCombo(cboNivelDeAcceso, "TblSecModoAcceso", "", true, "idModoAcceso", "nombre");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnGrabarAccesos_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("accesosTab");
            if (!(Boolean)ViewState["crear"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            ClsAccesoPantalla cpantalla = new ClsAccesoPantalla();
            
            if (string.IsNullOrEmpty(cboRolAcceso.SelectedValue.ToString()))
            {
                clsHelper.mensaje("Debe seleccionar un rol", this, clsHelper.tipoMensaje.alerta, true);
                return;
            }

            if (string.IsNullOrEmpty(cboNivelDeAcceso.SelectedValue.ToString()))
            {
                clsHelper.mensaje("Debe seleccionar un modo de acceso", this, clsHelper.tipoMensaje.alerta, true);
                return;
            }

            foreach (GridViewRow r in grdNoAsignadas.Rows)
            {
                if (((CheckBox)r.FindControl("chkPantalla")).Checked)
                {
                    try
                    {
                        cpantalla.grabar(int.Parse(cboRolAcceso.SelectedValue.ToString()), int.Parse(r.Cells[0].Text), int.Parse(cboNivelDeAcceso.SelectedValue));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            cargarPantallas();
            clsHelper.mensaje("Proceso finalizado", this, clsHelper.tipoMensaje.informacion, true);
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnGrabarAccesos_Click", ex, this, true);
        }
    }

    protected void lnkEliminarAcceso_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("accesosTab");
            if (!(Boolean)ViewState["eliminar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            GridViewRow r = (GridViewRow)((Control)sender).Parent.Parent;
            int idPantalla = int.Parse(r.Cells[0].Text);
            int idModoAcceso = int.Parse(r.Cells[3].Text);
            int idRol = int.Parse(cboRolAcceso.SelectedValue.ToString());
            ClsAccesoPantalla cpant = new ClsAccesoPantalla();
            cpant.eliminar(idRol, idPantalla, idModoAcceso);
            cargarPantallas();
            clsHelper.mensaje("Proceso finalizado", this, clsHelper.tipoMensaje.informacion, true);

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkEliminarAcceso_Click", ex, this, true);
        }
    }

    protected void cboRolAcceso_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            cargarPantallas();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("cboRolAcceso_SelectedIndexChanged", ex, this, true);
        }
    }

    void cargarPantallas()
    {
        try
        {
            visualizarTabs("accesosTab");
            ClsAccesoPantalla acceso = new ClsAccesoPantalla();
            DataTable dt = new DataTable();
            DataTable dtNoAsignadas = new DataTable();
            dt = acceso.listaPantallas(int.Parse(cboRolAcceso.SelectedValue.ToString()), 1);
            grdAsignadas.DataSource = dt;
            grdAsignadas.DataBind();

            dtNoAsignadas = acceso.listaPantallas(int.Parse(cboRolAcceso.SelectedValue.ToString()), 0);
            grdNoAsignadas.DataSource = dtNoAsignadas;
            grdNoAsignadas.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //*****************************************************************//Accesos

    //*****************************************************************//USuarios
    void cargarComboRolUsuario()
    {
        try
        {
            confCombo(cboRolUsuario, "TblSecRol", "", true, "idRol", "nombre");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void limpiarUsuario()
    {
        try
        {
            txtNombrePersona.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPassword2.Text = string.Empty;
            chkActivo.Checked = true;
            chkActivo.Enabled=false;
            chkReiniciarPassword.Checked = false;
            chkReiniciarPassword.Enabled = false;
            ViewState["idUsuario"] = null;
            cboRolUsuario.SelectedValue = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }

    protected void lnkEditUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("usuarioTab");
            if (!(Boolean)ViewState["actualizar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }
            ClsUsuario dt = new ClsUsuario();
            ClsUsuario us = new ClsUsuario();
            GridViewRow r;
            int idUsuario;
            r = (GridViewRow)((Control)sender).Parent.Parent;
            idUsuario = int.Parse(r.Cells[0].Text);
            dt = us.getById(idUsuario);

            ViewState["idUsuario"] = dt.idUsuario;
            txtNombrePersona.Text = dt.nombreUsuario;
            txtUsuario.Text = dt.usuario;
            cboRolUsuario.SelectedValue = dt.idRol.ToString();
            chkActivo.Checked = dt.activo;

            chkActivo.Enabled = true;
            chkReiniciarPassword.Enabled = true;
            ViewState["modoGrabarUsuario"] = "M";
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkEditUsuario_Click", ex, this, true);
        }
    }
    protected void btnNuevoUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("usuarioTab");
            limpiarUsuario();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("btnNuevoUsuario_Click", ex, this, true);
        }
    }

    protected void btnGrabarUsuarios_Click(object sender, EventArgs e)
    {
        try
        {
            ClsUsuario us = new ClsUsuario();
              visualizarTabs("usuarioTab");

              if (!(Boolean)ViewState["crear"])
              {
                  clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                  return;
              }

              if (!validarUsuario()) {
                  return;
              }
              if (ViewState["idUsuario"] == null)
              {
                  us.idUsuario = null;
              }
              else {
                  us.idUsuario = (int)ViewState["idUsuario"];
              }
              
              us.nombreUsuario = txtNombrePersona.Text.Trim();
              us.usuario = txtUsuario.Text.Trim();
              us.contrasena = txtPassword.Text.Trim();
              us.idRol = int.Parse(cboRolUsuario.SelectedValue.ToString());
              us.activo = chkActivo.Checked;
              us.reiniciarContrasena = chkReiniciarPassword.Checked;
              us.usuarioOpera = Session["Usuario"].ToString();
              us.grabar();
              clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion, true);
              limpiarUsuario();
              cargarUsuarios();
        }
        catch (Exception ex)
        {
            
            clsHelper.mostrarError("btnGrabarUsuarios_Click", ex, this, true);
        }
    }


    Boolean validarUsuario() {
        if (string.IsNullOrEmpty(txtNombrePersona.Text)) {
            clsHelper.mensaje("Ingrese nombre de la persona", this,clsHelper.tipoMensaje.alerta, true);
            txtNombrePersona.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUsuario.Text))
        {
            clsHelper.mensaje("Ingrese el usuario", this, clsHelper.tipoMensaje.alerta, true);
            txtUsuario.Focus();
            return false;
        }

        if (ViewState["modoGrabarUsuario"].ToString().Equals("N"))
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                clsHelper.mensaje("Ingrese la contraseña", this, clsHelper.tipoMensaje.alerta, true);
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword2.Text))
            {
                clsHelper.mensaje("debe confirmar la contraseña", this, clsHelper.tipoMensaje.alerta, true);
                txtPassword2.Focus();
                return false;
            }

            if (!txtPassword.Text.Equals(txtPassword2.Text))
            {
                clsHelper.mensaje("Las contraseñas ingresadas no coinciden", this, clsHelper.tipoMensaje.alerta, true);
                return false;
            }
        }

        if (ViewState["modoGrabarUsuario"].ToString().Equals("M"))
        {
            if (chkReiniciarPassword.Checked == true)
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    clsHelper.mensaje("Ingrese la contraseña", this, clsHelper.tipoMensaje.alerta, true);
                    txtPassword.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtPassword2.Text))
                {
                    clsHelper.mensaje("debe confirmar la contraseña", this, clsHelper.tipoMensaje.alerta, true);
                    txtPassword2.Focus();
                    return false;
                }

                if (!txtPassword.Text.Equals(txtPassword2.Text)) {
                    clsHelper.mensaje("Las contraseñas ingresadas no coinciden", this, clsHelper.tipoMensaje.alerta, true);
                    return false;
                }
            }
        }


        if (string.IsNullOrEmpty(cboRolUsuario.SelectedValue.ToString()))
        {
            clsHelper.mensaje("Debe seleccionar un rol", this, clsHelper.tipoMensaje.alerta, true);
            return false;
        }


        return true;
    }

    public void cargarUsuarios() {
        try
        {
            ClsUsuario us = new ClsUsuario();
            grdUsuarios.DataSource = us.select();
            grdUsuarios.DataBind();
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    //*****************************************************************//USUARIOS

    void confCombo(DropDownList combo, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
        ClsCombos cbo = new ClsCombos();
        try
        {
            combo.DataSource = cbo.fill(tabla, condicion, seleccione, dataField, textField);
            combo.DataValueField = dataField;
            combo.DataTextField = textField;
            combo.DataBind();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void visualizarTabs(string control)
    {
        try
        {
            //remueve
                    lnkRoles.Attributes.Remove("class");
                    rolesTab.Attributes.Remove("class");
                    lnkAccesos.Attributes.Remove("class");
                    accesosTab.Attributes.Remove("class");
                    lnkUsuarios.Attributes.Remove("class");
                    usuariosTab.Attributes.Remove("class");

            switch (control)
            {
                case "rolesTab": 
                    //agrega
                    lnkRoles.Attributes.Add("class", "active");
                    rolesTab.Attributes.Add("class", "tab-pane fade in active");
                    accesosTab.Attributes.Add("class", "tab-pane fade");
                    usuariosTab.Attributes.Add("class", "tab-pane fade");
                    break;

                    case "accesosTab":
                    //agrega
                    lnkAccesos.Attributes.Add("class", "active");
                    accesosTab.Attributes.Add("class", "tab-pane fade in active");
                    rolesTab.Attributes.Add("class", "tab-pane fade");
                    usuariosTab.Attributes.Add("class", "tab-pane fade");
                    break;

                    case "usuarioTab":
                    //agrega
                    lnkUsuarios.Attributes.Add("class", "active");
                    usuariosTab.Attributes.Add("class", "tab-pane fade in active");
                    rolesTab.Attributes.Add("class", "tab-pane fade");
                    accesosTab.Attributes.Add("class", "tab-pane fade");
                    break;
            }
             
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    void asignarPermisos()
    {
        try
        {
            ClsAccesoStruc acc = new ClsAccesoStruc();
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            acc = ClsValidaAcceso.validarPantalla((int)Session["idUsuario"], Request.Url.Segments[Request.Url.Segments.Length - 1]);
            ViewState["leer"] = acc.leer;
            ViewState["crear"] = acc.crear;
            ViewState["actualizar"] = acc.actualizar;
            ViewState["eliminar"] = acc.eliminar;
            if (!(Boolean)ViewState["leer"])
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    
}