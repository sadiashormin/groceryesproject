using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(grocery2.Startup))]
namespace grocery2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
