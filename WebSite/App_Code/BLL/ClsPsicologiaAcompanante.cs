using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descripción breve de ClsPsicologiaAcompanante
/// </summary>
public class ClsPsicologiaAcompanante
{
    public class ClspsicologiaAcompanante
    {
        public int? idPsicologiaAcompanante { get; set; }
        public int? idPaciente { get; set; }
        public DateTime? fechaVisita { get; set; }
        public int? edad { get; set; }
        public int? relacionConNino { get; set; }
        public int? proceso { get; set; }
        public int? tipoIntervencion { get; set; }
        public int? esAdherente { get; set; }
        public int? comprensionInformacionVIHSegunEdad { get; set; }
        public int? afrontamientoEnfermedad { get; set; }
        public int? alertasAfectivas { get; set; }
        public int? tipoalertaAfectiva { get; set; }
        public int? minimental { get; set; }
        public int? depresion { get; set; }
        public int? ansiedad { get; set; }
        public int? autoEstima { get; set; }
        public string usuario { get; set; }
        private ClsDb db = new ClsDb();
        public void grabar()
        {
            try
            {
                db.ejecutarSP("[SPPsicologiaAcompananteIU]", null
                        , db.parametro("@PidPsicologiaAcompanante", this.idPsicologiaAcompanante)
                    , db.parametro("@PidPaciente", this.idPaciente)
                    , db.parametro("@PfechaVisita", this.fechaVisita)
                    , db.parametro("@Pedad", this.edad)
                    , db.parametro("@PrelacionConNino", this.relacionConNino)
                    , db.parametro("@Pproceso", this.proceso)
                    , db.parametro("@PtipoIntervencion", this.tipoIntervencion)
                    , db.parametro("@PesAdherente", this.esAdherente)
                    , db.parametro("@PcomprensionInformacionVIHSegunEdad", this.comprensionInformacionVIHSegunEdad)
                    , db.parametro("@PafrontamientoEnfermedad", this.afrontamientoEnfermedad)
                    , db.parametro("@PalertasAfectivas", this.alertasAfectivas)
                    , db.parametro("@PtipoalertaAfectiva", this.tipoalertaAfectiva)
                    , db.parametro("@Pminimental", this.minimental)
                    , db.parametro("@Pdepresion", this.depresion)
                    , db.parametro("@Pansiedad", this.ansiedad)
                    , db.parametro("@PautoEstima", this.autoEstima)
                    ,db.parametro("@Pusuario",this.usuario )
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminar(int idPsicologiaAcompanante)
        {
            try
            {
                db.ejecutarSP("SPPsicologiaAcompananteD", null, db.parametro("@PidPsicologiaAcompanante", idPsicologiaAcompanante));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClspsicologiaAcompanante seleccionarPorId(int idPsicologiaAcompanante)
        {
            try
            {
                ClspsicologiaAcompanante r = new ClspsicologiaAcompanante();
                DataTable dt = new DataTable();
                dt = db.dataTableSP("SPSPsicologiaAcompanantePorID", null, db.parametro("@PidPsicologiaAcompanante", idPsicologiaAcompanante));
                if (dt.Rows.Count > 0)
                {
                    r.idPsicologiaAcompanante = clsHelper.valI(dt.Rows[0]["idPsicologiaAcompanante"].ToString());
                    r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
                    r.fechaVisita = clsHelper.valDate(dt.Rows[0]["fechaVisita"].ToString());
                    r.edad = clsHelper.valI(dt.Rows[0]["edad"].ToString());
                    r.relacionConNino = clsHelper.valI(dt.Rows[0]["relacionConNino"].ToString());
                    r.proceso = clsHelper.valI(dt.Rows[0]["proceso"].ToString());
                    r.tipoIntervencion = clsHelper.valI(dt.Rows[0]["tipoIntervencion"].ToString());
                    r.esAdherente = clsHelper.valI(dt.Rows[0]["esAdherente"].ToString());
                    r.comprensionInformacionVIHSegunEdad = clsHelper.valI(dt.Rows[0]["comprensionInformacionVIHSegunEdad"].ToString());
                    r.afrontamientoEnfermedad = clsHelper.valI(dt.Rows[0]["afrontamientoEnfermedad"].ToString());
                    r.alertasAfectivas = clsHelper.valI(dt.Rows[0]["alertasAfectivas"].ToString());
                    r.tipoalertaAfectiva = clsHelper.valI(dt.Rows[0]["tipoalertaAfectiva"].ToString());
                    r.minimental = clsHelper.valI(dt.Rows[0]["minimental"].ToString());
                    r.depresion = clsHelper.valI(dt.Rows[0]["depresion"].ToString());
                    r.ansiedad = clsHelper.valI(dt.Rows[0]["ansiedad"].ToString());
                    r.autoEstima = clsHelper.valI(dt.Rows[0]["autoEstima"].ToString());
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
                dt = db.dataTableSP("SPPsicologiaAcompananteSelect", null, db.parametro("@PidPaciente", idPaciente ));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}