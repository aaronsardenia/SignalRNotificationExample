# SignalRNotificationExample with sqldependency to detect database onchange
Example of SignalR Push Notification with Asynchronous 

#### Take note that the project is not executable as there are error. Objective of this repo is to serve as a documentation ##

## Step of implementation

1. add assembly at web.config 

```c#
  <!--include in startup.cs-->
    <add key="owin:appStartup" value="NotificationTest.Startup" />
```

2. add sqldependency to global.asax to detect change when application start
```c#
   protected void Application_Start(object sender, EventArgs e)
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }
```
3. add NotificationComponent to session_start in global.asax

4. Override IUserIdProvider to supply custom id mapping to connection for hub for usage of server call to specific user.

e.g 
```c#
   context.Clients.Client(userId).displayStatus("sending b from hub to specific client..");
```

5. Register hub to startup.cs
```c#
   //register signalR for mapping custom id to connection
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new CustomUserIdProvider());
            app.MapSignalR();
```
6. inherit hub class to use. check documentation
6. Completed server side configuration

## Client side documentation

1. Connect to hub
```c#
    var notificationHub = $.connection.notificationHub;

```
2. to send query string . do
```c#
  hub.qs = { 'id': id };
```
#### 3. invoking client from server side hub. 

e.g server side
```c#

 public void notify(string userId)
        {
        
        }
```


e.g client side
```javascript
  notificationHub.client.notify = function (message) {
  //things to do here. message = server side parameter. which is userId
  
  }
```






# Appendix

[SignalR Websocket Realtime Notification](https://techbrij.com/database-change-notifications-asp-net-signalr-sqldependency) 

[SignalR specific user](https://books.google.com.sg/books?id=hddnAwAAQBAJ&pg=PT352&lpg=PT352&dq=signalr+iuseridprovider+querystring+not+working&source=bl&ots=Qls0h00X77&sig=ACfU3U3UBBVQDab6-DthFctv02cyi0onmw&hl=en&sa=X&ved=2ahUKEwjEru7_r_7hAhVYk3AKHbzzBMIQ6AEwB3oECAkQAQ#v=onepage&q=signalr%20iuseridprovider%20querystring%20not%20working&f=false)

