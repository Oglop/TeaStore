using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaEWebStore.Models;

namespace TeaEWebStore.Controllers
{
    public class StoreController : Controller
    {
        DatabaseAdapter db = new DatabaseAdapter();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var teaTypes = db.TeaTypes.ToList();
            return View(teaTypes);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string teaType)
        {
            var teatypes = db.TeaTypes.Include("Teas").Single(t => t.Name == teaType);
            if (teatypes == null) 
            {
                return HttpNotFound();
            }
            return View(teatypes);
        }

        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var tea = db.Teas.Find(id);
            if (tea == null) 
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        public ActionResult Search(string querry)
        {
            var teas = from t in db.Teas select t;
            if (!String.IsNullOrEmpty(querry)) 
            {
                teas = teas.Where(t => t.Title.Contains(querry));
            }
            return View(teas);
        }

        //
        // Get: /Store/TeaTypes
        [ChildActionOnly]
        public ActionResult TeaTypesMenu() 
        {
            var types = db.TeaTypes.ToList();
            return PartialView(types);
        }
    }
}
