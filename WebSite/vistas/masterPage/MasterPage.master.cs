﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class vistas_masterPage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClsUsuario us = new ClsUsuario();
            DataTable dt = new DataTable();
            if (Session["idusuario"] == null) { Response.Redirect("../Default.aspx"); }
            if (Session["idPaciente"] == null) { Response.Redirect("../inicio.aspx"); }
            dt = us.datosInicio(Session["idusuario"].ToString());
            if (dt.Rows.Count < 1) { return; }
            avatarImg.ImageUrl = dt.Rows[0]["urlImagen"].ToString();
            avatarImage.ImageUrl = dt.Rows[0]["urlImagen"].ToString();
            nombreCorto.InnerText = dt.Rows[0]["usuario"].ToString();
            usuario.InnerText = dt.Rows[0]["nombreUsuario"].ToString();
            rol.InnerText = "Rol: " + dt.Rows[0]["rol"].ToString();
            tituloPaciente(Session["nombrePaciente"].ToString(), Session["expedienteHR"].ToString(), Session["expedientePD"].ToString());
        }

        catch (Exception)
        {


        }
    }

    void tituloPaciente(string nombre, string expedienteHR, string expedientePD)
    {
        try
        {
           
            lblNombrePaciente.InnerText = "Nombre: " + nombre;
            lblExpedienteHR.InnerText = "Expediente HR: " + expedienteHR;
           lblExpedientePD.InnerText = "Expediente PD: " + expedientePD;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


}
