using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_psicologiaAcompanante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       try
       {
           cargarCombos();
       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("Page_Load",  ex,this,true);
       }
    }
    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
       try
       {

       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkNuevo_Click", ex, this, true);
       }
    }
    protected void lnkCerrar_Click(object sender, EventArgs e)
    {
       try
       {

       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkCerrar_Click", ex, this, true);
       }
    }
    protected void lnkModificar_Click(object sender, EventArgs e)
    {
       try
       {

       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkModificar_Click", ex, this, true);
       }
    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
       try
       {

       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
       }
    }
    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkGuardar_Click", ex, this, true);
        }
    }

    void confRb(RadioButtonList rbList, string tabla, string condicion = "", Boolean seleccione = true, string dataField = "id", string textField = "nombre")
    {
        ClsCombos cbo = new ClsCombos();
        try
        {
            rbList.DataSource = cbo.fill(tabla, condicion, seleccione, dataField, textField);
            rbList.DataValueField = dataField;
            rbList.DataTextField = textField;
            rbList.DataBind();

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
            combo.DataSource = cbo.fill(tabla, condicion, seleccione,dataField,textField );
            combo.DataValueField = dataField;
            combo.DataTextField = textField;
            combo.DataBind();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void cargarCombos()
    {
        try
        {
            confCombo(cboRelacionConNino, "MRelacionConElNino", "",false);
            confCombo(cboIntervencion, "MTipoIntervencion","",false);
            confCombo(cboTipoAlertaAfectiva, "MAlertasAfectivas","",false);
            confRb(rbProceso, "MProcesoPsicologiaAcompanante","",false);
            confRb(rbEsAdherente, "MSiNoParcial", "", false);
            confRb(rbComprensionVIHSegunEdad, "MSiNoParcial", "", false);
            confRb(rbAlertasAfectivas, "MSiNoNoAplica", "", false);
            confRb(rbAfrontamientoEnfermedad, "MAfrontamientoEnfermedad", "", false);
            confRb(rbMinimental, "MminimentalResultado", "", false);
            confRb(rbDepresion, "MDepresionAnsiedadResultado", "", false);
            confRb(rbAnsiedad, "MDepresionAnsiedadResultado", "", false);
            confRb(rbAutoestima, "MAutoestimaResultado", "", false);


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}