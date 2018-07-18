using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsNutricionMayores
/// </summary>
public class ClsNutricionMayores
{

   public int? idNutricionMayores { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaVisita { get; set; }
   public Double? pesoLibras { get; set; }
   public Double? talla { get; set; }
   public Double? imc { get; set; }
   public string pt { get; set; }
   public int? diagnosticoPt { get; set; }
   public string te { get; set; }
   public int? diagnosticoTe { get; set; }
   public string pe { get; set; }
   public int? diagnosticoPe { get; set; }
   public string imcZcore { get; set; }
   public int? diagnosticoImcZscore { get; set; }
   public Double? cmb { get; set; }
   public Double? ccintura { get; set; }
   public Double? ccadera { get; set; }
   public Double? cp { get; set; }
   public Boolean? gananciaPeso { get; set; }
   public Boolean? perdidaPeso { get; set; }
   public Boolean? perdidaApetito { get; set; }
   public Boolean? sindromeDesgaste { get; set; }
   public Boolean? diarrea { get; set; }
   public Boolean? nausea { get; set; }
   public Boolean? vomitos { get; set; }
   public Boolean? presentaProblemaMetabolismoGrasas { get; set; }
   public Boolean? trigliceridosElevados { get; set; }
   public Boolean? hdlElevado { get; set; }
   public Boolean? colesterolElevado { get; set; }
   public Boolean? ldlElevado { get; set; }
   public Boolean? presentaResistenciaInsulina { get; set; }
   public Boolean? presentaLipodistrofia { get; set; }
   public Boolean? lipoAtrofia { get; set; }
   public Boolean? lipoHipertrofia { get; set; }
   public Boolean? mixta { get; set; }
   public Boolean? dietaCubreRequerimientosNutricionales { get; set; }
   public Boolean? habitosAlimentariosAdecuados { get; set; }
   public Boolean? realizaActividadFisica { get; set; }
   public int? dieta { get; set; }
   public Boolean? suplementoNutricional { get; set; }
   public Boolean? multivitaminico { get; set; }
   public Boolean? educacionNutricional { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
          db.ejecutarSP("SPNutricionMayoresIU", null
               , db.parametro("@PidNutricionMayores", this.idNutricionMayores)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaVisita", this.fechaVisita)
            , db.parametro("@PpesoLibras", this.pesoLibras)
            , db.parametro("@Ptalla", this.talla)
            , db.parametro("@Pimc", this.imc)
            , db.parametro("@Ppt", this.pt)
            , db.parametro("@PdiagnosticoPt", this.diagnosticoPt)
            , db.parametro("@Pte", this.te)
            , db.parametro("@PdiagnosticoTe", this.diagnosticoTe)
            , db.parametro("@Ppe", this.pe)
            , db.parametro("@PdiagnosticoPe", this.diagnosticoPe)
            , db.parametro("@PimcZcore", this.imcZcore)
            , db.parametro("@PdiagnosticoImcZscore", this.diagnosticoImcZscore)
            , db.parametro("@Pcmb", this.cmb)
            , db.parametro("@Pccintura", this.ccintura)
            , db.parametro("@Pccadera", this.ccadera)
            , db.parametro("@Pcp", this.cp)
            , db.parametro("@PgananciaPeso", this.gananciaPeso)
            , db.parametro("@PperdidaPeso", this.perdidaPeso)
            , db.parametro("@PperdidaApetito", this.perdidaApetito)
            , db.parametro("@PsindromeDesgaste", this.sindromeDesgaste)
            , db.parametro("@Pdiarrea", this.diarrea)
            , db.parametro("@Pnausea", this.nausea)
            , db.parametro("@Pvomitos", this.vomitos)
            , db.parametro("@PpresentaProblemaMetabolismoGrasas", this.presentaProblemaMetabolismoGrasas)
            , db.parametro("@PtrigliceridosElevados", this.trigliceridosElevados)
            , db.parametro("@PhdlElevado", this.hdlElevado)
            , db.parametro("@PcolesterolElevado", this.colesterolElevado)
            , db.parametro("@PldlElevado", this.ldlElevado)
            , db.parametro("@PpresentaResistenciaInsulina", this.presentaResistenciaInsulina)
            , db.parametro("@PpresentaLipodistrofia", this.presentaLipodistrofia)
            , db.parametro("@PlipoAtrofia", this.lipoAtrofia)
            , db.parametro("@PlipoHipertrofia", this.lipoHipertrofia)
            , db.parametro("@Pmixta", this.mixta)
            , db.parametro("@PdietaCubreRequerimientosNutricionales", this.dietaCubreRequerimientosNutricionales)
            , db.parametro("@PhabitosAlimentariosAdecuados", this.habitosAlimentariosAdecuados)
            , db.parametro("@PrealizaActividadFisica", this.realizaActividadFisica)
            , db.parametro("@Pdieta", this.dieta)
            , db.parametro("@PsuplementoNutricional", this.suplementoNutricional)
            , db.parametro("@Pmultivitaminico", this.multivitaminico)
            , db.parametro("@PeducacionNutricional", this.educacionNutricional)
            ,db.parametro("@Pusuario",this.usuario )
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idNutricionMayores)
   {
      try
      {
          db.ejecutarSP("UPNutricionMayoresD", null, db.parametro("@PidNutricionMayores", idNutricionMayores));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsNutricionMayores seleccionarPorId(int idNutricionMayores)
   {
      try
      {
         ClsNutricionMayores r = new ClsNutricionMayores();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSNutricionMayoresPorID", null, db.parametro("@PidNutricionMayores", idNutricionMayores));
         if (dt.Rows.Count > 0)
         {
            r.idNutricionMayores = clsHelper.valI(dt.Rows[0]["idNutricionMayores"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaVisita = clsHelper.valDate(dt.Rows[0]["fechaVisita"].ToString());
            r.pesoLibras = clsHelper.valD(dt.Rows[0]["pesoLibras"].ToString());
            r.talla = clsHelper.valD(dt.Rows[0]["talla"].ToString());
            r.imc = clsHelper.valD(dt.Rows[0]["imc"].ToString());
            r.pt = dt.Rows[0]["pt"].ToString();
            r.diagnosticoPt = clsHelper.valI(dt.Rows[0]["diagnosticoPt"].ToString());
            r.te = dt.Rows[0]["te"].ToString();
            r.diagnosticoTe = clsHelper.valI(dt.Rows[0]["diagnosticoTe"].ToString());
            r.pe = dt.Rows[0]["pe"].ToString();
            r.diagnosticoPe = clsHelper.valI(dt.Rows[0]["diagnosticoPe"].ToString());
            r.imcZcore = dt.Rows[0]["imcZcore"].ToString();
            r.diagnosticoImcZscore = clsHelper.valI(dt.Rows[0]["diagnosticoImcZscore"].ToString());
            r.cmb = clsHelper.valD(dt.Rows[0]["cmb"].ToString());
            r.ccintura = clsHelper.valD(dt.Rows[0]["ccintura"].ToString());
            r.ccadera = clsHelper.valD(dt.Rows[0]["ccadera"].ToString());
            r.cp = clsHelper.valD(dt.Rows[0]["cp"].ToString());
            r.gananciaPeso = clsHelper.valB(dt.Rows[0]["gananciaPeso"].ToString());
            r.perdidaPeso = clsHelper.valB(dt.Rows[0]["perdidaPeso"].ToString());
            r.perdidaApetito = clsHelper.valB(dt.Rows[0]["perdidaApetito"].ToString());
            r.sindromeDesgaste = clsHelper.valB(dt.Rows[0]["sindromeDesgaste"].ToString());
            r.diarrea = clsHelper.valB(dt.Rows[0]["diarrea"].ToString());
            r.nausea = clsHelper.valB(dt.Rows[0]["nausea"].ToString());
            r.vomitos = clsHelper.valB(dt.Rows[0]["vomitos"].ToString());
            r.presentaProblemaMetabolismoGrasas = clsHelper.valB(dt.Rows[0]["presentaProblemaMetabolismoGrasas"].ToString());
            r.trigliceridosElevados = clsHelper.valB(dt.Rows[0]["trigliceridosElevados"].ToString());
            r.hdlElevado = clsHelper.valB(dt.Rows[0]["hdlElevado"].ToString());
            r.colesterolElevado = clsHelper.valB(dt.Rows[0]["colesterolElevado"].ToString());
            r.ldlElevado = clsHelper.valB(dt.Rows[0]["ldlElevado"].ToString());
            r.presentaResistenciaInsulina = clsHelper.valB(dt.Rows[0]["presentaResistenciaInsulina"].ToString());
            r.presentaLipodistrofia = clsHelper.valB(dt.Rows[0]["presentaLipodistrofia"].ToString());
            r.lipoAtrofia = clsHelper.valB(dt.Rows[0]["lipoAtrofia"].ToString());
            r.lipoHipertrofia = clsHelper.valB(dt.Rows[0]["lipoHipertrofia"].ToString());
            r.mixta = clsHelper.valB(dt.Rows[0]["mixta"].ToString());
            r.dietaCubreRequerimientosNutricionales = clsHelper.valB(dt.Rows[0]["dietaCubreRequerimientosNutricionales"].ToString());
            r.habitosAlimentariosAdecuados = clsHelper.valB(dt.Rows[0]["habitosAlimentariosAdecuados"].ToString());
            r.realizaActividadFisica = clsHelper.valB(dt.Rows[0]["realizaActividadFisica"].ToString());
            r.dieta = clsHelper.valI(dt.Rows[0]["dieta"].ToString());
            r.suplementoNutricional = clsHelper.valB(dt.Rows[0]["suplementoNutricional"].ToString());
            r.multivitaminico = clsHelper.valB(dt.Rows[0]["multivitaminico"].ToString());
            r.educacionNutricional = clsHelper.valB(dt.Rows[0]["educacionNutricional"].ToString());
            
         }
         return r;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }

   public DataTable seleccionar(int idPaciente) {
      try
      {
          DataTable dt = new DataTable();
         dt =  db.dataTableSP("SPNutricionMayoresSelect", null, db.parametro("@PidPaciente", idPaciente));
          return dt;
      }
      catch (Exception ex)
      {
         
         throw ex;
      }
   }

}