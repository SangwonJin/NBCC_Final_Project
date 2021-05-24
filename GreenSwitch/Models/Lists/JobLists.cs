using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobLists
    {
        public int JobId { get; set; }

        [Display(Name = "Job Name")]
        public string Name { get; set; }
    }
}
