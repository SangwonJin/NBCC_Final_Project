using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Type;

namespace Models
{
    public class Review : Base
    {
        public int ReviewId { get; set; }   
        public PerformanceRating Performance { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int SuperviosrId { get; set; }
        public int EmployeeId { get; set; }
        public byte[] TimeStamp { get; set; }
        public String FullName { get; set; }

    }
}
