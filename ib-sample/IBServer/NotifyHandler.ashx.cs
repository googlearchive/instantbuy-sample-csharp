
using System;
using System.Web;
using System.Web.UI;
using System.IO;
using JWT;
using Newtonsoft.Json;
using InstantBuyLibrary;

namespace IBServer
{
    public class NotifyHandler : System.Web.IHttpHandler
    {

        public class Request
        {
            public String jwt;
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public virtual void ProcessRequest(HttpContext context)
        {

            String googleTransactionId = context.Request["gid"];
            //Create Transaction Status Notification body
            WalletBody tsb = new WalletBody.TransactionStatusNotificationBuilder()
                .GoogleTransactionId(googleTransactionId)
                .ClientId(Config.getOauthClientId())
                .MerchantName(Config.getMerchantName())
                .Origin(Config.getOrigin(context.Request))
                .Status(WalletBody.Status.SUCCESS)
                .Build();

            //Create Transaction Status Notification object
            JwtRequest tsn = new JwtRequest(JwtRequest.TRANSACTION_STATUS, Config.getMerchantId(), tsb);

            tsn.exp = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds) + 60000L;

            //Convert the JwtRequest object to a string
            String transactionStatusJwt = 
                JsonWebToken.Encode(tsn, Config.getMerchantSecret(), JwtHashAlgorithm.HS256);

            context.Response.Write(transactionStatusJwt);
        }
    }
}

