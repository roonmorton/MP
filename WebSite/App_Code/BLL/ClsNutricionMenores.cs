using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsNutricionMenores
/// </summary>
public class ClsNutricionMenores
{
   public int? idNutricionMenores { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaVisita { get; set; }
   public Double? pesoLibras { get; set; }
   public Double? pesoOnzas { get; set; }
   public Double? talla { get; set; }
   public Double? circunferenciaCefalica { get; set; }
   public string pl { get; set; }
   public int? diagnosticoPl { get; set; }
   public string le { get; set; }
   public int? diagnosticoLe { get; set; }
   public string pe { get; set; }
   public int? diagnosticoPe { get; set; }
   public string cce { get; set; }
   public int? diagnosticoCce { get; set; }
   public Boolean? gananciaPeso { get; set; }
   public Boolean? perdidaPeso { get; set; }
   public Boolean? vomitos { get; set; }
   public Boolean? diarrea { get; set; }
   public Boolean? estrenimiento { get; set; }
   public Boolean? reflujo { get; set; }
   public Boolean? colicos { get; set; }
   public int? opcionAlimentacion { get; set; }
   public int? lactanciaMaterna { get; set; }
   public int? tiempoLactanciaMaterna { get; set; }
   public int? preparacion { get; set; }
   public int? comoLaObtienen { get; set; }
   public Boolean? lecheAdecuadaEdad { get; set; }
   public Boolean? ofreceOtrosLiquidos { get; set; }
   public Boolean? lactanciaMixta { get; set; }
   public Boolean? alimentacionComplementaria { get; set; }
   public int? edadAblacion { get; set; }
   public Boolean? educacionNutricional { get; set; }
   public Boolean? multivitaminico { get; set; }
   public Boolean? formulaRecuperacionNutricional { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPNutricionMenoresIU]", null
               , db.parametro("@PidNutricionMenores", this.idNutricionMenores)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaVisita", this.fechaVisita)
            , db.parametro("@PpesoLibras", this.pesoLibras)
            , db.parametro("@PpesoOnzas", this.pesoOnzas)
            , db.parametro("@Ptalla", this.talla)
            , db.parametro("@PcircunferenciaCefalica", this.circunferenciaCefalica)
            , db.parametro("@Ppl", this.pl)
            , db.parametro("@PdiagnosticoPl", this.diagnosticoPl)
            , db.parametro("@Ple", this.le)
            , db.parametro("@PdiagnosticoLe", this.diagnosticoLe)
            , db.parametro("@Ppe", this.pe)
            , db.parametro("@PdiagnosticoPe", this.diagnosticoPe)
            , db.parametro("@Pcce", this.cce)
            , db.parametro("@PdiagnosticoCce", this.diagnosticoCce)
            , db.parametro("@PgananciaPeso", this.gananciaPeso)
            , db.parametro("@PperdidaPeso", this.perdidaPeso)
            , db.parametro("@Pvomitos", this.vomitos)
            , db.parametro("@Pdiarrea", this.diarrea)
            , db.parametro("@Pestrenimiento", this.estrenimiento)
            , db.parametro("@Preflujo", this.reflujo)
            , db.parametro("@Pcolicos", this.colicos)
            , db.parametro("@PopcionAlimentacion", this.opcionAlimentacion)
            , db.parametro("@PlactanciaMaterna", this.lactanciaMaterna)
            , db.parametro("@PtiempoLactanciaMaterna", this.tiempoLactanciaMaterna)
            , db.parametro("@Ppreparacion", this.preparacion)
            , db.parametro("@PcomoLaObtienen", this.comoLaObtienen)
            , db.parametro("@PlecheAdecuadaEdad", this.lecheAdecuadaEdad)
            , db.parametro("@PofreceOtrosLiquidos", this.ofreceOtrosLiquidos)
            , db.parametro("@PlactanciaMixta", this.lactanciaMixta)
            , db.parametro("@PalimentacionComplementaria", this.alimentacionComplementaria)
            , db.parametro("@PedadAblacion", this.edadAblacion)
            , db.parametro("@PeducacionNutricional", this.educacionNutricional)
            , db.parametro("@Pmultivitaminico", this.multivitaminico)
            , db.parametro("@PformulaRecuperacionNutricional", this.formulaRecuperacionNutricional)
            , db.parametro("@Pusuario", this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idNutricionMenores)
   {
      try
      {
         db.ejecutarSP("SPNutricionMenoresD", null, db.parametro("@PidNutricionMenores", idNutricionMenores));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsNutricionMenores seleccionarPorId(int idNutricionMenores)
   {
      try
      {
         ClsNutricionMenores r = new ClsNutricionMenores();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPNutricionMenoresSPorID", null, db.parametro("@PidNutricionMenores", idNutricionMenores));
         if (dt.Rows.Count > 0)
         {
            r.idNutricionMenores = clsHelper.valI(dt.Rows[0]["idNutricionMenores"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaVisita = clsHelper.valDate(dt.Rows[0]["fechaVisita"].ToString());
            r.pesoLibras = clsHelper.valD(dt.Rows[0]["pesoLibras"].ToString());
            r.pesoOnzas = clsHelper.valD(dt.Rows[0]["pesoOnzas"].ToString());
            r.talla = clsHelper.valD(dt.Rows[0]["talla"].ToString());
            r.circunferenciaCefalica = clsHelper.valD(dt.Rows[0]["circunferenciaCefalica"].ToString());
            r.pl = dt.Rows[0]["pl"].ToString();
            r.diagnosticoPl = clsHelper.valI(dt.Rows[0]["diagnosticoPl"].ToString());
            r.le = dt.Rows[0]["le"].ToString();
            r.diagnosticoLe = clsHelper.valI(dt.Rows[0]["diagnosticoLe"].ToString());
            r.pe = dt.Rows[0]["pe"].ToString();
            r.diagnosticoPe = clsHelper.valI(dt.Rows[0]["diagnosticoPe"].ToString());
            r.cce = dt.Rows[0]["cce"].ToString();
            r.diagnosticoCce = clsHelper.valI(dt.Rows[0]["diagnosticoCce"].ToString());
            r.gananciaPeso = clsHelper.valB(dt.Rows[0]["gananciaPeso"].ToString());
            r.perdidaPeso = clsHelper.valB(dt.Rows[0]["perdidaPeso"].ToString());
            r.vomitos = clsHelper.valB(dt.Rows[0]["vomitos"].ToString());
            r.diarrea = clsHelper.valB(dt.Rows[0]["diarrea"].ToString());
            r.estrenimiento = clsHelper.valB(dt.Rows[0]["estrenimiento"].ToString());
            r.reflujo = clsHelper.valB(dt.Rows[0]["reflujo"].ToString());
            r.colicos = clsHelper.valB(dt.Rows[0]["colicos"].ToString());
            r.opcionAlimentacion = clsHelper.valI(dt.Rows[0]["opcionAlimentacion"].ToString());
            r.lactanciaMaterna = clsHelper.valI(dt.Rows[0]["lactanciaMaterna"].ToString());
            r.tiempoLactanciaMaterna = clsHelper.valI(dt.Rows[0]["tiempoLactanciaMaterna"].ToString());
            r.preparacion = clsHelper.valI(dt.Rows[0]["preparacion"].ToString());
            r.comoLaObtienen = clsHelper.valI(dt.Rows[0]["comoLaObtienen"].ToString());
            r.lecheAdecuadaEdad = clsHelper.valB(dt.Rows[0]["lecheAdecuadaEdad"].ToString());
            r.ofreceOtrosLiquidos = clsHelper.valB(dt.Rows[0]["ofreceOtrosLiquidos"].ToString());
            r.lactanciaMixta = clsHelper.valB(dt.Rows[0]["lactanciaMixta"].ToString());
            r.alimentacionComplementaria = clsHelper.valB(dt.Rows[0]["alimentacionComplementaria"].ToString());
            r.edadAblacion = clsHelper.valI(dt.Rows[0]["edadAblacion"].ToString());
            r.educacionNutricional = clsHelper.valB(dt.Rows[0]["educacionNutricional"].ToString());
            r.multivitaminico = clsHelper.valB(dt.Rows[0]["multivitaminico"].ToString());
            r.formulaRecuperacionNutricional = clsHelper.valB(dt.Rows[0]["formulaRecuperacionNutricional"].ToString());
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
         dt = db.dataTableSP("SPNutricionMenoresS", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
