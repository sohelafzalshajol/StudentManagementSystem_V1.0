using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class AuthDAL
    {
        public DataTable CheckUser(string UserName, string UserPassword)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetStoredProcCommand("AuthSP_CheckLogin");
            db.AddInParameter(dbCmd, "UserName", DbType.String, UserName);
            db.AddInParameter(dbCmd, "UserPassword", DbType.String, UserPassword);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable getUserReg(int ReligionId, int Gender, int UserId)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetStoredProcCommand("AuthSp_GetUserReg");
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, ReligionId);
            db.AddInParameter(dbCmd, "Gender", DbType.Int32, Gender);
            db.AddInParameter(dbCmd, "UserId", DbType.Int32, UserId);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable ddlLoad(string query)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetSqlStringCommand(query);
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public int InsertUserReg(Entity.EUserReg objEUR)
        {
            int result = 0;
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetStoredProcCommand("AuthSP_InsertUserReg");
            db.AddInParameter(dbCmd, "UserName", DbType.String, objEUR.UserName);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objEUR.FirstName);
            db.AddInParameter(dbCmd, "MidName", DbType.String, objEUR.MidName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEUR.LastName);
            db.AddInParameter(dbCmd, "DateOfBirth", DbType.String, objEUR.DateOfBirth);
            db.AddInParameter(dbCmd, "Gender", DbType.Int32, objEUR.Gender);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEUR.ContactNo);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEUR.Email);
            db.AddInParameter(dbCmd, "UserAddress", DbType.String, objEUR.UserAddress);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEUR.ReligionId);
            db.AddInParameter(dbCmd, "UserImage", DbType.String, objEUR.UserImage);

            result = db.ExecuteNonQuery(dbCmd);

            return result;
        }

        public int UpdateUserReg(int UserId, string ApprovalStatus, string UserPassword)
        {
            int result = 0;
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("dbConnection");
            dbCmd = db.GetStoredProcCommand("AuthSP_ApproveUserReg");
            db.AddInParameter(dbCmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "ApprovalStatus", DbType.String, ApprovalStatus);
            db.AddInParameter(dbCmd, "UserPassword", DbType.String, UserPassword);

            result = db.ExecuteNonQuery(dbCmd);

            return result;
        }
    }
}
