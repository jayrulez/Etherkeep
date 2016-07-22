using Etherkeep.Server.Data.Enums;
using OpenIddict;
using System;
using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class User : OpenIddictUser<Guid>
    {
        public User() : base()
        {
            Actions = new HashSet<Action>();
            Activities = new HashSet<Activity>();
            OwnedContacts = new HashSet<Contact>();
            SubjectContacts = new HashSet<Contact>();
            Devices = new HashSet<Device>();
            LoginAttempts = new HashSet<LoginAttempt>();
            Notifications = new HashSet<Notification>();
            UserSettings = new HashSet<UserSetting>();
            Wallets = new HashSet<Wallet>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        public UserStatus Status { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Contact> OwnedContacts { get; set; }
        public virtual ICollection<Contact> SubjectContacts { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Payment> SentPayments { get; set; }
        public virtual ICollection<Payment> ReceivedPayments { get; set; }
        public virtual ICollection<PaymentRequest> SentPaymentRequests { get; set; }
        public virtual ICollection<PaymentRequest> ReceivedPaymentRequests { get; set; }
        public virtual ICollection<ExternalPayment> SentExternalPayments { get; set; }
        public virtual ICollection<ExternalPaymentRequest> SentExternalPaymentRequests { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
        public virtual ICollection<MobileNumber> MobileNumbers { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }

        public virtual UserPrimaryEmailAddress PrimaryEmailAddress { get; set; }
        public virtual UserPrimaryMobileNumber PrimaryMobileNumber { get; set; }
        public virtual UserPrimaryWallet PrimaryWallet { get; set; }

        public virtual MerchantInfo MerchantInfo { get; set; }
    }
}
