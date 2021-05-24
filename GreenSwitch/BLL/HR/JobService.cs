using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class JobService
    {
        JobRepository jobRepo = new JobRepository();
        public DataTable GetAllJobs()
        {
            return jobRepo.GetAllJobsLists();
        }
    }
}
