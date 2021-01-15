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
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
    {
        
        readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(UserViewModel UVM)
        {
            var users = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new UserViewModel()
                                  {
                                      ID = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Role = role.Name
                                  }).ToList();

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
            var userRol = userManager.GetRoles(UVM.ID);

            if (userRol.Count > 0)
            {
                userManager.RemoveFromRoles(UVM.ID,userRol.ToArray());
                userManager.AddToRole(UVM.ID,UVM.Role);
            }
            else
            {
                userManager.AddToRole(UVM.ID, UVM.Role);
            }

            return RedirectToAction("Index");
        }

    }
}