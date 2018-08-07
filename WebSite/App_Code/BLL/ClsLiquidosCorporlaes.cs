using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsLiquidosCorporlaes
/// </summary>
public class ClsLiquidosCorporales
{
    public int? idLiquidosCorporales { get; set; }
    public int? idPaciente { get; set; }
    public DateTime? FechaAnalitica { get; set; }
    public string liquido { get; set; }
    public string aspecto { get; set; }
    public Double? volumen { get; set; }
    public string sedimento { get; set; }
    public string xantocromia { get; set; }
    public Double? leucocitos { get; set; }
    public Double? eritocitos { get; set; }
    public Double? polimorfonucleares { get; set; }
    public Double? mononucleares { get; set; }
    public Double? linfocitos { get; set; }
    public string liquidoQuimico { get; set; }
    public Double? PH { get; set; }
    public Double? glucosa { get; set; }
    public Double? proteinas { get; set; }
    public Double? albumina { get; set; }
    public Double? LDH { get; set; }
    public Double? amilasa { get; set; }
    public Double? urea { get; set; }
    public Double? acidoUrico { get; set; }
    public Double? sodio { get; set; }
    public Double? potasio { get; set; }
    public Double? cloro { get; set; }
    public Double? bicarbonato { get; set; }
    public Double? IgG { get; set; }
    public Double? CK { get; set; }
    public string liquidoAntigenos { get; set; }
    public string sifilisVDRL { get; set; }
    public string sifilisTPHA { get; set; }
    public string ecoli { get; set; }
    public string dilucionVDRL { get; set; }
    public string sifilisRPR { get; set; }
    public string sifilisRPR1 { get; set; }
    public string sifilisFTAABS { get; set; }
    public string sPneumoniae { get; set; }
    public string hInfluenza { get; set; }
    public string cryptococcus { get; set; }
    public string dilucion1 { get; set; }
    public string ADA { get; set; }

    public string Usuario { get; set; }

    private ClsDb db = new ClsDb();

