using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeService
    {
        EmployeeRepository EmployeeRepo = new EmployeeRepository();

        public Employee AddEmployee(Employee e, String password)
        {
            e.getErrors().Clear();

            IsValidDate(e);
            isValidUsernameAndPassword(e, password);
            IsValidJobStartDate(e);
            IsValidSeniorityDate(e);
            CheckEmpTpye_Supervior(e);
            isValidAge(e);

            if (e.getErrors().Count == 0)
            {
                String encrypedPassword = ComputeStringToSha256Hash(password);
            EmployeeRepo.InsertEmployee(e, encrypedPassword);
            }
            return e;
        }

        public Employee UpdateEmployee(Employee e)
        {
            e.getErrors().Clear();
            IsValidDate(e);
            if (e.getErrors().Count == 0)
            {
                EmployeeRepo.UpdateEmployee(e);
                
            }
            return e;
        }
        //public List<Employee> ListEmployeesWithDueForReviewBySupervisor(int supervisorId, DateTime today)
        //{
        //    List<Employee> em

        //}
        public bool UpdateEmployeeStatus(Employee e)
        {
            e.getErrors().Clear();
            if (Convert.ToInt32(e.Status) == 0)  //0 : Retired
            {
                e.LastDayOfWork = CalculateRetireAge(e.DOB);
                IsValidRetireAge(e);
            }

            if (e.getErrors().Count == 0)
            {
                EmployeeRepo.UpdateEmployeeStatus(e);
                return true;

            }
            return false;
        }

        public bool UpdateEmployeeByHr(Employee e)
        {
            e.getErrors().Clear();
            IsValidDate(e);
            if (e.getErrors().Count == 0)
            {
                EmployeeRepo.UpdateEmployeeByHr(e);
                return true;

            }
            return false;
        }
        public bool UpdateJobByHr(Employee e)
        {
            e.getErrors().Clear();
            IsValidDate(e);
            //CheckEmpTpye_Supervior(e);
            isValidJoStartDateForModify(e);
            if (e.getErrors().Count == 0)
            {
                EmployeeRepo.UpdateJob(e);
                return true;

            }
            return false;
        }

        public List<Employee> GetAllOrEmployeeByDepartment(int? departmentId)
        {
            return EmployeeRepo.GetAllOrEmployeeByDepartment(departmentId);
        }

        public List<EmployeeLists> GetEmployeeLookup(string keyword)
        {
            return EmployeeRepo.GetEmployeeLookup(keyword);
        }

        public Employee GetEmployeeOne(int empId)
        {
            return EmployeeRepo.GetEmployeeOne(empId);
        }

        public List<EmployeeLists>GetEmployeesBySupervisor(int supervisorId)
        {
            return EmployeeRepo.GetEmployeeBySupervisor(supervisorId);
        }

        public DataTable GetAllSupervisors()
        {
            return EmployeeRepo.GetAllSupervisor();
        }

        private DateTime CalculateRetireAge(DateTime age)
        {
            DateTime retiredAge;
            retiredAge = age.AddYears(55).AddDays(-1);

            return retiredAge;
        }

        private void isValidUsernameAndPassword(Employee e, String password)
        {
            if (e.UserName=="")
            {
                e.addError(new Error(100, "UserName is required"));
            }
            if (password == "")
            {
                e.addError(new Error(100, "Password is required"));
            }
        }

        int GetAge(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
                age--;

            return age;
        }
        private void isValidAge(Employee e)
        {
            int age = GetAge(e.DOB);
            if (age<18)
            {
                e.addError(new Error(100, "Age must be older than 18"));
            }
        }

        private string ComputeStringToSha256Hash(string plainText)
        {
            // Create a SHA256 hash from string   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
        private void IsValidRetireAge(Employee e)
        {
            if(e.LastDayOfWork > DateTime.Now) 
            {
                e.addError(new Error(205, "You are not at retirement age\n " +
                    "You can retire at Year:"+e.LastDayOfWork.Value.Year+
                    " Month: "+ e.LastDayOfWork.Value.Month+
                    " Date : " + e.LastDayOfWork.Value.Day));
            }
        }


        private void isValidJoStartDateForModify(Employee e)
        {
            
            if (e.JobStartDate.ToShortDateString().CompareTo(DateTime.Now.ToShortDateString()) < 0  )
            {
                e.addError(new Error(100, "JobStart Date should be equal or greater than Today"));
            }

        }
        private void IsValidJobStartDate(Employee e)
        {
            if (e.JobStartDate < DateTime.Now.AddDays(-1))
            {
                e.addError(new Error(100, "JobStart Date should be equal or greater than Today"));
            }

            int result = e.SeniorityDate.ToShortDateString().CompareTo(e.JobStartDate.ToShortDateString());
            if (result>0)
            {
                e.addError(new Error(205, "JobStart Date should be more than Seniority Date"));
            }
 

        }

        private void IsValidSeniorityDate(Employee e)
        {
            if (e.SeniorityDate<DateTime.Now.AddDays(-1))
                {
                    e.addError(new Error(100, "SeniorityDate cannot be less than Today"));
                }
        }

        private void CheckEmpTpye_Supervior(Employee e) 
        {
            //empTpye  0 == HR Supervisor
            //empTpye  1 == Regular Supervisor
            //empTpye  2 == HR Employee
            //empTpye  3 == Regular Employee

            if (Convert.ToInt32(e.Type) == 0 || Convert.ToInt32(e.Type) == 1)
            {
  
                if (Convert.ToInt32(e.Type) == 0 && e.DepartmentId != 2)
                {
                    e.addError(new Error(205, "HR Supervior type should be in HR department"));
                }
                if (Convert.ToInt32(e.Type) == 1 && e.DepartmentId == 2)
                {
                    e.addError(new Error(205, "Regular Supervior type should not be in HR department"));
                }
            }
            if (Convert.ToInt32(e.Type) == 2 || Convert.ToInt32(e.Type) == 3)
            {
                if (e.SupervisorId == null)
                {
                    e.addError(new Error(205, "Your employee type is Employee. You should select supervisor"));
                }
                if (Convert.ToInt32(e.Type) == 2 && e.DepartmentId != 2)
                {
                    e.addError(new Error(205, "HR Employee type should be in HR department"));
                }
                if (Convert.ToInt32(e.Type) == 3 && e.DepartmentId == 2)
                {
                    e.addError(new Error(205, "Regular Employee type should not be in HR department"));
                }
            }
        }

        private void IsValidDate(Employee e)
        {
            if(e.Type < 0)
            {
                e.addError(new Error(100, "Employee Type is required"));
            }
            if (e.UserName == null)
            {
                e.addError(new Error(100, "This Employee need to have username"));
            }
            if (e.DepartmentId == 0)
            {
                e.addError(new Error(100, "Department is required"));
            }
            if (e.LastName.Length == 0)
            {
                e.addError(new Error(100, "LastName is required"));
            }
            if (e.FirstName.Length == 0)
            {
                e.addError(new Error(100, "FirstName is required"));
            }
            if (e.DOB.ToString().Length == 0)
            {
                e.addError(new Error(100, "DOB is required"));
            }
            if (e.StreetAddress.Length == 0)
            {
                e.addError(new Error(100, "StreetAddress is required"));
            }
            if (e.City.Length == 0)
            {
                e.addError(new Error(100, "City is required"));
            }
            if (e.PostalCode.Length == 0)
            {
                e.addError(new Error(100, "PostalCode is required"));
            }
            if (e.SIN.Length == 0)
            {
                e.addError(new Error(100, "SIN is required"));
            }

            if (e.WorkPhone.Length == 0)
            {
                e.addError(new Error(100, "WorkPhone is required"));
            }
            if (e.CellPhone.Length == 0)
            {
                e.addError(new Error(100, "CellPhone is required"));
            }
            if (e.IsActive.ToString().Length == 0)
            {
                e.addError(new Error(100, "IsActive is required"));
            }
        }

    }
}
