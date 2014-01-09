using System;

namespace InstantBuyLibrary
{
  /**
   * This class is a container to represent the Address object.
   * 
   * The address is returned in the Masked Wallet and Full Wallet responses.
   */
  public class Address
  {
    public String name { get; set; }

    public String address1 { get; set; }

    public String address2 { get; set; }

    public String address3 { get; set; }

    public String countryCode { get; set; }

    public String city { get; set; }

    public String state { get; set; }

    public String postalCode { get; set; }

    public String phoneNumber { get; set; }

    public Boolean postBox { get; set; }

    public String companyName { get; set; }

    public Address ()
    {
    }
  }
}

