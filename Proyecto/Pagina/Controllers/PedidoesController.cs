using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pagina.Models;
using System.Collections.ObjectModel;

namespace Pagina.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PedidoesController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Pedidoes
        public ActionResult Index(PedidosViewModel PEVM)
        {
            var usuarios = db.Users.ToList();
            var pedidos = db.Pedidos.Include(p => p.Producto).ToList();
            var productos = db.Productos.ToList();       
            PEVM.Productos = productos;
            PEVM.Pedidos = pedidos;
            PEVM.Clientes = usuarios;
            return View(PEVM);
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pedido = db.Pedidos.Include(p => p.Producto).Include(p => p.Cliente).FirstOrDefault(p => p.ID == id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Productos, "ID", "Nombre");
            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productos, "ID", "Nombre", pedido.ProductoID);
            return View(pedido);
        }

        [HttpPost]
        public ActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.Productos, "ID", "Nombre", pedido.ProductoID);
            return View(pedido);
        }


        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(IEnumerable<int> ID)
        {
            var pedidos = db.Pedidos.ToList();

            foreach (var item in pedidos)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var borrarpedido = db.Pedidos.FirstOrDefault(p => p.ID == id);
                        db.Pedidos.Remove(borrarpedido);
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
