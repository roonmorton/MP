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
            crol.idRol = null;
            ViewState["idRol"] = null;
            cargarRoles();
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
    protected void btnGrabarUsuarios_Click(object sender, EventArgs e)
    {

    }
    protected void lnkEliminarAcceso_Click(object sender, EventArgs e)
    {
        try
        {
            visualizarTabs("accesosTab");
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

}