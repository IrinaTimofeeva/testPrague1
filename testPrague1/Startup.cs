using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testPrague1.Startup))]
namespace testPrague1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
