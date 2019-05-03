using Microsoft.AspNet.SignalR;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NotificationTest.model
{
    public class NotificationComponent
    {


        public void RegisterNotification(DateTime currentTime)
        {
            System.Diagnostics.Debug.WriteLine("registernotification invoked");
            //take note that select cannot include * and tablename needs [dbo] for sqldependency to work
            string sqlCommand = " SELECT columnname from[dbo].[tablename]";
            SqlConnection con = IDbConnectionhere
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Notification = null;
            SqlDependency sqlDep = new SqlDependency(cmd);


            sqlDep.OnChange += new OnChangeEventHandler(sqlDep_OnChange);

            //we must have to execute the command here
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // nothing need to add here now
            }
        }

        void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //NotificationHub.Show();

            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;
                System.Diagnostics.Debug.WriteLine("sqldep_onchange");
                //from here we will send notification message to client
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");

                //re-register notification
                RegisterNotification(DateTime.Now);

            }
        }
    }
}