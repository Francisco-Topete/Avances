using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pagina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina.Controllers
{
    public class RolesController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult AddRoles(string id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult AddRoles(UserViewModel UVM)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userRol = userManager.GetRoles(UVM.UserId);

            if (userRol.Count > 0)
            {
                userManager.RemoveFromRoles(UVM.UserId,userRol.ToArray());
                userManager.AddToRole(UVM.UserId,UVM.UserRol);
            }
            else
            {
                userManager.AddToRole(UVM.UserId, UVM.UserRol);
            }

            return RedirectToAction("Index");
        }

    }
}