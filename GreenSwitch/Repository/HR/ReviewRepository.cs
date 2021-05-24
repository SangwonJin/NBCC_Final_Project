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
    public class ReviewRepository
    {
        public bool CreateReview(Review review)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@performance", review.Performance, SqlDbType.TinyInt, ParameterDirection.Input));
            parms.Add(new ParmStruct("@comment", review.Comment, SqlDbType.NVarChar, ParameterDirection.Input, 200));
            parms.Add(new ParmStruct("@reviewDate", review.ReviewDate, SqlDbType.DateTime2, ParameterDirection.Input));
            parms.Add(new ParmStruct("@supervisorId", review.SuperviosrId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@employeeId", review.EmployeeId, SqlDbType.Int, ParameterDirection.Input));


            DataAccess db = new DataAccess();
            return (db.ExecuteNonQuery("sp_createReview", CommandType.StoredProcedure, parms) > 0);
        }

        public int CheckReviewCount(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@EmployeeId", empId, SqlDbType.Int, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            return Convert.ToInt32(db.ExecuteScaler("sp_CheckReviewCount", CommandType.StoredProcedure, parms));
        }
        public Review GetLatestReviewByEmployee(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@EmployeeId", empId, SqlDbType.Int, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_GetLastestReviewDate", CommandType.StoredProcedure, parms);

            return Populate_LastReview(dt.Rows[0]);
        }
        public List<Review> GetReviewsByEmp(int empId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
     
                parms.Add(new ParmStruct("@empID", empId, SqlDbType.Int, ParameterDirection.Input));
            


            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("sp_getAllReviewsByEmp", CommandType.StoredProcedure, parms);

            List<Review> reviewList = new List<Review>();
            foreach (DataRow row in dt.Rows)
            {
                reviewList.Add(Populate_LastReview(row));
            }
            return reviewList;
        }
        private Review Populate_LastReview(DataRow row)
        {
            Review r = new Review();
            r.ReviewId = Convert.ToInt32(row["ReviewId"]);
            r.Performance = (PerformanceRating)Convert.ToInt32(row["PerformanceRating"]);
            r.Comment = row["Comment"].ToString();
            r.ReviewDate = Convert.ToDateTime(row["ReviewDate"]);
            r.SuperviosrId = Convert.ToInt32(row["SupervisorId"]);
            r.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            r.TimeStamp = (byte[])row["TimeStamp"];
            return r;
        }


    }
}
