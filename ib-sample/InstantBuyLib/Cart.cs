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

