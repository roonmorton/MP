using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_pacBasales : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

   }
   protected void btnPrueba_Click(object sender, EventArgs e)
   {
      try
      {
        //throw new Exception("Prueba de excepcion");
         //clsHelper.mensaje("Texto exitoso", this, clsHelper.tipoMensaje.informacion, true);
         clsHelper.mostrarAlerta("texto de prueba", this, clsHelper.tipoAlerta.success, true);
      }
      catch (Exception ex)
      {
         clsHelper.mostrarError( "btnPrueba",  ex, this, true);
      }
   }

}