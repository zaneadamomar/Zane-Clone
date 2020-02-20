using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartupAttribute(typeof(HelpingHandsWebApp.Startup))]
namespace HelpingHandsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            ConfigureAuth(app);
        }
    }
}
