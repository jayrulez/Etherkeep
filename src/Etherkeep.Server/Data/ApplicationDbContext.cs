using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Etherkeep.Server.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationParam> NotificationParams { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SettingGroup> SettingGroups { get; set; }
        public virtual DbSet<SettingOption> SettingOptions { get; set; }
        public virtual DbSet<SuspenseWallet> SuspenseWallets { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<TransferFee> TransferFees { get; set; }
        public virtual DbSet<TransferInvitation> TransferInvitations { get; set; }
        public virtual DbSet<TransferMessage> TransferMessages { get; set; }
        public virtual new DbSet<User> Users { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletAddress> WalletAddresses { get; set; }

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
                entity.HasOne(e => e.User).WithMany(e => e.OwnedContacts).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Subject).WithMany(e => e.SubjectContacts).HasForeignKey(e => e.ContactId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.HasOne(e => e.Currency).WithMany(e => e.Countries).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.LoginAttempts).WithOne(e => e.Country).HasForeignKey(e => e.CountryCode);
            });

            builder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.HasMany(e => e.Countries).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.Transfers).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.TransferInvitations).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.Fees).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
            });

            builder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Devices).HasForeignKey(e => e.UserId);
            });

            builder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Currency).WithMany(e => e.Fees).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.TransferFees).WithOne(e => e.Fee).HasForeignKey(e => e.FeeId);
                entity.HasMany(e => e.TransferInvitationFees).WithOne(e => e.Fee).HasForeignKey(e => e.FeeId);
            });

            builder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<LoginAttempt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Country).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.CountryCode);
            });

            builder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.NotificationType).WithMany(e => e.Notifications).HasForeignKey(e => e.NotificationTypeId);
                entity.HasOne(e => e.User).WithMany(e => e.Notifications).HasForeignKey(e => e.UserId);
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

            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
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

            builder.Entity<SuspenseWallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.TransferInvitation).WithOne(e => e.SuspenseWallet).HasPrincipalKey<SuspenseWallet>(e => e.TransferInvitationId);
            });

            builder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Transfer).WithOne(e => e.Transaction).HasForeignKey<Transfer>(e => e.TransactionId);
            });

            builder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Transaction).WithOne(e => e.Transfer).HasPrincipalKey<Transfer>(e => e.TransactionId);
                entity.HasOne(e => e.Sender).WithMany(e => e.SentTransfers).HasForeignKey(e => e.SenderUserId);
                entity.HasOne(e => e.Receiver).WithMany(e => e.ReceivedTransfers).HasForeignKey(e => e.ReceiverUserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Currency).WithMany(e => e.Transfers).HasForeignKey(e => e.CurrencyCode);
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
                entity.HasOne(e => e.Currency).WithMany(e => e.TransferInvitations).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.TransferInvitationFees).WithOne(e => e.TransferInvitation).HasForeignKey(e => e.TransferInvitationId);
                entity.HasOne(e => e.SuspenseWallet).WithOne(e => e.TransferInvitation).HasPrincipalKey<SuspenseWallet>(e => e.TransferInvitationId);
            });

            builder.Entity<TransferInvitationFee>(entity =>
            {
                entity.HasKey(e => new { e.TransferInvitationId, e.FeeId });
                entity.HasOne(e => e.TransferInvitation).WithMany(e => e.TransferInvitationFees).HasForeignKey(e => e.TransferInvitationId);
                entity.HasOne(e => e.Fee).WithMany(e => e.TransferInvitationFees).HasForeignKey(e => e.FeeId);
            });

            builder.Entity<TransferMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Transfer).WithMany(e => e.TransferMessages).HasForeignKey(e => e.TransferId);
                entity.HasOne(e => e.User).WithMany(e => e.TransferMessages).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.UserActions).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Activities).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.OwnedContacts).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SubjectContacts).WithOne(e => e.Subject).HasForeignKey(e => e.ContactId);
                entity.HasMany(e => e.Devices).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.LoginAttempts).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Notifications).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SentTransfers).WithOne(e => e.Sender).HasForeignKey(e => e.SenderUserId);
                entity.HasMany(e => e.ReceivedTransfers).WithOne(e => e.Receiver).HasForeignKey(e => e.ReceiverUserId);
                entity.HasMany(e => e.InvokedTransferInvitations).WithOne(e => e.Invoker).HasForeignKey(e => e.InvokerUserId);
                entity.HasMany(e => e.TransferMessages).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.UserSettings).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Wallet).WithOne(e => e.User).HasPrincipalKey<Wallet>(e => e.UserId);
            });

            builder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(e => e.UserSettings).HasForeignKey(e => e.UserId);
            });

            builder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.UserId);

                entity.HasOne(e => e.User).WithOne(e => e.Wallet).HasForeignKey<Wallet>(e => e.UserId);
                entity.HasMany(e => e.WalletAddresses).WithOne(e => e.Wallet).HasForeignKey(e => e.WalletId);
            });

            builder.Entity<WalletAddress>(entity =>
            {
                entity.HasKey(e => e.Address);
                entity.HasOne(e => e.Wallet).WithMany(e => e.WalletAddresses).HasForeignKey(e => e.WalletId);
            });
        }
    }
}
