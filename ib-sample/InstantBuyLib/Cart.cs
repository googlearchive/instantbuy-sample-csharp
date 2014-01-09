using System;
using System.Collections.Generic;

namespace InstantBuyLibrary
{
  /**
   * This class is a container to represent the cart object.  It's
   * defined as part of the FullWalletRequest
   */
  public class Cart
  {
    public String totalPrice { get; set; }

    public String currencyCode { get; set; }

    public IList<LineItem> lineItems { get; set; }

    public Cart (String currency)
    {
      this.currencyCode = currency;
    }

    public void AddItem (LineItem item)
    {
      if (lineItems == null) {
        lineItems = new List<LineItem> ();
      }
      lineItems.Add (item);
      UpdateTotal (); 
    }

    private void UpdateTotal ()
    {
      Double total = 0.00;
      foreach (LineItem Item in lineItems) {
        total += Convert.ToDouble (Item.totalPrice);
      }
      this.totalPrice = total.ToString ();
    }
  }
}

