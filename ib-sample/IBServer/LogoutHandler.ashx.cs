/*
 * Copyright (c) 2014 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
 * in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License
 * is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions and limitations under
 * the License.
 */
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

