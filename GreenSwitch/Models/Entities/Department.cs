using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department : Base
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [StringLength(30, ErrorMessage = "Department Name cannot exceed 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department Description is Required")]
        [StringLength(100, ErrorMessage = "Department Description cannot exceed 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Department CreationDate is Required")]
        public DateTime CreationDate { get; set; }

        public byte[] TimeStamp { get; set; }
    }
}
