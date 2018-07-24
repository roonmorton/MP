using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


public class ClsPsicologiaMenores
{
   public int? idPsicologiaMenores { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaVisita { get; set; }
   public string edadDesarrollo { get; set; }
   public string areaMotoraGruesa { get; set; }
   public string areaLenguaje { get; set; }
   public string areaMotoraFina { get; set; }
   public string areaSocialAfectiva { get; set; }
   public string areaCognoscitiva { get; set; }
   public string areaHabitosSaludHigiene { get; set; }
   public Boolean? aprendizaje { get; set; }
   public int? tipoProblema { get; set; }
   public DateTime? finalizacionProceso { get; set; }
   public string observaciones { get; set; }
   public string usuario { get; set; }

   private ClsDb db = new ClsDb();


   public void grabar()
   {
      try
      {
         db.ejecutarSP("SPPsicologiaIU", null
               , db.parametro("@PidPsicologiaMenores", this.idPsicologiaMenores)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaVisita", this.fechaVisita)
            , db.parametro("@PedadDesarrollo", this.edadDesarrollo)
            , db.parametro("@PareaMotoraGruesa", this.areaMotoraGruesa)
            , db.parametro("@PareaLenguaje", this.areaLenguaje)
            , db.parametro("@PareaMotoraFina", this.areaMotoraFina)
            , db.parametro("@PareaSocialAfectiva", this.areaSocialAfectiva)
            , db.parametro("@PareaCognoscitiva", this.areaCognoscitiva)
            , db.parametro("@PareaHabitosSaludHigiene", this.areaHabitosSaludHigiene)
            , db.parametro("@Paprendizaje", this.aprendizaje)
            , db.parametro("@PtipoProblema", this.tipoProblema)
            , db.parametro("@PfinalizacionProceso", this.finalizacionProceso)
            , db.parametro("@Pobservaciones", this.observaciones)
            ,db.parametro("@Pusuario",this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idPsicologiaMenores)
   {
      try
      {
         db.ejecutarSP("SPPSicologiaMenoresD", null, db.parametro("@PidPsicologiaMenores", idPsicologiaMenores));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public ClsPsicologiaMenores seleccionarPorId(int idPsicologiaMenores)
   {
      try
      {
         ClsPsicologiaMenores r = new ClsPsicologiaMenores();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("SPPsicologiaMenoresPorID", null, db.parametro("@PidPsicologiaMenores", idPsicologiaMenores));
         if (dt.Rows.Count > 0)
         {
            r.idPsicologiaMenores = clsHelper.valI(dt.Rows[0]["idPsicologiaMenores"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaVisita = clsHelper.valDate(dt.Rows[0]["fechaVisita"].ToString());
            r.edadDesarrollo = dt.Rows[0]["edadDesarrollo"].ToString();
            r.areaMotoraGruesa = dt.Rows[0]["areaMotoraGruesa"].ToString();
            r.areaLenguaje = dt.Rows[0]["areaLenguaje"].ToString();
            r.areaMotoraFina = dt.Rows[0]["areaMotoraFina"].ToString();
            r.areaSocialAfectiva = dt.Rows[0]["areaSocialAfectiva"].ToString();
            r.areaCognoscitiva = dt.Rows[0]["areaCognoscitiva"].ToString();
            r.areaHabitosSaludHigiene = dt.Rows[0]["areaHabitosSaludHigiene"].ToString();
            r.aprendizaje = clsHelper.valB(dt.Rows[0]["aprendizaje"].ToString());
            r.tipoProblema = clsHelper.valI(dt.Rows[0]["tipoProblema"].ToString());
            r.finalizacionProceso = clsHelper.valDate(dt.Rows[0]["finalizacionProceso"].ToString());
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
         dt = db.dataTableSP("SPPsicologiaMenoresS", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }



}

