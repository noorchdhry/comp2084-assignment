using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COMP2084_Local_Assignment1.Startup))]
namespace COMP2084_Local_Assignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
