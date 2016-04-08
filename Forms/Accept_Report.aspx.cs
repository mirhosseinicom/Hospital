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
    public partial class Accept_Report : System.Web.UI.Page
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
            Drp_Search_Part.DataSource = dt;
            Drp_Search_Part.DataTextField = "PART_NAME";
            Drp_Search_Part.DataValueField = "PART_ID";
            Drp_Search_Part.DataBind();
            Drp_Search_Part.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_DrpPart();
            }
        }
        protected string Persian_Date(string Date)
        {
            if (Date.Trim() == "")
                return "";
            DateTime dt = Convert.ToDateTime(Date);
            PersianCalendar calendar = new PersianCalendar();
            string shamsidate = calendar.GetYear(dt).ToString() + "/" + calendar.GetMonth(dt).ToString() + "/" + calendar.GetDayOfMonth(dt).ToString("00");
            return shamsidate;
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Session["PartID"] = Drp_Search_Part.Text != "انتخاب کنید" ? Convert.ToInt32(Drp_Search_Part.SelectedValue) : 0;
            Session["PTNT_NAME"] = inp_Search_family.Text;
            Session["ACPT_TYPE"] = inp_Search_Type.Text;
            Session["PTNT_GENEDER"] = rdb_Search_Famale.Checked == true ? true : false;
            Session["ACPT_DATE"] = Persian_Date(inp_Search_Type.Text);
            string scriptString = "<script language='JavaScript'>window.open('../Forms/Accept_ReportViewer.aspx');</script";
            Response.Write(scriptString);
        }
    }
}