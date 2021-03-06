﻿using Pagina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Pagina.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Details()
        {
            var ID = User.Identity.GetUserId();

            var user = db.Users.Find(ID);
            return View(user);
        }

        [HttpPost]
        public ActionResult Details(ProfileViewModels PVM)
        {
            var ID = User.Identity.GetUserId();
            var userdb = db.Users.Find(ID);

            userdb.Name = PVM.Name;
            userdb.Description = PVM.Description;
            userdb.PhoneNumber = PVM.PhoneNumber;
            userdb.PhoneNumberConfirmed = true;
            db.SaveChanges();

            return RedirectToAction("Details");
        }

        [HttpPost]
        public ActionResult Picture(HttpPostedFileBase pic)
        {
            string path = Server.MapPath("~/Upload/");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var photo = pic.FileName;
            var userId = User.Identity.GetUserId();
            var userdb = db.Users.Find(userId);
            var dir = "";
            if (pic != null)
            {
                dir = User.Identity.Name + Path.GetExtension(photo);
                pic.SaveAs(path+dir);
            }

            userdb.Photo = dir;
            db.SaveChanges();

            return RedirectToAction("Details");
        }

        public ActionResult PaymentMethod()
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            return View(user);
        }

        public ActionResult History(OrderViewModels OVM)
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            var pedidos = db.Pedidos.Include(p => p.Producto).Where(p => p.ClienteID == ID).Where(p => p.Estado == "Comprado");

            OVM.Usuario = user;
            OVM.Pedidos = pedidos.ToList();

            return View(OVM);
        }

        public ActionResult DeleteMethod()
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);
            user.PaymentSave = false;
            user.PaymentNumber = "";
            user.PaymentName = "";
            user.PaymentMethod = "";
            user.PaymentExpDate = "";
            user.PaymentCCV = "";
            db.SaveChanges();
            return RedirectToAction("PaymentMethod");
        }
    }
}