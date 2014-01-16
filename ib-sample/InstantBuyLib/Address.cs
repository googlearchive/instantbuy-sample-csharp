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

