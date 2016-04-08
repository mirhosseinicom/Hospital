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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Exist_User";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_USERNAME", username.Text);
            cmd.Parameters.AddWithValue("@USER_PASSWORK", password.Text);
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
                if(dt.Rows.Count>0)
                {
                    Session["imag_avatar"] = dt.Rows[0]["USER_IMAG"];
                    string ss = Session["imag_avatar"].ToString();
                    Response.Redirect("Dashboard.aspx");
                  
                   
                }
           
               


            }
        }
    }
}