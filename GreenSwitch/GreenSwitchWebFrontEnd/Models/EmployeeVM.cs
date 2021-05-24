using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenSwitchWebFrontEnd.Models
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public JobLists Job { get; set; }
        public DepartmentLists Department { get; set; }
        public Supervisor Supervisor { get; set; }
    }
}