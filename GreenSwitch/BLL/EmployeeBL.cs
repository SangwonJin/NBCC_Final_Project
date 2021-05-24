using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBL
    {
        EmployeeRepo repo = new EmployeeRepo();
        public void IsValidData(Employee loggedEmp)
        {
            if (loggedEmp.EmployeeId <= 0)
            {
                loggedEmp.addError(new Error(102, "No Employee Logged In."));
            }
        }

        public Employee GetEmployeeInfo(Employee loggedEmp)
        {
            IsValidData(loggedEmp);
            if (loggedEmp.getErrors().Count == 0)
            {
                return repo.GetLoginInfo(loggedEmp.EmployeeId);
            }
            return loggedEmp;
        }
    }
}
