using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAsyncApiTest.Startup))]
namespace WebAsyncApiTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
