using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;


   public static class clsHelper
   {
      #region Notificaciones

      public enum tipoMensaje { informacion, alerta, err, msgbx };
      public enum tipoAlerta { primary, info, success, warning, danger };

     /* public static void mostrarError(string metodo, Exception ex, System.Web.UI.Page pagina, Boolean tieneMasterPage = true)
      {
         //Muestra un mensaje de error en un modal de bootstrap
         //Autor:AR
         //
         string _msg = string.Empty;
         string mensaje = string.Empty;
         try
         {
            if (ex.InnerException != null)
            {
               mensaje = ex.InnerException.ToString();
            }
            else
            {
               mensaje = ex.Message;
            }

            //EscribeMensaje en Log de errores
            escribeError(ex.Message, ex.TargetSite.Name, ex.StackTrace);
            mensaje = metodo + "-" + mensaje;
            mensaje = mensaje.Replace("'", " ");
            mensaje.Replace(Convert.ToChar(34).ToString(), "");
            mensaje = mensaje.Normalize();
            System.Web.UI.MasterPage master = new siteMaster();
            System.Web.UI.HtmlControls.HtmlGenericControl divDialog = new System.Web.UI.HtmlControls.HtmlGenericControl();
            //Si tiene masterPage busca el div en dicha masterpage
            if (tieneMasterPage)
            {
               divDialog = pagina.Master.FindControl("divDialog") as System.Web.UI.HtmlControls.HtmlGenericControl;
            }
            else
            {
               divDialog = pagina.FindControl("divDialog") as System.Web.UI.HtmlControls.HtmlGenericControl;
            }
            divDialog.InnerHtml = mensaje;
            pagina.ClientScript.RegisterStartupScript(master.GetType(), "MostrarError", "$('#errorModal').modal();", true);
         }
         catch (Exception exep)
         {
            escribeError(exep.Message, "clsHelper.cs", exep.StackTrace);
         }

      }*/


      public static void mensaje(string texto, System.Web.UI.Page pagina, tipoMensaje tipo = tipoMensaje.informacion, Boolean remplazarComillas = true)
      {
         /*Muestra una alerta con alertify
         Autor:AR*/
         string script = string.Empty;
         string html = string.Empty;
         try
         {
            script = " alertify.set('notifier','position', 'top-right');";
            if (remplazarComillas)
            {
               texto = texto.Replace("'", "  ").Replace(Convert.ToChar(34).ToString(), "  ");
            }
            texto = texto.Normalize();

            switch (tipo)
            {
               case tipoMensaje.informacion:
                  script += " alertify.success('" + texto + "');";
                  break;

               case tipoMensaje.alerta:
                  script += " alertify.error('" + texto + "');";
                  break;
               case tipoMensaje.err:
                  html = "<p style=" + Convert.ToChar(34).ToString() + "width:100%;overflow:scroll;" + Convert.ToChar(34).ToString() + ">" + texto + "</p>";
                  script = " alertify.alert().set('label','Aceptar'); ";
                  script += "alertify.alert('Error','" + html + "');";
                  break;
               case tipoMensaje.msgbx:
                  html = "<p style=" + Convert.ToChar(34).ToString() + "width:100%;overflow:scroll;" + Convert.ToChar(34).ToString() + ">" + texto + "</p>";
                  script = " alertify.alert().set('label','Aceptar'); ";
                  script += "alertify.alert('','" + html + "');";
                  break;
            }
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "alertify", script, true);
         }
         catch (Exception ex)
         {
            escribeError(ex.Message, "clsHelper.cs", ex.StackTrace);
         }
      }



      public static  void mostrarAlerta(string mensaje, System.Web.UI.Page pagina, tipoAlerta tipoAlerta = tipoAlerta.info, Boolean tieneMasterPage = true)
      {
         StringBuilder html = new StringBuilder();
         LiteralControl control = new LiteralControl();
         HtmlGenericControl divNotifications = new HtmlGenericControl();
         try
         {
            html.Append(" <div class='alert alert-" + tipoAlerta.ToString() + " alert-dismissible' role='alert'>");
            html.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times</span></button>");
            html.Append(mensaje);
            html.Append("</div>");

            control.Text = html.ToString();
            if (tieneMasterPage)
            {
               divNotifications = pagina.Master.FindControl("divNotifications") as HtmlGenericControl;
            }
            else
            {
               divNotifications = pagina.FindControl("divNotifications") as HtmlGenericControl;
            }
            divNotifications.Controls.Add(control);
         }
         catch (Exception ex)
         {
            escribeError(ex.Message, "clsHelper.cs", ex.StackTrace);
         }
      }


      #endregion

      private static void escribeError(string mensaje, string archivoCodigo, string metodo)
      {
         try
         {
            string usuario = (HttpContext.Current.Session["usuario"] == null) ? "forastero" : HttpContext.Current.Session["usuario"].ToString();
            string archivo = HttpContext.Current.Server.MapPath("~") + @"\ErrorLog\errorLog.txt";

            if (!File.Exists(archivo))
            {
               // Si no existe el archivo se crea junto con la línea de error
               File.WriteAllText(archivo, DateTime.Now.ToString() + "," + usuario + "," + archivoCodigo + "," + metodo + ",Error:" + mensaje + Environment.NewLine);
            }
            else
            {
               //Si el archivo ya existe se agregará la línea de error
               File.AppendAllText(archivo, DateTime.Now.ToString() + "," + usuario + "," + archivoCodigo + "," + metodo + ",Error:" + mensaje + Environment.NewLine);
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      #region exportarExcel
      public static void exportarExcel(GridView grd, System.Web.HttpResponse response)
      {
         /*
          Exporta a excel un objeto GridView
          * Autor AR
          */
         StringBuilder sb = new StringBuilder();
         System.IO.StringWriter sw = new System.IO.StringWriter(sb);
         HtmlTextWriter htw = new HtmlTextWriter(sw);
         Page page = new Page();
         HtmlForm form = new HtmlForm();
         try
         {
            grd.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(grd);
            page.RenderControl(htw);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "inline;filename=Reporte.xls");
            response.Charset = "utf-8";
            //Response.ContentEncoding = Encoding.Default
            response.Write(sb.ToString());
            //Response.End()
            response.Flush();
            response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
         }
         catch (Exception)
         { throw; }
      }

      public static void exportarExcel(DataTable dataTable, System.Web.HttpResponse response)
      {
         StringBuilder sb = new StringBuilder();
         System.IO.StringWriter sw = new System.IO.StringWriter(sb);
         HtmlTextWriter htw = new HtmlTextWriter(sw);
         Page page = new Page();
         HtmlForm form = new HtmlForm();
         GridView grd = new GridView();
         try
         {
            grd.DataSource = dataTable;
            grd.DataBind();
            grd.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(grd);
            page.RenderControl(htw);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "inline;filename=Reporte.xls");
            response.Charset = "utf-8";
            //Response.ContentEncoding = Encoding.Default
            response.Write(sb.ToString());
            //Response.End()
            response.Flush();
            response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
         }
         catch (Exception)
         {
            throw;
         }
      }

      public static void exportarExcel(string htmlString, System.Web.HttpResponse response)
      {
         StringBuilder sb = new StringBuilder();
         System.IO.StringWriter sw = new System.IO.StringWriter(sb);
         HtmlTextWriter htw = new HtmlTextWriter(sw);
         Page page = new Page();
         HtmlForm form = new HtmlForm();
         try
         {
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            page.RenderControl(htw);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "inline;filename=Reporte.xls");
            string style = @"<style> .textmode { mso-number-format:\@; } .ancho{width:50%} .fechaformat{mso-number-format:\dd/mm/yyyy;} </style>";
            response.Write(style);
            response.Charset = "utf-8";
            response.ContentEncoding = Encoding.UTF8;
            response.Write(htmlString);
            //'Response.End()
            response.Flush();
            response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion

      public static string dataTable2Json(DataTable table)
      {
         string res = string.Empty;
         try
         {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
               Dictionary<string, object> dict = new Dictionary<string, object>();

               foreach (DataColumn col in table.Columns)
               {
                  dict[col.ColumnName] = row[col];
               }
               list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            res = serializer.Serialize(list);
            return res;
         }
         catch (Exception ex)
         {
            escribeError(ex.Message, "clsHelper.cs", ex.StackTrace);
            return ex.Message;
         }
       
      }

        public static Boolean tieneDato(TextBox field)
        {
            Boolean res = true;
            try
            {
                if (string.IsNullOrEmpty(field.Text.Trim()))
                {
                    res = false;
                }
            }
            catch (Exception)
            { throw; }
            return res;
        }

        public static Boolean tieneDato(DropDownList field)
        {
            Boolean res = true;
            try
            {
                if (string.IsNullOrEmpty(field.Text.Trim())) res = false;
                if (string.IsNullOrEmpty(field.SelectedValue.ToString())) res = false;
                if (string.IsNullOrEmpty(field.SelectedValue.ToString())) res = false;
            }
            catch (Exception)
            { throw; }
            return res;
        }

        public static Boolean camposObligatorios(Page pagina,params Control[] controles)
        {
            Boolean res = true;
            try
            {
                foreach (Control vControl in controles)
                {

                    if (vControl.GetType().Name.ToUpper() == "TextBox".ToUpper())
                    {
                        if (!tieneDato((TextBox)vControl))
                        {
                            
                           mensaje( "El campo " + vControl.ID.ToUpper().Replace("TXT", "") + " es requerido para el proceso",pagina,tipoMensaje.alerta);
                            vControl.Focus();
                            res = false;
                            break;
                        }
                    }
                    else if (vControl.GetType().Name.ToUpper() == "ComboBox".ToUpper())
                    {
                        if (!tieneDato((DropDownList)vControl))
                        {
                            mensaje("El campo " + vControl.ID.ToUpper().Replace("CBO", "") + " es requerido para el proceso",pagina,tipoMensaje.alerta);
                            vControl.Focus();
                            res = false;
                            break;
                        }
                    }
             
                }//foreach
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public static Boolean fNull(string xstring)
      {
         try
         {
            Boolean res = true;
            if (xstring != string.Empty)
            {
               res = true;
            }
            if (xstring.Trim().Length == 0 || xstring == "__/__/____" || xstring == "__-___.___" || xstring == "__:__")
            {
               res = true;
            }
            else { res = false; }

            return res;
         }
         catch (Exception e)
         {
            throw e;
         }

      }

        public static bool isDate(string date)
        {
            DateTime Temp;
            return (DateTime.TryParse(date, out Temp) && date.Length >= 10);
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

      public static void mostrarError(String metodo ,Exception ex, System.Web.UI.Page pagina,  bool tieneMasterPage){
      //Muestra un mensaje de error en un modal de bootstrap
      //Autor:AR
      String  msg  = string.Empty;
      String  mensaje = string.Empty;
      try
   {
         if (ex.InnerException == null ){
            mensaje = ex.Message;
         }else{
            mensaje = ex.InnerException.ToString() ;
            
         }
         //EscribeMensaje en Log de errores
         escribeError( ex.Message + "-" + ex.TargetSite.Name,ex.StackTrace,metodo);
         mensaje = metodo + "-" + mensaje;
         mensaje = mensaje.Replace("'", " ");
         mensaje.Replace(Convert.ToChar(34).ToString(), "");
         mensaje = mensaje.Normalize();
         System.Web.UI.MasterPage master ; 
         master = pagina.Master;
         System.Web.UI.HtmlControls.HtmlGenericControl divDialog =  new System.Web.UI.HtmlControls.HtmlGenericControl();

         //Si tiene masterPage busca el div en dicha masterpage
         if(tieneMasterPage){
            divDialog = (System.Web.UI.HtmlControls.HtmlGenericControl)( pagina.Master.FindControl("divDialog"));
         }else{
            divDialog = (System.Web.UI.HtmlControls.HtmlGenericControl)(pagina.FindControl("divDialog") );
         }
         divDialog.InnerHtml = mensaje;
         //pagina.ClientScript.RegisterStartupScript(master.GetType(), "MostrarError", "$('#errorModal').modal();", True)
         pagina.ClientScript.RegisterStartupScript(master.GetType(), "MostrarError", "sweetAlert('Oops...', '¡" + mensaje + "!', 'error');", true);
   }catch (Exception exep ){
         escribeError(exep.Message + " - MasterHelperMostrarError-  " , exep.StackTrace, metodo);
   }

}

     public static Nullable<int> valI(string textNumber) {
          int? r = null;
          try
          {
              if (IsNumeric(textNumber))
              {
                  r = int.Parse(textNumber);
              }
              else {
                  r = null;
              }
              return r;
          }
          catch ( Exception ex)
          {
              
              throw ex;
          }
      }


     public static Nullable<double> valD(string textNumber)
      {
          Double? r = null;
          try
          {
              if (IsNumeric(textNumber))
              {
                  r = double.Parse(textNumber);
              }
              else
              {
                  r = null;
              }
              return r;
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

     public static Nullable<short> valSh(string textNumber)
      {
          short? r = null;
          try
          {
              if (IsNumeric(textNumber))
              {
                  r = short.Parse(textNumber);
              }
              else
              {
                  r = null;
              }
              return r;
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }
     public static Nullable<DateTime > valDate(string textDate)
     {
         DateTime? r = null;
         try
         {
             if (isDate(textDate))
             {
                 r = DateTime.Parse(textDate);
             }
             else
             {
                 r = null;
             }
             return r;
         }
         catch (Exception ex)
         {

             throw ex;
         }
     }

     public static Nullable<int> getValueI(DropDownList cbo)
     {
         int? r;
         try
         {
             if (clsHelper.IsNumeric(cbo.SelectedValue.ToString()))
             {
                 r = Convert.ToInt32(cbo.SelectedValue.ToString());
             }
             else
             {
                 r = null;
             }
             return r;
         }
         catch (Exception ex)
         {

             throw ex;
         }

     }

     public static Nullable<short> getValueS(DropDownList cbo)
     {
         short? r;
         try
         {
             if (clsHelper.IsNumeric(cbo.SelectedValue.ToString()))
             {
                 r = short.Parse(cbo.SelectedValue.ToString());
             }
             else
             {
                 r = null;
             }
             return r;
         }
         catch (Exception ex)
         {

             throw ex;
         }

     }


}//end class
