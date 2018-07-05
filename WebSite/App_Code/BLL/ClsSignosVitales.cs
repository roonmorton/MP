using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descripción breve de ClsSignosVitales
/// </summary>
public class ClsSignosVitales
{
    public int? IdSignosVitales { get; set; }
    public int? IdPaciente { get; set; }
    public DateTime? FechaVisita { get; set; }
    public DateTime? FechaProximaVisita { get; set; }
    public int? TipoVisita { get; set; }
    public Double? Peso { get; set; }
    public int? Talla { get; set; }
    public Double? IMC { get; set; }
    public int? Estadio { get; set; }
    public int? FrecCardiaca { get; set; }
    public int? FrecRespiratoria { get; set; }
    public int? PresionArterialSist { get; set; }
    public int? PresionArterialDiast { get; set; }
    public int? SaturacionOxigeno { get; set; }
    public Double? Temperatura { get; set; }
    public int? EdadAnos { get; set; }
    public int? EdadMeses { get; set; }
    public int? EdadDias { get; set; }
    public string observaciones { get; set; }
    private ClsDb db = new ClsDb();
    public void grabar()
    {
        try
        {
            db.ejecutarSP("SPSignosVitalesIU", null
                    , db.parametro("@PIdSignosVitales", this.IdSignosVitales)
                , db.parametro("@PIdPaciente", this.IdPaciente)
                , db.parametro("@PFechaVisita", this.FechaVisita)
                , db.parametro("@PFechaProximaVisita", this.FechaProximaVisita)
                , db.parametro("@PTipoVisita", this.TipoVisita)
                , db.parametro("@PPeso", this.Peso)
                , db.parametro("@PTalla", this.Talla)
                , db.parametro("@PIMC", this.IMC)
                , db.parametro("@PEstadio", this.Estadio)
                , db.parametro("@PFrecCardiaca", this.FrecCardiaca)
                , db.parametro("@PFrecRespiratoria", this.FrecRespiratoria)
                , db.parametro("@PPresionArterialSist", this.PresionArterialSist)
                , db.parametro("@PPresionArterialDiast", this.PresionArterialDiast)
                , db.parametro("@PSaturacionOxigeno", this.SaturacionOxigeno)
                , db.parametro("@PTemperatura", this.Temperatura)
                , db.parametro("@PEdadAnos", this.EdadAnos)
                , db.parametro("@PEdadMeses", this.EdadMeses)
                , db.parametro("@PEdadDias", this.EdadDias)
                , db.parametro("@Pobservaciones", this.observaciones)
                );
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void eliminar(int IdSignosVitales)
    {
        try
        {
            db.ejecutarSP("SPSignosVitalesD", null, db.parametro("@PIdSignosVitales", IdSignosVitales));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public ClsSignosVitales seleccionarPorId(int IdSignosVitales)
    {
        try
        {
            ClsSignosVitales r = new ClsSignosVitales();
            DataTable dt = new DataTable();
            dt = db.dataTableSP("SPSignosVitalesSPorId", null, db.parametro("@PIdSignosVitales", IdSignosVitales));
            if (dt.Rows.Count > 0)
            {
                r.IdSignosVitales = clsHelper.valI(dt.Rows[0]["IdSignosVitales"].ToString());
                r.IdPaciente = clsHelper.valI(dt.Rows[0]["IdPaciente"].ToString());
                r.FechaVisita = clsHelper.valDate(dt.Rows[0]["FechaVisita"].ToString());
                r.FechaProximaVisita = clsHelper.valDate(dt.Rows[0]["FechaProximaVisita"].ToString());
                r.TipoVisita = clsHelper.valI(dt.Rows[0]["TipoVisita"].ToString());
                r.Peso = clsHelper.valD(dt.Rows[0]["Peso"].ToString());
                r.Talla = clsHelper.valI(dt.Rows[0]["Talla"].ToString());
                r.IMC = clsHelper.valD(dt.Rows[0]["IMC"].ToString());
                r.Estadio = clsHelper.valI(dt.Rows[0]["Estadio"].ToString());
                r.FrecCardiaca = clsHelper.valI(dt.Rows[0]["FrecCardiaca"].ToString());
                r.FrecRespiratoria = clsHelper.valI(dt.Rows[0]["FrecRespiratoria"].ToString());
                r.PresionArterialSist = clsHelper.valI(dt.Rows[0]["PresionArterialSist"].ToString());
                r.PresionArterialDiast = clsHelper.valI(dt.Rows[0]["PresionArterialDiast"].ToString());
                r.SaturacionOxigeno = clsHelper.valI(dt.Rows[0]["SaturacionOxigeno"].ToString());
                r.Temperatura = clsHelper.valD(dt.Rows[0]["Temperatura"].ToString());
                r.EdadAnos = clsHelper.valI(dt.Rows[0]["EdadAnos"].ToString());
                r.EdadMeses = clsHelper.valI(dt.Rows[0]["EdadMeses"].ToString());
                r.EdadDias = clsHelper.valI(dt.Rows[0]["EdadDias"].ToString());
                r.observaciones = dt.Rows[0]["observaciones"].ToString();
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
            dt = db.dataTableSP("SPSignosVitalesSSELECT", null, db.parametro("@PIdPaciente", idPaciente));
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public ClsSignosVitales()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}