using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackOverflow.Presentation.WebApp.Startup))]
namespace StackOverflow.Presentation.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
