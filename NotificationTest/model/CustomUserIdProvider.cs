using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationTest.model
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            System.Diagnostics.Debug.WriteLine("Mapping:" + User.getUserId());
            System.Diagnostics.Debug.WriteLine("Mapping:" + request.QueryString["id"]);
            /*
            return request == null
         ? throw new ArgumentNullException(nameof(request))
         : User.getUserId();*/


            return request.QueryString["id"];
            //return id.ToString();
        }
    }
}