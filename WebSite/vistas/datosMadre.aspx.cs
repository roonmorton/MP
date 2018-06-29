using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_datosMadre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarCombos();
            }
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("Page_Load", ex, this, true);
        }
      
    }

    void cargarCombos() {
        try
        {
            confCombo(cboMadrePositiva, "MSiNo");
            confCombo(cboMomentoDx, "MMomentoDx");
            confCombo(cboSeguimiento, "MSiNo");
            confCombo(cboLugarSeguimiento,"M_Hospital");
            confCombo(cboControlPrenatal,"MSiNo");
            confCombo(cboLugarControlPrenatal, "M_Hospital");
            confCombo(cboTARGAEmbarazo, "MSiNo");
            confCombo(cboEsquemaTarga, "MEsquemaTargaMadre");
            confCombo(cboMomentoInicioTarga, "MMomentoInicioTarga");


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