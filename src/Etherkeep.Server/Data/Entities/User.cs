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
            UserActions = new HashSet<UserAction>();
            Activities = new HashSet<Activity>();
            OwnedContacts = new HashSet<Contact>();
            SubjectContacts = new HashSet<Contact>();
            Devices = new HashSet<Device>();
            LoginAttempts = new HashSet<LoginAttempt>();
            Notifications = new HashSet<Notification>();
            SentTransfers = new HashSet<Transfer>();
            ReceivedTransfers = new HashSet<Transfer>();
            InvokedTransferInvitations = new HashSet<TransferInvitation>();
            TransferMessages = new HashSet<TransferMessage>();
            UserSettings = new HashSet<UserSetting>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Contact> OwnedContacts { get; set; }
        public virtual ICollection<Contact> SubjectContacts { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Transfer> SentTransfers { get; set; }
        public virtual ICollection<Transfer> ReceivedTransfers { get; set; }
        public virtual ICollection<TransferInvitation> InvokedTransferInvitations { get; set; }
        public virtual ICollection<TransferMessage> TransferMessages { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
