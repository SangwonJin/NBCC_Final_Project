using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenSwitchWebFrontEnd.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        public ActionResult index()
        {
            try
            {
                List<DepartmentLists> departmentLists = GetAllDepartments();
                return View(departmentLists);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
  
        }

        public ActionResult Edit(int? supervisorId,int? departmentId)
        {
            try
            {
                Department department = new Department();
                if (supervisorId is null)
                {
                    department = new DepartmentService().GetDepartmentOne((int)departmentId);
                    ViewBag.EmployeeType = "HR";
                    return View(department);
                }
                else
                {
                    department = new DepartmentService().GetDepartmentBySuperviosr((int)supervisorId);
                    ViewBag.EmployeeType = "SuperVisor";
                }
                return View(department);

            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department d)
        {
            try
            {
                if (!new DepartmentService().UpdateDepartmentByHr(d) || d.getErrors().Count != 0)
                {
                    foreach (Error error in d.getErrors())
                    {
                        ViewBag.Message += error.ErrorDescription + Environment.NewLine;
                    }
                    return View(d);
                }

                if ((int)Session["EmployeeType"] == 1)
                {
                    ViewBag.EmployeeType = "SuperVisor";
                }
                ViewBag.Message = "Updated successfully!";
                return View(d);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }

        }


        private List<DepartmentLists> GetAllDepartments()
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
            return departmentLists;
        }
    }

    
}