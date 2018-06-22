using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de PacBasales
/// </summary>
public class ClsPacBasales
{

    public int? IdPaciente { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string ExpedienteHR { get; set; }
    public string ExpedientePD { get; set; }
    public string IdGenero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int? PaisResidencia { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int? DepartamentoResidencia { get; set; }
    public int? MunicipioResidencia { get; set; }
    public int? Etnia { get; set; }
    public int? NivelEducativo { get; set; }
    public DateTime Fecha1Visita { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int? PositivoConfirmado { get; set; }
    public int? TrasladoDe { get; set; }
    public int? ComunidadLinguistica { get; set; }
    public int? AtendidoEn { get; set; }
    public int? NacimientoPor { get; set; }
    public short? AZTIVMadre { get; set; }
    public int? PesoAlNacerLbs { get; set; }
    public int? PesoAlNacerOz { get; set; }
    public int? edadGestacional { get; set; }
    public double? TallaAlNacer { get; set; }
    public string APGAR { get; set; }
    public string CC { get; set; }
    public string crecimientoIntrauterino { get; set; }
    public string AEG { get; set; }
    public string PEG { get; set; }
    public string CEG { get; set; }
    public int? PatologiaNeonatal { get; set; }
    public short? ProfilaxisETMH { get; set; }
    public int? cualProfilaxisETMH { get; set; }
    public string OtroProfilaxisETMH { get; set; }
    public string DosisProfilaxis { get; set; }
    public int? PorcentajeAderenciaProfilaxis { get; set; }
    public string EfectosSecundarios { get; set; }
    public short? OtrosMedicamentos { get; set; }
    public string OtrosMedicamentosCual { get; set; }
    public short? LactanciaMaterna { get; set; }
    public double? tiempoLM { get; set; }
    public DateTime? FechaPositivoConfirmado { get; set; }
    public int? MetodoDX { get; set; }
    public int? ViaInfeccion { get; set; }
    public short? TARGAPrevio { get; set; }
    public string CualTARGAPREVIO { get; set; }
    public DateTime? FechaInicio { get; set; }
    public short? Suspendido { get; set; }
    public string MotivoSuspension { get; set; }
    public short? VidaSexual { get; set; }
    public short? PacienteConoceDiagnostico { get; set; }
    public string CrecimientoDesarrollo { get; set; }
    public string Medicos { get; set; }
    public string Quirurgicos { get; set; }
    public string Traumaticos { get; set; }
    public string Alergicos { get; set; }
    public string RevisionPorSistemas { get; set; }
    public short? RiesgoExpuesto { get; set; }
    public string Usuario { get; set; }
    public string NombreMadreEncargada { get; set; }
    public string NombrePadreEncargado { get; set; }
    public int? condicionSocial { get; set; }
    public int? Nacionalidad { get; set; }

    private ClsDb db = new ClsDb();
    public ClsPacBasales()
    {

    }


    public string grabar()
    {
        string rIdPaciente = string.Empty;
        DataTable dt = new DataTable();
        try
        {
            dt = db.dataTableSP("[SPPACBASALESIU]", null
                    , db.parametro("@PIdPaciente", this.IdPaciente)
                    , db.parametro("@PPrimerNombre", this.PrimerNombre)
                    , db.parametro("@PSegundoNombre", this.SegundoNombre)
                    , db.parametro("@PPrimerApellido", this.PrimerApellido)
                    , db.parametro("@PSegundoApellido", this.SegundoApellido)
                    , db.parametro("@PExpedienteHR", this.ExpedienteHR)
                    , db.parametro("@PExpedientePD", this.ExpedientePD)
                    , db.parametro("@PIdGenero", this.IdGenero)
                    , db.parametro("@PFechaNacimiento", this.FechaNacimiento)
                    , db.parametro("@PPaisResidencia", this.PaisResidencia)
                    , db.parametro("@PDireccion", this.Direccion)
                    , db.parametro("@PTelefono", this.Telefono)
                    , db.parametro("@PDepartamentoResidencia", this.DepartamentoResidencia)
                    , db.parametro("@PMunicipioResidencia", this.MunicipioResidencia)
                    , db.parametro("@PEtnia", this.Etnia)
                    , db.parametro("@PNivelEducativo", this.NivelEducativo)
                    , db.parametro("@PFecha1Visita", this.Fecha1Visita )
                    , db.parametro("@PFechaModificacion", this.FechaModificacion)
                    , db.parametro("@PPositivoConfirmado", this.PositivoConfirmado)
                    , db.parametro("@PTrasladoDe", this.TrasladoDe)
                    , db.parametro("@PComunidadLinguistica", this.ComunidadLinguistica)
                    , db.parametro("@PAtendidoEn", this.AtendidoEn)
                    , db.parametro("@PNacimientoPor", this.NacimientoPor)
                    , db.parametro("@PAZTIVMadre", this.AZTIVMadre)
                    , db.parametro("@PPesoAlNacerLbs", this.PesoAlNacerLbs)
                    , db.parametro("@PPesoAlNacerOz", this.PesoAlNacerOz)
                    , db.parametro("@PedadGestacional", this.edadGestacional)
                    , db.parametro("@PTallaAlNacer", this.TallaAlNacer)
                    , db.parametro("@PAPGAR", this.APGAR)
                    , db.parametro("@PCC", this.CC)
                    , db.parametro("@PcrecimientoIntrauterino", this.crecimientoIntrauterino)
                    , db.parametro("@PAEG", this.AEG)
                    , db.parametro("@PPEG", this.PEG)
                    , db.parametro("@PCEG", this.CEG)
                    , db.parametro("@PPatologiaNeonatal", this.PatologiaNeonatal)
                    , db.parametro("@PProfilaxisETMH", this.ProfilaxisETMH)
                    , db.parametro("@PcualProfilaxisETMH", this.cualProfilaxisETMH)
                    , db.parametro("@POtroProfilaxisETMH", this.OtroProfilaxisETMH)
                    , db.parametro("@PDosisProfilaxis", this.DosisProfilaxis)
                    , db.parametro("@PPorcentajeAderenciaProfilaxis", this.PorcentajeAderenciaProfilaxis)
                    , db.parametro("@PEfectosSecundarios", this.EfectosSecundarios)
                    , db.parametro("@POtrosMedicamentos", this.OtrosMedicamentos)
                    , db.parametro("@POtrosMedicamentosCual", this.OtrosMedicamentosCual)
                    , db.parametro("@PLactanciaMaterna", this.LactanciaMaterna)
                    , db.parametro("@PtiempoLM", this.tiempoLM)
                    , db.parametro("@PFechaPositivoConfirmado", this.FechaPositivoConfirmado)
                    , db.parametro("@PMetodoDX", this.MetodoDX)
                    , db.parametro("@PViaInfeccion", this.ViaInfeccion)
                    , db.parametro("@PTARGAPrevio", this.TARGAPrevio)
                    , db.parametro("@PCualTARGAPREVIO", this.CualTARGAPREVIO)
                    , db.parametro("@PFechaInicio", this.FechaInicio)
                    , db.parametro("@PSuspendido", this.Suspendido)
                    , db.parametro("@PMotivoSuspension", this.MotivoSuspension)
                    , db.parametro("@PVidaSexual", this.VidaSexual)
                    , db.parametro("@PPacienteConoceDiagnostico", this.PacienteConoceDiagnostico)
                    , db.parametro("@PCrecimientoDesarrollo", this.CrecimientoDesarrollo)
                    , db.parametro("@PMedicos", this.Medicos)
                    , db.parametro("@PQuirurgicos", this.Quirurgicos)
                    , db.parametro("@PTraumaticos", this.Traumaticos)
                    , db.parametro("@PAlergicos", this.Alergicos)
                    , db.parametro("@PRevisionPorSistemas", this.RevisionPorSistemas)
                    , db.parametro("@PRiesgoExpuesto", this.RiesgoExpuesto)
                    , db.parametro("@PUsuario", this.Usuario)
                    , db.parametro("@PNombreMadreEncargada", this.NombreMadreEncargada)
                    , db.parametro("@PNombrePadreEncargado", this.NombrePadreEncargado)
                    , db.parametro("@PCondicionSocial", this.condicionSocial)
                    , db.parametro("@PNacionalidad", this.Nacionalidad)
                 );

            if (dt.Rows.Count > 0)
            {
                rIdPaciente = dt.Rows[0][0].ToString();
            }
            return rIdPaciente;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public void eliminar()
    {
        try
        {

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable getData(string idPaciente) {
        DataTable dt = new DataTable();
        try
        {
            dt = db.dataTableSP("SPPACBASALESS", null, db.parametro("@PIdPaciente", idPaciente));
            return dt;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
}