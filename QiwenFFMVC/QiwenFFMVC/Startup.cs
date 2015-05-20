using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QiwenFFMVC.Startup))]
namespace QiwenFFMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
