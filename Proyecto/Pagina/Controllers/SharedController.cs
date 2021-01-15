using Microsoft.AspNet.Identity;
using Pagina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina.Controllers
{
    public class SharedController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: LoginPartial
        [ChildActionOnly]
        public ActionResult _LoginPartial()
        {
            var ID = User.Identity.GetUserId();
            var user = db.Users.Find(ID);

            return PartialView(user);
        }
    }
}