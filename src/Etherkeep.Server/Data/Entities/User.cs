using OpenIddict;
using System;
using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class User : OpenIddictUser<Guid>
    {
        public User() : base()
        {
            UserActions = new HashSet<UserAction>();
            Activities = new HashSet<Activity>();
            OwnedContacts = new HashSet<Contact>();
            SubjectContacts = new HashSet<Contact>();
            Devices = new HashSet<Device>();
            EmailAddresses = new HashSet<EmailAddress>();
            LoginAttempts = new HashSet<LoginAttempt>();
            MobileNumbers = new HashSet<MobileNumber>();
            SentNotifications = new HashSet<Notification>();
            ReceivedNotifications = new HashSet<Notification>();
            InvokedTransfers = new HashSet<Transfer>();
            TargetedTransfers = new HashSet<Transfer>();
            InvokedTransferInvitations = new HashSet<TransferInvitation>();
            TransferInvitationMessages = new HashSet<TransferInvitationMessage>();
            TransferMessages = new HashSet<TransferMessage>();
            UserSettings = new HashSet<UserSetting>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PinCode { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Contact> OwnedContacts { get; set; }
        public virtual ICollection<Contact> SubjectContacts { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }
        public virtual ICollection<MobileNumber> MobileNumbers { get; set; }
        public virtual ICollection<Notification> SentNotifications { get; set; }
        public virtual ICollection<Notification> ReceivedNotifications { get; set; }
        public virtual ICollection<Transfer> InvokedTransfers { get; set; }
        public virtual ICollection<Transfer> TargetedTransfers { get; set; }
        public virtual ICollection<TransferInvitation> InvokedTransferInvitations { get; set; }
        public virtual ICollection<TransferInvitationMessage> TransferInvitationMessages { get; set; }
        public virtual ICollection<TransferMessage> TransferMessages { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
        public virtual UserWallet UserWallet { get; set; }
        public virtual UserPrimaryEmailAddress PrimaryEmailAddress { get; set; }
        public virtual UserPrimaryMobileNumber PrimaryMobileNumber { get; set; }
    }
}
