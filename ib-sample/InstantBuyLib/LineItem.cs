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

