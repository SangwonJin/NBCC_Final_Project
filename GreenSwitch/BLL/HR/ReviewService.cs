using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReviewService
    {
        public bool createReview(Review review)
        {
            isValidData(review);
            if (review.getErrors().Count == 0)
            {
                new ReviewRepository().CreateReview(review);
                return true;
            }
            return false;
        }

        public Review RetrieveLatestReviewDateByEmployee(int empId)
        {
            ReviewRepository repo = new ReviewRepository();

            return repo.GetLatestReviewByEmployee(empId);
        }

        private void isValidData(Review review)
        {
            if (review.Performance < 0)
            {
                review.addError(new Error(205, "Performance cannot be empty"));
            }
            if (review.ReviewDate > DateTime.Now)
            {
                review.addError(new Error(205, "Review cannot be created in the future"));
            }
            if (review.Comment==null)
            {
                review.addError(new Error(205, "Comment cannot be empty"));
            }

            if (CheckReviewCount(review.EmployeeId)) { 
                if(RetrieveLatestReviewDateByEmployee(review.EmployeeId).ReviewDate.AddMonths(3) >= DateTime.Now)
                {
                    review.addError(new Error(205, "Quarterly review already submitted. You will be able to submit another review on " + review.ReviewDate.AddMonths(3).ToString()));
                }
            }
        }
        private bool CheckReviewCount(int empId)
        {
            ReviewRepository repo = new ReviewRepository();

            return repo.CheckReviewCount(empId) > 0;
        }

        public List<Review> GetReviewsByEmp(int empid)
        {
            ReviewRepository repo = new ReviewRepository();

            return repo.GetReviewsByEmp(empid);
        }
    }
}
