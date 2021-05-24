using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreentSwitchWebAPI.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        EmployeeService employeeService = new EmployeeService();

        [Route("{searchKeyword}")]
        [HttpGet]
        public IHttpActionResult searchEmployee(string searchKeyword)
        {
            try
            {

                List<EmployeeLists> employeeLists = employeeService.GetEmployeeLookup(searchKeyword);
                return Ok(employeeLists);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }

        [Route("{searchKeyword}/{id}")]
        [HttpGet]
        public IHttpActionResult getEmployeeOne(string searchKeyword, int id)
        {
            try
            {
                List<EmployeeLists> employeeLists = employeeService.GetEmployeeLookup(searchKeyword);
                employeeLists = employeeLists.Where(e => e.EmployeeId == id).ToList();
                if (employeeLists.Count==0)
                {
                    return Content(HttpStatusCode.BadRequest, "No result found with ID");
                }
                
                Employee emp = employeeService.GetEmployeeOne(id);
                return Ok(emp);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }


        [Route("department/all/{departmentId?}")]
        [HttpGet]
        public IHttpActionResult getAllOrOneEmployee(int? departmentId = null)
        {
            try
            {

                List<Employee> employees = employeeService.GetAllOrEmployeeByDepartment(departmentId);
                if (employees.Count == 0)
                {
                    return Content(HttpStatusCode.BadRequest, "No result found with Department");
                }
                return Ok(employees);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }

    }
}
