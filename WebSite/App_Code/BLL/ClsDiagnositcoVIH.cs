using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ClsDiagnosticoVIH
{
   public int? idDiagnosticoVIH { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaDiagnostico { get; set; }
   public int? edadAnos { get; set; }
   public int? edadMeses { get; set; }
   public int? edadDias { get; set; }
   public int? idrangoEdad { get; set; }
   public int? idGrupoTransmision { get; set; }
   public int? idMotivoPrueba { get; set; }
   public Boolean? anticuerpos { get; set; }
   public string valorAnticuerpos { get; set; }
   public Boolean? DNAProviral { get; set; }
   public string valorDNAProviral { get; set; }
   public Boolean? vihCargaViralRNA { get; set; }
   public string valorVihCargaViralRNA { get; set; }
   public string CV { get; set; }
   public string VIHCVLOG10 { get; set; }
   public int? idTipoPrueba { get; set; }
   public string usuario{get;set;}

   private ClsDb db = new ClsDb();


   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPDiagnosticoVIHIU]", null
            , db.parametro("@PidDiagnosticoVIH", this.idDiagnosticoVIH)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaDiagnostico", this.fechaDiagnostico)
            , db.parametro("@PedadAnos", this.edadAnos)
            , db.parametro("@PedadMeses", this.edadMeses)
            , db.parametro("@PedadDias", this.edadDias)
            , db.parametro("@PidrangoEdad", this.idrangoEdad)
            , db.parametro("@PidGrupoTransmision", this.idGrupoTransmision)
            , db.parametro("@PidMotivoPrueba", this.idMotivoPrueba)
            , db.parametro("@Panticuerpos", this.anticuerpos)
            , db.parametro("@PvalorAnticuerpos", this.valorAnticuerpos)
            , db.parametro("@PDNAProviral", this.DNAProviral)
            , db.parametro("@PvalorDNAProviral", this.valorDNAProviral)
            , db.parametro("@PvihCargaViralRNA", this.vihCargaViralRNA)
            , db.parametro("@PvalorVihCargaViralRNA", this.valorVihCargaViralRNA)
            , db.parametro("@PCV", this.CV)
            , db.parametro("@PVIHCVLOG10", this.VIHCVLOG10)
            , db.parametro("@PidTipoPrueba", this.idTipoPrueba)
            , db.parametro("@Pusuario",this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idDiagnosticoVIH)
   {
      try
      {
         db.ejecutarSP("SPDiagnosticoVIHD", null, db.parametro("@PidDiagnosticoVIH", idDiagnosticoVIH));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsDiagnosticoVIH seleccionarPorId(int idDiagnosticoVIH)
   {
      try
      {
         ClsDiagnosticoVIH r = new ClsDiagnosticoVIH();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("SPSDiagnosticoVIHPorID", null, db.parametro("@PidDiagnosticoVIH", idDiagnosticoVIH));
         if (dt.Rows.Count > 0)
         {
            r.idDiagnosticoVIH = clsHelper.valI(dt.Rows[0]["idDiagnosticoVIH"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaDiagnostico = clsHelper.valDate(dt.Rows[0]["fechaDiagnostico"].ToString());
            r.edadAnos = clsHelper.valI(dt.Rows[0]["edadAnos"].ToString());
            r.edadMeses = clsHelper.valI(dt.Rows[0]["edadMeses"].ToString());
            r.edadDias = clsHelper.valI(dt.Rows[0]["edadDias"].ToString());
            r.idrangoEdad = clsHelper.valI(dt.Rows[0]["idrangoEdad"].ToString());
            r.idGrupoTransmision = clsHelper.valI(dt.Rows[0]["idGrupoTransmision"].ToString());
            r.idMotivoPrueba = clsHelper.valI(dt.Rows[0]["idMotivoPrueba"].ToString());
            r.anticuerpos = clsHelper.valB(dt.Rows[0]["anticuerpos"].ToString());
            r.valorAnticuerpos = dt.Rows[0]["valorAnticuerpos"].ToString();
            r.DNAProviral = clsHelper.valB(dt.Rows[0]["DNAProviral"].ToString());
            r.valorDNAProviral = dt.Rows[0]["valorDNAProviral"].ToString();
            r.vihCargaViralRNA = clsHelper.valB(dt.Rows[0]["vihCargaViralRNA"].ToString());
            r.valorVihCargaViralRNA = dt.Rows[0]["valorVihCargaViralRNA"].ToString();
            r.CV = dt.Rows[0]["CV"].ToString();
            r.VIHCVLOG10 = dt.Rows[0]["VIHCVLOG10"].ToString();
            r.idTipoPrueba = clsHelper.valI(dt.Rows[0]["idTipoPrueba"].ToString());
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
         dt = db.dataTableSP("SPSDiagnosticoVIHPorPaciente", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }


}
