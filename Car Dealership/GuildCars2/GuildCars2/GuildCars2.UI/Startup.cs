using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildCars2.UI.Startup))]
namespace GuildCars2.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
