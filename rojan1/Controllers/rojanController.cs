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
        public ActionResult Index(string option, string search)
        {
            //if a user choose the radio button option as name
            if (option == "name")
            {
                //Index action method will return a view with a employee records based on what a user specify the value in textbox  
                return View(db.employees.Where(x => x.name.StartsWith(search) || search == null).ToList());
            }
            //List<employee> alldata = db.employees.ToList();
            //return View(alldata);
       
            //else if(option == "address")
            //{
            //  return View(db.employees.Where(x => x.address.StartsWith(search) || search == null).ToList()); 
            //}
            else {
                return View( db.employees.Where(x => x.name == search || search == null).ToList());
            }
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