using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ClsBiologiaMolecular
{
   public int? idBiologiaMolecular { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaMuestra { get; set; }
   public DateTime? fechaAnalisis { get; set; }
   public Double? muestra { get; set; }
   public Double? PCRMycobacteriumTuberculosis { get; set; }
   public Double? PCRHistoplasmaCapsulatum { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPBiologiaMolecularIU]", null
               , db.parametro("@PidBiologiaMolecular", this.idBiologiaMolecular)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaMuestra", this.fechaMuestra)
            , db.parametro("@PfechaAnalisis", this.fechaAnalisis)
            , db.parametro("@Pmuestra", this.muestra)
            , db.parametro("@PPCRMycobacteriumTuberculosis", this.PCRMycobacteriumTuberculosis)
            , db.parametro("@PPCRHistoplasmaCapsulatum", this.PCRHistoplasmaCapsulatum)
            , db.parametro("Pusuario",this.usuario )
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idBiologiaMolecular)
   {
      try
      {
         db.ejecutarSP("SPBiologiaMolecularD", null, db.parametro("@PidBiologiaMolecular", idBiologiaMolecular));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsBiologiaMolecular seleccionarPorId(int idBiologiaMolecular)
   {
      try
      {
         ClsBiologiaMolecular r = new ClsBiologiaMolecular();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("SPSBiologiaMolecularPorID", null, db.parametro("@PidBiologiaMolecular", idBiologiaMolecular));
         if (dt.Rows.Count > 0)
         {
            r.idBiologiaMolecular = clsHelper.valI(dt.Rows[0]["idBiologiaMolecular"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaMuestra = clsHelper.valDate(dt.Rows[0]["fechaMuestra"].ToString());
            r.fechaAnalisis = clsHelper.valDate(dt.Rows[0]["fechaAnalisis"].ToString());
            r.muestra = clsHelper.valD(dt.Rows[0]["muestra"].ToString());
            r.PCRMycobacteriumTuberculosis = clsHelper.valD(dt.Rows[0]["PCRMycobacteriumTuberculosis"].ToString());
            r.PCRHistoplasmaCapsulatum = clsHelper.valD(dt.Rows[0]["PCRHistoplasmaCapsulatum"].ToString());
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
         dt = db.dataTableSP("SPSBiologiaMolecularTodos", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
