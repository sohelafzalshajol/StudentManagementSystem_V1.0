using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class CommonDAL
    {
        public static DropDownList ddlLoad(DropDownList ddl, string query, string txtField, string valueField)
        {
            CommonDAL objCDAL = new CommonDAL();
            DataTable dt = new DataTable();
            dt = objCDAL.loadDT(query);
            ddl.DataSource = dt;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ListItem li = new ListItem("Select one---", "0");
            ddl.Items.Insert(0, li);

            return ddl;
        }

        public DataTable loadDT(string query)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public string getString(string query)
        {
            string result = "";

            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0][0].ToString();
            }
            return result;
        }
    }
}
