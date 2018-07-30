using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comeagua.Startup))]
namespace comeagua
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
