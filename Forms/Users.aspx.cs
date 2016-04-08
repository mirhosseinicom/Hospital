using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital_asp.Forms
{
    public partial class Users : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = HOSPITAL; Integrated Security=True;");
        protected void Bind_GridView()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "Show_Row_USERS";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cnn.Open();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            if (dt.Rows.Count == 0)
                Grid_User.Visible = false;
            else
                Grid_User.Visible = true;
            Grid_User.DataSource = dt;
            Grid_User.DataBind();
        }
        protected void Insert_Users()
        {

            if (FileUpload.PostedFile != null && FileUpload.PostedFile.FileName != "")
            {

                try
                {
                    SqlCommand scom = new SqlCommand("Insert_USERS", cnn);
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@USER_USERNAME", inpUser.Text);
                    scom.Parameters.AddWithValue("@USER_PASSWORK", inpPass.Text);
                    scom.Parameters.AddWithValue("@USER_FName", inpName.Text);
                    scom.Parameters.AddWithValue("@USER_FAMILY", inpFamily.Text);
                    byte[] n_Image_Size = new byte[FileUpload.PostedFile.ContentLength];
                    HttpPostedFile Posted_Image = FileUpload.PostedFile;
                    Posted_Image.InputStream.Read(n_Image_Size, 0, (int)FileUpload.PostedFile.ContentLength);
                    SqlParameter UploadedImage = new SqlParameter("@USER_IMAG", SqlDbType.Image, n_Image_Size.Length);
                    UploadedImage.Value = n_Image_Size;
                    scom.Parameters.Add(UploadedImage);

                    cnn.Open();
                    scom.ExecuteNonQuery();
                    cnn.Close();
                    string message = "ثبت انجام شد.";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("');");
                    ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
                }
                catch
                {
                    cnn.Close();
                }
            }
        }
        protected void Delete_Users(string lbl)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete_USERS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USER_ID", Convert.ToInt32(lbl));
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
                Bind_GridView();
            }
        }

        protected void Grid_User_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Grid_User.EditIndex = e.RowIndex;
                string lbDOC_ID = Grid_User.Rows[Grid_User.EditIndex].Cells[0].Text.ToString();

                Delete_Users(lbDOC_ID);
            }
            catch
            {

            }
            Bind_GridView();
            Response.Redirect(Request.RawUrl);
        }

        protected void Grid_User_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_GridView();
            Grid_User.PageIndex = e.NewPageIndex;

            Grid_User.DataBind();
        }

        protected void btnUsers_sabt_Click(object sender, EventArgs e)
        {
            if (inpFamily.Text != "" & inpName.Text != "" & inpPass.Text != "" & inpUser.Text != "")
            {
                Insert_Users();
                Bind_GridView();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}