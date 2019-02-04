using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comp2084_assignment1.Startup))]
namespace comp2084_assignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
