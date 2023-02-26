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
    public partial class ContactList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            //string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
            string ConnectionStr = "Data Source=DESKTOP-VHHBPK5;  Initial Catalog = EveningDataBaseB2; Integrated Security=True; ";
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            //SqlCommand cmd;

            string sqlstr = @"SELECT UserId,
	CId,
	Name,
	(ur.FirstName+' '+ISNULL(ur.MidName, '')+' '+ur.LastName) as EntryBy,
	Contact.ContactNo,
	Contact.Email,
	Social,
	UserAddress,
	Conf_Religion.ReligionName,
	UserImage
  FROM Contact inner join UserRegistration ur
  on UserId = EntryBy
  inner join Conf_Religion
  on Conf_Religion.ReligionId = ur.ReligionId;";
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
    }
}