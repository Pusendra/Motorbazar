using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Motorbazar.Startup))]
namespace Motorbazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
