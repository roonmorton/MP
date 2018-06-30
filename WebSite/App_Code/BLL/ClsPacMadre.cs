using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsPacMadre
/// </summary>
public class ClsPacMadre
{
    public int idPaciente { get; set; }
    public short MadrePositiva { get; set; }
    public string NHC { get; set; }
    public DateTime? FechaDX { get; set; }
    public int? MomentoDX { get; set; }
    public short? Seguimiento { get; set; }
    public int? LugarSeguimiento { get; set; }
    public string OtroLugarSeguimiento { get; set; }
    public short? ControlPrenatal { get; set; }
    public int? lugarControlPrenatal { get; set; }
    public string ComplicacionesEmbarazo { get; set; }
    public short? TARGAEmbarazo { get; set; }
    public int? EsquemaTARGA { get; set; }
    public int? MomentoInicioTARGA { get; set; }
    public int? adherenciaTARGA { get; set; }
    public double? UltimaCV { get; set; }
    public double? UltimoCD4 { get; set; }
    public int? EdadGestacionalUltimaCVCD4 { get; set; }
    public int? infeccionOportunista { get; set; }
    public int? clasificacionClinicaInmunologica { get; set; }
    public string usuario { get; set; }
    public DateTime? fechaTomaDatos { get; set; }

    public ClsPacMadre()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void grabar()
    {
        try
        {
            ClsDb db = new ClsDb();
            db.ejecutarSP("", null
                , db.parametro("@PidPaciente", this.idPaciente)
                , db.parametro("@PMadrePositiva", this.MadrePositiva)
                , db.parametro("@PNHC", this.NHC)
                , db.parametro("@PFechaDX", this.FechaDX)
                , db.parametro("@PMomentoDX", this.MomentoDX)
                , db.parametro("@PSeguimiento", this.Seguimiento)
                , db.parametro("@PLugarSeguimiento", this.LugarSeguimiento)
                , db.parametro("@POtroLugarSeguimiento", this.OtroLugarSeguimiento)
                , db.parametro("@PControlPrenatal", this.ControlPrenatal)
                , db.parametro("@PlugarControlPrenatal", this.lugarControlPrenatal)
                , db.parametro("@PComplicacionesEmbarazo", this.ComplicacionesEmbarazo)
                , db.parametro("@PTARGAEmbarazo", this.TARGAEmbarazo)
                , db.parametro("@PEsquemaTARGA", this.EsquemaTARGA)
                , db.parametro("@PMomentoInicioTARGA", this.MomentoInicioTARGA)
                , db.parametro("@PadherenciaTARGA", this.adherenciaTARGA)
                , db.parametro("@PUltimaCV", this.UltimaCV)
                , db.parametro("@PUltimoCD4", this.UltimoCD4)
                , db.parametro("@PEdadGestacionalUltimaCVCD4", this.EdadGestacionalUltimaCVCD4)
                , db.parametro("@PinfeccionOportunista", this.infeccionOportunista)
                , db.parametro("@PclasificacionClinicaInmunologica", this.clasificacionClinicaInmunologica)
                , db.parametro("@Pusuario", this.usuario)
                  , db.parametro("@PfechaTomaDatos", this.fechaTomaDatos)
        );
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public ClsPacMadre seleccionar(int idPaciente)
    {
        try
        {
            ClsDb db = new ClsDb();
            ClsPacMadre r = new ClsPacMadre();
            DataTable dt = new DataTable();
            dt = db.dataTableSP("SPPACMADRESelect", null, db.parametro("@PidPaciente", idPaciente));
            if (dt.Rows.Count > 0)
            {
                r.idPaciente = (int)dt.Rows[0]["idPaciente"];
                r.MadrePositiva = (short)dt.Rows[0]["MadrePositiva"];
                r.NHC = dt.Rows[0]["nhc"].ToString();
                r.FechaDX = (DateTime)dt.Rows[0]["fechaDX"];
                r.MomentoDX = (int)dt.Rows[0]["momentoDX"];
                r.Seguimiento = (short)dt.Rows[0]["seguimiento"];
                r.LugarSeguimiento = (int)dt.Rows[0]["lugarSeguimiento"];
                r.OtroLugarSeguimiento = dt.Rows[0]["otroLugarSeguimiento"].ToString();
                r.ControlPrenatal = (short)dt.Rows[0]["controlPrenatal"];
                r.lugarControlPrenatal = (int)dt.Rows[0]["lugarControlPrenatal"];
                r.ComplicacionesEmbarazo = dt.Rows[0]["complicacionesEmbarazo"].ToString();
                r.TARGAEmbarazo = (short)dt.Rows[0]["TARGAEmbarazo"];
                r.EsquemaTARGA = (int)dt.Rows[0]["EsquemaTARGA"];
                r.MomentoInicioTARGA = (int)dt.Rows[0]["momentoInicioTARGA"];
                r.adherenciaTARGA = (int)dt.Rows[0]["adherenciaTARGA"];
                r.UltimaCV = (double)dt.Rows[0]["ultimaCV"];
                r.UltimoCD4 = (double)dt.Rows[0]["ultimoCD4"];
                r.EdadGestacionalUltimaCVCD4 = (int)dt.Rows[0]["EdadGestacionalUltimaCVCD4"];
                r.infeccionOportunista = (int)dt.Rows[0]["infeccionOportunista"];
                r.clasificacionClinicaInmunologica = (int)dt.Rows[0]["clasificacionClinicaInmunologica"];
                r.fechaTomaDatos = (DateTime)dt.Rows[0]["fechaTomaDatos"];
            }
            return r;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}