using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RealProjectEveningB2
{
    public partial class login : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //divMessage.Visible = false;
                RememberMe();
            }
        }

        private void RememberMe()
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
            {
                txtUserName.Text = Request.Cookies["Username"].Value;
                txtPassword.Attributes["Value"] = Request.Cookies["Password"].Value;

            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Attributes["Value"] = "";
            }
        }

        //private DataTable LoginCheck(string Username, string UPass)
        //{
        //    DataTable dt = new DataTable();
        //    //string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
        //    string ConnectionStr = "Data Source=DESKTOP-5J0I5J4;  Initial Catalog = EveningDataBaseB2; Integrated Security=True; ";
        //    SqlConnection cnn;
        //    cnn = new SqlConnection(ConnectionStr);
        //    SqlCommand cmd;

        //    string sqlstr = @"select UserAuth.UserId,
        //        (ur.FirstName+' '+ISNULL(ur.MidName, '')+' '+ur.LastName) as FullName,
        //        ur.UserImage
        //        from UserAuth inner join
        //        UserRegistration ur
        //        on UserAuth.UserId = ur.UserId
        //        where IsActive = 1 and UserAuth.UserName = '" + Username + "' and UserPassword = '" + UPass + "'";

        //    SqlDataAdapter sda = new SqlDataAdapter();

        //    //DataSet ds = new DataSet();
        //    try
        //    {
        //        cnn.Open();
        //        cmd = new SqlCommand(sqlstr, cnn);
        //        sda.SelectCommand = cmd;
        //        //sda.Fill(ds);
        //        //dt = ds.Tables[0];
        //        sda.Fill(dt);
        //        cnn.Close();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return dt;
        //}



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtUserName.Text != "" && txtPassword.Text != "")
            //{
            //    if (txtUserName.Text == "admin@gmail.com" && txtPassword.Text == "1234")
            //    {
            //        Response.Redirect("~/AdminHome.aspx");
            //    }
            //}
            //else
            //{
            //    lblMessage.Text = "Username or password can't be empty!";
            //    divMessage.Visible = true;
            //}

            if (CheckFieldValue() == false)
            {
                DataTable dtLoginInfo = new DataTable();
                dtLoginInfo = objAuthBLL.CheckUserInfo(txtUserName.Text.Trim(), txtPassword.Text);
                if (dtLoginInfo.Rows.Count > 0)
                {
                    Session["UserId"] = dtLoginInfo.Rows[0]["UserId"].ToString();
                    Session["Username"] = dtLoginInfo.Rows[0]["FullName"].ToString();
                    Session["UserImg"] = dtLoginInfo.Rows[0]["UserImage"].ToString();
                    CreateCookie();
                    Response.Redirect("~/AdminHome.aspx");
                }
                else
                {
                    //lblMessage.Text = "Incorrect Username or password!";
                    ucRmMsg.FailureMessage = "Incorrect Username or password!";
                    //divMessage.Visible = true;
                }
            }
        }

        private void CreateCookie()
        {
            if (cbRemember.Checked)
            {
                HttpCookie auth = new HttpCookie("auth");
                auth["Username"] = "";
                auth["Password"] = "";
                Response.Cookies.Add(auth);

                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(30);

                Response.Cookies["Username"].Value = txtUserName.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
            }
            else
            {
                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);

            }

        }

        private bool CheckFieldValue()
        {
            bool IsRequired = false;
            if (txtUserName.Text == "")
            {
                //lblMessage.Text = "Username can't be empty!";
                ucRmMsg.FailureMessage = "Username can't be empty!";
                txtUserName.Focus();
                IsRequired = true;
            }
            else if (txtPassword.Text == "")
            {
                //lblMessage.Text = "Password can't be empty!";
                ucRmMsg.FailureMessage = "Password can't be empty!";
                txtPassword.Focus();
                IsRequired = true;
            }

            //if (IsRequired == true)
            //{
            //    divMessage.Visible = true;
            //}
            //else
            //{
            //    divMessage.Visible = false;
            //}

            return IsRequired;
        }
    }
}