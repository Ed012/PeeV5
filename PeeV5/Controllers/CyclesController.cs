using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeeV5.Models;

namespace PeeV5.Controllers
{
    public class CyclesController : Controller
    {
        private PeeV5Context db = new PeeV5Context();

        // GET: Cycles
        public ActionResult Index()
        {
            var cycles = db.Cycles.Include(c => c.Teacher);
            return View(cycles.ToList());
        }

        // GET: Cycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            return View(cycle);
        }

        // GET: Cycles/Create
        public ActionResult Create()
        {
            ViewBag.IdTeacher = new SelectList(db.Teachers, "IdTeacher", "Name");
            return View();
        }

        // POST: Cycles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCycle,Name,Category,IdTeacher")] Cycle cycle)
        {
            if (ModelState.IsValid)
            {
                db.Cycles.Add(cycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTeacher = new SelectList(db.Teachers, "IdTeacher", "Name", cycle.IdTeacher);
            return View(cycle);
        }

        // GET: Cycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTeacher = new SelectList(db.Teachers, "IdTeacher", "Name", cycle.IdTeacher);
            return View(cycle);
        }

        // POST: Cycles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCycle,Name,Category,IdTeacher")] Cycle cycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTeacher = new SelectList(db.Teachers, "IdTeacher", "Name", cycle.IdTeacher);
            return View(cycle);
        }

        // GET: Cycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            return View(cycle);
        }

        // POST: Cycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cycle cycle = db.Cycles.Find(id);
            db.Cycles.Remove(cycle);
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
