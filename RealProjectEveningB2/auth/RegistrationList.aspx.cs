using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace RealProjectEveningB2.auth
{
    public partial class RegistrationList : System.Web.UI.Page
    {
        AuthBLL objAuthBLL = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligionId, "select ReligionId, ReligionName from Conf_Religion", "ReligionName", "ReligionId");
                LoadGridData();
            }
        }

        protected string BaseUrl(string url)
        {
            if (url != null)
            {
                url = "~/Assets/img/users/" + url;
                return url;
            }
            else
            {
                return null;
            }
        }

        private void LoadGridData()
        {
            int religion = int.Parse(ddlReligionId.SelectedValue);
            int gendar = Convert.ToInt32(ddlGender.SelectedValue);
            DataTable dt = new DataTable();
            //            //string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
            //            string ConnectionStr = "Data Source=DESKTOP-VHHBPK5;  Initial Catalog = EveningDataBaseB2; Integrated Security=True; ";
            //            SqlConnection cnn;
            //            cnn = new SqlConnection(ConnectionStr);
            //            //SqlCommand cmd;

            //            string sqlstr = @"select UserId, UserName,
            //(FirstName+' '+ISNULL(MidName,'')+' '+LastName) as FullName,
            //(case when Gender=1 then 'Male' when Gender=2 then 'FeMale' else 'other' end) as Gender
            //, convert(varchar(15), DateOfBirth, 106) as DateOfBirth, ContactNo, Email, UserAddress, ReligionName
            //from [dbo].[UserRegistration] inner join
            //Conf_Religion on UserRegistration.ReligionId = Conf_Religion.ReligionId
            //where (UserRegistration.ReligionId = " + religion+" or "+religion+@"=0)
            //and (Gender = "+gendar+" or "+gendar+"=0);";
            //            using (SqlCommand cmd = new SqlCommand(sqlstr, cnn))
            //            {
            //                SqlDataAdapter sda = new SqlDataAdapter();
            //                DataSet ds = new DataSet();
            //                cnn.Open();
            //                sda.SelectCommand = cmd;
            //                sda.Fill(ds);
            //                dt = ds.Tables[0];
            //            }

            dt = objAuthBLL.getUserRegList(religion, gendar);
            if (dt.Rows.Count > 0)
            {
                gvRegList.DataSource = dt;
                gvRegList.DataBind();
            }
            else
            {
                gvRegList.DataSource = null;
                gvRegList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void gvRegList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "approve")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                HiddenField hdnUserId = (HiddenField)gvRegList.Rows[rowIndex].Cells[0].FindControl("hdnUserId");

                string url = "UserApproval.aspx?param=" + hdnUserId.Value;
                string totalUrl = "var Mleft = (screen.width/2)-(800/2);var Mtop = (screen.height/2)-(500/2);window.open( '" + url + "', null, 'height=500,width=820,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", totalUrl, true);
            }
        }
    }
}