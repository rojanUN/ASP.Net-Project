using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rojan1.Models;

namespace rojan1.Controllers
{
    public class rojanController : Controller
       
    {
        rojanEntities db =  new rojanEntities();
        // GET: rojan
        public ActionResult Index()
        {
            List<employee> alldata = db.employees.ToList();
            return View(alldata);
        }
        public ActionResult create()
        {
            return View();

        }
        public ActionResult SaveData(employee employees)
        {
            db.employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            employee data = db.employees.Find(id);
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            employee alldata = db.employees.Find(id); 
            return View(alldata);                               
        }
        public ActionResult UpdateData(employee employees)
        {
            db.Entry(employees).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}