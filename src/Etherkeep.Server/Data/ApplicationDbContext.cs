using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Etherkeep.Server.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Etherkeep.Server.Data
{
    public class ApplicationDbContext : OpenIddictDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Action> Actions { get; set; }
        public virtual DbSet<ActionParameter> ActionParameters { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityParameter> ActivityParameters { get; set; }
        public virtual DbSet<AddressBookEntry> AddressBookEntries { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<ConfigGroup> ConfigGroups { get; set; }
        public virtual DbSet<ConfigOption> ConfigOptions { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<ExternalPayment> ExternalPayments { get; set; }
        public DbSet<ExternalPaymentRequest> ExternalPaymentRequests { get; set; }
        public DbSet<ExternalPaymentSuspenseWallet> ExternalPaymentSuspenseWallets { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<MerchantInfo> MerchantInfos { get; set; }
        public DbSet<MobileNumber> MobileNumbers { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationParameter> NotificationParameters { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentSuspenseWallet> PaymentSuspenseWallets { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SettingGroup> SettingGroups { get; set; }
        public virtual DbSet<SettingOption> SettingOptions { get; set; }
        public virtual DbSet<SuspenseWallet> SuspenseWallets { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual new DbSet<User> Users { get; set; }
        public DbSet<UserPrimaryEmailAddress> UserPrimaryEmailAddresses { get; set; }
        public DbSet<UserPrimaryMobileNumber> UserPrimaryMobileNumbers { get; set; }
        public DbSet<UserPrimaryWallet> UserPrimaryWallets { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletAddress> WalletAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasPostgresExtension("uuid-ossp");

            builder.Entity<Entities.Action>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Actions).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Parameters).WithOne(e => e.Action).HasForeignKey(e => e.ActionId);
            });

            builder.Entity<ActionParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Action).WithMany(e => e.Parameters).HasForeignKey(e => e.ActionId);
            });

            builder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Activities).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Parameters).WithOne(e => e.Activity).HasForeignKey(e => e.ActivityId);
            });

            builder.Entity<ActivityParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Activity).WithMany(e => e.Parameters).HasForeignKey(e => e.ActivityId);
            });

            builder.Entity<AddressBookEntry>(entity => {
                entity.HasKey(e => e.Name);
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
                entity.HasMany(e => e.Fees).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.Payments).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.PaymentRequests).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.ExternalPayments).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
                entity.HasMany(e => e.ExternalPayments).WithOne(e => e.Currency).HasForeignKey(e => e.CurrencyCode);
            });

            builder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Devices).HasForeignKey(e => e.UserId);
            });

            builder.Entity<EmailAddress>(entity =>
            {
                entity.HasKey(e => e.Address);

                entity.HasOne(e => e.User).WithMany(e => e.EmailAddresses).HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.PrimaryEmailAddress).WithOne(e => e.EmailAddress).HasPrincipalKey<UserPrimaryEmailAddress>(e => e.Address);
            });

            builder.Entity<ExternalPayment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Sender).WithMany(e => e.SentExternalPayments).HasForeignKey(e => e.SenderId);
                entity.HasOne(e => e.Payment).WithOne(e => e.ExternalPayment).HasPrincipalKey<Payment>(e => e.ExternalPaymentId).IsRequired(false);
                entity.HasOne(e => e.SuspenseWallet).WithOne(e => e.ExternalPayment).HasForeignKey<ExternalPaymentSuspenseWallet>(e => e.ExternalPaymentId);
            });

            builder.Entity<ExternalPaymentRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Sender).WithMany(e => e.SentExternalPaymentRequests).HasForeignKey(e => e.SenderId);
                entity.HasOne(e => e.PaymentRequest).WithOne(e => e.ExternalPaymentRequest).HasPrincipalKey<PaymentRequest>(e => e.ExternalPaymentRequestId).IsRequired(false);
            });

            builder.Entity<ExternalPaymentSuspenseWallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.ExternalPaymentId);
                entity.HasOne(e => e.ExternalPayment).WithOne(e => e.SuspenseWallet).HasForeignKey<ExternalPaymentSuspenseWallet>(e => e.ExternalPaymentId);
            });

            builder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Currency).WithMany(e => e.Fees).HasForeignKey(e => e.CurrencyCode);
            });

            builder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Payments).WithOne(e => e.Invoice).HasForeignKey(e => e.InvoiceId).IsRequired(false);
            });

            builder.Entity<LoginAttempt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Country).WithMany(e => e.LoginAttempts).HasForeignKey(e => e.CountryCode);
            });

            builder.Entity<MerchantInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User).WithOne(e => e.MerchantInfo).HasPrincipalKey<MerchantInfo>(e => e.UserId);
            });

            builder.Entity<MobileNumber>(entity =>
            {
                entity.HasKey(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });

                entity.HasOne(e => e.User).WithMany(e => e.MobileNumbers).HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.PrimaryMobileNumber).WithOne(e => e.MobileNumber).HasPrincipalKey<UserPrimaryMobileNumber>(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
            });

            builder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Notifications).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Parameters).WithOne(e => e.Notification).HasForeignKey(e => e.NotificationId);
            });

            builder.Entity<NotificationParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Notification).WithMany(e => e.Parameters).HasForeignKey(e => e.NotificationId);
            });

            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Sender).WithMany(e => e.SentPayments).HasForeignKey(e => e.SenderId);
                entity.HasOne(e => e.Receiver).WithMany(e => e.ReceivedPayments).HasForeignKey(e => e.ReceiverId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Currency).WithMany(e => e.Payments).HasForeignKey(e => e.CurrencyCode);
                entity.HasOne(e => e.ExternalPayment).WithOne(e => e.Payment).HasPrincipalKey<Payment>(e => e.ExternalPaymentId).IsRequired(false);
                entity.HasOne(e => e.PaymentRequest).WithOne(e => e.Payment).HasPrincipalKey<Payment>(e => e.PaymentRequestId).IsRequired(false);
                entity.HasOne(e => e.Invoice).WithMany(e => e.Payments).HasForeignKey(e => e.InvoiceId).IsRequired(false);
                entity.HasOne(e => e.SuspenseWallet).WithOne(e => e.Payment).HasForeignKey<PaymentSuspenseWallet>(e => e.PaymentId);
            });

            builder.Entity<PaymentRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Sender).WithMany(e => e.SentPaymentRequests).HasForeignKey(e => e.SenderId);
                entity.HasOne(e => e.Receiver).WithMany(e => e.ReceivedPaymentRequests).HasForeignKey(e => e.ReceiverId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Currency).WithMany(e => e.PaymentRequests).HasForeignKey(e => e.CurrencyCode);
                entity.HasOne(e => e.ExternalPaymentRequest).WithOne(e => e.PaymentRequest).HasPrincipalKey<PaymentRequest>(e => e.ExternalPaymentRequestId).IsRequired(false);
                entity.HasOne(e => e.Payment).WithOne(e => e.PaymentRequest).HasPrincipalKey<Payment>(e => e.PaymentRequestId).IsRequired(false);
            });

            builder.Entity<PaymentSuspenseWallet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.PaymentId);
                entity.HasOne(e => e.Payment).WithOne(e => e.SuspenseWallet).HasForeignKey<PaymentSuspenseWallet>(e => e.PaymentId);
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
            });

            builder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Actions).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Activities).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.OwnedContacts).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SubjectContacts).WithOne(e => e.Subject).HasForeignKey(e => e.ContactId);
                entity.HasMany(e => e.Devices).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.LoginAttempts).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Notifications).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.UserSettings).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Wallets).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.MobileNumbers).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.EmailAddresses).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.SentPayments).WithOne(e => e.Sender).HasForeignKey(e => e.SenderId);
                entity.HasMany(e => e.ReceivedPayments).WithOne(e => e.Receiver).HasForeignKey(e => e.ReceiverId);
                entity.HasMany(e => e.SentPaymentRequests).WithOne(e => e.Sender).HasForeignKey(e => e.SenderId);
                entity.HasMany(e => e.ReceivedPaymentRequests).WithOne(e => e.Receiver).HasForeignKey(e => e.ReceiverId);
                entity.HasMany(e => e.SentExternalPayments).WithOne(e => e.Sender).HasForeignKey(e => e.SenderId);
                entity.HasMany(e => e.SentExternalPaymentRequests).WithOne(e => e.Sender).HasForeignKey(e => e.SenderId);

                entity.HasOne(e => e.PrimaryEmailAddress).WithOne(e => e.User).HasForeignKey<UserPrimaryEmailAddress>(e => e.UserId);
                entity.HasOne(e => e.PrimaryMobileNumber).WithOne(e => e.User).HasForeignKey<UserPrimaryMobileNumber>(e => e.UserId);
                entity.HasOne(e => e.PrimaryWallet).WithOne(e => e.User).HasForeignKey<UserPrimaryWallet>(e => e.UserId);
                entity.HasOne(e => e.MerchantInfo).WithOne(e => e.User).HasPrincipalKey<MerchantInfo>(e => e.UserId);
            });

            builder.Entity<UserPrimaryEmailAddress>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasOne(e => e.User).WithOne(e => e.PrimaryEmailAddress).HasForeignKey<UserPrimaryEmailAddress>(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.EmailAddress).WithOne(e => e.PrimaryEmailAddress).HasForeignKey<UserPrimaryEmailAddress>(e => e.Address);
            });

            builder.Entity<UserPrimaryMobileNumber>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasOne(e => e.User).WithOne(e => e.PrimaryMobileNumber).HasForeignKey<UserPrimaryMobileNumber>(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.MobileNumber).WithOne(e => e.PrimaryMobileNumber).HasForeignKey<UserPrimaryMobileNumber>(e => new { e.CountryCallingCode, e.AreaCode, e.SubscriberNumber });
            });

            builder.Entity<UserPrimaryWallet>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasOne(e => e.User).WithOne(e => e.PrimaryWallet).HasForeignKey<UserPrimaryWallet>(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Wallet).WithOne(e => e.PrimaryWallet).HasForeignKey<UserPrimaryWallet>(e => e.WalletId);
            });

            builder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(e => e.UserSettings).HasForeignKey(e => e.UserId);
            });

            builder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User).WithMany(e => e.Wallets).HasForeignKey(e => e.UserId);
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
