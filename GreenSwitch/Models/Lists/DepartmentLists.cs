using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DepartmentLists
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}
