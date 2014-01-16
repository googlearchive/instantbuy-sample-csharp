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

