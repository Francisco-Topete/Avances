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
    [Authorize(Roles = "Administrador")]
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

        [HttpPost]
        public ActionResult Create(Gema gema)
        {
            if (ModelState.IsValid)
            {
                db.Gemas.Add(gema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gema);
        }

        [HttpPost]
        public ActionResult Edit(Gema gema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gema);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(IEnumerable<int> ID)
        {
            var gemas = db.Gemas.ToList();

            foreach (var item in gemas)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var borrargema = db.Gemas.FirstOrDefault(p => p.ID == id);
                        db.Gemas.Remove(borrargema);
                    }
                }
            }

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
