using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ClsTrabajoSocialAdherencia
{
   public int? idTrabajoSocialAdherencia { get; set; }
   public int? idPaciente { get; set; }
   public int? apoyoFamiliarEstable { get; set; }
   public int? apoyoFamiliarInestable { get; set; }
   public int? ausenciaApoyoFamiliar { get; set; }
   public int? grupoFamiliarTrabajoEstable { get; set; }
   public int? grupoFamiliarTrabajoInestable { get; set; }
   public int? grupoFamiliarDesempleado { get; set; }
   public int? comprendePlenamenteVIH { get; set; }
   public int? comprendeParcialmenteVIH { get; set; }
   public int? noComprendeGeneralidadesVIH { get; set; }
   public int? aceptadoDiagnostico { get; set; }
   public int? noAceptadoDiagnostico { get; set; }
   public int? niegaDiagnostico { get; set; }
   public int? nino { get; set; }
   public int? adolescente { get; set; }
   public int? ninoAdolescenteConflictivo { get; set; }
   public int? RSAT { get; set; }
   public string usuario { get; set; }

   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPTrabajoSocialAdherenciaIU]", null
               , db.parametro("@PidTrabajoSocialAdherencia", this.idTrabajoSocialAdherencia)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PapoyoFamiliarEstable", this.apoyoFamiliarEstable)
            , db.parametro("@PapoyoFamiliarInestable", this.apoyoFamiliarInestable)
            , db.parametro("@PausenciaApoyoFamiliar", this.ausenciaApoyoFamiliar)
            , db.parametro("@PgrupoFamiliarTrabajoEstable", this.grupoFamiliarTrabajoEstable)
            , db.parametro("@PgrupoFamiliarTrabajoInestable", this.grupoFamiliarTrabajoInestable)
            , db.parametro("@PgrupoFamiliarDesempleado", this.grupoFamiliarDesempleado)
            , db.parametro("@PcomprendePlenamenteVIH", this.comprendePlenamenteVIH)
            , db.parametro("@PcomprendeParcialmenteVIH", this.comprendeParcialmenteVIH)
            , db.parametro("@PnoComprendeGeneralidadesVIH", this.noComprendeGeneralidadesVIH)
            , db.parametro("@PaceptadoDiagnostico", this.aceptadoDiagnostico)
            , db.parametro("@PnoAceptadoDiagnostico", this.noAceptadoDiagnostico)
            , db.parametro("@PniegaDiagnostico", this.niegaDiagnostico)
            , db.parametro("@Pnino", this.nino)
            , db.parametro("@Padolescente", this.adolescente)
            , db.parametro("@PninoAdolescenteConflictivo", this.ninoAdolescenteConflictivo)
            , db.parametro("@PRSAT", this.RSAT)
            , db.parametro("@Pusuario", this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }

   public ClsTrabajoSocialAdherencia seleccionarPorId(int idPaciente)
   {
      try
      {
         ClsTrabajoSocialAdherencia r = new ClsTrabajoSocialAdherencia();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSTrabajoSocialAdherenciaPorID", null, db.parametro("@PidPaciente", idPaciente));
         if (dt.Rows.Count > 0)
         {
            r.idTrabajoSocialAdherencia = clsHelper.valI(dt.Rows[0]["idTrabajoSocialAdherencia"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.apoyoFamiliarEstable = clsHelper.valI(dt.Rows[0]["apoyoFamiliarEstable"].ToString());
            r.apoyoFamiliarInestable = clsHelper.valI(dt.Rows[0]["apoyoFamiliarInestable"].ToString());
            r.ausenciaApoyoFamiliar = clsHelper.valI(dt.Rows[0]["ausenciaApoyoFamiliar"].ToString());
            r.grupoFamiliarTrabajoEstable = clsHelper.valI(dt.Rows[0]["grupoFamiliarTrabajoEstable"].ToString());
            r.grupoFamiliarTrabajoInestable = clsHelper.valI(dt.Rows[0]["grupoFamiliarTrabajoInestable"].ToString());
            r.grupoFamiliarDesempleado = clsHelper.valI(dt.Rows[0]["grupoFamiliarDesempleado"].ToString());
            r.comprendePlenamenteVIH = clsHelper.valI(dt.Rows[0]["comprendePlenamenteVIH"].ToString());
            r.comprendeParcialmenteVIH = clsHelper.valI(dt.Rows[0]["comprendeParcialmenteVIH"].ToString());
            r.noComprendeGeneralidadesVIH = clsHelper.valI(dt.Rows[0]["noComprendeGeneralidadesVIH"].ToString());
            r.aceptadoDiagnostico = clsHelper.valI(dt.Rows[0]["aceptadoDiagnostico"].ToString());
            r.noAceptadoDiagnostico = clsHelper.valI(dt.Rows[0]["noAceptadoDiagnostico"].ToString());
            r.niegaDiagnostico = clsHelper.valI(dt.Rows[0]["niegaDiagnostico"].ToString());
            r.nino = clsHelper.valI(dt.Rows[0]["nino"].ToString());
            r.adolescente = clsHelper.valI(dt.Rows[0]["adolescente"].ToString());
            r.ninoAdolescenteConflictivo = clsHelper.valI(dt.Rows[0]["ninoAdolescenteConflictivo"].ToString());
            r.RSAT = clsHelper.valI(dt.Rows[0]["RSAT"].ToString());

         }
         return r;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }

}
