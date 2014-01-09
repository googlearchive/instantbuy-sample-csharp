using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InstantBuyLibrary
{
  /**
   * This class represents the request and response body
   * MaskedWalletRequest
   * FullWalletRequest
   * TransactionStatusNotification
   * MaskedWalletResponse
   * FullWalletResponse
   * 
   * Generating the objects are handled by the various builders.
   */
  public class WalletBody
  {
    //Success and failure Enumeration for Transaction Status Notification
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
      SUCCESS,
      FAILURE
    }
    
    //Enumeration to define the failure reason
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Reason
    {
      BAD_CVC,
      BAD_CARD,
      DECLINED,
      OTHER
    }

    //Abstract generic builder base class
    public abstract class Builder<T>
    {
      public String googleTransactionId = null;
      public String merchantTransactionId = null;
      public String clientId = null;
      public String merchantName = null;
      public String origin = null;
      public String email = null;

      public abstract T Self ();

      public T GoogleTransactionId (String googleTransactionId)
      {
        this.googleTransactionId = googleTransactionId;
        return Self ();
      }

      public T MerchantTransactionId (String merchantTransactionId)
      {
        this.merchantTransactionId = merchantTransactionId;
        return Self ();
      }

      public T ClientId (String clientId)
      {
        this.clientId = clientId;
        return Self ();
      }

      public T MerchantName (String merchantName)
      {
        this.merchantName = merchantName;
        return Self ();
      }

      public T Origin (String origin)
      {
        this.origin = origin;
        return Self ();
      }

      public T Email (String email)
      {
        this.email = email;
        return Self ();
      }

    }

    /**
     * Builder to generate a MaskedWalletRequest
     */
    public class MaskedWalletBuilder : Builder<MaskedWalletBuilder>
    {
      public Pay pay = null;
      public Ship ship = null;
      public Boolean phoneNumberRequired = false;

      public override MaskedWalletBuilder Self ()
      {
        return this;
      }

      public MaskedWalletBuilder Pay (Pay pay)
      {
        this.pay = pay;
        return this;
      }
      
      public MaskedWalletBuilder Ship (Ship ship)
      {
        this.ship = ship;
        return this;
      }
      
      public MaskedWalletBuilder PhoneNumberRequired (Boolean phoneNumberRequired)
      {
        this.phoneNumberRequired = phoneNumberRequired;
        return this;
      }

      public WalletBody Build ()
      {
        return new WalletBody (this);
      }
    }

    /**
     * Builder to generate a FullWalletRequest
     */
    public class FullWalletBuilder : Builder<FullWalletBuilder>
    {
      public Cart cart = null;

      public override FullWalletBuilder Self ()
      {
        return this;
      }

      public FullWalletBuilder Cart (Cart cart)
      {
        this.cart = cart;
        return this;
      }

      public WalletBody Build ()
      {
        return new WalletBody (this);
      }
    }

    public class TransactionStatusNotificationBuilder :Builder<TransactionStatusNotificationBuilder>
    {

      public Status? status = null;
      public Reason? reason = null;
      public String detailedReason = null;

      public override TransactionStatusNotificationBuilder Self ()
      {
        return this;
      }

      public TransactionStatusNotificationBuilder Status (Status status)
      {
        this.status = status;
        return this;
      }

      public TransactionStatusNotificationBuilder Reason (Reason reason)
      {
        this.reason = reason;
        return this;
      }

      public TransactionStatusNotificationBuilder DetailedReason (String detailedReason)
      {
        this.detailedReason = detailedReason;
        return this;
      }

      public WalletBody Build ()
      {
        return new WalletBody (this);
      }
    }

    public String googleTransactionId { get; set; }

    public String merchantTransactionId { get; set; }

    public String clientId { get; set; }

    public String merchantName { get; set; }

    public String origin { get; set; }

    public String email { get; set; }

    public Cart cart { get; set; }

    public Status? status { get; set; }

    public Reason? reason { get; set; }

    public String detailedReason { get; set; }

    public Pay pay { get; set; }

    public Ship ship { get; set; }

    public Boolean phoneNumberRequired { get; set; }

    public WalletBody ()
    {
    }

    private WalletBody (MaskedWalletBuilder builder)
    {
      this.phoneNumberRequired = builder.phoneNumberRequired;
      this.pay = builder.pay;
      this.ship = builder.ship;
      this.googleTransactionId = builder.googleTransactionId;
      this.merchantTransactionId = builder.merchantTransactionId;
      this.clientId = builder.clientId;
      this.merchantName = builder.merchantName;
      this.origin = builder.origin;
      this.email = builder.email;
    }

    private WalletBody (FullWalletBuilder builder)
    {
      this.googleTransactionId = builder.googleTransactionId;
      this.merchantTransactionId = builder.merchantTransactionId;
      this.clientId = builder.clientId;
      this.merchantName = builder.merchantName;
      this.origin = builder.origin;
      this.email = builder.email;
      this.cart = builder.cart;
    }

    private WalletBody (TransactionStatusNotificationBuilder builder)
    {
      this.googleTransactionId = builder.googleTransactionId;
      this.merchantTransactionId = builder.merchantTransactionId;
      this.clientId = builder.clientId;
      this.merchantName = builder.merchantName;
      this.origin = builder.origin;
      this.email = builder.email;
      this.reason = builder.reason;
      this.status = builder.status;
      this.detailedReason = builder.detailedReason;
    }
  }
}

