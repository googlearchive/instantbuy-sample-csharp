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

