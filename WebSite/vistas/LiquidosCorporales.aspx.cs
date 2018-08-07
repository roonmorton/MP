using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_LiquidosCorporales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                asignarPermisos();
                if (Session["idLiquidosCorporales"] != null)
                {
                    buscar();
                }

            }
        }
        catch (Exception ex)
        {
            clsHelper.mostrarError("Load", ex, this, true);
        }
    }

    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            limpiar();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkNuevo_Click", ex, this, true);
        }
    }

    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            ClsLiquidosCorporales lc = new ClsLiquidosCorporales();
            if (!(Boolean)ViewState["crear"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta acción", this, clsHelper.tipoMensaje.alerta);
                return;
            }
            if (!clsHelper.isDate(txtFechaAalitica.Text))
            {
                clsHelper.mensaje("Debe ingresar una fecha correcta", this, clsHelper.tipoMensaje.alerta);
                txtFechaAalitica.Focus();
                return;
            }

            if (Session["idPaciente"] == null)
            {
                clsHelper.mensaje("Ocurrió un inconveniente, por favor reinicie la aplicación", this, clsHelper.tipoMensaje.err, true);
            }

            if (ViewState["idLiquidosCorporales"] != null)
            {
                lc.idLiquidosCorporales = int.Parse(ViewState["idLiquidosCorporales"].ToString());
            }
            else
            {
                lc.idLiquidosCorporales = null;
            }


            lc.idPaciente = int.Parse(Session["idPaciente"].ToString());
            lc.FechaAnalitica = clsHelper.valDate(txtFechaAalitica.Text);
            lc.liquido = txtLiquidoFisico.Text;
            lc.aspecto = txtAspecto.Text;
            lc.volumen = clsHelper.valD(txtVolumen.Text);
            lc.sedimento = txtSedimiento.Text;
            lc.xantocromia = txtXantocromia.Text;
            lc.leucocitos = clsHelper.valD(txtLeucocitos.Text);
            lc.eritocitos = clsHelper.valD(txtEritocitos.Text);
            lc.polimorfonucleares = clsHelper.valD(txtPolimorfonucleares.Text);
            lc.mononucleares = clsHelper.valD(txtMononucleares.Text);
            lc.linfocitos = clsHelper.valD(txtLinfocitos.Text);
            lc.liquidoQuimico = txtLiquidoQuimico.Text;
            lc.PH = clsHelper.valD(txtpH.Text);
            lc.glucosa = clsHelper.valD(txtGlocosa.Text);
            lc.proteinas = clsHelper.valD(txtProteinas.Text);
            lc.albumina = clsHelper.valD(txtAlbumina.Text);
            lc.LDH = clsHelper.valD(txtLDH.Text);
            lc.amilasa = clsHelper.valD(txtAmilasia.Text);
            lc.urea = clsHelper.valD(txtUrea.Text);
            lc.acidoUrico = clsHelper.valD(txtAcidoUrico.Text);
            lc.sodio = clsHelper.valD(txtSodio.Text);
            lc.potasio = clsHelper.valD(txtPotasio.Text);
            lc.cloro = clsHelper.valD(txtCloro.Text);
            lc.bicarbonato = clsHelper.valD(txtBicarbonato.Text);
            lc.IgG = clsHelper.valD(txtIgG.Text);
            lc.CK = clsHelper.valD(txtCK.Text);
            lc.liquidoAntigenos = txtLiquidoAntigenos.Text;
            lc.sifilisVDRL = txtSifilisVDRL.Text;
            lc.sifilisTPHA = txtSifilisTPHA.Text;
            lc.ecoli = txteColi.Text;
            lc.dilucionVDRL = txtDilucionVDRL.Text;
            lc.sifilisRPR = txtSifilisRPR.Text;
            lc.sifilisRPR1 = txtSifilisRPR1.Text;
            lc.sifilisFTAABS = txtSifilisFTAABS.Text;
            lc.sPneumoniae = txtsPneumoniae.Text;
            lc.hInfluenza = txthInfluenza.Text;
            lc.cryptococcus = txtCryptococcus.Text;
            lc.dilucion1 = txtDilucion1.Text;
            lc.ADA = txtAda.Text;
            lc.Usuario = Session["usuario"].ToString();
            lc.grabar();
            clsHelper.mensaje("Registro grabado correctamente", this, clsHelper.tipoMensaje.informacion, true);
            limpiar();
            buscar();
        }
        catch (Exception ex)
        {
            clsHelper.mostrarError("lnkGuardar_Click", ex, this, true);
        }
    }

    protected void lnkCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["idPaciente"] = null;
            Response.Redirect("inicio.aspx");
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
            if (!(Boolean)ViewState["actualizar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            int idLiquidosCorporales;
            GridViewRow r = (GridViewRow)((Control)(sender)).Parent.Parent;
            idLiquidosCorporales = int.Parse(((Label)r.FindControl("lblidLiquidosCorporales")).Text);
            ViewState["idLiquidosCorporales"] = idLiquidosCorporales;
            ClsLiquidosCorporales lc = new ClsLiquidosCorporales();
            lc = lc.seleccionarPorId(idLiquidosCorporales);

            txtFechaAalitica.Text = clsHelper.dateFormat(lc.FechaAnalitica.ToString());
            txtLiquidoFisico.Text = lc.liquido.ToString();
            txtAspecto.Text = lc.aspecto.ToString();
            txtVolumen.Text = lc.volumen.ToString();
            txtSedimiento.Text = lc.sedimento.ToString();
            txtXantocromia.Text = lc.xantocromia.ToString();
            txtLeucocitos.Text = lc.leucocitos.ToString();
            txtEritocitos.Text = lc.eritocitos.ToString();
            txtPolimorfonucleares.Text = lc.polimorfonucleares.ToString();
            txtMononucleares.Text = lc.mononucleares.ToString();
            txtLinfocitos.Text = lc.linfocitos.ToString();
            txtLiquidoQuimico.Text = lc.liquidoQuimico.ToString();
            txtpH.Text = lc.PH.ToString();
            txtGlocosa.Text = lc.glucosa.ToString();
            txtProteinas.Text = lc.proteinas.ToString();
            txtAlbumina.Text = lc.albumina.ToString();
            txtLDH.Text = lc.LDH.ToString();
            txtAmilasia.Text = lc.amilasa.ToString();
            txtUrea.Text = lc.urea.ToString();
            txtAcidoUrico.Text = lc.acidoUrico.ToString();
            txtSodio.Text = lc.sodio.ToString();
            txtPotasio.Text = lc.potasio.ToString();
            txtCloro.Text = lc.cloro.ToString();
            txtBicarbonato.Text = lc.bicarbonato.ToString();
            txtIgG.Text = lc.IgG.ToString();
            txtCK.Text = lc.CK.ToString();
            txtLiquidoAntigenos.Text = lc.liquidoAntigenos.ToString();
            txtSifilisVDRL.Text = lc.sifilisVDRL.ToString();
            txtSifilisTPHA.Text = lc.sifilisTPHA.ToString();
            txteColi.Text = lc.ecoli.ToString();
            txtDilucionVDRL.Text = lc.dilucionVDRL.ToString();
            txtSifilisRPR.Text = lc.sifilisRPR.ToString();
            txtSifilisRPR1.Text = lc.sifilisRPR1.ToString();
            txtSifilisFTAABS.Text = lc.sifilisFTAABS.ToString();
            txtsPneumoniae.Text = lc.sPneumoniae.ToString();
            txthInfluenza.Text = lc.hInfluenza.ToString();
            txtCryptococcus.Text = lc.cryptococcus.ToString();
            txtDilucion1.Text = lc.dilucion1.ToString();
            txtAda.Text = lc.ADA.ToString();
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
            if (!(Boolean)ViewState["eliminar"])
            {
                clsHelper.mensaje("No tiene permiso para realizar esta operación", this, clsHelper.tipoMensaje.alerta);
                return;
            }

            int idLiquidosCorporales;
            GridViewRow r = (GridViewRow)((Control)(sender)).Parent.Parent;
            idLiquidosCorporales = int.Parse(((Label)r.FindControl("lblidLiquidosCorporales")).Text);
            ClsLiquidosCorporales lc = new ClsLiquidosCorporales();
            lc.eliminar(idLiquidosCorporales);
            limpiar();
            buscar();
        }
        catch (Exception ex)
        {

            clsHelper.mostrarError("lnkModificar_Click", ex, this, true);
        }
    }

    void buscar()
    {
        try
        {
            DataTable dt = new DataTable();
            ClsLiquidosCorporales lc = new ClsLiquidosCorporales();
            dt = lc.seleccionarTodos((int.Parse(Session["idPaciente"].ToString())));
            grdLiquidosCorporales.DataSource = dt;
            grdLiquidosCorporales.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    void limpiar()
    {
        try
        {
            txtLiquidoFisico.Text = string.Empty;
            txtAspecto.Text = string.Empty;
            txtVolumen.Text = string.Empty;
            txtSedimiento.Text = string.Empty;
            txtXantocromia.Text = string.Empty;
            txtLeucocitos.Text = string.Empty;
            txtEritocitos.Text = string.Empty;
            txtPolimorfonucleares.Text = string.Empty;
            txtMononucleares.Text = string.Empty;
            txtLinfocitos.Text = string.Empty;
            txtLiquidoQuimico.Text = string.Empty;
            txtpH.Text = string.Empty;
            txtGlocosa.Text = string.Empty;
            txtProteinas.Text = string.Empty;
            txtAlbumina.Text = string.Empty;
            txtLDH.Text = string.Empty;
            txtAmilasia.Text = string.Empty;
            txtUrea.Text = string.Empty;
            txtAcidoUrico.Text = string.Empty;
            txtSodio.Text = string.Empty;
            txtPotasio.Text = string.Empty;
            txtCloro.Text = string.Empty;
            txtBicarbonato.Text = string.Empty;
            txtIgG.Text = string.Empty;
            txtCK.Text = string.Empty;
            txtLiquidoAntigenos.Text = string.Empty;
            txtSifilisVDRL.Text = string.Empty;
            txtDilucionVDRL.Text = string.Empty;
            txtSifilisRPR.Text = string.Empty;
            txtSifilisRPR1.Text = string.Empty;
            txtSifilisTPHA.Text = string.Empty;
            txtSifilisFTAABS.Text = string.Empty;
            txtsPneumoniae.Text = string.Empty;
            txthInfluenza.Text = string.Empty;
            txteColi.Text = string.Empty;
            txtCryptococcus.Text = string.Empty;
            txtDilucion1.Text = string.Empty;
            txtAda.Text = string.Empty;
            ViewState["idLiquidosCorporales"] = null;
            txtFechaAalitica.Text = string.Empty;
            txtFechaAalitica.Focus();

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