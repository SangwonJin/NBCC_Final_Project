using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreentSwitchWebAPI.Controllers
{

    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {


        [HttpGet]
        public IHttpActionResult GetAllDepartment()
        {
            try
            {

                List<DepartmentLists> departmentLists = GetAllDepartments();
                return Ok(departmentLists);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
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
