using System;
using System.Collections;

namespace InstantBuyLibrary
{
  /**
   * This class represents the wallet Pay object for both JWT requests and responses.
   * For requests estimatedTotalPrice and CurrencyCode are defined.
   * For responses the JWT response is deserialized into the other fields.
   */
  public class Pay
  {
    public String estimatedTotalPrice { get; set; }

    public String currencyCode { get; set; }

    public String objectId { get; set; }

    public Int32 expirationMonth { get; set; }

    public Int32 expirationYear { get; set; }

    public IList description { get; set; }

    public Address billingAddress { get; set; }

    public Pay ()
    {
    }

    public Pay (String etp, String cur)
    {
      this.estimatedTotalPrice = etp;
      this.currencyCode = cur;
    }
  }
}

