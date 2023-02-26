using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Entity;
using BLL;
using DAL;
using System.Data;
using System.IO;

namespace RealProjectEveningB2.auth
{
    public partial class register : System.Web.UI.Page
    {
        AuthBLL objAuthUR = new AuthBLL();
        AuthDAL objAuthDAL = new AuthDAL();
        CommonDAL objC = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligionId, "select ReligionId, ReligionName from Conf_Religion", "ReligionName", "ReligionId");
                divMessage.Visible = false;
                divMessageSuccess.Visible = false;
            }
        }

        //private void ddlLoad()
        //{
        //    DataTable dt = new DataTable();
        //    dt = objAuthDAL.ddlLoad("select ReligionId, ReligionName from Conf_Religion");
        //    ddlReligionId.DataTextField = "ReligionName";
        //    ddlReligionId.DataTextField = "ReligionId";
        //    ddlReligionId.DataBind();
        //    ListItem li = new ListItem("Select one---", "0");
        //    ddlReligionId.Items.Insert(0,li);
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                int result = SaveUReg();
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
        }

        #region AllMethods
        private void ClearFieldValue()
        {
            txtUserName.Text = "";
            txtFirstName.Text = "";
            txtMidName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            ddlGender.SelectedValue = "0";
            txtContact.Text = "";
            txtEmail.Text = "";
            ddlReligionId.SelectedValue = "0";
            txtAddress.Text = "";

            flUserImage.PostedFile.InputStream.Dispose();
        }

        private bool CheckFieldValue()
        {
            bool IsRequired = false;
            string Userchk = objC.getString("select UserName from UserRegistration where UserName = '"+txtUserName.Text+"'");
            if (txtUserName.Text == "")
            {
                lblMessage.Text = "UserName can't be empty!";
                txtUserName.Focus();
                IsRequired = true;
            }
            else if (txtFirstName.Text == "")
            {
                lblMessage.Text = "FirstName can't be empty!";
                txtFirstName.Focus();
                IsRequired = true;
            }
            else if (txtLastName.Text == "")
            {
                lblMessage.Text = "LastName can't be empty!";
                txtLastName.Focus();
                IsRequired = true;
            }
            else if (txtDOB.Text == "")
            {
                lblMessage.Text = "Date Of Birth can't be empty!";
                txtDOB.Focus();
                IsRequired = true;
            }
            else if (ddlGender.SelectedValue == "0")
            {
                lblMessage.Text = "Gender can't be empty!";
                ddlGender.Focus();
                IsRequired = true;
            }
            else if (txtContact.Text == "")
            {
                lblMessage.Text = "Contact can't be empty!";
                txtContact.Focus();
                IsRequired = true;
            }
            else if (txtEmail.Text == "")
            {
                lblMessage.Text = "Email can't be empty!";
                txtEmail.Focus();
                IsRequired = true;
            }
            else if (txtAddress.Text == "")
            {
                lblMessage.Text = "Address can't be empty!";
                txtAddress.Focus();
                IsRequired = true;
            }
            else if (ddlReligionId.SelectedValue == "0")
            {
                lblMessage.Text = "Religion can't be empty!";
                ddlReligionId.Focus();
                IsRequired = true;
            }
            else if (Userchk != "")
            {
                lblMessage.Text = "This User Already Exits!";
                txtUserName.Focus();
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
            EUserReg objEUR = new EUserReg();
            objEUR.UserName = txtUserName.Text.Trim();
            objEUR.FirstName = txtFirstName.Text.Trim();
            objEUR.MidName = txtMidName.Text.Trim();
            objEUR.LastName = txtLastName.Text.Trim();
            objEUR.DateOfBirth = txtDOB.Text;
            objEUR.Gender = int.Parse(ddlGender.SelectedValue);
            objEUR.ContactNo = txtContact.Text.Trim();
            objEUR.Email = txtEmail.Text.Trim();
            objEUR.UserAddress = txtAddress.Text.Trim();
            objEUR.ReligionId = Convert.ToInt32(ddlReligionId.SelectedValue);
            objEUR.UserImage = UserImage();
            result = objAuthUR.InsertUserRegInfo(objEUR);
            return result;
        }

        private string UserImage()
        {
            string imageName = flUserImage.FileName;
            var fileExtension = Path.GetExtension(flUserImage.PostedFile.FileName).Substring(1);
            if (fileExtension == "jpg" || fileExtension == "png" || fileExtension == "jpeg")
            {
                flUserImage.SaveAs(Server.MapPath("~/Assets/img/users/" + flUserImage.FileName));
            }
            return imageName;
        }

        //private int SaveUReg()
        //{
        //    int result = 0;
        //    //string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
        //    string ConnectionStr = "Data Source=DESKTOP-VHHBPK5;  Initial Catalog = EveningDataBaseB2; Integrated Security=True; ";
        //    SqlConnection cnn;
        //    cnn = new SqlConnection(ConnectionStr);
        //    //SqlCommand cmd;

        //    string sqlstr = @"insert into [dbo].[UserRegistration](
        //        [UserName], [FirstName], [MidName], [LastName], [DateOfBirth], [Gender],
        //        [ContactNo], [Email], [UserAddress], [ReligionId], [EntryDate], [UserImage]
        //        )
        //        values
        //        (
        //        @UserName, @FirstName, @MidName, @LastName, @DateOfBirth, @Gender,
        //        @ContactNo, @Email, @UserAddress, @ReligionId, GETDATE(), @UserImage
        //        );";
        //    using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
        //    {
        //        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@MidName", txtMidName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
        //        cmd.Parameters.AddWithValue("@DateOfBirth", txtDOB.Text);
        //        cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
        //        cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text.Trim());
        //        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
        //        cmd.Parameters.AddWithValue("@UserAddress", txtAddress.Text.Trim());
        //        cmd.Parameters.AddWithValue("@ReligionId", ddlReligionId.SelectedValue);
        //        cmd.Parameters.AddWithValue("@UserImage", "1.png");
        //        cnn.Open();
        //        result = cmd.ExecuteNonQuery();
        //        cnn.Close();
        //    }

        //    return result;
        //} 
        #endregion
    }
}