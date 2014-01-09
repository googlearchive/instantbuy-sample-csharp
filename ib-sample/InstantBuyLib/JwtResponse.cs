using System;

namespace InstantBuyLibrary
{
  /**
   * This class represents the JWT responses from Google Wallet.
   * JSON is deserialized into JwtResponses Objects.
   */
  public class JwtResponse : Jwt
  {
    public WalletBody response;
  }
}

