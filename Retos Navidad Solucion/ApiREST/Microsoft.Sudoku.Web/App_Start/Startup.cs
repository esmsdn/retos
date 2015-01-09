using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Microsoft.Sudoku.Web.App_Start.Startup))]

namespace Microsoft.Sudoku.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            app.MapSignalR(new HubConfiguration()
            {
                EnableDetailedErrors = true
            });
        }
    }
}
