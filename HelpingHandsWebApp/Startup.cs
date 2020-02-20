using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpingHandsWebApp.Startup))]
namespace HelpingHandsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
