using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_biologiaMolecular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       try
       {
          if (!IsPostBack)
          {
             ViewState["idBiologiaMolecular"] = null;
             asignarPermisos();
          
             if (Session["idPaciente"] == null)
             {
                Response.Redirect("inicio.aspx");
             }
             else
             {
                cargarDatosExistentes();
             }
          }
       }
       catch (Exception ex)
       {
          
         clsHelper.mostrarError("load", ex, this, true);
       }
    }
    protected void lnkNuevo_Click(object sender, EventArgs e)
    {
       try
       {
          limpiar();
          cargarDatosExistentes();
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
          if (!(Boolean)ViewState["crear"])
          {
             Response.Redirect("../Default.aspx");
          }

          if (string.IsNullOrEmpty(txtFechaMuestra .Text))
          {
             clsHelper.mensaje("Ingrese fecha de muestra", this, clsHelper.tipoMensaje.alerta);
             return;
          }
          if (string.IsNullOrEmpty(txtFechaAnalisis.Text))
          {
             clsHelper.mensaje("Ingrese fecha de análisis", this, clsHelper.tipoMensaje.alerta);
             return;
          }

          if (!clsHelper.isDate(txtFechaMuestra.Text))
          {
             clsHelper.mensaje("Ingrese una fecha de muestra válida", this, clsHelper.tipoMensaje.alerta);
             return;
          }

          if (!clsHelper.isDate(txtFechaAnalisis.Text))
          {
             clsHelper.mensaje("Ingrese una fecha de análisis válida", this, clsHelper.tipoMensaje.alerta);
             return;
          }
          //

          ClsBiologiaMolecular  bm = new ClsBiologiaMolecular();
          if (ViewState["idBiologiaMolecular"] != null)
          {
             bm.idBiologiaMolecular = int.Parse(ViewState["idBiologiaMolecular"].ToString());
          }
          else
          {
             bm.idBiologiaMolecular = null;
          }
          if (Session["idPaciente"] != null)
          {
             bm.idPaciente = int.Parse(Session["idPaciente"].ToString());
          }
          else
          {
             clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
             return;
          }

          bm.fechaMuestra = clsHelper.valDate(txtFechaMuestra.Text);
          bm.fechaAnalisis = clsHelper.valDate(txtFechaAnalisis.Text);
          bm.muestra = clsHelper.valD(txtMuestra.Text);
          bm.PCRMycobacteriumTuberculosis = clsHelper.valD(txtPCRMycobacterium.Text);
          bm.PCRHistoplasmaCapsulatum = clsHelper.valD(txtPCRHistoplasma.Text);
          bm.usuario = Session["usuario"].ToString();
          bm.grabar();
          limpiar();
          clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion, true);
          cargarDatosExistentes();
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
            Response.Redirect("../Default.aspx");
         }
         GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
         int idBiologiaMolecular;
         idBiologiaMolecular = int.Parse(((Label)gr.FindControl("lblIdBiologiaMolecular")).Text);
         ClsBiologiaMolecular  bm = new ClsBiologiaMolecular();
         bm = bm.seleccionarPorId(idBiologiaMolecular);
         if (bm.idBiologiaMolecular != null)
         {
            ViewState["idBiologiaMolecular"] = bm.idBiologiaMolecular;
            txtFechaMuestra.Text = clsHelper.dateFormat(bm.fechaMuestra.ToString());
            txtFechaAnalisis.Text = clsHelper.dateFormat(bm.fechaAnalisis.ToString());
            txtMuestra.Text = bm.muestra.ToString();
            txtPCRHistoplasma.Text = bm.PCRHistoplasmaCapsulatum.ToString();
            txtPCRMycobacterium.Text = bm.PCRMycobacteriumTuberculosis.ToString();
         }
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
             Response.Redirect("../Default.aspx");
          }
          GridViewRow gr = (GridViewRow)((Control)sender).Parent.Parent;
          int idBiologiaMolecular;
          idBiologiaMolecular = int.Parse(((Label)gr.FindControl("lblIdBiologiaMolecular")).Text);
          ClsBiologiaMolecular  bm = new ClsBiologiaMolecular();
          bm.eliminar(idBiologiaMolecular);
          clsHelper.mensaje("Proceso exitoso", this, clsHelper.tipoMensaje.informacion);
          limpiar();
          cargarDatosExistentes();
       }
       catch (Exception ex)
       {

          clsHelper.mostrarError("lnkEliminar_Click", ex, this, true);
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

    void cargarDatosExistentes()
    {
       try
       {
          ClsBiologiaMolecular bm = new ClsBiologiaMolecular();
          DataTable dt = new DataTable();
          dt = bm.seleccionarTodos(int.Parse(Session["idPaciente"].ToString()));
          grdExistentes.DataSource = dt;
          grdExistentes.DataBind();
       }
       catch (Exception ex)
       {

          throw ex;
       }

    }

    void limpiar() {
       ViewState["idBiologiaMolecular"] = null;
       txtFechaAnalisis.Text = string.Empty;
       txtFechaMuestra.Text = string.Empty;
       txtMuestra.Text = string.Empty;
       txtPCRMycobacterium.Text = string.Empty;
       txtPCRHistoplasma.Text = string.Empty;
                
    }

}