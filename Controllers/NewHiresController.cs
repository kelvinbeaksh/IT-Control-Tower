﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_Control_Tower;
using PagedList;

namespace IT_Control_Tower.Controllers
{
    public class NewHiresController : Controller
    {
        private ITControlTowerEntities db = new ITControlTowerEntities();

        // GET: NewHires
        public ActionResult Index(string searchText)
        {
            var newHires = db.NewHires.Include(n => n.TechPartner);
            //.Include(n => n.TechPartner);
            //Search
            if (!String.IsNullOrEmpty(searchText))
            {
                newHires = newHires.Where(n => n.SESA.Equals(searchText));
            }
    
            return View(newHires.ToList().OrderBy(x => x.StartDate)); 
        }
        
        public ActionResult testview(string searchtext)
        {
            var newhires = db.NewHires.Include(n => n.TechPartner);
            //.include(n => n.techpartner);
            //search
            if (!string.IsNullOrEmpty(searchtext))
            {
                newhires = newhires.Where(n => n.SESA.Equals(searchtext));
            }

            return PartialView("_t0table", newhires.ToList().OrderBy(x => x.StartDate));
        }

        // GET: NewHires/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHire newHire = db.NewHires.Find(id);
            if (newHire == null)
            {
                return HttpNotFound();
            }
            return View(newHire);
        }

        // GET: NewHires/Create
        public ActionResult Create()
        {
            ViewBag.Assignee = new SelectList(db.TechPartners, "Names", "Email");
            return View();
        }

        // POST: NewHires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SESA,StartDate,Assignee,Email,Box,Computer,Headset,Printer,Statuses,Lock")] NewHire newHire)
        {
            if (ModelState.IsValid)
            {
                db.NewHires.Add(newHire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Assignee = new SelectList(db.TechPartners, "Names", "Email", newHire.Assignee);
            return View(newHire);
        }

        // GET: NewHires/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHire newHire = db.NewHires.Find(id);
            if (newHire == null)
            {
                return HttpNotFound();
            }
            ViewBag.Assignee = new SelectList(db.TechPartners, "Names", "Email", newHire.Assignee);
            return View(newHire);
        }

        //Locking new hire
        public ActionResult LockNH(string id)
        {
            NewHire newHire = db.NewHires.Find(id);
            if (newHire.Lock == 1)
            {
                newHire.Lock = 0;
            }
            else {
                newHire.Lock = 1;
            }
            db.Entry(newHire).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

            // POST: NewHires/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SESA,StartDate,Assignee,Email,Box,Computer,Headset,Printer,Statuses")] NewHire newHire)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(newHire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Assignee = new SelectList(db.TechPartners, "Names", "Email", newHire.Assignee);
            return View(newHire);
        }

        // GET: NewHires/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewHire newHire = db.NewHires.Find(id);
            if (newHire == null)
            {
                return HttpNotFound();
            }
            return View(newHire);
        }

        // POST: NewHires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewHire newHire = db.NewHires.Find(id);
            db.NewHires.Remove(newHire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
