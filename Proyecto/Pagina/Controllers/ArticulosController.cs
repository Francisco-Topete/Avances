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
    public class ArticulosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articulos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Gema).Include(p => p.Tipo);
            return View(productos.ToList());
        }
    }
}