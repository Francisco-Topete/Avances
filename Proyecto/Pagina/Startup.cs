using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pagina.Startup))]
namespace Pagina
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
