using System;

namespace InstantBuyLibrary
{
  public class Ship
  {
    /**
     * Represents the ShippingAddress object.
     * You must create an empty ShippingAddress object if you want a shipping address returned in
     * the Masked Wallet Response.
     */
    public String objectId { get; set; }

    public Address shippingAddress { get; set; }

    public Ship ()
    {
    }
  }
}

