using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsImagenPaciente
/// </summary>
public class ClsImagenPaciente
{
   public int? IdImagenPaciente { get; set; }
   public int? IdPaciente { get; set; }
   public int? TipoImagen { get; set; }
   public string CualOtra { get; set; }
   public int? ValorImagen { get; set; }
   public DateTime? FechaImagen { get; set; }
   public string Alteracion { get; set; }
   public string usuario { get; set; }

   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPImagenPacienteIU]", null
            , db.parametro("@PIdImagenPaciente", this.IdImagenPaciente)
            , db.parametro("@PIdPaciente", this.IdPaciente)
            , db.parametro("@PTipoImagen", this.TipoImagen)
            , db.parametro("@PValorImagen", this.ValorImagen)
            , db.parametro("@PFechaImagen", this.FechaImagen)
            , db.parametro("@PAlteracion", this.Alteracion)
            , db.parametro("@Pusuario", this.usuario)
            , db.parametro("@PCualOtra", this.CualOtra)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int IdImagenPaciente)
   {
      try
      {
         db.ejecutarSP("UPImagenPacienteD", null, db.parametro("@PIdImagenPaciente", IdImagenPaciente));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsImagenPaciente seleccionarPorId(int IdImagenPaciente)
   {
      try
      {
         ClsImagenPaciente r = new ClsImagenPaciente();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSImagenPacientePorID", null, db.parametro("@PIdImagenPaciente", IdImagenPaciente));
         if (dt.Rows.Count > 0)
         {
            r.IdImagenPaciente = clsHelper.valI(dt.Rows[0]["IdImagenPaciente"].ToString());
            r.IdPaciente = clsHelper.valI(dt.Rows[0]["IdPaciente"].ToString());
            r.TipoImagen = clsHelper.valI(dt.Rows[0]["TipoImagen"].ToString());
            r.ValorImagen = clsHelper.valI(dt.Rows[0]["ValorImagen"].ToString());
            r.FechaImagen = clsHelper.valDate(dt.Rows[0]["FechaImagen"].ToString());
            r.Alteracion = dt.Rows[0]["Alteracion"].ToString();
            r.CualOtra = dt.Rows[0]["CualOtra"].ToString();
         }
         return r;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public DataTable seleccionar(int IdPaciente)
   {
      try
      {
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSImagenPaciente", null, db.parametro("@PIdPaciente", IdPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
