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

