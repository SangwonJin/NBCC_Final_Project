using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Supervisor
    {
        public int EmployeeId { get; set; }

        [Display(Name ="Supervisor Name")]
        public string FullName { get; set; }
    }
}
