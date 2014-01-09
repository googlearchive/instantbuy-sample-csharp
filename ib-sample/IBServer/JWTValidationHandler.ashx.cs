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