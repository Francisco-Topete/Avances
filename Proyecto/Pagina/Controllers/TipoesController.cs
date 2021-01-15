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
    public class TipoesController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Tipoes
        public ActionResult Index()
        {
            return View(db.Tipos.ToList());
        }

        // GET: Tipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipos.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: Tipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        [HttpPost]
        public ActionResult Edit(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(IEnumerable<int> ID)
        {
            var tipos = db.Tipos.ToList();

            foreach (var item in tipos)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var borrartipo = db.Tipos.FirstOrDefault(p => p.ID == id);
                        db.Tipos.Remove(borrartipo);
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
