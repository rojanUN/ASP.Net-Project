using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rojan1.Models;

namespace rojan1.Controllers
{
    public class empSalController : Controller
    {
        // GET: empSal
        rojanEntities db = new rojanEntities();

        public ActionResult Index(DateTime? beginDate, DateTime? endDate)
        {
            List<employee_salary_details> alldata = db.employee_salary_details.ToList();
            if (beginDate != null && endDate != null)
            {
                alldata = alldata.Where(x => beginDate <= x.paid_date && endDate >= x.paid_date).ToList();
            }
            return View(alldata);
        }
        public ActionResult create()
        {
            var empList = db.employees.ToList();
            ViewBag.employeeList = new SelectList(empList, "id","name");
            return View();

        }
        [HttpPost]
        public ActionResult create(employee_salary_details employee_Salary_Details)
        {
            db.employee_salary_details.Add(employee_Salary_Details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaveData(employee_salary_details employee_salary_details)
        {
            db.employee_salary_details.Add(employee_salary_details);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult deleteData(int id)
        {
            employee_salary_details salary1 = db.employee_salary_details.Find(id);
            db.employee_salary_details.Remove(salary1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult edit(int id)
        {
            employee_salary_details salary1= db.employee_salary_details.Find(id);
            var emplist = db.employees.ToList();
            ViewBag.employeeList = new SelectList(emplist, "id", "name");
            return View(salary1);
        }
        public ActionResult UpdateData(employee_salary_details employee_Salary_Details)
        {
            db.Entry(employee_Salary_Details).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}