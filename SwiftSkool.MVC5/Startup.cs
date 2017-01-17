using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SwiftSkool.MVC5.Startup))]
namespace SwiftSkool.MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
