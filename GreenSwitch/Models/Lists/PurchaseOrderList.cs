using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace Models
{
    public class PurchaseOrderList
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Employee")]
        public string Fullname { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public int SupervisorId { get; set; }

        public POStatus Status { get; set; }

        public byte[] TimeStamp { get; set; }

        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "Supervisor")]
        public string SupervisorName { get; set; }
    }
}
