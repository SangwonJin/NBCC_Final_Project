using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JobRepository
    {
        public DataTable GetAllJobsLists()
        {
            DataAccess db = new DataAccess();
            return db.Execute("sp_getAlljJobs", CommandType.StoredProcedure);
        }
    }
}
