using DataFirstApproach.Database;
using DataFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataFirstApproach.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult LoginForm()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(LoginModel m)
        {
            NehaEntities DbObj = new NehaEntities();

            var result = DbObj.Listtbls.Where(a => a.Email == m.Email).FirstOrDefault();
            if(result==null)
            {
                TempData["Error"] = "invailid User";
            } 
            else
            {
                if (result.Email == m.Email && result.Password == m.Password)
                    return RedirectToAction("Create", "Home");
                else
                {
                    TempData["invalid"] = "Email or password does not match";
                }
            }

            return View();
        }
    }
}