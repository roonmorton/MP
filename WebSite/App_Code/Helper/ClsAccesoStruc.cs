using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsAccesoStruc
/// </summary>
public class ClsAccesoStruc
{
	 
public int idModoAcceso{get;set;}
public string nombre { get; set; }
public Boolean crear { get; set; }
public Boolean leer { get; set; }
public Boolean actualizar { get; set; }
public Boolean eliminar { get; set; }
}