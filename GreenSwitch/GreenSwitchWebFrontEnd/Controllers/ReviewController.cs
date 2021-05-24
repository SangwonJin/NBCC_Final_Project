using BLL;
using GreenSwitchWebFrontEnd.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Type;

namespace GreenSwitchWebFrontEnd.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {

            try
            {
                Employee emp = new EmployeeService().GetEmployeeOne(Convert.ToInt32(Session["employeeId"]));
                List<EmployeeLists> employeeLists = new EmployeeService().GetEmployeesBySupervisor(Convert.ToInt32(Session["employeeId"]));
                ViewBag.SupervisorName = emp.LastName +" " + emp.FirstName;
                return View(employeeLists);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }

        }

        public ActionResult Create(int? emploeeId)
        {

            try
            {
                Review review = new Review();
                review.EmployeeId = (int)emploeeId;
                review.ReviewDate = DateTime.Now;
                review.SuperviosrId = Convert.ToInt32(Session["employeeId"]);
                return View(review);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {

            try
            {
                
                if (!new ReviewService().createReview(review) || review.getErrors().Count != 0)
                {
                    ViewBag.Message = "";
                    foreach (Error error in review.getErrors())
                    {
                        ViewBag.Message += error.ErrorDescription + Environment.NewLine;
                    }
                    return View(review);
                }
                ViewBag.Message = "Updated successfully!";

                return View(review);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

        public ActionResult ViewReview(int? empId)
        {

            try
            {
                List<Review> review = new ReviewService().GetReviewsByEmp((int)empId);

                if(review.Count <= 0)
                {
                    ViewBag.Message = "You don't have any review";
                    return View();
                }
                ViewBag.Message = "";
                return View(review);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

        public ActionResult Details(DateTime reviewDate, PerformanceRating rating, int supervisorId, int empId, String comment)
        {
            try
            {
             
                ReviewVM reviewDetail = new ReviewVM();
                reviewDetail.Review = new Review();
                reviewDetail.supervisor = new SupervisorViewModel();
                reviewDetail.Review.EmployeeId = empId;
                reviewDetail.Review.Performance = rating;
                reviewDetail.Review.ReviewDate = reviewDate;
                reviewDetail.Review.Comment = comment;

                reviewDetail.supervisor = new LoginBL().GetSupervisor(supervisorId);


                return View(reviewDetail);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex.Message + Environment.NewLine;
                return View();

            }
        }

    }
}