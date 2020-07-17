using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(finalmawjoud_nlh.Startup))]
namespace finalmawjoud_nlh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
