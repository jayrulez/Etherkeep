using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Etherkeep.Server.Data;

namespace Etherkeep.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160704184255_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityTypeId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActivityParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityParams");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActivityType", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Template");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
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

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.CountryCurrency", b =>
                {
                    b.Property<string>("CountryCode");

                    b.Property<string>("CurrencyCode");

                    b.HasKey("CountryCode", "CurrencyCode");

                    b.HasIndex("CountryCode");

                    b.HasIndex("CurrencyCode");

                    b.ToTable("CountryCurrencies");
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("NotificationTypeId");

                    b.Property<Guid>("SubjectUserId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("SubjectUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.NotificationParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NotificationId");

                    b.Property<string>("Parameter");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.ToTable("NotificationParams");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.NotificationType", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Template");

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Confirmations");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Hash");

                    b.Property<int>("Status");

                    b.Property<int?>("TransferId");

                    b.HasKey("Id");

                    b.HasIndex("TransferId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("ExchangeRate");

                    b.Property<double>("FeeAmount");

                    b.Property<double>("InvokerAmount");

                    b.Property<string>("InvokerCurrencyCode");

                    b.Property<Guid>("InvokerUserId");

                    b.Property<int>("Status");

                    b.Property<double>("TargetAmount");

                    b.Property<string>("TargetCurrencyCode");

                    b.Property<Guid>("TargetUserId");

                    b.Property<double>("TotalCharge");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("InvokerCurrencyCode");

                    b.HasIndex("InvokerUserId");

                    b.HasIndex("TargetCurrencyCode");

                    b.HasIndex("TargetUserId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferFee", b =>
                {
                    b.Property<int>("TransferId");

                    b.Property<int>("FeeId");

                    b.Property<double>("Amount");

                    b.Property<int>("FeeType");

                    b.Property<double>("FeeValue");

                    b.HasKey("TransferId", "FeeId");

                    b.HasIndex("FeeId");

                    b.HasIndex("TransferId");

                    b.ToTable("TransferFees");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<double>("ExchangeRate");

                    b.Property<double>("InvokerAmount");

                    b.Property<string>("InvokerCurrencyCode");

                    b.Property<Guid>("InvokerUserId");

                    b.Property<int>("Status");

                    b.Property<double>("TargetAmount");

                    b.Property<string>("TargetCurrencyCode");

                    b.Property<string>("TargetIdentity");

                    b.Property<int>("TargetType");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("InvokerCurrencyCode");

                    b.HasIndex("InvokerUserId");

                    b.HasIndex("TargetCurrencyCode");

                    b.ToTable("TransferInvitations");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitationFee", b =>
                {
                    b.Property<int>("TransferInvitationId");

                    b.Property<int>("FeeId");

                    b.Property<double>("Amount");

                    b.Property<int>("FeeType");

                    b.Property<double>("FeeValue");

                    b.HasKey("TransferInvitationId", "FeeId");

                    b.HasIndex("FeeId");

                    b.HasIndex("TransferInvitationId");

                    b.ToTable("TransferInvitationFee");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitationMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("TransferInvitationId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TransferInvitationId");

                    b.HasIndex("UserId");

                    b.ToTable("TransferInvitationMessage");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Read");

                    b.Property<int>("TransferId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TransferId");

                    b.HasIndex("UserId");

                    b.ToTable("TransferMessages");
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

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<int>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserSetting", b =>
                {
                    b.Property<Guid>("UserId");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserWallet", b =>
                {
                    b.Property<string>("Id");

                    b.Property<double>("Balance");

                    b.Property<string>("Label");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserWalletAddress", b =>
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Activity", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.ActivityType", "ActivityType")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityTypeId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.ActivityParam", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Activity", "Activity")
                        .WithMany("ActivityParams")
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
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Owner")
                        .WithMany("OwnedContacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.CountryCurrency", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Country", "Country")
                        .WithMany("CountryCurrencies")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "Currency")
                        .WithMany("CountryCurrencies")
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Device", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Notification", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.NotificationType", "NotificationType")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTypeId");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "SubjectUser")
                        .WithMany("ReceivedNotifications")
                        .HasForeignKey("SubjectUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("SentNotifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.NotificationParam", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Notification", "Notification")
                        .WithMany("NotificationParams")
                        .HasForeignKey("NotificationId")
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

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Transaction", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Transfer", "Transfer")
                        .WithMany()
                        .HasForeignKey("TransferId");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.Transfer", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "InvokerCurrency")
                        .WithMany("InvokerTransfers")
                        .HasForeignKey("InvokerCurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Invoker")
                        .WithMany("InvokedTransfers")
                        .HasForeignKey("InvokerUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "TargetCurrency")
                        .WithMany("TargetTransfers")
                        .HasForeignKey("TargetCurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Target")
                        .WithMany("TargetedTransfers")
                        .HasForeignKey("TargetUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferFee", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Fee", "Fee")
                        .WithMany("TransferFees")
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.Transfer", "Transfer")
                        .WithMany("TransferFees")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitation", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "InvokerCurrency")
                        .WithMany("InvokerTransferInvitations")
                        .HasForeignKey("InvokerCurrencyCode");

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "Invoker")
                        .WithMany("InvokedTransferInvitations")
                        .HasForeignKey("InvokerUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.Currency", "TargetCurrency")
                        .WithMany("TargetTransferInvitations")
                        .HasForeignKey("TargetCurrencyCode");
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitationFee", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Fee", "Fee")
                        .WithMany("TransferInvitationFees")
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.TransferInvitation", "TransferInvitation")
                        .WithMany("TransferInvitationFees")
                        .HasForeignKey("TransferInvitationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferInvitationMessage", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.TransferInvitation", "TransferInvitation")
                        .WithMany("TransferInvitationMessages")
                        .HasForeignKey("TransferInvitationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("TransferInvitationMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.TransferMessage", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.Transfer", "Transfer")
                        .WithMany("TransferMessages")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("TransferMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserAction", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("UserActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserSetting", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserWallet", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.User", "User")
                        .WithOne("UserWallet")
                        .HasForeignKey("Etherkeep.Server.Data.Entities.UserWallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Etherkeep.Server.Data.Entities.UserWalletAddress", b =>
                {
                    b.HasOne("Etherkeep.Server.Data.Entities.UserWallet", "UserWallet")
                        .WithMany("UserWalletAddresses")
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
