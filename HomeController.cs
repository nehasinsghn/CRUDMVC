using DataFirstApproach.Database;
using DataFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataFirstApproach.Controllers
{
  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NehaEntities dbObj = new NehaEntities();
            List<EmpModel> ModelObj = new List<EmpModel>();
            var result = dbObj.Employees.ToList();

            foreach (var i in result)
            {
                ModelObj.Add(new EmpModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Email = i.Email,
                    Mobile = i.Mobile,
                    Company = i.Company,
                    Salary = i.Salary


                });
            }

                return View(ModelObj);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpModel obj)
        {
            NehaEntities dbObj = new NehaEntities();
            Employee tblObj = new Employee();
            tblObj.Id = obj.Id;
            tblObj.Name = obj.Name;
            tblObj.Email = obj.Email;
            tblObj.Mobile = obj.Mobile;
            tblObj.Company = obj.Company;
            tblObj.Salary = obj.Salary;
            if (tblObj.Id == 0)
            {
                dbObj.Employees.Add(tblObj);
                dbObj.SaveChanges();
            }
            else
            {
                dbObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                dbObj.SaveChanges();
            }
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            NehaEntities dbObj = new NehaEntities();
          var delet = dbObj.Employees.Where(x => x.Id == id).First();
            dbObj.Employees.Remove(delet);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            EmpModel modelObj = new EmpModel();
            NehaEntities dbObj = new NehaEntities();
            var edi = dbObj.Employees.Where(x => x.Id == id).First();
            modelObj.Id = edi.Id;
            modelObj.Name = edi.Name;
            modelObj.Email = edi.Email;
            modelObj.Mobile = edi.Mobile;
            modelObj.Company = edi.Company;
            modelObj.Salary = edi.Salary;
           
            dbObj.Employees.Add(edi);
            
            
            dbObj.SaveChanges();
            return RedirectToAction("Create",modelObj);
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
    }
}