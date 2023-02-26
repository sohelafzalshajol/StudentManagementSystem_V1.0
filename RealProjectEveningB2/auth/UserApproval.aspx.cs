using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using BLL;


namespace RealProjectEveningB2.auth
{
    public partial class UserApproval : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnUpdateUserId.Value = Request.QueryString["param"].ToString();
                FillData(int.Parse(hdnUpdateUserId.Value));
            }
        }

        private void FillData(int UserId)
        {
            DataTable dt = new DataTable();
            dt = objAuthBLL.getUserRegList(0, 0, UserId);
            if (dt.Rows.Count>0)
            {
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlApprovedStatus.SelectedValue = dt.Rows[0]["ApprovalStatus"].ToString();
            }
        }

        protected void ddlApprovedStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlApprovedStatus.SelectedValue == "Approved")
            {
                divPassword.Visible = true;
            }
            else
            {
                divPassword.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int result = objAuthBLL.ApproveUserRegInfo(int.Parse(hdnUpdateUserId.Value), ddlApprovedStatus.SelectedValue, txtPassword.Text);
            if (result>0)
            {
                MessageBox.Show("Update successful!!!");
            }
        }
    }
}