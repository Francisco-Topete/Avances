using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pagina.Models;

namespace Pagina.Controllers
{
    public class GemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gemas
        public ActionResult Index()
        {
            return View(db.Gemas.ToList());
        }

        // GET: Gemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gema gema = db.Gemas.Find(id);
            if (gema == null)
            {
                return HttpNotFound();
            }
            return View(gema);
        }

        // GET: Gemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gemas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Gema gema)
        {
            if (ModelState.IsValid)
            {
                db.Gemas.Add(gema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gema);
        }

        // GET: Gemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gema gema = db.Gemas.Find(id);
            if (gema == null)
            {
                return HttpNotFound();
            }
            return View(gema);
        }

        // POST: Gemas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Gema gema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gema);
        }

        // GET: Gemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gema gema = db.Gemas.Find(id);
            if (gema == null)
            {
                return HttpNotFound();
            }
            return View(gema);
        }

        // POST: Gemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gema gema = db.Gemas.Find(id);
            db.Gemas.Remove(gema);
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
