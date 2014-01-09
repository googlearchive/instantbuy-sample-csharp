using System;

namespace InstantBuyLibrary
{
  /**
   * This class represents JWT requests.  It contains WalletBody which is the main content for the request.
   */
  public class JwtRequest : Jwt
  {
    public static readonly String MASKED_WALLET = "google/wallet/online/masked/v2/request";
    public static readonly String FULL_WALLET = "google/wallet/online/full/v2/request";
    public static readonly String TRANSACTION_STATUS = "google/wallet/online/transactionstatus/v2";
    public static String AUD = "Google";

    public WalletBody request { get; set; }

    public JwtRequest (String type, String mid, WalletBody request)
    {
      this.aud = AUD;
      this.iss = mid;
      this.typ = type;
      this.iat = Convert.ToInt64 (DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds);
      this.request = request;
    }
  }
}

