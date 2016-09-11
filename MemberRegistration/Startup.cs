using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemberRegistration.Startup))]
namespace MemberRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
