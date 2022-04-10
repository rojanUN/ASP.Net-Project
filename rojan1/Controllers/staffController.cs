using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rojan1.Models;

namespace rojan1.Controllers
{
    public class staffController : Controller
    {
        // GET: staff
        //public ActionResult Index()
        //{
        //    return View();
        //}
        rojanEntities db = new Models.rojanEntities();
        // GET: rojan
        public ActionResult Index()
        {
            List<staff> alldata = db.staffs.ToList();
            return View(alldata);
        }
        public ActionResult create()
        {
            return View();

        }
        public ActionResult SaveData(staff staffs)
        {
            db.staffs.Add(staffs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            staff alldata = db.staffs.Find(id);
            return View(alldata);
        }
        public ActionResult UpdateData(staff staffs)
        {
            db.Entry(staffs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
