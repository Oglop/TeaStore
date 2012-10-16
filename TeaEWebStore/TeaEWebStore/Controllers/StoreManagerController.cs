using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaEWebStore.Models;

namespace TeaEWebStore.Controllers
{ 
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private DatabaseAdapter db = new DatabaseAdapter();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var teas = db.Teas.Include(t => t.TeaType).Include(t => t.Country);
            return View(teas.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Tea tea = db.Teas.Find(id);
            return View(tea);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.TeaTypeID = new SelectList(db.TeaTypes, "TeaTypeID", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Tea tea)
        {
            if (ModelState.IsValid)
            {
                db.Teas.Add(tea);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.TeaTypeID = new SelectList(db.TeaTypes, "TeaTypeID", "Name", tea.TeaTypeID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", tea.CountryID);
            return View(tea);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tea tea = db.Teas.Find(id);
            ViewBag.TeaTypeID = new SelectList(db.TeaTypes, "TeaTypeID", "Name", tea.TeaTypeID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", tea.CountryID);
            return View(tea);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Tea tea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeaTypeID = new SelectList(db.TeaTypes, "TeaTypeID", "Name", tea.TeaTypeID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", tea.CountryID);
            return View(tea);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tea tea = db.Teas.Find(id);
            return View(tea);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tea tea = db.Teas.Find(id);
            db.Teas.Remove(tea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}