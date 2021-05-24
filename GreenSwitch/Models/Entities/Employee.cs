using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace Models
{
    public class Employee : Base
    {


        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "DepartmentId is Required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [StringLength(30, ErrorMessage = "Department Name cannot exceed 30 characters.")]
        public string DepartmentName { get; set; }

        public int? JobId { get; set; }

        public int? SupervisorId { get; set; }

        [Required(ErrorMessage = "FirstName  is Required")]
        [StringLength(30, ErrorMessage = "FirstName  cannot exceed 30 characters.")]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "LastName  is Required")]
        [StringLength(30, ErrorMessage = "LastName cannot exceed 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Day of Birth is Required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = " StreetAddress is Required")]
        [StringLength(100, ErrorMessage = "StreetAddress cannot exceed 100 characters.")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(30, ErrorMessage = "City cannot exceed 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "PostalCode is Required")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "SIN is Required")]
        public string SIN { get; set; }

        [Required(ErrorMessage = "SeniorityDate is Required")]
        public DateTime SeniorityDate { get; set; }

        [Required(ErrorMessage = "JobStartDate is Required")]
        public DateTime JobStartDate { get; set; }

        [Required(ErrorMessage = "WorkPhone is Required")]
        public string WorkPhone { get; set; }

        [Required(ErrorMessage = "CellPhone is Required")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "EmailAddress is Required")]
        [StringLength(30, ErrorMessage = "EmailAddress cannot exceed 30 characters.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "IsActive is Required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(30, ErrorMessage = "UserName cannot exceed 30 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Type is Required")]
        public EmployeeType Type { get; set; }

        public byte[] TimeStamp { get; set; }
        public EmployeeStatus? Status { get; set; }
        public DateTime? LastDayOfWork { get; set; }

    }
}
