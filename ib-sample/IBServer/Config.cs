using System;
using System.Web;
using System.Configuration;

namespace IBServer
{
    /**
     * This class handles the configuration elements for the Jwt handlers.
     */
    public class Config
    {
        public static String CURRENCY = "USD";

        private Config()
        {
        }
        // Returns the protocol://domain:port of the server
        public static String getOrigin(HttpRequest request)
        {
            String origin = string.Format("{0}://{1}{2}",
                                          request.Url.Scheme,
                                          request.Url.Host,
                                          request.Url.Port == 80
                                          ? string.Empty
                                          : ":" + request.Url.Port);

            return origin;
        }

        // Returns the merchant name
        public static String getMerchantName()
        {
            return ConfigurationManager.AppSettings["merchant_name"];
        }

        // Returns the OauthClientId
        public static String getOauthClientId()
        {
            return ConfigurationManager.AppSettings["oauth_client_id"];
        }

        // Returns the InstantBuy MerchantId
        public static String getMerchantId()
        {
            if (isSandbox())
            {
                return ConfigurationManager.AppSettings["sandbox_merchant_id"];
            }
            else if (isProduction())
            {
                return ConfigurationManager.AppSettings["production_merchant_id"];
            }
            else
            {
                return null;
            }
        }

        // Returns the InstantBy MerchantSecret
        public static String getMerchantSecret()
        {
            if (isSandbox())
            {
                return ConfigurationManager.AppSettings["sandbox_merchant_auth_key"];
            }
            else if (isProduction())
            {
                return ConfigurationManager.AppSettings["production_merchant_auth_key"];
            }
            else
            {
                return null;
            }
        }

        public static String getOauthScopes()
        {
            return isProduction() ? ConfigurationManager.AppSettings["scopes"] : 
                ConfigurationManager.AppSettings["sandbox_scopes"];
        }


        // Returns whether we are in Sandbox mode
        public static Boolean isSandbox()
        {
            return ConfigurationManager.AppSettings["environment"].Equals("SANDBOX");
        }

        // Returns whether we are in production mode
        public static Boolean isProduction()
        {
            return ConfigurationManager.AppSettings["environment"].Equals("PRODUCTION");
        }

        // Get the named cookie from the request 
        public static String getCookieValue(string name, HttpRequestBase Request)
        {
            HttpCookie cookie = Request.Cookies[name];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return null;
        }
    }
}

