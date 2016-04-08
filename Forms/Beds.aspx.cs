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
    public partial class Beds : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Bind_Grid_BEDS()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_BEDS";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_BED.Visible = false;
            else
                Grid_BED.Visible = true;
            Grid_BED.DataSource = dt;
            Grid_BED.DataBind();
        }
        protected void Bind_Grid_ROOMS()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_ROOM";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_ROOM.Visible = false;
            else
                Grid_ROOM.Visible = true;
            Grid_ROOM.DataSource = dt;
            Grid_ROOM.DataBind();
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
            Drp_Part.Items.Clear();
            Drp_Part.DataSource = dt;
            Drp_Part.DataTextField = "PART_NAME";
            Drp_Part.DataValueField = "PART_ID";
            Drp_Part.DataBind();
            Drp_Part.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

        }
        protected void Bind_DrpRoom()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_ROOMS";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            DrpRoom_Number.Items.Clear();
            DrpRoom_Number.DataSource = dt;
            DrpRoom_Number.DataTextField = "ROOM_NUMBER";
            DrpRoom_Number.DataValueField = "ROOM_ID";
            DrpRoom_Number.DataBind();
            DrpRoom_Number.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

        }
        protected void Insert_BEDS()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Insert_BEDS", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@BED_NUMBER", inpBed_Number.Text);
                scom.Parameters.AddWithValue("@ROOM_ID", DrpRoom_Number.Text != "انتخاب کنید" ? Convert.ToInt32(DrpRoom_Number.SelectedValue) : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
                
            }
            catch
            {

            }

        }
        protected void Insert_ROOMS()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Insert_ROOM", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@ROOM_NUMBER", inpNumber_Room.Text);
                scom.Parameters.AddWithValue("@PART_ID", Drp_Part.Text != "انتخاب کنید" ? Convert.ToInt32(Drp_Part.SelectedValue) : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
                string message = "ثبت انجام شد.";
                
            }
            catch
            {

            }

        }
        protected void Update_BEDS()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Update_BEDS", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@BED_ID", Convert.ToInt32(Session["id"]));
                scom.Parameters.AddWithValue("@BED_NUMBER", inpBed_Number.Text);

                int Room_id = 0;
                {
                    DataTable get_Id_ROOM_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Room_With_RooM_Number", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@ROOM_NUMBER", DrpRoom_Number.SelectedItem.Text);
                    cnn.Open();
                    get_Id_ROOM_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_ROOM_Selected.Rows.Count != 0)
                        Room_id = Convert.ToInt32(get_Id_ROOM_Selected.Rows[0]["ROOM_ID"].ToString());
                    else
                        Room_id = 0;
                }
                scom.Parameters.AddWithValue("@ROOM_ID", DrpRoom_Number.Text != "انتخاب کنید" ? Room_id : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
               
            }
            catch
            {

            }

        }
        protected void Update_ROOMS()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Update_ROOM", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@ROOM_ID", Convert.ToInt32(Session["id"]));
                scom.Parameters.AddWithValue("@ROOM_NUMBER", inpNumber_Room.Text);
                int Part_id = 0;
                {
                    DataTable get_Id_Part_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Part_With_PartName", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@PART_NAME", Drp_Part.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Part_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Part_Selected.Rows.Count != 0)
                        Part_id = Convert.ToInt32(get_Id_Part_Selected.Rows[0]["PART_ID"].ToString());
                    else
                        Part_id = 0;
                }
                scom.Parameters.AddWithValue("@PART_ID", Drp_Part.Text != "انتخاب کنید" ? Part_id : 0);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
                
            }
            catch
            {

            }

        }
        protected void Delete_BEDS(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_BEDS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BED_ID", Convert.ToInt32(lbl));
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }
        }
        protected void Delete_ROOMS(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_ROOM", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ROOM_ID", Convert.ToInt32(lbl));
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
                Session["Insert_B"] = true;
                Session["Insert_R"] = true;
                Bind_Grid_BEDS();
                Bind_Grid_ROOMS();
                Bind_DrpPart();
                Bind_DrpRoom();
            }
        }

        protected void Grid_ROOM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Grid_ROOM.EditIndex = e.RowIndex;
                string lbDOC_ID = Grid_ROOM.Rows[Grid_ROOM.EditIndex].Cells[0].Text.ToString();

                Delete_ROOMS(lbDOC_ID);
            }
            catch
            {

            }
            Bind_Grid_ROOMS();
            Response.Redirect(Request.RawUrl);
        }

        protected void Grid_ROOM_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["Insert_R"] = false;
                Grid_ROOM.EditIndex = e.NewEditIndex;
                Session["id"] = Grid_ROOM.Rows[Grid_ROOM.EditIndex].Cells[0].Text;
                inpNumber_Room.Text = Grid_ROOM.Rows[Grid_ROOM.EditIndex].Cells[2].Text;
                Drp_Part.SelectedItem.Text = Grid_ROOM.Rows[Grid_ROOM.EditIndex].Cells[1].Text.ToString();

            }
            catch
            {

            }
        }

        protected void Grid_ROOM_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_Grid_ROOMS();
            Grid_ROOM.PageIndex = e.NewPageIndex;

            Grid_ROOM.DataBind();
        }

        protected void btn_Room_Sabt_Click(object sender, EventArgs e)
        {
            if (Drp_Part.SelectedItem.Text.ToString() != "-1")
            {
                if (true == Convert.ToBoolean(Session["Insert_R"]))
                    Insert_ROOMS();
                else
                    Update_ROOMS();

                Bind_Grid_ROOMS();
                Bind_DrpRoom();
                Response.Redirect(Request.RawUrl);
            }


        }

        protected void btnBed_sabt_Click(object sender, EventArgs e)
        {
            if (DrpRoom_Number.SelectedValue.ToString() != "-1")
            {
                if (true == Convert.ToBoolean(Session["Insert_B"]))
                    Insert_BEDS();
                else
                    Update_BEDS();

                Bind_Grid_BEDS();
                Response.Redirect(Request.RawUrl);
            }


        }

        protected void Grid_BED_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Grid_BED.EditIndex = e.RowIndex;
                string lbDOC_ID = Grid_BED.Rows[Grid_BED.EditIndex].Cells[0].Text.ToString();

                Delete_ROOMS(lbDOC_ID);
            }
            catch
            {

            }
            Bind_Grid_ROOMS();
            Response.Redirect(Request.RawUrl);
        }

        protected void Grid_BED_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_Grid_BEDS();
            Grid_BED.PageIndex = e.NewPageIndex;

            Grid_BED.DataBind();
        }

        protected void Grid_BED_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["Insert_B"] = false;
                Grid_BED.EditIndex = e.NewEditIndex;
                Session["id"] = Grid_BED.Rows[Grid_BED.EditIndex].Cells[0].Text;
                inpBed_Number.Text = Grid_BED.Rows[Grid_BED.EditIndex].Cells[2].Text;
                DrpRoom_Number.SelectedItem.Text = Grid_BED.Rows[Grid_BED.EditIndex].Cells[1].Text.ToString();

            }
            catch
            {

            }
        }
    }
}