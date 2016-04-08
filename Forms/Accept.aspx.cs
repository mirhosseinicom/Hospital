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
    public partial class Accept : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = Hospital; Integrated Security=True;");
        protected void Bind_GridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_Accept";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_Accept.Visible = false;
            else
                Grid_Accept.Visible = true;
            Grid_Accept.DataSource = dt;
            Grid_Accept.DataBind();
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
        protected void Bind_DrpBeds()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_BEDS";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            DrpBed.DataSource = dt;
            DrpBed.DataTextField = "BED_NUMBER";
            DrpBed.DataValueField = "BED_ID";
            DrpBed.DataBind();
            DrpBed.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

        }
        protected void Bind_DrpRooms()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_ROOMS_Blank";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            DrpRoom.DataSource = dt;
            DrpRoom.DataTextField = "ROOM_NUMBER";
            DrpRoom.DataValueField = "ROOM_ID";
            DrpRoom.DataBind();
            DrpRoom.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

        }
        protected void Insert_Accepts()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Insert_ACCEPT", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@PTNT_NAME", inpName.Text);
                scom.Parameters.AddWithValue("@PTNT_FAMILY", inpFamily.Text);
                scom.Parameters.AddWithValue("@PTNT_FATHER_NAME", inpFather.Text);
                scom.Parameters.AddWithValue("@PTNT_NATIONAL", inpNation.Text);
                scom.Parameters.AddWithValue("@ACPT_TYPE", inpType.Text);
                scom.Parameters.AddWithValue("@ACPT_DATE", Persian_Date(PDPDate.Text));
                scom.Parameters.AddWithValue("@ROOM_ID", Convert.ToInt32(DrpRoom.SelectedValue));
                scom.Parameters.AddWithValue("@BED_ID", Convert.ToInt32(DrpBed.SelectedValue));
                scom.Parameters.AddWithValue("@PART_ID", Convert.ToInt32(DrpPart.SelectedValue));
                scom.Parameters.AddWithValue("@NURS_ID", Convert.ToInt32(DrpNurse.SelectedValue));
                scom.Parameters.AddWithValue("@DOC_ID", Convert.ToInt32(DrpDoctore.SelectedValue));
                scom.Parameters.AddWithValue("@PTNT_COMPEER_MOBILE", inpMoblie_Compeer.Text);
                scom.Parameters.AddWithValue("@PTNT_TYPE_HISTORY_PATIENT", inpHistory.Text);
                scom.Parameters.AddWithValue("@PTNT_COMPEER_NAME", inpCompeer.Text);
                scom.Parameters.AddWithValue("@PTNT_GENEDER", rdbFamale.Checked == true ? true : false);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                cnn.Close();
            }
        }
        protected void Update_Accepts()
        {
            try
            {
                SqlCommand scom = new SqlCommand("Update_ACCEPT", cnn);
                scom.CommandType = CommandType.StoredProcedure;
                scom.Parameters.AddWithValue("@ACPT_ID", Convert.ToInt32(Session["id"]));
                scom.Parameters.AddWithValue("@PTNT_NAME", inpName.Text);
                scom.Parameters.AddWithValue("@PTNT_FAMILY", inpFamily.Text);
                scom.Parameters.AddWithValue("@PTNT_FATHER_NAME", inpFather.Text);
                scom.Parameters.AddWithValue("@PTNT_NATIONAL", inpNation.Text);
                scom.Parameters.AddWithValue("@ACPT_TYPE", inpType.Text);
                scom.Parameters.AddWithValue("@ACPT_DATE", Persian_Date(PDPDate.Text));
                scom.Parameters.AddWithValue("@PTNT_COMPEER_MOBILE", inpMoblie_Compeer.Text);
                scom.Parameters.AddWithValue("@PTNT_TYPE_HISTORY_PATIENT", inpHistory.Text);
                scom.Parameters.AddWithValue("@PTNT_COMPEER_NAME", inpCompeer.Text);
                scom.Parameters.AddWithValue("@PTNT_GENEDER", rdbFamale.Checked == true ? true : false);

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
                int Doc_id = 0;
                {
                    DataTable get_Id_Doc_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Doctore_With_DocName", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@DOC_NAME", DrpDoctore.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Doc_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Doc_Selected.Rows.Count != 0)
                        Doc_id = Convert.ToInt32(get_Id_Doc_Selected.Rows[0]["DOC_ID"].ToString());
                    else
                        Doc_id = 0;
                }
                scom.Parameters.AddWithValue("@DOC_ID", Doc_id);
                int Nurse_id = 0;
                {
                    DataTable get_Id_Nurs_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Nurse_With_NurseName", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@NURS_NAME", DrpNurse.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Nurs_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Nurs_Selected.Rows.Count != 0)
                        Nurse_id = Convert.ToInt32(get_Id_Nurs_Selected.Rows[0]["NURS_ID"].ToString());
                    else
                        Nurse_id = 0;
                }
                scom.Parameters.AddWithValue("@NURS_ID", Nurse_id);
                int Room_id = 0;
                {
                    DataTable get_Id_Room_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Room_With_RooM_Number", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@ROOM_NUMBER", DrpRoom.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Room_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Room_Selected.Rows.Count != 0)
                        Room_id = Convert.ToInt32(get_Id_Room_Selected.Rows[0]["ROOM_ID"].ToString());
                    else
                        Room_id = 0;
                }
                scom.Parameters.AddWithValue("@ROOM_ID", Room_id);
                int Bed_id = 0;
                {
                    DataTable get_Id_Room_Selected = new DataTable();
                    SqlCommand scom_two = new SqlCommand("Get_Bed_With_RooM_Number", cnn);
                    scom_two.CommandType = CommandType.StoredProcedure;
                    scom_two.Parameters.AddWithValue("@BED_NUMBER", DrpBed.SelectedItem.Text);
                    cnn.Open();
                    get_Id_Room_Selected.Load(scom_two.ExecuteReader());
                    cnn.Close();

                    if (get_Id_Room_Selected.Rows.Count != 0)
                        Bed_id = Convert.ToInt32(get_Id_Room_Selected.Rows[0]["BED_ID"].ToString());
                    else
                        Bed_id = 0;
                }
                scom.Parameters.AddWithValue("@BED_ID", Bed_id);
                cnn.Open();
                scom.ExecuteNonQuery();
                cnn.Close();

            }
            catch
            {
                cnn.Close();
            }

        }
        protected void Bind_DrpNurse()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_Nurse";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            DrpNurse.Items.Clear();
            DrpNurse.DataSource = dt;
            DrpNurse.DataTextField = "name";
            DrpNurse.DataValueField = "NURS_ID";
            DrpNurse.DataBind();
            DrpNurse.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

        }
        protected void Bind_DrpDoctors()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Get_Doctors";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            DrpDoctore.DataSource = dt;
            DrpDoctore.DataTextField = "name";
            DrpDoctore.DataValueField = "DOC_ID";
            DrpDoctore.DataBind();
            DrpDoctore.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));

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
        protected void Search()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Search_Accept";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PTNT_NAME", inp_Search_family.Text);
            cmd.Parameters.AddWithValue("@ACPT_TYPE", inp_Search_Type.Text);
            cmd.Parameters.AddWithValue("@PTNT_GENEDER", rdb_Search_Famale.Checked == true ? true : false);
            cmd.Parameters.AddWithValue("@ACPT_DATE", Persian_Date(inp_Search_Type.Text));
            cmd.Parameters.AddWithValue("@PART_ID", Drp_Search_Part.Text != "انتخاب کنید" ? Convert.ToInt32(Drp_Search_Part.SelectedValue) : 0);
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_Accept.Visible = false;
            else
                Grid_Accept.Visible = true;
            Grid_Accept.DataSource = dt;
            Grid_Accept.DataBind();
        }
        protected void Delete_Accepts(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_ACCEPT", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACPT_ID", Convert.ToInt32(lbl));
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                cnn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Insert"] = true;
                Bind_GridView();
                Bind_DrpPart();
                Bind_DrpBeds();
                Bind_DrpRooms();
                Bind_DrpDoctors();
                Bind_DrpNurse();
            }

        }

        protected void Grid_Accept_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Grid_Accept.EditIndex = e.RowIndex;
                string lbAcc_ID = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[0].Text.ToString();

                Delete_Accepts(lbAcc_ID);
            }
            catch
            {
                cnn.Close();
            }
            Bind_GridView();
            Response.Redirect(Request.RawUrl);
        }

        protected void Grid_Accept_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_GridView();
            Grid_Accept.PageIndex = e.NewPageIndex;

            Grid_Accept.DataBind();
        }

        protected void Grid_Accept_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["Insert"] = false;
                Grid_Accept.EditIndex = e.NewEditIndex;
                Session["id"] = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[0].Text;
                inpName.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[1].Text;
                inpFamily.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[2].Text;
                inpFather.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[3].Text;
                inpNation.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[4].Text;
                inpType.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[6].Text;
                DrpNurse.SelectedItem.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[7].Text;
                DrpDoctore.SelectedItem.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[8].Text;
                DrpPart.SelectedItem.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[9].Text;
                DrpRoom.SelectedItem.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[10].Text;
                DrpBed.SelectedItem.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[11].Text;
                inpCompeer.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[12].Text;
                inpMoblie_Compeer.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[13].Text;
                PDPDate.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[14].Text;
                inpHistory.Text = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[15].Text;
                string geneder = Grid_Accept.Rows[Grid_Accept.EditIndex].Cells[5].Text;
                if (geneder == "زن")
                    rdbFamale.Checked = true;
                else
                    rdbMale.Checked = true;
            }
            catch
            {
                cnn.Close();
            }
        }

        protected void btnAccept_sabt_Click(object sender, EventArgs e)
        {
            if (inpFamily.Text != "" & inpFather.Text != "" & inpName.Text != "" & DrpBed.SelectedItem.Text.ToString() != "انتخاب کنید" & DrpDoctore.SelectedItem.Text.ToString() != "-1" & DrpNurse.SelectedItem.Text.ToString() != "-1" & DrpPart.SelectedItem.Text.ToString() != "-1" & PDPDate.Text != "")
            {
                if (true == Convert.ToBoolean(Session["Insert"]))
                    Insert_Accepts();
                else
                    Update_Accepts();
                Bind_GridView();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Search();

        }

        protected void DrpPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cnn;
                cmd.CommandText = "Get_ROOMS_Blank_with_Part_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PART_ID", DrpPart.Text != "انتخاب کنید" ? Convert.ToInt32(DrpPart.SelectedValue) : 0);
                DataTable dt = new DataTable();
                cnn.Open();
                dt.Load(cmd.ExecuteReader());
                cnn.Close();
                DrpRoom.DataSource = dt;
                DrpRoom.DataTextField = "ROOM_NUMBER";
                DrpRoom.DataValueField = "ROOM_ID";
                DrpRoom.DataBind();
                DrpRoom.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
            }
            catch
            {
                cnn.Close();
            }

        }

        protected void DrpRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cnn;
                cmd.CommandText = "Get_Bed_Blank_with_Room_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ROOM_ID", DrpRoom.Text != "انتخاب کنید" ? Convert.ToInt32(DrpRoom.SelectedValue) : 0);
                DataTable dt = new DataTable();
                cnn.Open();
                dt.Load(cmd.ExecuteReader());
                cnn.Close();
                DrpBed.DataSource = dt;
                DrpBed.DataTextField = "BED_NUMBER";
                DrpBed.DataValueField = "BED_ID";
                DrpBed.DataBind();
                DrpBed.Items.Insert(0, new ListItem("انتخاب کنید", "-1"));
            }
            catch
            {
                cnn.Close();
            }
        }
    }
}