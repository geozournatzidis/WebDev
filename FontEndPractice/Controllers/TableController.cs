using RazorSyntaxFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorSyntaxFrontEnd.Controllers
{
    public class TableController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            List<UserModel> customer = new List<UserModel>();
            customer.Add(new UserModel("George", "george@gmail.com", "6999999999"));
            customer.Add(new UserModel("John", "john@gmail.com", "9944444444"));
            customer.Add(new UserModel("Ani", "ani@gmail.com", "9633333333"));
            return View("Table", customer);
        }
    }
}