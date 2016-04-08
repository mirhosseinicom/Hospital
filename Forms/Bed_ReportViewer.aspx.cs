using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_asp.Forms
{
    public partial class Bed_Report_viewer : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");


        protected void Search()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_BEDS_Blank_For_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PART_ID", Convert.ToInt32(Session["PartID"]));
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
           
            Grid_Report_Bed.DataSource = dt;
            Grid_Report_Bed.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Search();
            }
        }
    }
}