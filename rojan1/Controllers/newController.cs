using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rojan1.Models;

namespace rojan1.Controllers
{
    public class newController : Controller
    {
        rojanEntities db = new rojanEntities();
        // GET: new
        public ActionResult newtable()
        {
            List<student> alldata = db.students.ToList();
            return View(alldata);
        }
    }
}