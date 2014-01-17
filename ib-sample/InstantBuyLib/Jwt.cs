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
   * This class reprsents the base class for JWT request and responses.
   */
  public abstract class Jwt
  {
    public String iss { get; set; }

    public String aud { get; set; }

    public String typ { get; set; }

    public long iat { get; set; }

    public long exp { get; set; }
  }
}

