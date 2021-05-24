using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace Repository
{
    public class LoginRepo
    {
        public Authentication GetLoginInfo(int empId, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@Username", empId, SqlDbType.Int, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@Password", password, SqlDbType.NVarChar, ParameterDirection.Input, 255));

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getLoginInformation", CommandType.StoredProcedure, parms);

            return Populate_Authentication(dt.Rows[0]);
        }

        public SupervisorViewModel GetSupervisorInfo(int? supervisorId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@SupervisorId", supervisorId, SqlDbType.Int));

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_SelectSupervisorName", CommandType.StoredProcedure, parms);

            return Populate_SupervisorInfo(dt.Rows[0]);
        }


        public bool IsActiveUser(string username, string password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@Username", username, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@Password", password, SqlDbType.NVarChar, ParameterDirection.Input, 30));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_VerifyIsActiveUser", CommandType.StoredProcedure, parms) > 0)
            {
                return true;
            }

            return false;            
        }

        private SupervisorViewModel Populate_SupervisorInfo(DataRow row)
        {
            SupervisorViewModel vm = new SupervisorViewModel();
            vm.SupervisorId = Convert.ToInt32(row["SupervisorId"]);
            vm.FullName = row["FullName"].ToString();

            return vm;
        }

        private Authentication Populate_Authentication(DataRow row)
        {
            Authentication a = new Authentication();
            a.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            a.Username = row["Username"].ToString();
            a.Password = row["Password"].ToString();
            a.EmployeeType = (EmployeeType)Convert.ToInt32(row["EmployeeType"]);
           
            return a;
        }
    }
}
