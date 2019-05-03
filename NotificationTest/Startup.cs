using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using NotificationTest.model;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartup(typeof(NotificationTest.Startup))]
namespace NotificationTest
{
    //startup.cs application pipeline
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //register signalR for mapping custom id to connection
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new CustomUserIdProvider());
            app.MapSignalR();




            /*
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAuth(app);*/
        }
    }
}