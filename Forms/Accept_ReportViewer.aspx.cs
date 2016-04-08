using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_asp.Forms
{
    public partial class Accept_ReportViewer : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");


        protected void Search()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Search_Accept_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PTNT_NAME", Session["PTNT_NAME"].ToString());
            cmd.Parameters.AddWithValue("@ACPT_TYPE", Session["ACPT_TYPE"].ToString());
            cmd.Parameters.AddWithValue("@PTNT_GENEDER", Convert.ToBoolean(Session["PTNT_GENEDER"]));
            cmd.Parameters.AddWithValue("@ACPT_DATE", Session["ACPT_DATE"].ToString());
            cmd.Parameters.AddWithValue("@PART_ID", Convert.ToInt32(Session["PartID"]));
            DataTable dt = new DataTable();
            //DataSet_Hospital ds = new DataSet_Hospital();
            //SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            //sdp.Fill(ds, "DataTable_Accept");
            //ReportDocument rptDoc = new ReportDocument();
            //rptDoc.Load(Server.MapPath(@"../Report/Accept_Report.rpt"));
            //rptDoc.SetDataSource(ds);
            //CrystalReportViewer1.ReportSource = rptDoc;
            //CrystalReportViewer1.RefreshReport();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            Grid_Report_Accept.DataSource = dt;
            Grid_Report_Accept.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Search();
                //ReportDocument rptDoc = new ReportDocument();
                //rptDoc.Load(Server.MapPath("../Report/CrystalReport1.rpt"));
               
                //CrystalReportViewer1.ReportSource = rptDoc;
                ////rptDoc.Close();
                ////rptDoc.Dispose();
                ////GC.Collect();
            }
        }
    }
}