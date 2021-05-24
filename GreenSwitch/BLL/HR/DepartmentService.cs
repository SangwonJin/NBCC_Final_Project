using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentService
    {
        DepartmentRepository DeparRepo = new DepartmentRepository();
        public Department CreateDepartment(Department d)
        {

            d.getErrors().Clear();
            IsValidDate(d);
            if (d.getErrors().Count == 0)
            {
                DeparRepo.CreateDepartment(d);
                
            };
            return d;
        }

        public bool UpdateDepartmentByHr(Department department)
        {
            department.getErrors().Clear();
            IsValidDate(department);
            if (department.getErrors().Count == 0)
            {
                return DeparRepo.UpdateDepartmentByHr(department);

            }
            return false;
        }

        public Department GetDepartmentBySuperviosr(int employeeId)
        {
            return DeparRepo.GetDepartmentBySuperviosr(employeeId);
        }
        public DataTable GetAllDepartmentLists()
        {
            return DeparRepo.GetAllDepartmentLists();
        }
        public Department GetDepartmentOne(int departmentId)
        {
            return DeparRepo.GetDepartmentOne(departmentId);
        }

        public bool DeleteDepartemnt(int departmentid)
        {
            return DeparRepo.DeleteDepartment(departmentid);
        }

        private void IsValidDate(Department d)
        {
            if(d.Name.Length >30 || d.Name.Length <= 0)
            {
                d.addError(new Error(100, "Department Name Lengh cannot be empty or more than 30"));
            }
            if (d.Description.Length > 100 || d.Description.Length <= 0)
            {
                d.addError(new Error(101, "Department Description Lengh cannot be empty or more than 100"));
            }
            if (d.CreationDate < DateTime.Now.AddDays(-1))
            {
                d.addError(new Error(102, "Department CreationDate cannot be made before today"));
            }
        }
    }
}
