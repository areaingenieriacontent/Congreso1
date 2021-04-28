using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Congreso_1.Startup))]
namespace Congreso_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
