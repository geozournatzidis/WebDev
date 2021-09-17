using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityBondGadgetCollection.Startup))]
namespace EntityBondGadgetCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
