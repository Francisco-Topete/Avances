using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pagina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Clases
{
    public class Utility
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string rol)
        {
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!role.RoleExists(rol))
            {
                role.Create(new IdentityRole(rol));
            }
        }

        internal static void CheckSuperUser()
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermanager.FindByEmail("superuser@hotmail.com");

            if (user==null)
            {
                CreateSuperUser("superuser@hotmail.com", "desarrolloweb1", null, "Administrador");
            }
        }

        private static void CreateSuperUser(string email, string password, string telefono, string rol)
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                PhoneNumber = telefono
            };

            usermanager.Create(user,password);
            usermanager.AddToRole(user.Id,rol);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}