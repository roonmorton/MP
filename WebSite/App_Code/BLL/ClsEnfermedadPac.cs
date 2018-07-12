using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsEnfermedadPac
/// </summary>
public class ClsEenfermedadPac
{
   public int? IdEnfermedadPaciente { get; set; }
   public int? IdPaciente { get; set; }
   public int? TipoEnfermedad { get; set; }
   public string Enfermedad { get; set; }
   public DateTime? FechaEnfermedad { get; set; }
   public Boolean? Tratada { get; set; }
   public int? estado { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("SPEnfermedadPacIU", null
               , db.parametro("@PIdEnfermedadPaciente", this.IdEnfermedadPaciente)
            , db.parametro("@PIdPaciente", this.IdPaciente)
            , db.parametro("@PTipoEnfermedad", this.TipoEnfermedad)
            , db.parametro("@PEnfermedad", this.Enfermedad)
            , db.parametro("@PFechaEnfermedad", this.FechaEnfermedad)
            , db.parametro("@PTratada", this.Tratada)
            , db.parametro("@Pestado", this.estado)
            , db.parametro("@Pusuario", this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int IdEnfermedadPaciente)
   {
      try
      {
         db.ejecutarSP("SPEnfermedadPacD", null, db.parametro("@PIdEnfermedadPaciente", IdEnfermedadPaciente));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsEenfermedadPac  seleccionarPorId(int IdEnfermedadPaciente)
   {
      try
      {
         ClsEenfermedadPac r = new ClsEenfermedadPac();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("SPEnfermedadPacSPorID", null, db.parametro("@PIdEnfermedadPaciente", IdEnfermedadPaciente));
         if (dt.Rows.Count > 0)
         {
            r.IdEnfermedadPaciente = clsHelper.valI(dt.Rows[0]["IdEnfermedadPaciente"].ToString());
            r.IdPaciente = clsHelper.valI(dt.Rows[0]["IdPaciente"].ToString());
            r.TipoEnfermedad = clsHelper.valI(dt.Rows[0]["TipoEnfermedad"].ToString());
            r.Enfermedad = dt.Rows[0]["Enfermedad"].ToString();
            r.FechaEnfermedad = clsHelper.valDate(dt.Rows[0]["FechaEnfermedad"].ToString());
            r.Tratada = clsHelper.valB(dt.Rows[0]["Tratada"].ToString());
            r.estado = clsHelper.valI(dt.Rows[0]["estado"].ToString());
         }
         return r;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public DataTable seleccionar(int idPaciente)
   {
      try
      {
         DataTable dt = new DataTable();
         dt = db.dataTableSP("SPEnfermedadPacS", null, db.parametro("@PIdPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
