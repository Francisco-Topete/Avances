using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pagina.Models;

namespace Pagina.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductoesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Productoes
        public ActionResult Index(ProductoesViewModel PVM)
        {
            var productos = db.Productos.Include(p => p.Gema).Include(p => p.Tipo).ToList();
            var gemas = db.Gemas.ToList();
            var tipos = db.Tipos.ToList();
            PVM.Productos = productos;
            PVM.Gemas = gemas;
            PVM.Tipos = tipos;
            return View(PVM);
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.Productos.Include(p => p.Gema).Include(p => p.Tipo).FirstOrDefault(p => p.ID == id);
            if (producto == null)
            {
                return HttpNotFound();
            }
             
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(Producto producto, HttpPostedFileBase img)
        {
            string path = Server.MapPath("~/Upload/Productoes/");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var picture = img.FileName;
            var dir = "";

            if (img != null)
            {
                dir = producto.Nombre + Path.GetExtension(picture);
                img.SaveAs(path + dir);
            }

            producto.Imagen = dir;

            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GemaID = new SelectList(db.Gemas, "ID", "Nombre", producto.GemaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "ID", "Nombre", producto.TipoID);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.GemaID = new SelectList(db.Gemas, "ID", "Nombre", producto.GemaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "ID", "Nombre", producto.TipoID);
            return View(producto);
        }*/

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto, HttpPostedFileBase img)
        {
            string path = Server.MapPath("~/Upload/Productoes/");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var picture = img.FileName;
            var dir = "";

            if (img != null)
            {
                dir = producto.Nombre + Path.GetExtension(picture);
                img.SaveAs(path + dir);
            }

            producto.Imagen = dir;

            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GemaID = new SelectList(db.Gemas, "ID", "Nombre", producto.GemaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "ID", "Nombre", producto.TipoID);
            return RedirectToAction("Index");
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(IEnumerable<int> ID)
        {
            var productos = db.Productos.Include(p => p.Gema).Include(p => p.Tipo).ToList();

            foreach(var item in productos)
            {
                foreach(var id in ID)
                {
                    if(id == item.ID)
                    {
                        var producto = db.Productos.Include(p => p.Gema).Include(p => p.Tipo).FirstOrDefault(p => p.ID == id);
                        db.Productos.Remove(producto);
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
