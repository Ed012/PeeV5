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
    public class PrincipalsController : Controller
    {
        private PeeV5Context db = new PeeV5Context();

        // GET: Principals
        public ActionResult Index()
        {
            var principals = db.Principals.Include(p => p.Place);
            return View(principals.ToList());
        }

        // GET: Principals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Principal principal = db.Principals.Find(id);
            if (principal == null)
            {
                return HttpNotFound();
            }
            return View(principal);
        }

        // GET: Principals/Create
        public ActionResult Create()
        {
            ViewBag.IdPlace = new SelectList(db.Places, "IdPlace", "Name");
            return View();
        }

        // POST: Principals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPrincipal,Name,Last_Name,Address,DNI,email,pass,Job_tittle,IdPlace")] Principal principal)
        {
            if (ModelState.IsValid)
            {
                db.Principals.Add(principal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlace = new SelectList(db.Places, "IdPlace", "Name", principal.IdPlace);
            return View(principal);
        }

        // GET: Principals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Principal principal = db.Principals.Find(id);
            if (principal == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlace = new SelectList(db.Places, "IdPlace", "Name", principal.IdPlace);
            return View(principal);
        }

        // POST: Principals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPrincipal,Name,Last_Name,Address,DNI,email,pass,Job_tittle,IdPlace")] Principal principal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(principal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlace = new SelectList(db.Places, "IdPlace", "Name", principal.IdPlace);
            return View(principal);
        }

        // GET: Principals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Principal principal = db.Principals.Find(id);
            if (principal == null)
            {
                return HttpNotFound();
            }
            return View(principal);
        }

        // POST: Principals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Principal principal = db.Principals.Find(id);
            db.Principals.Remove(principal);
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
