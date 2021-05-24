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
    public class EmployeeRepo
    {
        public Employee GetLoginInfo(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@EmployeeId", empId, SqlDbType.NVarChar));

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_SelectLoggedInEmployee", CommandType.StoredProcedure, parms);

            return Populate_LoggedInEmp(dt.Rows[0]);
        }
        private Employee Populate_LoggedInEmp(DataRow row)
        {
            Employee e = new Employee();
            e.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            e.DepartmentId = Convert.ToInt32(row["departmentId"]);
            e.DepartmentName = row["Name"].ToString();
            e.JobId = Convert.ToInt32(row["JobId"]);
            e.FirstName = row["FirstName"].ToString();
            e.MiddleInitial = row["MI"].ToString();
            e.LastName = row["LastName"].ToString();
            e.DOB = Convert.ToDateTime(row["Dob"]);
            e.StreetAddress = row["StreetAddress"].ToString();
            e.City = row["City"].ToString();
            e.PostalCode = row["PostalCode"].ToString();
            e.SIN = row["SIN"].ToString();
            e.SeniorityDate = Convert.ToDateTime(row["SeniorityDate"]);
            e.JobStartDate = Convert.ToDateTime(row["JobStartDate"]);
            e.SupervisorId = Convert.ToInt32(row["SupervisorId"]);
            e.WorkPhone = row["WorkPhone"].ToString();
            e.CellPhone = row["CellPhone"].ToString();
            e.EmailAddress = row["Email"].ToString();
            e.IsActive = Convert.ToBoolean(row["IsActive"]);
            return e;
        }       
    }
}
