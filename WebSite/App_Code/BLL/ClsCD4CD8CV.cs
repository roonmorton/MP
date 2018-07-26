using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ClsCD4CD8CV
{
   public int? idCD4CD8CV { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaAnalitica { get; set; }
   public Double? CD4 { get; set; }
   public Double? CD8 { get; set; }
   public Double? CD4P { get; set; }
   public Double? CD8P { get; set; }
   public Double? CD3 { get; set; }
   public Double? CD4CD8 { get; set; }
   public Double? CVRNA { get; set; }
   public Double? CVLog10 { get; set; }
   public Double? CV { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPCD4CD8CVIU]", null
            , db.parametro("@PidCD4CD8CV", this.idCD4CD8CV)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaAnalitica",this.fechaAnalitica )
            , db.parametro("@PCD4", this.CD4)
            , db.parametro("@PCD8", this.CD8)
            , db.parametro("@PCD4P", this.CD4P)
            , db.parametro("@PCD8P", this.CD8P)
            , db.parametro("@PCD3", this.CD3)
            , db.parametro("@PCD4CD8", this.CD4CD8)
            , db.parametro("@PCVRNA", this.CVRNA)
            , db.parametro("@PCVLog10", this.CVLog10)
            , db.parametro("@PCV", this.CV)
            ,db.parametro("@Pusuario",this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idCD4CD8CV)
   {
      try
      {
         db.ejecutarSP("UPCD4CD8CVD", null, db.parametro("@PidCD4CD8CV", idCD4CD8CV));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsCD4CD8CV seleccionarPorId(int idCD4CD8CV)
   {
      try
      {
         ClsCD4CD8CV r = new ClsCD4CD8CV();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSCD4CD8CVPorID", null, db.parametro("@PidCD4CD8CV", idCD4CD8CV));
         if (dt.Rows.Count > 0)
         {
            r.idCD4CD8CV = clsHelper.valI(dt.Rows[0]["idCD4CD8CV"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaAnalitica = clsHelper.valDate(dt.Rows[0]["fechaAnalitica"].ToString());
            r.CD4 = clsHelper.valD(dt.Rows[0]["CD4"].ToString());
            r.CD8 = clsHelper.valD(dt.Rows[0]["CD8"].ToString());
            r.CD4P = clsHelper.valD(dt.Rows[0]["CD4P"].ToString());
            r.CD8P = clsHelper.valD(dt.Rows[0]["CD8P"].ToString());
            r.CD3 = clsHelper.valD(dt.Rows[0]["CD3"].ToString());
            r.CD4CD8 = clsHelper.valD(dt.Rows[0]["CD4CD8"].ToString());
            r.CVRNA = clsHelper.valD(dt.Rows[0]["CVRNA"].ToString());
            r.CVLog10 = clsHelper.valD(dt.Rows[0]["CVLog10"].ToString());
            r.CV = clsHelper.valD(dt.Rows[0]["CV"].ToString());
         }
         return r;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public DataTable seleccionarTodos(int idPaciente)
   {
      try
      {
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSCD4CD8CVTodos", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
