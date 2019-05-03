using NotificationTest.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NotificationTest
{
    public class Global : System.Web.HttpApplication
    {
        //string con = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["conString"]].ConnectionString;

        protected void Application_Start(object sender, EventArgs e)
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            NotificationComponent NC = new NotificationComponent();

            var currentTime = DateTime.Now;


            //passing currentTime in can be used to track notification recieved at specific time
            NC.RegisterNotification(currentTime);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }
    }
}