    public void grabar()
    {
        try
        {
            db.ejecutarSP("[SPLiquidoscorporalesIU]", null
                    , db.parametro("@PidLiquidosCorporales", this.idLiquidosCorporales)
                , db.parametro("@PidPaciente", this.idPaciente)
                , db.parametro("@PFechaAnalitica", this.FechaAnalitica)
                , db.parametro("@Pliquido", this.liquido)
                , db.parametro("@Paspecto", this.aspecto)
                , db.parametro("@Pvolumen", this.volumen)
                , db.parametro("@Psedimento", this.sedimento)
                , db.parametro("@Pxantocromia", this.xantocromia)
                , db.parametro("@Pleucocitos", this.leucocitos)
                , db.parametro("@Peritocitos", this.eritocitos)
                , db.parametro("@Ppolimorfonucleares", this.polimorfonucleares)
                , db.parametro("@Pmononucleares", this.mononucleares)
                , db.parametro("@Plinfocitos", this.linfocitos)
                , db.parametro("@PliquidoQuimico", this.liquidoQuimico)
                , db.parametro("@PPH", this.PH)
                , db.parametro("@Pglucosa", this.glucosa)
                , db.parametro("@Pproteinas", this.proteinas)
                , db.parametro("@Palbumina", this.albumina)
                , db.parametro("@PLDH", this.LDH)
                , db.parametro("@Pamilasa", this.amilasa)
                , db.parametro("@Purea", this.urea)
                , db.parametro("@PacidoUrico", this.acidoUrico)
                , db.parametro("@Psodio", this.sodio)
                , db.parametro("@Ppotasio", this.potasio)
                , db.parametro("@Pcloro", this.cloro)
                , db.parametro("@Pbicarbonato", this.bicarbonato)
                , db.parametro("@PIgG", this.IgG)
                , db.parametro("@PCK", this.CK)
                , db.parametro("@PliquidoAntigenos", this.liquidoAntigenos)
                , db.parametro("@PsifilisVDRL", this.sifilisVDRL)
                , db.parametro("@PsifilisTPHA", this.sifilisTPHA)
                , db.parametro("@Pecoli", this.ecoli)
                , db.parametro("@PdilucionVDRL", this.dilucionVDRL)
                , db.parametro("@PsifilisRPR", this.sifilisRPR)
                , db.parametro("@PsifilisRPR1", this.sifilisRPR1)
                , db.parametro("@PsifilisFTAABS", this.sifilisFTAABS)
                , db.parametro("@PsPneumoniae", this.sPneumoniae)
                , db.parametro("@PhInfluenza", this.hInfluenza)
                , db.parametro("@Pcryptococcus", this.cryptococcus)
                , db.parametro("@Pdilucion1", this.dilucion1)
                , db.parametro("@PADA", this.ADA)
                , db.parametro("@PUsuario",this.Usuario)
                );
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void eliminar(int idLiquidosCorporales)
    {
        try
        {
            db.ejecutarSP("SPLiquidosCorporalesD", null, db.parametro("@PidLiquidosCorporales", idLiquidosCorporales));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public ClsLiquidosCorporales seleccionarPorId(int idLiquidosCorporales)
    {
        try
        {
            ClsLiquidosCorporales r = new ClsLiquidosCorporales();
            DataTable dt = new DataTable();
            dt = db.dataTableSP("[SPSLiquidosCorporalesPorID]", null, db.parametro("@PidLiquidosCorporales", idLiquidosCorporales));
            if (dt.Rows.Count > 0)
            {
                r.idLiquidosCorporales = clsHelper.valI(dt.Rows[0]["idLiquidosCorporales"].ToString());
                r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
                r.FechaAnalitica = clsHelper.valDate(dt.Rows[0]["FechaAnalitica"].ToString());
                r.liquido = dt.Rows[0]["liquido"].ToString();
                r.aspecto = dt.Rows[0]["aspecto"].ToString();
                r.volumen = clsHelper.valD(dt.Rows[0]["volumen"].ToString());
                r.sedimento = dt.Rows[0]["sedimento"].ToString();
                r.xantocromia = dt.Rows[0]["xantocromia"].ToString();
                r.leucocitos = clsHelper.valD(dt.Rows[0]["leucocitos"].ToString());
                r.eritocitos = clsHelper.valD(dt.Rows[0]["eritocitos"].ToString());
                r.polimorfonucleares = clsHelper.valD(dt.Rows[0]["polimorfonucleares"].ToString());
                r.mononucleares = clsHelper.valD(dt.Rows[0]["mononucleares"].ToString());
                r.linfocitos = clsHelper.valD(dt.Rows[0]["linfocitos"].ToString());
                r.liquidoQuimico = dt.Rows[0]["liquidoQuimico"].ToString();
                r.PH = clsHelper.valD(dt.Rows[0]["PH"].ToString());
                r.glucosa = clsHelper.valD(dt.Rows[0]["glucosa"].ToString());
                r.proteinas = clsHelper.valD(dt.Rows[0]["proteinas"].ToString());
                r.albumina = clsHelper.valD(dt.Rows[0]["albumina"].ToString());
                r.LDH = clsHelper.valD(dt.Rows[0]["LDH"].ToString());
                r.amilasa = clsHelper.valD(dt.Rows[0]["amilasa"].ToString());
                r.urea = clsHelper.valD(dt.Rows[0]["urea"].ToString());
                r.acidoUrico = clsHelper.valD(dt.Rows[0]["acidoUrico"].ToString());
                r.sodio = clsHelper.valD(dt.Rows[0]["sodio"].ToString());
                r.potasio = clsHelper.valD(dt.Rows[0]["potasio"].ToString());
                r.cloro = clsHelper.valD(dt.Rows[0]["cloro"].ToString());
                r.bicarbonato = clsHelper.valD(dt.Rows[0]["bicarbonato"].ToString());
                r.IgG = clsHelper.valD(dt.Rows[0]["IgG"].ToString());
                r.CK = clsHelper.valD(dt.Rows[0]["CK"].ToString());
                r.liquidoAntigenos = dt.Rows[0]["liquidoAntigenos"].ToString();
                r.sifilisVDRL = dt.Rows[0]["sifilisVDRL"].ToString();
                r.sifilisTPHA = dt.Rows[0]["sifilisTPHA"].ToString();
                r.ecoli = dt.Rows[0]["ecoli"].ToString();
                r.dilucionVDRL = dt.Rows[0]["dilucionVDRL"].ToString();
                r.sifilisRPR = dt.Rows[0]["sifilisRPR"].ToString();
                r.sifilisRPR1 = dt.Rows[0]["sifilisRPR1"].ToString();
                r.sifilisFTAABS = dt.Rows[0]["sifilisFTAABS"].ToString();
                r.sPneumoniae = dt.Rows[0]["sPneumoniae"].ToString();
                r.hInfluenza = dt.Rows[0]["hInfluenza"].ToString();
                r.cryptococcus = dt.Rows[0]["cryptococcus"].ToString();
                r.dilucion1 = dt.Rows[0]["dilucion1"].ToString();
                r.ADA = dt.Rows[0]["ADA"].ToString();
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
            dt = db.dataTableSP("[SPLiquidosCorporalesPaciente]", null, db.parametro("@PidPaciente", idPaciente));
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
