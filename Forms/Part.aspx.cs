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
    public partial class Part : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Bind_GridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_Part";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                GridView1.Visible = false;
            else
                GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

       
      
        protected void Bind_Drp_Department()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cnn;
                cmd.CommandText = "Get_DEPARMENTS";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                cnn.Open();
                dt.Load(cmd.ExecuteReader());
                cnn.Close();
                Drp_Dempartment.Items.Clear();
                Drp_Dempartment.DataSource = dt;
                Drp_Dempartment.DataTextField = "DPRM_NAME";
                Drp_Dempartment.DataValueField = "DPRM_ID";
                Drp_Dempartment.DataBind();
                Drp_Dempartment.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
            }
            catch
            {

            }
           
        }
        protected void Insert_DEPARMENTS()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Insert_DEPARMENTS", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@DPRM_NAME", inpDepartment_Name.Text);
                Session["DPRM_NAME"] = inpDepartment_Name.Text;
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }

        }
        protected void Insert_Part()
        {
            DataTable get_id_department=new DataTable();
            try
            {
                SqlCommand scom1 = new SqlCommand("Get_DPRT_ID_with_Name", cnn);
                scom1.CommandType = CommandType.StoredProcedure;
                scom1.Parameters.AddWithValue("@DPRM_NAME", Drp_Dempartment.SelectedItem.Text);
                cnn.Open();
               get_id_department.Load(scom1.ExecuteReader());
                cnn.Close();
                if (get_id_department.Rows.Count != 0)
                {
                    SqlCommand scom = new SqlCommand("Insert_PARTS", cnn);
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@PART_NAME", inp_part_Name.Text);
                    scom.Parameters.AddWithValue("@DPRM_ID",Convert.ToInt32( get_id_department.Rows[0]["DPRM_ID"]));
                    cnn.Open();
                    scom.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch
            {

            }

        }
        protected void Update_Part()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Update_PARTS", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@PART_ID", Convert.ToInt32(Session["id"]));
                scom.Parameters.AddWithValue("@PART_NAME", inp_part_Name.Text);

                scom.Parameters.AddWithValue("@DPRM_ID", Drp_Dempartment.Text != "انتخاب کنید" ?Convert.ToInt32( Drp_Dempartment.SelectedValue) : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }

        }
        protected void Delete_PARTS(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_PARTS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PART_ID", Convert.ToInt32(lbl));
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Insert"] = true;
                Bind_Drp_Department();
                Bind_GridView();
            }
        }

        protected void btnPart_sabt_Click(object sender, EventArgs e)
        {
            if (Drp_Dempartment.SelectedItem.Text.ToString() != "-1" & inp_part_Name.Text != "")
            {
                if (true == Convert.ToBoolean(Session["Insert"]))
                    Insert_Part();
                else
                    Update_Part();
                Bind_GridView();
                Response.Redirect(Request.RawUrl);
            }
            else
                Response.Redirect(Request.RawUrl);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_GridView();
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();
        }

       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.RowIndex;
                string lbDOC_ID = GridView1.Rows[GridView1.EditIndex].Cells[0].Text.ToString();

                Delete_PARTS(lbDOC_ID);
            }
            catch
            {

            }
            Bind_GridView();
            Response.Redirect(Request.RawUrl);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["Insert"] = false;
                GridView1.EditIndex = e.NewEditIndex;
                Session["id"] = GridView1.Rows[GridView1.EditIndex].Cells[0].Text;
                inp_part_Name.Text = GridView1.Rows[GridView1.EditIndex].Cells[2].Text;
                Drp_Dempartment.SelectedItem.Text = GridView1.Rows[GridView1.EditIndex].Cells[1].Text.ToString();
               
            }
            catch
            {

            }
        }

        
        protected void btn_Sabt_Department_Click(object sender, EventArgs e)
        {
            if (inpDepartment_Name.Text != "")
            {
                Insert_DEPARMENTS();
                Bind_Drp_Department();
                Response.Redirect(Request.RawUrl);
            }
        }

       
    }
}