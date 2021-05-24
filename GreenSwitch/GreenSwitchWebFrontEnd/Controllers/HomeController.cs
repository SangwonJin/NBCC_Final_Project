using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Type;

namespace GreenSwitchWebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private LoginBL loginService = new LoginBL();
        Authentication loggedEmp;
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Authentication login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginBL loginBL = new LoginBL();
                    loggedEmp = loginService.GetAuthentication(login);
                    if (loggedEmp.getErrors().Count != 0)
                    {
                        string msg = "";
                        foreach (Error error in loggedEmp.getErrors())
                        {
                            msg += error.ErrorDescription + Environment.NewLine;
                        }

                        ViewBag.Message = msg;
                    }
                    else
                    {
                        Session["username"] = loggedEmp.Username;
                        Session["employeeId"] = loggedEmp.EmployeeId;
                        Session["loggedInEmp"] = loggedEmp;
                        Session["EmployeeType"] = (EmployeeType)loggedEmp.EmployeeType;
                       
                        if (Session["RedirectToAction"] != null && Session["RedirectToController"] != null && Session["RedirectToId"] != null)
                        {
                            string actionName = Session["RedirectToAction"].ToString();
                            string controllerName = Session["RedirectToController"].ToString();
                            int theId = Convert.ToInt32(Session["RedirectToId"]);

                            Session["RedirectToAction"] = null;
                            Session["RedirectToController"] = null;
                            Session["RedirectToId"] = null;
                            return RedirectToAction(actionName, controllerName, new { id = theId });
                        }

                        return Redirect("/Home");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + Environment.NewLine;
                return View();
            }          
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["loggedInName"] = null;
            Session["loggedInEmp"] = null;
            return Redirect("/Home");
        }

        private Employee PopulateLoginObject()
        {
            return new Employee()
            {
                EmployeeId = Convert.ToInt32(Session["employeeId"])
            };
        }
    }
}