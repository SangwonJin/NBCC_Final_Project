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
    public class EmployeeRepository
    {
        public DataTable GetAllSupervisor()
        {
            DataAccess db = new DataAccess();
            return db.Execute("sp_getAllSupervisor", CommandType.StoredProcedure);
        }

        public bool InsertEmployee(Employee e,String password)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@empId",e.EmployeeId, SqlDbType.Int, ParameterDirection.Output));

            if (e.SupervisorId != null)
            {
                parms.Add(new ParmStruct("@supervisorId", e.SupervisorId, SqlDbType.Int, ParameterDirection.Input));
            }
            else
            {
                parms.Add(new ParmStruct("@supervisorId", DBNull.Value, SqlDbType.Int, ParameterDirection.Input));
            }
            if (e.SupervisorId != null)
            {
                parms.Add(new ParmStruct("@jobId", e.JobId, SqlDbType.Int, ParameterDirection.Input));
            }
            else
            {
                parms.Add(new ParmStruct("@jobId", DBNull.Value, SqlDbType.Int, ParameterDirection.Input));
            }

            parms.Add(new ParmStruct("@departmentId", e.DepartmentId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@lastName", e.LastName, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@firstName", e.FirstName, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@mi", e.MiddleInitial, SqlDbType.NChar, ParameterDirection.Input, 1));
            parms.Add(new ParmStruct("@dob", e.DOB, SqlDbType.DateTime, ParameterDirection.Input));
            parms.Add(new ParmStruct("@streetAddress", e.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input,100));
            parms.Add(new ParmStruct("@city", e.City, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@postalCode", e.PostalCode, SqlDbType.NChar, ParameterDirection.Input,6));
            parms.Add(new ParmStruct("@sin", e.SIN, SqlDbType.NChar, ParameterDirection.Input,11));
            parms.Add(new ParmStruct("@seniorityDate", e.SeniorityDate, SqlDbType.DateTime2, ParameterDirection.Input));
            parms.Add(new ParmStruct("@jobStartDate", e.JobStartDate, SqlDbType.DateTime2, ParameterDirection.Input));
            parms.Add(new ParmStruct("@workPhone", e.WorkPhone, SqlDbType.NVarChar, ParameterDirection.Input,13));
            parms.Add(new ParmStruct("@cellPhone", e.CellPhone, SqlDbType.NVarChar, ParameterDirection.Input,13));
            parms.Add(new ParmStruct("@Email", e.EmailAddress, SqlDbType.NVarChar, ParameterDirection.Input,30));
            parms.Add(new ParmStruct("@isActive", e.IsActive, SqlDbType.Bit, ParameterDirection.Input));
            parms.Add(new ParmStruct("@empType", e.Type, SqlDbType.TinyInt, ParameterDirection.Input));
            parms.Add(new ParmStruct("@username", e.UserName, SqlDbType.NVarChar, ParameterDirection.Input,30));
            parms.Add(new ParmStruct("@password", password, SqlDbType.NVarChar, ParameterDirection.Input, 255));


            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_insertEmployee", CommandType.StoredProcedure, parms) > 0)
            {
                e.EmployeeId = Convert.ToInt32(parms[0].Value);
                return true;
            }
            return false;
        }

        public bool UpdateEmployeeStatus(Employee e)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@TimeStamp", e.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@empId", e.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@empStatus", e.Status, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@lastdayofwork", e.LastDayOfWork, SqlDbType.DateTime2, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_updateEmployeeStatus", CommandType.StoredProcedure, parms) > 0)
            {
                e.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }

        public bool UpdateJob(Employee e)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@TimeStamp", e.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@empId", e.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@supervisorId", e.SupervisorId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@jobId", e.JobId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@departmentId", e.DepartmentId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@jobStartDate", e.JobStartDate, SqlDbType.DateTime2, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_updateJobByHr", CommandType.StoredProcedure, parms) > 0)
            {
                e.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }

        public bool UpdateEmployee(Employee e)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@TimeStamp", e.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput, 100));
            parms.Add(new ParmStruct("@empId", e.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@streetAddress", e.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input, 100));
            parms.Add(new ParmStruct("@city", e.City, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@postalCode", e.PostalCode, SqlDbType.NChar, ParameterDirection.Input, 6));
            parms.Add(new ParmStruct("@workPhone", e.WorkPhone, SqlDbType.NVarChar, ParameterDirection.Input, 13));
            parms.Add(new ParmStruct("@cellPhone", e.CellPhone, SqlDbType.NVarChar, ParameterDirection.Input, 13));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_updatePersonalInfo", CommandType.StoredProcedure, parms) > 0)
            {
                e.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }

        public bool UpdateEmployeeByHr(Employee e)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@TimeStamp", e.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@empId", e.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@lastName", e.LastName, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@firstName", e.FirstName, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@mi", e.MiddleInitial, SqlDbType.NChar, ParameterDirection.Input, 1));
            parms.Add(new ParmStruct("@dob", e.DOB, SqlDbType.DateTime, ParameterDirection.Input));
            parms.Add(new ParmStruct("@streetAddress", e.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input, 100));
            parms.Add(new ParmStruct("@city", e.City, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@postalCode", e.PostalCode, SqlDbType.NChar, ParameterDirection.Input, 6));
            parms.Add(new ParmStruct("@workPhone", e.WorkPhone, SqlDbType.NVarChar, ParameterDirection.Input, 13));
            parms.Add(new ParmStruct("@cellPhone", e.CellPhone, SqlDbType.NVarChar, ParameterDirection.Input, 13));
            parms.Add(new ParmStruct("@Email", e.EmailAddress, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@isActive", e.IsActive, SqlDbType.Bit, ParameterDirection.Input));
            parms.Add(new ParmStruct("@username", e.UserName, SqlDbType.NVarChar, ParameterDirection.Input, 30));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("sp_updatePersonalInfoByHR", CommandType.StoredProcedure, parms) > 0)
            {
                e.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }

        public List<EmployeeLists> GetEmployeeLookup(string keyword)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            if (int.TryParse(keyword, out int result))
            {
                parms.Add(new ParmStruct("@Keyword", result, SqlDbType.Int, ParameterDirection.Input));
            }
            else
            {
                parms.Add(new ParmStruct("@Keyword", keyword, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            }
          
            DataAccess db = new DataAccess();
            DataTable  dt =  db.Execute("sp_getEmployeeLookup", CommandType.StoredProcedure, parms);
            return PopulateEmpLists(dt);
        }

        public List<Employee> GetAllOrEmployeeByDepartment(int? departmentId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@department", departmentId, SqlDbType.Int, ParameterDirection.Input));
           
            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getAllOrDepartmentEmployeeInfo", CommandType.StoredProcedure, parms);
            return PopulateEmployees(dt);
        }

        public List<EmployeeLists> GetEmployeeBySupervisor(int supervisorId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
   
            parms.Add(new ParmStruct("@supervisor", supervisorId, SqlDbType.Int, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getEmployeeBySupervisor", CommandType.StoredProcedure, parms);
            return PopulateEmpLists(dt);
        }
        public List<EmployeeLists> GetAllSupervisorForReminder()
        {
           

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getAllSupervisor", CommandType.StoredProcedure);
            return PopulateEmpListsForReminder(dt);
        }

        public List<EmployeeLists> GetAllneedingEmployee()
        {


            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getReviewsBySupervisorWithQuarter", CommandType.StoredProcedure);
            return PopulateEmpListsForReminder(dt);
        }

        public List<EmployeeLists> GetAllHrForReminder()
        {


            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getAllHr", CommandType.StoredProcedure);
            return PopulateEmpListsForReminder(dt);
        }


        public Employee GetEmployeeOne(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
       
            parms.Add(new ParmStruct("@employeeid", empId, SqlDbType.Int, ParameterDirection.Input));
     

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getEmployeeOne", CommandType.StoredProcedure, parms);
            return PopulateEmployee(dt.Rows[0]);
        }

        private List<EmployeeLists> PopulateEmpLists(DataTable dt)
        {
            List<EmployeeLists> employeeLists = new List<EmployeeLists>();
            foreach(DataRow row in dt.Rows)
            {
                employeeLists.Add(
                    new EmployeeLists
                    {
                        EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                        FullName = row["FullName"].ToString(),
                   
                    }
                );
            }
            return employeeLists;

        }

        private List<EmployeeLists> PopulateEmpListsForReminder(DataTable dt)
        {
            List<EmployeeLists> employeeLists = new List<EmployeeLists>();
            foreach (DataRow row in dt.Rows)
            {
                employeeLists.Add(
                    new EmployeeLists
                    {
                        EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                        FullName = row["FullName"].ToString(),
                        Email = row["Email"].ToString(),
                    }
                );
            }
            return employeeLists;

        }

        private List<Employee> PopulateEmployees(DataTable dt)
        {
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dt.Rows)
            {
                employees.Add(
                    new Employee
                    {
                        EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                        DepartmentId = Convert.ToInt32(row["departmentId"]),
                        FirstName = row["FirstName"].ToString(),
                        MiddleInitial = row["MI"] is System.DBNull ? "" : row["MI"].ToString(),
                        LastName = row["LastName"].ToString(),
                        DOB = Convert.ToDateTime(row["Dob"]),
                        StreetAddress = row["StreetAddress"].ToString(),
                        City = row["City"].ToString(),
                        PostalCode = row["PostalCode"].ToString(),
                        WorkPhone = row["WorkPhone"].ToString(),
                        CellPhone = row["CellPhone"].ToString(),
                        EmailAddress = row["Email"].ToString(),
                        Type = (EmployeeType)Convert.ToInt32(row["EmployeeType"])
            }
                );
            }
            return employees;

        }


        private Employee PopulateEmployee(DataRow row)
        {
            Employee e = new Employee();
            e.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            e.DepartmentId = Convert.ToInt32(row["departmentId"]);
            e.JobId = row["JobId"] is System.DBNull ? null: (int?)Convert.ToInt32(row["JobId"]);
            e.SupervisorId = row["supervisorid"] is System.DBNull ? null : (int?)row["supervisorid"];
            e.FirstName = row["FirstName"].ToString();
            e.MiddleInitial = row["MI"] is System.DBNull ? "" : row["MI"].ToString();
            e.LastName = row["LastName"].ToString();
            e.DOB =  Convert.ToDateTime(row["Dob"]);
            e.StreetAddress = row["StreetAddress"].ToString();
            e.City = row["City"].ToString();
            e.PostalCode = row["PostalCode"].ToString();
            e.SIN = row["SIN"].ToString();
            e.SeniorityDate = Convert.ToDateTime(row["SeniorityDate"]);
            e.JobStartDate = row["JobStartDate"] is System.DBNull ? DateTime.Today : Convert.ToDateTime(row["JobStartDate"]);
            e.WorkPhone = row["WorkPhone"].ToString();
            e.CellPhone = row["CellPhone"].ToString();
            e.EmailAddress = row["Email"].ToString();
            e.IsActive = Convert.ToBoolean(row["IsActive"]);
            e.UserName = row["UserName"].ToString();
            e.Type = (EmployeeType)Convert.ToInt32(row["EmployeeType"]);
            e.TimeStamp = (byte[])row["TimeStamp"];
            e.Status = row["Status"] is System.DBNull ? null : (EmployeeStatus?)Convert.ToInt32(row["Status"]);
            e.LastDayOfWork = row["LastDayOfWork"] is System.DBNull ? null : (DateTime?)row["LastDayOfWork"];
       
       

            return e;
        }
    }
}
