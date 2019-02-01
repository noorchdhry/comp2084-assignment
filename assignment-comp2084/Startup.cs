using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(assignment_comp2084.Startup))]
namespace assignment_comp2084
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
