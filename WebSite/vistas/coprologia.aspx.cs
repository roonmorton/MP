using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_coprologia : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         if (!IsPostBack)
         {
            ViewState["idCoprologia"] = null;
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

         clsHelper.mostrarError("Page_Load", ex, this, true);
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

         if (string.IsNullOrEmpty(txtFechaAnalitica.Text))
         {
            clsHelper.mensaje("Ingrese fecha de analítica", this, clsHelper.tipoMensaje.alerta);
            return;
         }


         if (!clsHelper.isDate(txtFechaAnalitica.Text))
         {
            clsHelper.mensaje("Ingrese una fecha de analítica válida", this, clsHelper.tipoMensaje.alerta);
            return;
         }



         Clscoprologia c = new Clscoprologia();
         if (ViewState["idCoprologia"] != null)
         {
            c.idCoprologia = int.Parse(ViewState["idCoprologia"].ToString());
         }
         else
         {
            c.idCoprologia = null;
         }
         if (Session["idPaciente"] != null)
         {
            c.idPaciente = int.Parse(Session["idPaciente"].ToString());
         }
         else
         {
            clsHelper.mensaje("Por favor reinicie la aplicación", this, clsHelper.tipoMensaje.msgbx);
            return;
         }

         c.fechaAnalitica = clsHelper.valDate(txtFechaAnalitica.Text);
         c.sangreOculta = (txtSangreOculta.Text);
         c.azulMetilenoHeces = (txtAzulMetilenoHeces.Text);
         c.polimorfonucleares = (txtPolimorfonucleares.Text);
         c.mononucleares = (txtMononucleares.Text);
         c.paracitosHeces =(txtParásitosheces.Text);
         c.azucaresReductores =(txtAzucaresReductores.Text);
         c.usuario = Session["usuario"].ToString();
         c.grabar();
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
         int idCoprologia;
         idCoprologia = int.Parse(((Label)gr.FindControl("lblIdCoprologia")).Text);
         Clscoprologia c = new Clscoprologia();
         c = c.seleccionarPorId(idCoprologia);
         if (c.idCoprologia != null)
         {
            ViewState["idCoprologia"] = c.idCoprologia;
            txtFechaAnalitica.Text = clsHelper.dateFormat(c.fechaAnalitica.ToString());
            txtSangreOculta.Text = c.sangreOculta.ToString();
            txtAzulMetilenoHeces.Text = c.azulMetilenoHeces.ToString();
            txtPolimorfonucleares.Text = c.polimorfonucleares.ToString();
            txtMononucleares.Text = c.mononucleares.ToString();
            txtParásitosheces.Text = c.paracitosHeces.ToString();
            txtAzucaresReductores.Text = c.azucaresReductores.ToString();
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
         int idCoprologia;
         idCoprologia = int.Parse(((Label)gr.FindControl("lblIdCoprologia")).Text);
         Clscoprologia c = new Clscoprologia();
         c.eliminar(idCoprologia);
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
         Clscoprologia c = new Clscoprologia();
         DataTable dt = new DataTable();
         dt = c.seleccionarTodos(int.Parse(Session["idPaciente"].ToString()));
         grdExistentes.DataSource = dt;
         grdExistentes.DataBind();
      }
      catch (Exception ex)
      {

         throw ex;
      }

   }

   void limpiar()
   {
      ViewState["idCoprologia"] = null;
      txtFechaAnalitica.Text = string.Empty;
      txtSangreOculta.Text = string.Empty;
      txtAzulMetilenoHeces.Text = string.Empty;
      txtPolimorfonucleares.Text = string.Empty;
      txtMononucleares.Text = string.Empty;
      txtParásitosheces.Text = string.Empty;
      txtAzucaresReductores.Text = string.Empty;

   }

}