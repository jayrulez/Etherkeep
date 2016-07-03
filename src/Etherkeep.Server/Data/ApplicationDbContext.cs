using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Etherkeep.Server.Data.Entities;

namespace Etherkeep.Server.Data
{
    public class ApplicationDbContext : OpenIddictDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserAction> Actions { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityParam> ActivityParams { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<ConfigGroup> ConfigGroups { get; set; }
        public virtual DbSet<ConfigOption> ConfigOptions { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }
        public virtual DbSet<MobileNumber> MobileNumbers { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationParam> NotificationParams { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SettingGroup> SettingGroups { get; set; }
        public virtual DbSet<SettingOption> SettingOptions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<TransferFee> TransferFees { get; set; }
        public virtual DbSet<TransferInvitation> TransferInvitations { get; set; }
        public virtual DbSet<TransferMessage> TransferMessages { get; set; }
        public virtual new DbSet<User> Users { get; set; }
        public virtual DbSet<UserPrimaryEmailAddress> UserPrimaryEmailAddresses { get; set; }
        public virtual DbSet<UserPrimaryMobileNumber> UserPrimaryMobileNumbers { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<UserWallet> Wallets { get; set; }
        public virtual DbSet<UserWalletAddress> WalletAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserAction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.UserActions).HasForeignKey(e => e.UserId);
            });

