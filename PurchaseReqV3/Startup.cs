using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurchaseReqV3.Startup))]
namespace PurchaseReqV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
