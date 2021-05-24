using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReviewReminder : Base
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int HREmpId { get; set; }

        [Required]
        public int RecipientSupervisorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReminderDate { get; set; }

        //[Required]
        //public List<EmployeeLookup> EmployeesNeedingReview { get; set; } = new List<EmployeeLookup>();
    }
}
