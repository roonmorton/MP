using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
//using System.Web.HttpResponse;
using System.Data;

/// <summary>
/// Descripción breve de masterServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService()] 
public class masterServices : System.Web.Services.WebService {

    public masterServices () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string datosInicio() {
        try
        {
            DataTable dt = new DataTable();
            ClsDb db = new ClsDb();
            dt = db.dataTableSP("[SPDatosUsuario]", null, db.parametro("@PidUsuario", Session["idUsurio"].ToString()));
            return DataTableToJSON(dt);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        
    }

     public string  DataTableToJSON( DataTable table )  {
         try 
	{	        
		 List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow row in table.Rows) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns) {
                dict[col.ColumnName] = row[col];
            }
            
            list.Add(dict);
        }
        
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(list);
	}
	catch (Exception ex)
	{
		
		throw ex;
	}

     }

    
    
}
