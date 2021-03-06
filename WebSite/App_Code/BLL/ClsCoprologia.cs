﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Clscoprologia
{
   public int? idCoprologia { get; set; }
   public int? idPaciente { get; set; }
   public DateTime? fechaAnalitica { get; set; }
   public string sangreOculta { get; set; }
   public string azulMetilenoHeces { get; set; }
   public string polimorfonucleares { get; set; }
   public string mononucleares { get; set; }
   public string paracitosHeces { get; set; }
   public string azucaresReductores { get; set; }
   public string usuario { get; set; }
   private ClsDb db = new ClsDb();
   public void grabar()
   {
      try
      {
         db.ejecutarSP("[SPCoprologiaIU]", null
            , db.parametro("@PidCoprologia", this.idCoprologia)
            , db.parametro("@PidPaciente", this.idPaciente)
            , db.parametro("@PfechaAnalitica", this.fechaAnalitica)
            , db.parametro("@PsangreOculta", this.sangreOculta)
            , db.parametro("@PazulMetilenoHeces", this.azulMetilenoHeces)
            , db.parametro("@Ppolimorfonucleares", this.polimorfonucleares)
            , db.parametro("@Pmononucleares", this.mononucleares)
            , db.parametro("@PparacitosHeces", this.paracitosHeces)
            , db.parametro("@PazucaresReductores", this.azucaresReductores)
            ,db.parametro("@Pusuario",this.usuario)
            );
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public void eliminar(int idCoprologia)
   {
      try
      {
         db.ejecutarSP("UPCoprologiaD", null, db.parametro("@PidCoprologia", idCoprologia));
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
   public Clscoprologia seleccionarPorId(int idCoprologia)
   {
      try
      {
         Clscoprologia r = new Clscoprologia();
         DataTable dt = new DataTable();
         dt = db.dataTableSP("UPSCoprologiaPorID", null, db.parametro("@PidCoprologia", idCoprologia));
         if (dt.Rows.Count > 0)
         {
            r.idCoprologia = clsHelper.valI(dt.Rows[0]["idCoprologia"].ToString());
            r.idPaciente = clsHelper.valI(dt.Rows[0]["idPaciente"].ToString());
            r.fechaAnalitica = clsHelper.valDate(dt.Rows[0]["fechaAnalitica"].ToString());
            r.sangreOculta = dt.Rows[0]["sangreOculta"].ToString();
            r.azulMetilenoHeces =dt.Rows[0]["azulMetilenoHeces"].ToString();
            r.polimorfonucleares =dt.Rows[0]["polimorfonucleares"].ToString();
            r.mononucleares =dt.Rows[0]["mononucleares"].ToString();
            r.paracitosHeces =dt.Rows[0]["paracitosHeces"].ToString();
            r.azucaresReductores =dt.Rows[0]["azucaresReductores"].ToString();
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
         dt = db.dataTableSP("SPCoprologiaTodos", null, db.parametro("@PidPaciente", idPaciente));
         return dt;
      }
      catch (Exception ex)
      {
         throw ex;
      }
   }
}
