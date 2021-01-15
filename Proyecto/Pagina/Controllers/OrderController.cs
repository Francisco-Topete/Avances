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
    [Authorize]
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Order
        public ActionResult Index(int? id)
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
        public ActionResult Encargo(int? idp, HttpPostedFileBase amount)
        {
            var userid = User.Identity.GetUserId();
            var producto = db.Productos.Include(p => p.Gema).Include(p => p.Tipo).FirstOrDefault(p => p.ID == idp);
            Pedido pedido = new Pedido();
            pedido.ProductoID = producto.ID;
            pedido.ClienteID = userid;
            pedido.Total = producto.Precio;
            pedido.Estado = "En carro";

            db.Pedidos.Add(pedido);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = idp});
        }

        public ActionResult BorrarEncargo(int idpedido)
        {
            Pedido pedido = db.Pedidos.Find(idpedido);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("ShoppingCart");
        }

        public ActionResult ShoppingCart(OrderViewModels OVM)
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            var pedidos = db.Pedidos.Include(p => p.Producto).Where(p => p.ClienteID == ID).Where(p => p.Estado == "En carro");

            OVM.Usuario = user;
            OVM.Pedidos = pedidos.ToList();

            return View(OVM);
        }

        public ActionResult Payment()
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);

            if (user.PaymentSave == true)
            {
                var pedidos = db.Pedidos.Include(p => p.Producto).Where(p => p.ClienteID == ID).Where(p => p.Estado == "En carro").ToList();

                db.SaveChanges();
                return RedirectToAction("PaymentComplete");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Payment(PaymentViewModels PVM)
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            var pedidos = db.Pedidos.Include(p => p.Producto).Where(p => p.ClienteID == ID).Where(p => p.Estado == "En carro").ToList();

            user.Address = PVM.Address;
            user.Country = PVM.Country;
            user.State = PVM.State;
            user.ZipCode = PVM.Zip;
            user.PaymentName = PVM.PaymentName;
            user.PaymentNumber = PVM.PaymentNumber;
            user.PaymentExpDate = PVM.PaymentExpDate;
            user.PaymentCCV = PVM.PaymentCCV;
            user.PaymentMethod = PVM.PaymentMethod;
            user.PaymentSave = PVM.PaymentSave;

            db.SaveChanges();

            return RedirectToAction("PaymentComplete");
        }

        public ActionResult PaymentComplete(OrderViewModels OVM)
        {          
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            var pedidos = db.Pedidos.Include(p => p.Producto).Where(p => p.ClienteID == ID).Where(p => p.Estado == "En carro").ToList();

            OVM.Usuario = user;
            OVM.Pedidos = pedidos.ToList();

            foreach (var item in pedidos)
            {
                Pedido pedido = db.Pedidos.Find(item.ID);
                pedido.Estado = "Comprado";
            }

            db.SaveChanges();

            return View(OVM);
        }
    }
}