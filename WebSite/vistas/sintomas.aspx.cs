using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_sintomas : System.Web.UI.Page
{
    ClsRol crol = new ClsRol();
    ClsCSintoma clsCsintoma = new ClsCSintoma();
    ClsSintomologia clsSintomologia = new ClsSintomologia();
    ClsPacBasales clsPacBasales = new ClsPacBasales();
    //string idSintomatologia = "0";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //asignarPermisos();
            Session["Usuario"] = "Aramirez";
            crol.idRol = null;
            Session["idPaciente"] = "1";
            DataTable dtPaciente = this.clsPacBasales.getData(Session["idPaciente"].ToString());
            this.lblNombrePaciente.Text = dtPaciente.Rows[0]["PrimerNombre"].ToString();
            this.cargarCheckBoxList();
            this.limpiar();
            

        }
    }


    protected void limpiar()
    {
        try {
            //cargarCheckBoxList();
            this.cboxListGastrointestinal.ClearSelection();
            this.cBoxListGeneral.ClearSelection();
            this.cBoxListGenitoUrinario.ClearSelection();
            this.cBoxListMusculoEsqueletico.ClearSelection();
            this.cBoxListNeurologico.ClearSelection();
            this.cBoxListOrganosSentidos.ClearSelection();
            this.cBoxListPulmonar.ClearSelection();
            //Vaciar casillas Otros
            this.txtOtroGeneral.Text = "";
            this.txtOtroCardioPulmonar.Text = "";
            this.txtOtroGastroIntestinal.Text = "";
            this.txtOtroGenitoUnirnario.Text = "";
            this.txtOtroMusculoEsqueletico.Text = "";
            this.txtOtroNeurologico.Text = "";
            this.txtOtroOrganosSentidos.Text = "";


            // Generar la fecha para cargar fecha de hoy automaticamente
            this.txtFechaSintomologia.Text = "";
            this.txtFechaSintomologia.Focus();
            this.txtFechaSintomologia.Enabled = true;

            Session["idSintomologia"] = "0";
            this.cargarHistorico();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void cargarCheckBoxList()
    {
        try
        {
            this.cargarCheckBoxList(clsCsintoma.CSelect("Gastrointestinal"),this.cboxListGastrointestinal) ;
            this.cargarCheckBoxList(clsCsintoma.CSelect("General"), this.cBoxListGeneral);
            this.cargarCheckBoxList(clsCsintoma.CSelect("Sistema Cardio-Pulmonar"), this.cBoxListPulmonar);
            this.cargarCheckBoxList(clsCsintoma.CSelect("Sistema Nervioso Central"), this.cBoxListNeurologico);
            this.cargarCheckBoxList(clsCsintoma.CSelect("Músculo – Esquelético"), this.cBoxListMusculoEsqueletico);
            this.cargarCheckBoxList(clsCsintoma.CSelect("Genito urinario"), this.cBoxListGenitoUrinario);
            this.cargarCheckBoxList(clsCsintoma.CSelect("Órganos sentidos"), this.cBoxListOrganosSentidos);
            /*this.txtOtroGeneral.Enabled = false;
            this.txtOtroCardioPulmonar.Enabled = false;
            this.txtOtroGastroIntestinal.Enabled = false;
            this.txtOtroGenitoUnirnario.Enabled = false;
            this.txtOtroMusculoEsqueletico.Enabled = false;
            this.txtOtroNeurologico.Enabled = false;
            this.txtOtroOrganosSentidos.Enabled = false;*/
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    protected void cargarCheckBoxList(DataTable data, CheckBoxList cboxl)
    {
        try
        {
            foreach (DataRow row in data.Rows)
            {
                cboxl.Items.Add(new ListItem(row[0].ToString(), row[1].ToString()));
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }


    protected void btnNuevaSintomologia_Click(object sender, EventArgs e)
    {
        try
        {
            limpiar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void cargarHistorico()
    {
        try
        {
            //DataTable dt = new DataTable();
            /*dt.Columns.Add("fechaSintomologia", typeof(string));
            dt.Columns.Add("sintomas", typeof(string));

            DataRow dr = dt.NewRow();

            dr["fechaSintomologia"] = "10/05/2018";
            dr["sintomas"] = "sintoma 1, sintoma 2, sintoma 3,sintoma 1, sintoma 2, sintoma 3,sintoma 1, sintoma 2, sintoma 3,sintoma 1, sintoma 2, sintoma 3,sintoma 1, sintoma 2, sintoma 3,sintoma 1, sintoma 2, sintoma 3";

            dt.Rows.Add(dr);**/
            //dr = dt.NewRow();
            this.gridHistoricoSintomologia.DataSource = clsSintomologia.seleccionarSintomatologiasPaciente(Session["idPaciente"].ToString());
            this.gridHistoricoSintomologia.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void generarDT(ref DataTable dtSintomas, ref DataTable dtOtros, CheckBoxList list,string Tab)
    {
        foreach (ListItem item in list.Items)
        {
            //Creacion de DataTable para Sintomas chequeados
            DataRow rowSintomas, rowOtro;
            rowSintomas = dtSintomas.NewRow();
            rowSintomas["idSintomologia"] = Session["idSintomologia"].ToString();
            rowSintomas["IdSintoma"] = item.Value;
            rowSintomas["chequeado"] = 0;

            if (item.Selected)
            {
                rowSintomas["chequeado"] = 1;

                // Crear DataTable para Guardar textos de otros

                if (item.Text.ToString().Trim() == "Otros")
                {
                    rowOtro = dtOtros.NewRow();
                    rowOtro["idSintoma"] = item.Value;
                    switch (Tab)
                    {
                        case "General":
                            rowOtro["descripcion"] = this.txtOtroGeneral.Text;
                            break;
                        case "Sistema Cardio-Pulmonar":
                            rowOtro["descripcion"] = this.txtOtroCardioPulmonar.Text;
                            break;
                        case "Gastrointestinal":
                            rowOtro["descripcion"] = this.txtOtroGastroIntestinal.Text;
                            break;
                        case "Sistema Nervioso Central":
                            rowOtro["descripcion"] = this.txtOtroNeurologico.Text;
                            break;
                        case "Músculo – Esquelético":
                            rowOtro["descripcion"] = this.txtOtroMusculoEsqueletico.Text;
                            break;
                        case "Genito urinario":
                            rowOtro["descripcion"] = this.txtOtroGenitoUnirnario.Text;
                            break;
                        case "Órganos sentidos":
                            rowOtro["descripcion"] = this.txtOtroOrganosSentidos.Text;
                            break;
                        
                    }
                    dtOtros.Rows.Add(rowOtro);
                }
                
            }
            dtSintomas.Rows.Add(rowSintomas);
        }
    }

    protected void guardar()
    {
        try
        {
            //this.txtOtroGeneral.Text = Session["idSintomologia"].ToString();
            DataTable dtSintomas = new DataTable();
            DataTable dtOtros = new DataTable();
            List<DataTable> lDataTable = new List<DataTable>() ;
            

            dtSintomas.Columns.Add("IdSintomologia", typeof(string));
            dtSintomas.Columns.Add("IdSintoma", typeof(string));
            dtSintomas.Columns.Add("chequeado", typeof(string));
            dtSintomas.Columns.Add("id", typeof(string));

            dtOtros.Columns.Add("idSintoma",typeof(string));
            dtOtros.Columns.Add("descripcion", typeof(string));

            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListGeneral, "General");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cboxListGastrointestinal, "Gastrointestinal");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListPulmonar, "Sistema Cardio-Pulmonar");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListNeurologico, "Sistema Nervioso Central");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListMusculoEsqueletico, "Músculo – Esquelético");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListGenitoUrinario, "Genito urinario");
            this.generarDT(ref dtSintomas, ref dtOtros, this.cBoxListOrganosSentidos, "Órganos sentidos");

            lDataTable.Add(dtSintomas);
            lDataTable.Add(dtOtros);

            if(dtSintomas == null)
            {
                this.txtOtroGeneral.Text = "sintomas es null";
            }else if(dtOtros == null)
            {
                this.txtOtroGeneral.Text = "Otros es null";
            }
            if(lDataTable == null)
                this.txtOtroGeneral.Text = "Lista DT es null";

            this.clsSintomologia.grabar(
                 this.txtFechaSintomologia.Text.Trim(),
                 Session["idSintomologia"].ToString(), //IdSintomologia
                 Session["idPaciente"].ToString(),
                 lDataTable);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancelarSintomolia_Click(object sender, EventArgs e)
    {
        Server.Transfer("inicio.aspx",true);
    }

    protected void btnGuardarSintomologia_Click(object sender, EventArgs e)
    {
        this.guardar();
        this.limpiar();
        Server.Transfer("sintomas.aspx",false);
    }

    protected void lnkEditSintomatologia_Click(object sender, EventArgs e)
    {
        // CARGAR COMBOS PARA EDICION, RECORDAR QUE DEBE DE CARGAR EL IDSINTOMOLOGIA PARA EL GRID A INSERTAR
        try
        {
            GridViewRow r = (GridViewRow)((Control)sender).Parent.Parent;
            Session["idSintomologia"] = (r.Cells[0].Text);
            //this.txtOtroGeneral.Text = Session["idSintomologia"].ToString();
            this.txtFechaSintomologia.Text = (r.Cells[1].Text);
            this.txtFechaSintomologia.Enabled = false;

            DataTable dt = new DataTable();
            dt = this.clsCsintoma.seleccionarSintomasSintomologia(Session["idSintomologia"].ToString());
            
            foreach(DataRow row in dt.Rows)
            {
                this.validarCheckbox(this.cBoxListGeneral,row);
                this.validarCheckbox(this.cboxListGastrointestinal, row);
                this.validarCheckbox(this.cBoxListGenitoUrinario, row);
                this.validarCheckbox(this.cBoxListMusculoEsqueletico, row);
                this.validarCheckbox(this.cBoxListNeurologico, row);
                this.validarCheckbox(this.cBoxListOrganosSentidos, row);
                this.validarCheckbox(this.cBoxListPulmonar, row);
                
                
            }

        }
        catch(Exception ex)
        {
            throw ex; 
        }
    }

    protected void cBoxListGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Verificar si se se marco otros para habi
    }


    private void validarCheckbox(CheckBoxList chkList, DataRow row)
    {
        foreach(ListItem item in chkList.Items)
        {
            if(item.Value == row["idSintoma"].ToString())
            {
                if (row["chequeado"].ToString() == "1")
                    item.Selected = true;
                else
                    item.Selected = false;

                if (row["nombreSintoma"].ToString() == "Otros")
                {
                    switch (row["nombreCategoria"].ToString())
                    {
                        case "General":

                            this.txtOtroGeneral.Text = 
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(), 
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString() ;
                            break;
                        case "Sistema Cardio-Pulmonar":
                            this.txtOtroCardioPulmonar.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                        case "Gastrointestinal":
                            this.txtOtroGastroIntestinal.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                        case "Sistema Nervioso Centralr":
                            this.txtOtroNeurologico.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                        case "Músculo – Esquelético":
                            this.txtOtroMusculoEsqueletico.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                        case "Genito urinario":
                            this.txtOtroGenitoUnirnario.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                        case "Órganos sentidos":
                            this.txtOtroOrganosSentidos.Text =
                                this.clsCsintoma.seleccionarSintomaOtro(
                                    row["idSintoma"].ToString(),
                                    Session["idSintomologia"].ToString())
                                    .Rows[0]["descripcion"].ToString();
                            break;
                    }
                }
            }
        }
    }

    
}