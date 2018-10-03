using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TrainingSite.Startup))]
namespace TrainingSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {

            
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
