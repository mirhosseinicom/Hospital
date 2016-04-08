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
    public partial class bed_Report : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Bind_DrpPart()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_Part";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            Drp_Part.DataSource = dt;
            Drp_Part.DataTextField = "PART_NAME";
            Drp_Part.DataValueField = "PART_ID";
            Drp_Part.DataBind();
            Drp_Part.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_DrpPart();
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Session["PartID"] = Drp_Part.Text != "انتخاب کنید" ? Convert.ToInt32(Drp_Part.SelectedValue) : 0;
            string scriptString = "<script language='JavaScript'>window.open('../Forms/Bed_ReportViewer.aspx');</script";
            Response.Write(scriptString);
        }
    }
}