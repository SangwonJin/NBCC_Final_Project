using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public Error(int errCode, string errDescription)
        {
            this.ErrorCode = errCode;
            this.ErrorDescription = errDescription;
        }
    }
}
