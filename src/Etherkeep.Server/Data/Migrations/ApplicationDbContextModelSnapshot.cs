using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Etherkeep.Server.Data;

namespace Etherkeep.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionType");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActionParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("ActionParameters");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Activity", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActivityParameter", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.AddressBookEntry", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("AddressBookEntries");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Config", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ConfigGroup", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ConfigGroups");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ConfigOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfigId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.ToTable("ConfigOptions");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Contact", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Country", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Currency", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<int>("Precision");

                    b.Property<string>("Symbol");

                    b.Property<string>("Template");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Device", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Token");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.EmailAddress", b =>
                {
                    b.Property<string>("Address");

                    b.Property<Guid>("UserId");

                    b.Property<bool>("Verified");

                    b.HasKey("Address");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ExternalPayment", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ExternalPaymentRequest", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Fee", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WalletAddress");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.LoginAttempt", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.MerchantInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("UserId");

                    b.ToTable("MerchantInfos");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.MobileNumber", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Notification", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.NotificationParameter", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Payment", b =>
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

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.PaymentRequest", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Setting", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.SettingGroup", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SettingGroups");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.SettingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SettingId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SettingId");

                    b.ToTable("SettingOptions");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.SuspenseWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("SuspenseWallets");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Transaction", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.User", b =>
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

                    b.Property<int?>("MerchantInfoUserId");

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

                    b.HasIndex("MerchantInfoUserId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryEmailAddress", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryMobileNumber", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryWallet", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserSetting", b =>
                {
                    b.Property<Guid>("UserId");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Wallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.WalletAddress", b =>
                {
                    b.Property<string>("Address");

                    b.Property<double>("Balance");

                    b.Property<string>("WalletId");

                    b.HasKey("Address");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletAddresses");
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Action", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Actions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActionParameter", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Action", "Action")
                        .WithMany("Parameters")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Activity", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActivityParameter", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Activity", "Activity")
                        .WithMany("Parameters")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Config", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.ConfigGroup", "ConfigGroup")
                        .WithMany("Configs")
                        .HasForeignKey("ConfigGroupId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ConfigOption", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Config", "Config")
                        .WithMany("ConfigOptions")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Contact", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Subject")
                        .WithMany("SubjectContacts")
                        .HasForeignKey("ContactId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("OwnedContacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Country", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("Countries")
                        .HasForeignKey("CurrencyCode");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Device", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.EmailAddress", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ExternalPayment", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("ExternalPayments")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.Payment", "Payment")
                        .WithOne("ExternalPayment")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.ExternalPayment", "PaymentExternalPaymentId")
                        .HasPrincipalKey("Etherkeep.Server.Data.Entities.Payment", "ExternalPaymentId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Sender")
                        .WithMany("SentExternalPayments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ExternalPaymentRequest", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("ExternalPaymentRequests")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.PaymentRequest", "PaymentRequest")
                        .WithOne("ExternalPaymentRequest")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.ExternalPaymentRequest", "PaymentRequestExternalPaymentRequestId")
                        .HasPrincipalKey("Etherkeep.Server.Data.Entities.PaymentRequest", "ExternalPaymentRequestId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Sender")
                        .WithMany("SentExternalPaymentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Fee", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("Fees")
                        .HasForeignKey("CurrencyCode");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.LoginAttempt", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Country", "Country")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("CountryCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("LoginAttempts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.MobileNumber", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("MobileNumbers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Notification", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.NotificationParameter", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Notification", "Notification")
                        .WithMany("Parameters")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Payment", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("Payments")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.Invoice", "Invoice")
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Receiver")
                        .WithMany("ReceivedPayments")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Sender")
                        .WithMany("SentPayments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.PaymentRequest", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("PaymentRequests")
                        .HasForeignKey("CurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.Payment", "Payment")
                        .WithOne("PaymentRequest")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.PaymentRequest", "PaymentRequestId")
                        .HasPrincipalKey("Etherkeep.Server.Data.Entities.Payment", "PaymentRequestId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Receiver")
                        .WithMany("ReceivedPaymentRequests")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Sender")
                        .WithMany("SentPaymentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Setting", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.SettingGroup", "SettingGroup")
                        .WithMany("Settings")
                        .HasForeignKey("SettingGroupId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.SettingOption", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Setting", "Setting")
                        .WithMany("SettingOptions")
                        .HasForeignKey("SettingId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.User", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.MerchantInfo", "MerchantInfo")
                        .WithOne("User")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.User", "MerchantInfoUserId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryEmailAddress", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.EmailAddress", "EmailAddress")
                        .WithOne("PrimaryEmailAddress")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryEmailAddress", "Address")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithOne("PrimaryEmailAddress")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryEmailAddress", "UserId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryMobileNumber", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithOne("PrimaryMobileNumber")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryMobileNumber", "UserId");

                    b.HasOne("Etherkeep.Server.Data.Entities.MobileNumber", "MobileNumber")
                        .WithOne("PrimaryMobileNumber")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryMobileNumber", "CountryCallingCode", "AreaCode", "SubscriberNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserPrimaryWallet", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithOne("PrimaryWallet")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryWallet", "UserId");

                    b.HasOne("Etherkeep.Server.Data.Entities.Wallet", "Wallet")
                        .WithOne("PrimaryWallet")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserPrimaryWallet", "WalletId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserSetting", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Wallet", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.WalletAddress", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Wallet", "Wallet")
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
                    b.HasOne("Etherkeep.Server.Data.Entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User")
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

                    b.HasOne("Etherkeep.Server.Data.Entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization<System.Guid>", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User")
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

                    b.HasOne("Etherkeep.Server.Data.Entities.User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId");
                });
        }
    }
}
