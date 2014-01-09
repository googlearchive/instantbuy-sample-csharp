
using System;
using System.Web;
using System.Web.UI;
using System.IO;
using JWT;
using Newtonsoft.Json;
using InstantBuyLibrary;

namespace IBServer
{
    public class LogoutHandler : System.Web.IHttpHandler
    {

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public virtual void ProcessRequest(HttpContext context)
        {
            if (context.Session != null)
            {
                context.Session.Clear();
                context.Session.Abandon();  
            }
            // Remove all cookies
            int count = context.Request.Cookies.Count;

            for (int i = 0; i < count; i++)
            {
                HttpCookie cookie = context.Request.Cookies[i];
                cookie.Expires = DateTime.Now.AddDays(-1d);
                context.Response.Cookies.Set(cookie);
            }
            // Redirect to "/"
            context.Response.Redirect("/");
        }
    }
}

