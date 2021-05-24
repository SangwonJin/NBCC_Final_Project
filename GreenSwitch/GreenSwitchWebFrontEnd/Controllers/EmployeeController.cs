using BLL;
using GreenSwitchWebFrontEnd.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GreenSwitchWebFrontEnd.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            try
            {
                if (searchString == "")
                {
                    ViewBag.Message = "Search Key word is requried\n";
                    return View();
                }

                EmployeeService employeeService = new EmployeeService();
                List<EmployeeLists> employees = employeeService.GetEmployeeLookup(searchString);
                return View(employees);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message+ Environment.NewLine;
                return View();

            }
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            try
            {

                EmployeeVM employeeVM = new EmployeeVM();
                EmployeeService employeeService = new EmployeeService();
                if (id == null)
                {
                    employeeVM = new EmployeeVM
                    {
                        Employee = employeeService.GetEmployeeOne(Convert.ToInt32(Session["employeeId"]))
                    };
                    ViewBag.IsProfile = "Profile";
                }
                else
                {
                    employeeVM = new EmployeeVM
                    {
                        Employee = employeeService.GetEmployeeOne((int)id)
                    };
                }


                employeeVM.Job = GetJob((int)employeeVM.Employee.JobId);
                employeeVM.Department = GetDepartment(employeeVM.Employee.DepartmentId);
                employeeVM.Supervisor = GetSupervisor((int)employeeVM.Employee.SupervisorId);
               
                return View(employeeVM);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            try
            {
                EmployeeService employeeService = new EmployeeService();
                Employee employee = employeeService.GetEmployeeOne(id);

                return View(employee);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {

            try
            {
                EmployeeService employeeService = new EmployeeService();
                employeeService.UpdateEmployee(emp);
                if (emp.getErrors().Count != 0)
                {
                    foreach (Error error in emp.getErrors())
                    {
                        ViewBag.Message += error.ErrorDescription + Environment.NewLine;
                    }
                    return View(emp);
                  
                }
                ViewBag.Message = "Updated successfully!";
                return View(emp);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

        private JobLists GetJob(int jobid)
        {

            List<JobLists> jobs = new List<JobLists>();
            DataTable dt = new JobService().GetAllJobs();
            foreach (DataRow row in dt.Rows)
            {
                jobs.Add(
                    new JobLists()
                    {
                        JobId = Convert.ToInt32(row["JobId"]),
                        Name = row["JobTitle"].ToString()
                    }
                );
            }
            JobLists job = jobs.Where(c => c.JobId.Equals(jobid)).FirstOrDefault();

            return job;

        }
        private DepartmentLists GetDepartment(int departmentId)
        {
            List<DepartmentLists> departmentLists = new List<DepartmentLists>();
            DataTable dt = new DepartmentService().GetAllDepartmentLists();
            foreach (DataRow row in dt.Rows)
            {
                departmentLists.Add(
                    new DepartmentLists()
                        {
                            DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                            Name = row["Name"].ToString()
                        }
                ); 
            }
            return departmentLists.Where(c => c.DepartmentId.Equals(departmentId)).FirstOrDefault(); ;
        }

        private Supervisor GetSupervisor(int supervisorId)
        {
            List<Supervisor> supervisors = new List<Supervisor>();
            DataTable dt = new EmployeeService().GetAllSupervisors();
            foreach (DataRow row in dt.Rows)
            {
                supervisors.Add(
                    new Supervisor()
                    {
                        EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                        FullName = row["FullName"].ToString()
                    }
                );
            }
            return supervisors.Cast<Supervisor>().Where(c => c.EmployeeId.Equals(supervisorId)).FirstOrDefault(); ;
        }

    }
}