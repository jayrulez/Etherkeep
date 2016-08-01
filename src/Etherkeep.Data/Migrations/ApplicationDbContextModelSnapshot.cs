using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Etherkeep.Data;

namespace Etherkeep.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Etherkeep.Data.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityType");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ActivityParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityParameters");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.AddressBookEntry", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("AddressBookEntries");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Config", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConfigGroupId");

                    b.Property<string>("ConfigType");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ConfigGroupId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ConfigGroup", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ConfigGroups");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ConfigOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfigId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.ToTable("ConfigOptions");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<DateTime>("LastActivity");

                    b.Property<int>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "ContactId");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Country", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Currency", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<int>("Precision");

                    b.Property<string>("Symbol");

                    b.Property<string>("Template");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Device", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Token");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.EmailAddress", b =>
                {
                    b.Property<string>("Address");

                    b.Property<Guid>("UserId");

                    b.Property<bool>("Verified");

                    b.HasKey("Address");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CurrencyCode");

                    b.Property<double>("ExchangeRate");

                    b.Property<double>("Fee");

                    b.Property<int?>("PaymentExternalPaymentId");

                    b.Property<string>("Receiver");

                    b.Property<int>("ReceiverType");

                    b.Property<Guid>("SenderId");

                    b.Property<int>("Status");

                    b.Property<double>("Tokens");

                    b.Property<double>("Total");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("PaymentExternalPaymentId")
                        .IsUnique();

                    b.HasIndex("SenderId");

                    b.ToTable("ExternalPayments");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPaymentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CurrencyCode");

                    b.Property<int?>("PaymentRequestExternalPaymentRequestId");

                    b.Property<string>("Receiver");

                    b.Property<int>("ReceiverType");

                    b.Property<Guid>("SenderId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("PaymentRequestExternalPaymentRequestId")
                        .IsUnique();

                    b.HasIndex("SenderId");

                    b.ToTable("ExternalPaymentRequests");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPaymentSuspenseWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<int>("ExternalPaymentId");

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalPaymentId");

                    b.HasIndex("ExternalPaymentId")
                        .IsUnique();

                    b.ToTable("ExternalPaymentSuspenseWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Fee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyCode");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<double>("RangeEnd");

                    b.Property<double>("RangeStart");

                    b.Property<int>("Type");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WalletAddress");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.LoginAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<string>("GeoLocation");

                    b.Property<string>("IpAddress");

                    b.Property<int>("Status");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode");

                    b.HasIndex("UserId");

                    b.ToTable("LoginAttempts");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Merchant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CurrencyCode");

                    b.Property<int>("MerchantId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantBills");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.Property<int>("MerchantId");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantWalletAddress", b =>
                {
                    b.Property<string>("Address");

                    b.Property<double>("Balance");

                    b.Property<string>("WalletId");

                    b.HasKey("Address");

                    b.HasIndex("WalletId");

                    b.ToTable("MerchantWalletAddresses");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MobileNumber", b =>
                {
                    b.Property<string>("CountryCallingCode");

                    b.Property<string>("AreaCode");

                    b.Property<string>("SubscriberNumber");

                    b.Property<Guid>("UserId");

                    b.Property<bool>("Verified");

                    b.HasKey("CountryCallingCode", "AreaCode", "SubscriberNumber");

                    b.HasIndex("UserId");

                    b.ToTable("MobileNumbers");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("NotificationType");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.NotificationParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NotificationId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.ToTable("NotificationParameters");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CurrencyCode");

                    b.Property<double>("ExchangeRate");

                    b.Property<int?>("ExternalPaymentId")
                        .IsRequired();

                    b.Property<double>("Fee");

                    b.Property<int?>("InvoiceId");

                    b.Property<int?>("MerchantBillId");

                    b.Property<int?>("PaymentRequestId")
                        .IsRequired();

                    b.Property<Guid>("ReceiverId");

                    b.Property<Guid>("SenderId");

                    b.Property<int>("Status");

                    b.Property<double>("Tokens");

                    b.Property<double>("Total");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("MerchantBillId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.PaymentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CurrencyCode");

                    b.Property<int?>("ExternalPaymentRequestId")
                        .IsRequired();

                    b.Property<int?>("PaymentRequestId");

                    b.Property<Guid>("ReceiverId");

                    b.Property<Guid>("SenderId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode");

                    b.HasIndex("PaymentRequestId")
                        .IsUnique();

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("PaymentRequests");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.PaymentSuspenseWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.Property<int>("PaymentId");

                    b.HasKey("Id");

                    b.HasAlternateKey("PaymentId");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("PaymentSuspenseWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Setting", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("SettingGroupId");

                    b.Property<string>("SettingType");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SettingGroupId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.SettingGroup", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SettingGroups");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.SettingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SettingId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SettingId");

                    b.ToTable("SettingOptions");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.SuspenseWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("SuspenseWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Confirmations");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Hash");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionType");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserActions");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserActionParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("UserActionParameters");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryEmailAddress", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasAlternateKey("Address");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPrimaryEmailAddresses");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryMobileNumber", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("AreaCode")
                        .IsRequired();

                    b.Property<string>("CountryCallingCode")
                        .IsRequired();

                    b.Property<string>("SubscriberNumber")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasAlternateKey("CountryCallingCode", "AreaCode", "SubscriberNumber");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("CountryCallingCode", "AreaCode", "SubscriberNumber")
                        .IsUnique();

                    b.ToTable("UserPrimaryMobileNumbers");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryWallet", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("WalletId");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("WalletId")
                        .IsUnique();

                    b.ToTable("UserPrimaryWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserSetting", b =>
                {
                    b.Property<Guid>("UserId");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Data");

                    b.Property<string>("Label");

                    b.Property<string>("Passphrase");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserWallets");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserWalletAddress", b =>
                {
                    b.Property<string>("Address");

                    b.Property<double>("Balance");

                    b.Property<string>("WalletId");

                    b.HasKey("Address");

                    b.HasIndex("WalletId");

                    b.ToTable("UserWalletAddresses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictApplication<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId");

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LogoutRedirectUri");

                    b.Property<string>("RedirectUri");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Scope");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictScope<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ApplicationId");

                    b.Property<Guid?>("AuthorizationId");

                    b.Property<string>("Type");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("UserId");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Activity", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ActivityParameter", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Activity", "Activity")
                        .WithMany("Parameters")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Config", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.ConfigGroup", "ConfigGroup")
                        .WithMany("Configs")
                        .HasForeignKey("ConfigGroupId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ConfigOption", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Config", "Config")
                        .WithMany("ConfigOptions")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Contact", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "Subject")
                        .WithMany("SubjectContacts")
                        .HasForeignKey("ContactId");

                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("OwnedContacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Country", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CurrencyCode");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Device", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.EmailAddress", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPayment", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("ExternalPayments")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Data.Entities.Payment", "Payment")
                        .WithOne("ExternalPayment")
                        .HasForeignKey("Etherkeep.Data.Entities.ExternalPayment", "PaymentExternalPaymentId")
                        .HasPrincipalKey("Etherkeep.Data.Entities.Payment", "ExternalPaymentId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Sender")
                        .WithMany("SentExternalPayments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPaymentRequest", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("ExternalPaymentRequests")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Data.Entities.PaymentRequest", "PaymentRequest")
                        .WithOne("ExternalPaymentRequest")
                        .HasForeignKey("Etherkeep.Data.Entities.ExternalPaymentRequest", "PaymentRequestExternalPaymentRequestId")
                        .HasPrincipalKey("Etherkeep.Data.Entities.PaymentRequest", "ExternalPaymentRequestId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Sender")
                        .WithMany("SentExternalPaymentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.ExternalPaymentSuspenseWallet", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.ExternalPayment", "ExternalPayment")
                        .WithOne("SuspenseWallet")
                        .HasForeignKey("Etherkeep.Data.Entities.ExternalPaymentSuspenseWallet", "ExternalPaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Fee", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("Fees")
                        .HasForeignKey("CurrencyCode");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.LoginAttempt", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Country", "Country")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("CountryCode");

                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Merchant", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Merchants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantBill", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.MerchantWalletAddress", "WalletAddress")
                        .WithOne("MerchantBill")
                        .HasForeignKey("Etherkeep.Data.Entities.MerchantBill", "Address");

                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("MerchantBills")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Data.Entities.Merchant", "Merchant")
                        .WithMany("Bills")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantWallet", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Merchant", "Merchant")
                        .WithMany("Wallets")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MerchantWalletAddress", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.MerchantWallet", "Wallet")
                        .WithMany("WalletAddresses")
                        .HasForeignKey("WalletId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.MobileNumber", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("MobileNumbers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Notification", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.NotificationParameter", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Notification", "Notification")
                        .WithMany("Parameters")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Payment", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("Payments")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Data.Entities.Invoice", "Invoice")
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Etherkeep.Data.Entities.MerchantBill", "MerchantBill")
                        .WithMany("Payments")
                        .HasForeignKey("MerchantBillId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Receiver")
                        .WithMany("ReceivedPayments")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Sender")
                        .WithMany("SentPayments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.PaymentRequest", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Currency", "Currency")
                        .WithMany("PaymentRequests")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Data.Entities.Payment", "Payment")
                        .WithOne("PaymentRequest")
                        .HasForeignKey("Etherkeep.Data.Entities.PaymentRequest", "PaymentRequestId")
                        .HasPrincipalKey("Etherkeep.Data.Entities.Payment", "PaymentRequestId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Receiver")
                        .WithMany("ReceivedPaymentRequests")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Etherkeep.Data.Entities.User", "Sender")
                        .WithMany("SentPaymentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.PaymentSuspenseWallet", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Payment", "Payment")
                        .WithOne("SuspenseWallet")
                        .HasForeignKey("Etherkeep.Data.Entities.PaymentSuspenseWallet", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.Setting", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.SettingGroup", "SettingGroup")
                        .WithMany("Settings")
                        .HasForeignKey("SettingGroupId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.SettingOption", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.Setting", "Setting")
                        .WithMany("SettingOptions")
                        .HasForeignKey("SettingId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserAction", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Actions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserActionParameter", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.UserAction", "Action")
                        .WithMany("Parameters")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryEmailAddress", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.EmailAddress", "EmailAddress")
                        .WithOne("PrimaryEmailAddress")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryEmailAddress", "Address")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithOne("PrimaryEmailAddress")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryEmailAddress", "UserId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryMobileNumber", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithOne("PrimaryMobileNumber")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryMobileNumber", "UserId");

                    b.HasOne("Etherkeep.Data.Entities.MobileNumber", "MobileNumber")
                        .WithOne("PrimaryMobileNumber")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryMobileNumber", "CountryCallingCode", "AreaCode", "SubscriberNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserPrimaryWallet", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithOne("PrimaryWallet")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryWallet", "UserId");

                    b.HasOne("Etherkeep.Data.Entities.UserWallet", "Wallet")
                        .WithOne("PrimaryWallet")
                        .HasForeignKey("Etherkeep.Data.Entities.UserPrimaryWallet", "WalletId");
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserSetting", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserWallet", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Data.Entities.UserWalletAddress", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.UserWallet", "Wallet")
                        .WithMany("WalletAddresses")
                        .HasForeignKey("WalletId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<System.Guid>")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Data.Entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization<System.Guid>", b =>
                {
                    b.HasOne("Etherkeep.Data.Entities.User")
                        .WithMany("Authorizations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken<System.Guid>", b =>
                {
                    b.HasOne("OpenIddict.OpenIddictApplication<System.Guid>")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.OpenIddictAuthorization<System.Guid>")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");

                    b.HasOne("Etherkeep.Data.Entities.User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId");
                });
        }
    }
}
