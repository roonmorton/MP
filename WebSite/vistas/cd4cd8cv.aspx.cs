﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class vistas_cd4cd8cv : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      try
      {
         if (!IsPostBack)
         {
            ViewState["idCD4CD8CV"] = null;
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



         ClsCD4CD8CV c = new ClsCD4CD8CV();
         if (ViewState["idCD4CD8CV"] != null)
         {
            c.idCD4CD8CV = int.Parse(ViewState["idCD4CD8CV"].ToString());
         }
         else
         {
            c.idCD4CD8CV = null;
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
         c.CD4 = clsHelper.valD(txtCD4.Text);
         c.CD8 = clsHelper.valD(txtCD8.Text);
         c.CD3 = clsHelper.valD(txtCD3.Text);
         c.CD4P = clsHelper.valD(txtCD4P.Text);
         c.CD8P = clsHelper.valD(txtCD8P.Text);
         c.CD4CD8 = clsHelper.valD(txtCd4Cd8.Text);
         c.CV = clsHelper.valD(txtCV.Text);
         c.CVRNA = clsHelper.valD(txtCVRNA.Text);
         c.CVLog10 = clsHelper.valD(txtCVLog10.Text);
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
         Response.Redirect("/vistas/inicio.aspx");
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
         int idCD4CD8CV;
         idCD4CD8CV = int.Parse(((Label)gr.FindControl("lblIdCD4CD8CV")).Text);
         ClsCD4CD8CV  c = new ClsCD4CD8CV();
         c = c.seleccionarPorId(idCD4CD8CV);
         if (c.idCD4CD8CV != null)
         {
            ViewState["idCD4CD8CV"] = c.idCD4CD8CV;
            txtFechaAnalitica.Text = clsHelper.dateFormat(c.fechaAnalitica.ToString());
            txtCD4.Text = c.CD4.ToString();
            txtCD8.Text = c.CD8.ToString();
            txtCD3.Text = c.CD3.ToString();
            txtCd4Cd8.Text = c.CD4CD8.ToString();
            txtCD4P.Text = c.CD4P.ToString();
            txtCD8P.Text = c.CD8P.ToString();
            txtCV.Text = c.CV.ToString();
            txtCVRNA.Text = c.CVRNA.ToString();
            txtCVLog10.Text = c.CVLog10.ToString();
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
         int idCD4CD8CV;
         idCD4CD8CV = int.Parse(((Label)gr.FindControl("lblIdCD4CD8CV")).Text);
         ClsCD4CD8CV  c = new ClsCD4CD8CV();
         c.eliminar(idCD4CD8CV);
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
         ClsCD4CD8CV c = new ClsCD4CD8CV();
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
      ViewState["idCD4CD8CV"] = null;
      txtFechaAnalitica.Text = string.Empty;
      txtCD4.Text = string.Empty;
      txtCD8.Text = string.Empty;
      txtCD3.Text = string.Empty;
      txtCD4P.Text = string.Empty;
      txtCD8P.Text = string.Empty;
      txtCd4Cd8.Text = string.Empty;
      txtCVRNA.Text = string.Empty;
      txtCVLog10.Text = string.Empty;
      txtCV.Text = string.Empty;
   }
}