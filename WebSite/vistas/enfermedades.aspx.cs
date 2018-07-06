using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_enfermedades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       try
       {
          if (!IsPostBack) {
             cargarCombos();
          }
       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("Load", ex, this, true);
       }
    }

    void cargarCombos() {
       try
       {
          confCombo(cboEnfermedad, "MTipoVisita");
          string script = " $('#ctl00_ContentPlaceHolder1_cboEnfermedad').select2();";
          ClientScript.RegisterStartupScript(this.GetType(), "cboEnf", script,true);
          cboEnfermedad.Style.Add("width", "100%!important");
       }
       catch (Exception ex)
       {
          
          throw ex;
       }
    }
    void confCombo(DropDownList combo, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
       ClsCombos cbo = new ClsCombos();
       try
       {
          combo.DataSource = cbo.fill(tabla, condicion, seleccione);
          combo.DataValueField = dataField;
          combo.DataTextField = textField;
          combo.DataBind();

       }
       catch (Exception ex)
       {

          throw ex;
       }
    }
}