using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaEWebStore.Models;

namespace TeaEWebStore.Controllers
{
    public class HomeController : Controller
    {
        DatabaseAdapter db = new DatabaseAdapter();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searchString)
        {
            var teas = from t in db.Teas select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                teas = teas.Where(t => t.Title.Contains(searchString));
            }
            return View(teas);
        }
    }
}
