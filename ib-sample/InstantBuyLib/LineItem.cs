using System;

namespace InstantBuyLibrary
{
  /**
   * This class represents items in the shopping cart for the Full Wallet request.
   */
  public class LineItem
  {
    public enum Role
    {
      TAX,
      SHIPPING
    }

    public String description { get; set; }

    public Int32 quantity { get; set; }

    public String unitPrice { get; set; }

    public String totalPrice { get; set; }

    public String role { get; set; }

    public Boolean isDigital { get; set; }
    
    /**
     * Defines whether the line item is an item, tax or shipping
     *
     * If tax/shipping are not defined, then the library assumes it's an item
     */
    
    public LineItem ()
    {
    }

    public LineItem (String desc, Int32 quantity, String price)
    {
      this.description = desc;
      this.quantity = quantity;
      this.unitPrice = price;
      this.totalPrice = (quantity * Convert.ToDouble (price)).ToString ();
    }

    public LineItem (String desc, String price, Role role)
    {
      this.description = desc;
      this.totalPrice = price;
      this.role = role.ToString ();
    }

    public void setQuantity (Int32 quantity)
    {
      this.quantity = quantity;
      this.totalPrice = (quantity * Convert.ToDouble (unitPrice)).ToString ();
    }

  }
}

