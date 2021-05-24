using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Base
    {
        private List<Error> errors = new List<Error>();

        public List<Error> getErrors()
        {
            return errors;
        }
        public void addError(Error err)
        {
            errors.Add(err);
        }
    }
}
