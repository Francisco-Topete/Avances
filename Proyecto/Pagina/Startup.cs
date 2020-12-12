using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Pagina.Models;

[assembly: OwinStartupAttribute(typeof(Pagina.Startup))]
namespace Pagina
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // In this method we will create default User roles and Admin user for login    
       
    }
}
