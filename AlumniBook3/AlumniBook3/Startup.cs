using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlumniBook3.Startup))]
namespace AlumniBook3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