            builder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.ActivityType).WithMany(e => e.Activities).HasForeignKey(e => e.ActivityTypeId);
                entity.HasOne(e => e.User).WithMany(e => e.Activities).HasForeignKey(e => e.UserId);
            });

            builder.Entity<ActivityParam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Activity).WithMany(e => e.ActivityParams).HasForeignKey(e => e.ActivityId);
            });

            builder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Activities).WithOne(e => e.ActivityType).HasForeignKey(e => e.ActivityTypeId);
            });

            builder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.ConfigGroup).WithMany(e => e.Configs).HasForeignKey(e => e.ConfigGroupId);
                entity.HasMany(e => e.ConfigOptions).WithOne(e => e.Config).HasForeignKey(e => e.ConfigId);
            });

            builder.Entity<ConfigGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Configs).WithOne(e => e.ConfigGroup).HasForeignKey(e => e.ConfigGroupId);
            });

            builder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => new { e.UserId, e.ContactId });
                entity.HasOne(e => e.Owner).WithMany(e => e.OwnedContacts).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Subject).WithMany(e => e.SubjectContacts).HasForeignKey(e => e.ContactId);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.HasMany(e => e.CountryCurrencies).WithOne(e => e.Country).HasForeignKey(e => e.CountryCode);
                entity.HasMany(e => e.LoginAttempts).WithOne(e => e.Country).HasForeignKey(e => e.CountryCode);
            });

            builder.Entity<CountryCurrency>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.CurrencyCode });
                entity.HasOne(e => e.Country).WithMany(e => e.CountryCurrencies).HasForeignKey(e => e.CountryCode);
                entity.HasOne(e => e.Currency).WithMany(e => e.CountryCurrencies).HasForeignKey(e => e.CurrencyCode);
            });

            builder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.HasMany(e => e.CountryCurrencies).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.TargetTransfers).WithOne(e => e.TargetCurrency).HasForeignKey(e => e.TargetCurrencyCode);
                entity.HasMany(e => e.InvokerTransfers).WithOne(e => e.InvokerCurrency).HasForeignKey(e => e.InvokerCurrencyCode);
                entity.HasMany(e => e.TargetTransferInvitations).WithOne(e => e.TargetCurrency).HasForeignKey(e => e.TargetCurrencyCode);
                entity.HasMany(e => e.InvokerTransferInvitations).WithOne(e => e.InvokerCurrency).HasForeignKey(e => e.InvokerCurrencyCode);
                entity.HasMany(e => e.Fees).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
            });

            builder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Devices).HasForeignKey(e => e.UserId);
            });

            builder.Entity<EmailAddress>(entity =>
            {
                entity.HasKey(e => e.Address);
                entity.HasAlternateKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(e => e.EmailAddresses).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.PrimaryEmailAddress).WithOne(e => e.EmailAddress).HasPrincipalKey<UserPrimaryEmailAddress>(e => e.PrimaryEmailAddress);
            });

            builder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Currency).WithMany(e => e.Fees).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.TransferFees).WithOne(e => e.Fee).HasForeignKey(e => e.FeeId);
                entity.HasMany(e => e.TransferInvitationFees).WithOne(e => e.Fee).HasForeignKey(e => e.FeeId);
            });

            builder.Entity<LoginAttempt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Country).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.CountryCode);
            });

            builder.Entity<MobileNumber>(entity =>
            {
                entity.HasKey(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
                entity.HasAlternateKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(e => e.MobileNumbers).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.PrimaryMobileNumber).WithOne(e => e.MobileNumber).HasPrincipalKey<UserPrimaryMobileNumber>(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
            });

            builder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.NotificationType).WithMany(e => e.Notifications).HasForeignKey(e => e.NotificationTypeId);
                entity.HasOne(e => e.User).WithMany(e => e.SentNotifications).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.SubjectUser).WithMany(e => e.ReceivedNotifications).HasForeignKey(e => e.SubjectUserId);
                entity.HasMany(e => e.NotificationParams).WithOne(e => e.Notification).HasForeignKey(e => e.NotificationId);
            });

            builder.Entity<NotificationParam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Notification).WithMany(e => e.NotificationParams).HasForeignKey(e => e.NotificationId);
            });

            builder.Entity<NotificationType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Notifications).WithOne(e => e.NotificationType).HasForeignKey(e => e.NotificationTypeId);
            });

            builder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.SettingGroup).WithMany(e => e.Settings).HasForeignKey(e => e.SettingGroupId);
                entity.HasMany(e => e.SettingOptions).WithOne(e => e.Setting).HasForeignKey(e => e.SettingId);
            });

            builder.Entity<SettingGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Settings).WithOne(e => e.SettingGroup).HasForeignKey(e => e.SettingGroupId);
            });

            builder.Entity<SettingOption>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Setting).WithMany(e => e.SettingOptions).HasForeignKey(e => e.SettingId);
            });

            builder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Invoker).WithMany(e => e.InvokedTransfers).HasForeignKey(e => e.InvokerUserId);
                entity.HasOne(e => e.Target).WithMany(e => e.TargetedTransfers).HasForeignKey(e => e.TargetUserId);
                entity.HasOne(e => e.InvokerCurrency).WithMany(e => e.InvokerTransfers).HasForeignKey(e => e.InvokerCurrencyCode);
                entity.HasOne(e => e.TargetCurrency).WithMany(e => e.TargetTransfers).HasForeignKey(e => e.TargetCurrencyCode);
                entity.HasMany(e => e.TransferFees).WithOne(e => e.Transfer).HasForeignKey(e => e.TransferId);
                entity.HasMany(e => e.TransferMessages).WithOne(e => e.Transfer).HasForeignKey(e => e.TransferId);
            });

            builder.Entity<TransferFee>(entity =>
            {
                entity.HasKey(e => new { e.TransferId, e.FeeId });
                entity.HasOne(e => e.Transfer).WithMany(e => e.TransferFees).HasForeignKey(e => e.TransferId);
                entity.HasOne(e => e.Fee).WithMany(e => e.TransferFees).HasForeignKey(e => e.FeeId);
            });

            builder.Entity<TransferInvitation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Invoker).WithMany(e => e.InvokedTransferInvitations).HasForeignKey(e => e.InvokerUserId);
                entity.HasOne(e => e.InvokerCurrency).WithMany(e => e.InvokerTransferInvitations).HasForeignKey(e => e.InvokerCurrencyCode);
                entity.HasOne(e => e.TargetCurrency).WithMany(e => e.TargetTransferInvitations).HasForeignKey(e => e.TargetCurrencyCode);
                entity.HasMany(e => e.TransferInvitationFees).WithOne(e => e.TransferInvitation).HasForeignKey(e => e.TransferInvitationId);
                entity.HasMany(e => e.TransferInvitationMessages).WithOne(e => e.TransferInvitation).HasForeignKey(e => e.TransferInvitationId);
            });

            builder.Entity<TransferInvitationFee>(entity =>
            {
                entity.HasKey(e => new { e.TransferInvitationId, e.FeeId });
                entity.HasOne(e => e.TransferInvitation).WithMany(e => e.TransferInvitationFees).HasForeignKey(e => e.TransferInvitationId);
                entity.HasOne(e => e.Fee).WithMany(e => e.TransferInvitationFees).HasForeignKey(e => e.FeeId);
            });

            builder.Entity<TransferInvitationMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.TransferInvitation).WithMany(e => e.TransferInvitationMessages).HasForeignKey(e => e.TransferInvitationId);
                entity.HasOne(e => e.User).WithMany(e => e.TransferInvitationMessages).HasForeignKey(e => e.UserId);
            });

            builder.Entity<TransferMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Transfer).WithMany(e => e.TransferMessages).HasForeignKey(e => e.TransferId);
                entity.HasOne(e => e.User).WithMany(e => e.TransferMessages).HasForeignKey(e => e.UserId);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.UserActions).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Activities).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.OwnedContacts).WithOne(e => e.Owner).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SubjectContacts).WithOne(e => e.Subject).HasForeignKey(e => e.ContactId);
                entity.HasMany(e => e.Devices).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.EmailAddresses).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.LoginAttempts).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.MobileNumbers).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SentNotifications).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.ReceivedNotifications).WithOne(e => e.SubjectUser).HasForeignKey(e => e.SubjectUserId);
                entity.HasMany(e => e.InvokedTransfers).WithOne(e => e.Invoker).HasForeignKey(e => e.InvokerUserId);
                entity.HasMany(e => e.TargetedTransfers).WithOne(e => e.Target).HasForeignKey(e => e.TargetUserId);
                entity.HasMany(e => e.InvokedTransferInvitations).WithOne(e => e.Invoker).HasForeignKey(e => e.InvokerUserId);
                entity.HasMany(e => e.TransferInvitationMessages).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.TransferMessages).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.UserSettings).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.UserWallet).WithOne(e => e.User).HasPrincipalKey<UserWallet>(e => e.UserId);
                entity.HasOne(e => e.PrimaryEmailAddress).WithOne(e => e.User).HasForeignKey<UserPrimaryEmailAddress>(e => e.PrimaryEmailAddress);
                entity.HasOne(e => e.PrimaryMobileNumber).WithOne(e => e.User).HasForeignKey<UserPrimaryMobileNumber>(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
            });

            builder.Entity<UserPrimaryEmailAddress>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasAlternateKey(e => e.PrimaryEmailAddress);

                entity.HasOne(e => e.User).WithOne(e => e.PrimaryEmailAddress).HasForeignKey<UserPrimaryEmailAddress>(e => e.UserId);
                entity.HasOne(e => e.EmailAddress).WithOne(e => e.PrimaryEmailAddress).HasForeignKey<UserPrimaryEmailAddress>(e => e.PrimaryEmailAddress);
            });

            builder.Entity<UserPrimaryMobileNumber>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasAlternateKey(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });

                entity.HasOne(e => e.User).WithOne(e => e.PrimaryMobileNumber).HasForeignKey<UserPrimaryMobileNumber>(e => e.UserId);
                entity.HasOne(e => e.MobileNumber).WithOne(e => e.PrimaryMobileNumber).HasForeignKey<UserPrimaryMobileNumber>(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
            });

            builder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(e => e.UserSettings).HasForeignKey(e => e.UserId);
            });

            builder.Entity<UserWallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.UserId);

                entity.HasOne(e => e.User).WithOne(e => e.UserWallet).HasForeignKey<UserWallet>(e => e.UserId);
                entity.HasMany(e => e.UserWalletAddresses).WithOne(e => e.UserWallet).HasForeignKey(e => e.WalletId);
            });

            builder.Entity<UserWalletAddress>(entity =>
            {
                entity.HasKey(e => e.Address);
                entity.HasOne(e => e.UserWallet).WithMany(e => e.UserWalletAddresses).HasForeignKey(e => e.WalletId);
            });
        }
    }
}
