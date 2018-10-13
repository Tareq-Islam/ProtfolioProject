using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFile.Startup))]
namespace WebFile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
