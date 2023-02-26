using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;


namespace BLL
{
    public class AuthBLL
    {
        AuthDAL objAuthDAL = new AuthDAL();
        public DataTable CheckUserInfo(string UserName, string UserPassword)
        {
            DataTable dt = new DataTable();
            dt = objAuthDAL.CheckUser(UserName, UserPassword);
            return dt;
        }
        public int InsertUserRegInfo(EUserReg objEUR)
        {
            int result = 0;
            result = objAuthDAL.InsertUserReg(objEUR);
            return result;
        }

        public DataTable getUserRegList(int ReligionId, int Gender, int UserId=0)
        {
            DataTable dt = new DataTable();
            dt = objAuthDAL.getUserReg(ReligionId, Gender, UserId);
            return dt;
        }

        public int ApproveUserRegInfo(int UserId, string ApprovalStatus, string UserPassword)
        {
            int result = 0;
            result = objAuthDAL.UpdateUserReg( UserId,  ApprovalStatus,  UserPassword);
            return result;
        }
    }
}
