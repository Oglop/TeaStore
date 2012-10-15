using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaStore.Models;

namespace TeaStore.Controllers
{
    public class HomeController : Controller
    {
        TeaDatabaseContext db = new TeaDatabaseContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var types = db.Types.ToList();
            return View(types);
        }

        public ActionResult Browse(string type) 
        {
            var typeModel = db.Types.Include(type).Single(t => t.Name == type);
            return View(typeModel);
        }
    }
}
