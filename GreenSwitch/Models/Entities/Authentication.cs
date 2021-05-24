using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace Models
{
    public class Authentication : Base
    {
        [Required(ErrorMessage = "EmployeeID is Required")]
        public int EmployeeId { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
