using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace Repository
{
    public class ReviewReminderRepository
    {
        public bool isValidSentToday(DateTime today)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@today", today, SqlDbType.DateTime, ParameterDirection.Input));


            DataAccess db = new DataAccess();
            if (Convert.ToInt32( db.ExecuteScaler("sp_checkSentReviewReminderDate", CommandType.StoredProcedure, parms)) > 0)
            {
                //e.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;
        }
        public List<Review> GetReviewsBySupervisorWithQuater(DateTime startQuater, DateTime endQuater)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@startQuaterDate", startQuater, SqlDbType.DateTime, ParameterDirection.Input));
            parms.Add(new ParmStruct("@endQuaterDate", endQuater, SqlDbType.DateTime, ParameterDirection.Input));


            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getReviewsBySupervisorWithQuarter", CommandType.StoredProcedure, parms);

            List<Review> reviewList = new List<Review>();
            foreach (DataRow row in dt.Rows)
            {
                reviewList.Add(Populate_ReviewForReminder(row));
            }
            return reviewList;
        }

        public bool insertReminderData(ReviewReminder reviewReminder)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@hrEmpId", reviewReminder.HREmpId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@RecipientSupervisorId", reviewReminder.RecipientSupervisorId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@reminderDate", reviewReminder.ReminderDate, SqlDbType.DateTime, ParameterDirection.Input));



            DataAccess db = new DataAccess();
            int result =  db.ExecuteNonQuery("sp_createReviewReminder", CommandType.StoredProcedure, parms);
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        private Review Populate_ReviewForReminder(DataRow row)
        {
            Review r = new Review();
            r.ReviewId = Convert.ToInt32(row["ReviewId"]);
            r.Performance = (PerformanceRating)Convert.ToInt32(row["PerformanceRating"]);
            r.Comment = row["Comment"].ToString();
            r.ReviewDate = Convert.ToDateTime(row["ReviewDate"]);
            r.SuperviosrId = Convert.ToInt32(row["SupervisorId"]);
            r.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            r.TimeStamp = (byte[])row["TimeStamp"];
            r.FullName = row["FullName"].ToString();
            return r;
        }

        
    }
}
