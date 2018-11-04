using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysqlTest.Models;
using MysqlTest.DataAccess;

namespace MysqlTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly mysqlContext_test context;

        public HomeController(mysqlContext_test context) {
            this.context = context;
        }
        Customer newCustomer = new Customer();

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Signin()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [NonAction]
        public bool isEmailExist(string emailID)
        {
            //Working on email duplication verify
            using (mysqlContext_test dc = new mysqlContext_test())
            {
                var v = dc.Customers.Where(a => a.email == emailID).FirstOrDefault();
                return v != null;
            }
        }

        //Get the registration form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(Customer newCustomer)
        {
            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region
                var isExist = isEmailExist(newCustomer.email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already Exist");
                    return View(newCustomer);
                }
                #endregion

                #region Save to Database
                using (mysqlContext_test dc = new mysqlContext_test())
                {
                    dc.Customers.Add(newCustomer);
                    dc.SaveChanges();
                    message = "Registration successfully done.";
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(newCustomer);
        }

        //Get the login form
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
