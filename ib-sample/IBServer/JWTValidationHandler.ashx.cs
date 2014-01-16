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
using JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBServer
{
    /// <summary>
    /// A simple JWT validation handler that ensures that the JWT is correctly 
    /// signed.
    /// </summary>
    public class JWTValidationHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            String jwt = request["jwt"];
            try
            {
                String jsonResponse = JsonWebToken.Decode(jwt, Config.getMerchantSecret(), true);
                if (jsonResponse != null)
                {
                    response.Write("true");
                }
                else
                {
                    response.Write("false");
                }
            }
            catch (Exception )
            {
                response.Write("false");
            }
            response.End();
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}