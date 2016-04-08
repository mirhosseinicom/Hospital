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
    public partial class Doctors : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Bind_GridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_Doctors";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_doctore.Visible = false;
            else
                Grid_doctore.Visible = true;
            Grid_doctore.DataSource = dt;
            Grid_doctore.DataBind();
        }


        protected void Search()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Search_Doctores";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DOC_NAME", inp_Search_family.Text);
            cmd.Parameters.AddWithValue("@DOC_EXPERT", inp_Search_Expert.Text);
            cmd.Parameters.AddWithValue("@DOC_GENDER", rdb_Search_Famale.Checked == true ? true : false);
            cmd.Parameters.AddWithValue("@PART_ID", Drp_Search_Part.Text != "انتخاب کنید" ? Convert.ToInt32(Drp_Search_Part.SelectedValue) : 0);
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_doctore.Visible = false;
            else
                Grid_doctore.Visible = true;
            Grid_doctore.DataSource = dt;
            Grid_doctore.DataBind();
        }
        protected void Clear_Item()
        {
            inpFamily.Text = string.Empty;
            inpName.Text = string.Empty;
            inpDegree.Text = string.Empty;
            inpMobile.Text = string.Empty;
            inpExpert.Text = string.Empty;
            DrpPart.SelectedItem.Text = "انتخاب کنید";


        }
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
            DrpPart.DataSource = dt;
            DrpPart.DataTextField = "PART_NAME";
            DrpPart.DataValueField = "PART_ID";
            DrpPart.DataBind();
            DrpPart.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
            Drp_Search_Part.DataSource = dt;
            Drp_Search_Part.DataTextField = "PART_NAME";
            Drp_Search_Part.DataValueField = "PART_ID";
            Drp_Search_Part.DataBind();
            Drp_Search_Part.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
        }
        protected void Insert_Doctors()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Insert_Doctors", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@DOC_NAME", inpName.Text);
                scom.Parameters.AddWithValue("@DOC_FAMILY", inpFamily.Text);
                scom.Parameters.AddWithValue("@DOC_EXPERT", inpExpert.Text);
                scom.Parameters.AddWithValue("@DOC_DEGREE", inpDegree.Text);
                scom.Parameters.AddWithValue("@DOC_MOBILE", inpMobile.Text);
                scom.Parameters.AddWithValue("@DOC_GENDER", rdbFamale.Checked == true ? true : false);
                scom.Parameters.AddWithValue("@PART_ID", DrpPart.Text != "انتخاب کنید" ? Convert.ToInt32(DrpPart.SelectedValue) : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();

            }
            catch
            {

            }

        }
        protected void Update_Doctors()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Update_Doctors", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@DOC_ID", Convert.ToInt32(Session["id"]));
                scom.Parameters.AddWithValue("@DOC_NAME", inpName.Text);
                scom.Parameters.AddWithValue("@DOC_FAMILY", inpFamily.Text);
                scom.Parameters.AddWithValue("@DOC_EXPERT", inpExpert.Text);
                scom.Parameters.AddWithValue("@DOC_DEGREE", inpDegree.Text);
                scom.Parameters.AddWithValue("@DOC_MOBILE", inpMobile.Text);
                scom.Parameters.AddWithValue("@DOC_GENDER", rdbFamale.Checked == true ? true : false);
                int Part_id = 0;
                {
                    DataTable get_Id_Part_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Part_With_PartName", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@PART_NAME", DrpPart.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Part_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Part_Selected.Rows.Count != 0)
                        Part_id = Convert.ToInt32(get_Id_Part_Selected.Rows[0]["PART_ID"].ToString());
                    else
                        Part_id = 0;
                }
                scom.Parameters.AddWithValue("@PART_ID", DrpPart.Text != "انتخاب کنید" ? Part_id : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();

            }
            catch
            {

            }

        }
        protected void Delete_Doctors(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_Doctors", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DOC_ID", Convert.ToInt32(lbl));
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["Insert"] = true;
                Bind_GridView();
                Bind_DrpPart();

            }

        }



        protected void btnDoctor_sabt_Click(object sender, EventArgs e)
        {
            if (inpFamily.Text != "" & inpExpert.Text != "" & inpName.Text != "" & inpDegree.Text != "" & DrpPart.SelectedItem.Text.ToString() != "انتخاب کنید")
            {
                if (true == Convert.ToBoolean(Session["Insert"]))
                {
                    Insert_Doctors();
                }
                else
                {
                    Update_Doctors();

                }
                Bind_GridView();
                Response.Redirect(Request.RawUrl);
            }
            else

                Response.Redirect(Request.RawUrl);

        }




        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Search();

        }

        protected void Grid_doctore_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_GridView();
            Grid_doctore.PageIndex = e.NewPageIndex;

            Grid_doctore.DataBind();
        }

        protected void Grid_doctore_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Grid_doctore.EditIndex = e.RowIndex;
                string lbDOC_ID = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[0].Text.ToString();

                Delete_Doctors(lbDOC_ID);
            }
            catch
            {

            }
            Bind_GridView();
            Response.Redirect(Request.RawUrl);
        }

        protected void Grid_doctore_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["Insert"] = false;
                Grid_doctore.EditIndex = e.NewEditIndex;
                Session["id"] = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[0].Text;
                inpName.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[1].Text;
                inpFamily.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[2].Text;
                inpExpert.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[3].Text;
                inpDegree.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[4].Text;
                inpMobile.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[5].Text;
                DrpPart.SelectedItem.Text = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[7].Text.ToString();
                string geneder = Grid_doctore.Rows[Grid_doctore.EditIndex].Cells[6].Text;
                if (geneder == "زن")
                    rdbFamale.Checked = true;
                else
                    rdbMale.Checked = true;
            }
            catch
            {

            }
        }

        protected void Grid_doctore_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void Grid_doctore_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }



    }
}