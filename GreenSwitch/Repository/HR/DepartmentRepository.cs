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
    public class DepartmentRepository
    {
        public bool CreateDepartment(Department d)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@name", d.Name, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@description", d.Description, SqlDbType.NVarChar, ParameterDirection.Input, 100));
            parms.Add(new ParmStruct("@creationDate", d.CreationDate, SqlDbType.DateTime2, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            return (db.ExecuteNonQuery("sp_createDepartment", CommandType.StoredProcedure, parms) > 0);
        }

        public bool UpdateDepartmentByHr(Department d)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@TimeStamp", d.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@departmentId", d.DepartmentId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@name", d.Name, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@description", d.Description, SqlDbType.NVarChar, ParameterDirection.Input, 200));
            parms.Add(new ParmStruct("@creationDate", d.CreationDate, SqlDbType.DateTime, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_updateDepartmentByHR", CommandType.StoredProcedure, parms) > 0)
            {
                d.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }
        public Department GetDepartmentBySuperviosr(int employeeId)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@employeeId", employeeId, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = db.Execute("sp_getDepartmentBySupervisor", CommandType.StoredProcedure, parms);
            return PopulateDepartment(dt.Rows[0]);
        }

        public DataTable GetAllDepartmentLists()
        {
            DataAccess db = new DataAccess();
            return db.Execute("sp_getAllDepartment", CommandType.StoredProcedure);
        }

        public Department GetDepartmentOne(int departmentId)
        {

            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@departmentId", departmentId, SqlDbType.Int, ParameterDirection.Input));


            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getDepartmentOne", CommandType.StoredProcedure, parms);
            return PopulateDepartment(dt.Rows[0]);
           
        }

        public bool DeleteDepartment(int deaprtmentId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@departmentId", deaprtmentId, SqlDbType.Int, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_deleteDepartment", CommandType.StoredProcedure, parms) > 0)
            {
                
                return true;
            }
            return false;
        }
        private Department PopulateDepartment(DataRow row)
        {
            return new Department()
            {
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                Name = row["Name"].ToString(),
                Description = row["Description"].ToString(),
                CreationDate = Convert.ToDateTime(row["CreationDate"]),
                TimeStamp = (byte[])row["TimeStamp"]
            };
        }
    }
}
