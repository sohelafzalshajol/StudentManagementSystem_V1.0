using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectEveningB2.auth
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMessage.Visible = false;
                divMessageSuccess.Visible = false;
                LoadGridData();
                btnSave.Text = "Save";
            }
            txtContactNo.Attributes.Add("OnKeyUP", "checkNumber('"+txtContactNo.ClientID+"')");
        }

        //private string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
        private string ConnectionStr = "Data Source=DESKTOP-VHHBPK5;  Initial Catalog = EveningDataBaseB2; Integrated Security=True; ";

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            //SqlCommand cmd;

            string sqlstr = @"SELECT CId
      ,Name
      ,ContactNo
      ,Email
      ,Social
      ,EntryBy
      ,EntryDate
  FROM dbo.Contact;";
            using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }

            if (dt.Rows.Count > 0)
            {
                gvContactList.DataSource = dt;
                gvContactList.DataBind();
            }
            else
            {
                gvContactList.DataSource = null;
                gvContactList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                int result = 0;
                if (btnSave.Text == "Save")
                {
                    result = SaveUReg();
                    if (result > 0)
                    {
                        ClearFieldValue();
                        divMessageSuccess.Visible = true;
                        lblMessageSuccess.Text = "Save Success!!!";
                    }
                    else
                    {
                        divMessage.Visible = true;
                        lblMessage.Text = "Save Failed!!!";
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    result = UpdateUReg();
                    if (result > 0)
                    {
                        ClearFieldValue();
                        divMessageSuccess.Visible = true;
                        lblMessageSuccess.Text = "Update Success!!!";
                        LoadGridData();
                        btnSave.Text = "Save";
                    }
                    else
                    {
                        divMessage.Visible = true;
                        lblMessage.Text = "Update Failed!!!";
                        btnSave.Text = "Save";
                    }
                }
            }
        }

        private void LoadControl( int CId )
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            //SqlCommand cmd;

            string sqlstr = @"SELECT CId
      ,Name
      ,ContactNo
      ,Email
      ,Social
      ,EntryBy
      ,EntryDate
  FROM dbo.Contact WHERE CId="+ CId + "";
            using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }

            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSocialURL.Text = dt.Rows[0]["Social"].ToString();

                //EditCId = int.Parse(dt.Rows[0]["CId"].ToString());
                hdnEditCId.Value = dt.Rows[0]["CId"].ToString();

                btnSave.Text = "Update";

                
            }
            //else
            //{
            //    gvContactList.DataSource = null;
            //    gvContactList.DataBind();
            //}
        }

        #region AllMethods
        private void ClearFieldValue()
        {
            txtName.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtSocialURL.Text = "";
        }

        private bool CheckFieldValue()
        {
            bool IsRequired = false;
            if (txtName.Text == "")
            {
                lblMessage.Text = "Name can't be empty!";
                txtName.Focus();
                IsRequired = true;
            }
            else if (txtContactNo.Text == "")
            {
                lblMessage.Text = "ContactNo. can't be empty!";
                txtContactNo.Focus();
                IsRequired = true;
            }
            else if (txtEmail.Text == "")
            {
                lblMessage.Text = "Email can't be empty!";
                txtEmail.Focus();
                IsRequired = true;
            }
            else if (txtSocialURL.Text == "")
            {
                lblMessage.Text = "SocialURL can't be empty!";
                txtSocialURL.Focus();
                IsRequired = true;
            }

            if (IsRequired == true)
            {
                divMessage.Visible = true;
            }
            else
            {
                divMessage.Visible = false;
            }

            return IsRequired;
        }

        private int SaveUReg()
        {
            int result = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            //SqlCommand cmd;

            string sqlstr = @"INSERT INTO  dbo.Contact 
           (Name 
           ,ContactNo 
           ,Email 
           ,Social 
           ,EntryBy 
           ,EntryDate)
     VALUES
           (@Name 
           ,@ContactNo 
           ,@Email 
           ,@Social 
           ,@EntryBy
           ,GETDATE());";
            using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Social", txtSocialURL.Text.Trim());
                cmd.Parameters.AddWithValue("@EntryBy", Session["UserId"].ToString());
                cnn.Open();
                result = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            return result;
        }

        private int UpdateUReg()
        {
            int result = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            //SqlCommand cmd;

            string sqlstr = @"UPDATE dbo.Contact
                            SET
                            Name = @Name
                            ,ContactNo = @ContactNo
                            ,Email = @Email
                            ,Social = @Social
                            ,UpdateBy = @UpdateBy
                            ,UpdateDate = GETDATE()
                            WHERE CId = @CId;";
            using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Social", txtSocialURL.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateBy", Session["UserId"].ToString());
                cmd.Parameters.AddWithValue("@CId", hdnEditCId.Value);
                cnn.Open();
                result = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            return result;
        }
        #endregion

        protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "editC")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                HiddenField hdnCId = (HiddenField)gvContactList.Rows[rowIndex].Cells[0].FindControl("hdnCId");

                LoadControl(int.Parse(hdnCId.Value));
            }
        }
    }
}