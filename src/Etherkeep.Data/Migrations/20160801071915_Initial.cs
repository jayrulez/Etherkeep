using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Etherkeep.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreatePostgresExtension("uuid-ossp");

            migrationBuilder.CreateTable(
                name: "AddressBookEntries",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBookEntries", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ConfigGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Precision = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Template = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    WalletAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspenseWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseWallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Confirmations = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClientId = table.Column<string>(nullable: true),
                    ClientSecret = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    LogoutRedirectUri = table.Column<string>(nullable: true),
                    RedirectUri = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConfigGroupId = table.Column<string>(nullable: true),
                    ConfigType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configs_ConfigGroups_ConfigGroupId",
                        column: x => x.ConfigGroupId,
                        principalTable: "ConfigGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RangeEnd = table.Column<double>(nullable: false),
                    RangeStart = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SettingGroupId = table.Column<string>(nullable: true),
                    SettingType = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_SettingGroups_SettingGroupId",
                        column: x => x.SettingGroupId,
                        principalTable: "SettingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ActivityType = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ContactId = table.Column<Guid>(nullable: false),
                    LastActivity = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.UniqueConstraint("AK_Contacts_UserId_ContactId", x => new { x.UserId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_ContactId",
                        column: x => x.ContactId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Address);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileNumbers",
                columns: table => new
                {
                    CountryCallingCode = table.Column<string>(nullable: false),
                    AreaCode = table.Column<string>(nullable: false),
                    SubscriberNumber = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileNumbers", x => new { x.CountryCallingCode, x.AreaCode, x.SubscriberNumber });
                    table.ForeignKey(
                        name: "FK_MobileNumbers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NotificationType = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ActionType = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Passphrase = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Scope = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ConfigId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigOptions_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CountryCode = table.Column<string>(nullable: true),
                    GeoLocation = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginAttempts_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoginAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    SettingId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingOptions_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ActivityId = table.Column<int>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityParameters_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrimaryEmailAddresses",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrimaryEmailAddresses", x => x.UserId);
                    table.UniqueConstraint("AK_UserPrimaryEmailAddresses_Address", x => x.Address);
                    table.ForeignKey(
                        name: "FK_UserPrimaryEmailAddresses_EmailAddresses_Address",
                        column: x => x.Address,
                        principalTable: "EmailAddresses",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrimaryEmailAddresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchantWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    MerchantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantWallets_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrimaryMobileNumbers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AreaCode = table.Column<string>(nullable: false),
                    CountryCallingCode = table.Column<string>(nullable: false),
                    SubscriberNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrimaryMobileNumbers", x => x.UserId);
                    table.UniqueConstraint("AK_UserPrimaryMobileNumbers_CountryCallingCode_AreaCode_SubscriberNumber", x => new { x.CountryCallingCode, x.AreaCode, x.SubscriberNumber });
                    table.ForeignKey(
                        name: "FK_UserPrimaryMobileNumbers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPrimaryMobileNumbers_MobileNumbers_CountryCallingCode_AreaCode_SubscriberNumber",
                        columns: x => new { x.CountryCallingCode, x.AreaCode, x.SubscriberNumber },
                        principalTable: "MobileNumbers",
                        principalColumns: new[] { "CountryCallingCode", "AreaCode", "SubscriberNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    NotificationId = table.Column<int>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationParameters_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActionParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ActionId = table.Column<int>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActionParameters_UserActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "UserActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrimaryWallets",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    WalletId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrimaryWallets", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserPrimaryWallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPrimaryWallets_UserWallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "UserWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWalletAddresses",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    WalletId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWalletAddresses", x => x.Address);
                    table.ForeignKey(
                        name: "FK_UserWalletAddresses_UserWallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "UserWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ApplicationId = table.Column<Guid>(nullable: true),
                    AuthorizationId = table.Column<Guid>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchantWalletAddresses",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    WalletId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantWalletAddresses", x => x.Address);
                    table.ForeignKey(
                        name: "FK_MerchantWalletAddresses_MerchantWallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "MerchantWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchantBills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Address = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    MerchantId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantBills_MerchantWalletAddresses_Address",
                        column: x => x.Address,
                        principalTable: "MerchantWalletAddresses",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MerchantBills_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MerchantBills_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<double>(nullable: false),
                    ExternalPaymentId = table.Column<int>(nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true),
                    MerchantBillId = table.Column<int>(nullable: true),
                    PaymentRequestId = table.Column<int>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tokens = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.UniqueConstraint("AK_Payments_ExternalPaymentId", x => x.ExternalPaymentId);
                    table.UniqueConstraint("AK_Payments_PaymentRequestId", x => x.PaymentRequestId);
                    table.ForeignKey(
                        name: "FK_Payments_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_MerchantBills_MerchantBillId",
                        column: x => x.MerchantBillId,
                        principalTable: "MerchantBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<double>(nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    PaymentExternalPaymentId = table.Column<int>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    ReceiverType = table.Column<int>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tokens = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalPayments_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalPayments_Payments_PaymentExternalPaymentId",
                        column: x => x.PaymentExternalPaymentId,
                        principalTable: "Payments",
                        principalColumn: "ExternalPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalPayments_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    ExternalPaymentRequestId = table.Column<int>(nullable: false),
                    PaymentRequestId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.Id);
                    table.UniqueConstraint("AK_PaymentRequests_ExternalPaymentRequestId", x => x.ExternalPaymentRequestId);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_Payments_PaymentRequestId",
                        column: x => x.PaymentRequestId,
                        principalTable: "Payments",
                        principalColumn: "PaymentRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSuspenseWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSuspenseWallets", x => x.Id);
                    table.UniqueConstraint("AK_PaymentSuspenseWallets_PaymentId", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentSuspenseWallets_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPaymentSuspenseWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    ExternalPaymentId = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPaymentSuspenseWallets", x => x.Id);
                    table.UniqueConstraint("AK_ExternalPaymentSuspenseWallets_ExternalPaymentId", x => x.ExternalPaymentId);
                    table.ForeignKey(
                        name: "FK_ExternalPaymentSuspenseWallets_ExternalPayments_ExternalPaymentId",
                        column: x => x.ExternalPaymentId,
                        principalTable: "ExternalPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPaymentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    PaymentRequestExternalPaymentRequestId = table.Column<int>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    ReceiverType = table.Column<int>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPaymentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalPaymentRequests_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalPaymentRequests_PaymentRequests_PaymentRequestExternalPaymentRequestId",
                        column: x => x.PaymentRequestExternalPaymentRequestId,
                        principalTable: "PaymentRequests",
                        principalColumn: "ExternalPaymentRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalPaymentRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityParameters_ActivityId",
                table: "ActivityParameters",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_ConfigGroupId",
                table: "Configs",
                column: "ConfigGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigOptions_ConfigId",
                table: "ConfigOptions",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactId",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyCode",
                table: "Countries",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_UserId",
                table: "EmailAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPayments_CurrencyCode",
                table: "ExternalPayments",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPayments_PaymentExternalPaymentId",
                table: "ExternalPayments",
                column: "PaymentExternalPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPayments_SenderId",
                table: "ExternalPayments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPaymentRequests_CurrencyCode",
                table: "ExternalPaymentRequests",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPaymentRequests_PaymentRequestExternalPaymentRequestId",
                table: "ExternalPaymentRequests",
                column: "PaymentRequestExternalPaymentRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPaymentRequests_SenderId",
                table: "ExternalPaymentRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPaymentSuspenseWallets_ExternalPaymentId",
                table: "ExternalPaymentSuspenseWallets",
                column: "ExternalPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_CurrencyCode",
                table: "Fees",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_CountryCode",
                table: "LoginAttempts",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_UserId",
                table: "LoginAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBills_Address",
                table: "MerchantBills",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBills_CurrencyCode",
                table: "MerchantBills",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBills_MerchantId",
                table: "MerchantBills",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantWallets_MerchantId",
                table: "MerchantWallets",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantWalletAddresses_WalletId",
                table: "MerchantWalletAddresses",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileNumbers_UserId",
                table: "MobileNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationParameters_NotificationId",
                table: "NotificationParameters",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CurrencyCode",
                table: "Payments",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MerchantBillId",
                table: "Payments",
                column: "MerchantBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReceiverId",
                table: "Payments",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SenderId",
                table: "Payments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_CurrencyCode",
                table: "PaymentRequests",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_PaymentRequestId",
                table: "PaymentRequests",
                column: "PaymentRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_ReceiverId",
                table: "PaymentRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_SenderId",
                table: "PaymentRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSuspenseWallets_PaymentId",
                table: "PaymentSuspenseWallets",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_SettingGroupId",
                table: "Settings",
                column: "SettingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingOptions_SettingId",
                table: "SettingOptions",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_UserId",
                table: "UserActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionParameters_ActionId",
                table: "UserActionParameters",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryEmailAddresses_Address",
                table: "UserPrimaryEmailAddresses",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryEmailAddresses_UserId",
                table: "UserPrimaryEmailAddresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryMobileNumbers_UserId",
                table: "UserPrimaryMobileNumbers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryMobileNumbers_CountryCallingCode_AreaCode_SubscriberNumber",
                table: "UserPrimaryMobileNumbers",
                columns: new[] { "CountryCallingCode", "AreaCode", "SubscriberNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryWallets_UserId",
                table: "UserPrimaryWallets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryWallets_WalletId",
                table: "UserPrimaryWallets",
                column: "WalletId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallets_UserId",
                table: "UserWallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWalletAddresses_WalletId",
                table: "UserWalletAddresses",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_UserId",
                table: "OpenIddictAuthorizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId",
                table: "OpenIddictTokens",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_UserId",
                table: "OpenIddictTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPostgresExtension("uuid-ossp");

            migrationBuilder.DropTable(
                name: "ActivityParameters");

            migrationBuilder.DropTable(
                name: "AddressBookEntries");

            migrationBuilder.DropTable(
                name: "ConfigOptions");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "ExternalPaymentRequests");

            migrationBuilder.DropTable(
                name: "ExternalPaymentSuspenseWallets");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "LoginAttempts");

            migrationBuilder.DropTable(
                name: "NotificationParameters");

            migrationBuilder.DropTable(
                name: "PaymentSuspenseWallets");

            migrationBuilder.DropTable(
                name: "SettingOptions");

            migrationBuilder.DropTable(
                name: "SuspenseWallets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserActionParameters");

            migrationBuilder.DropTable(
                name: "UserPrimaryEmailAddresses");

            migrationBuilder.DropTable(
                name: "UserPrimaryMobileNumbers");

            migrationBuilder.DropTable(
                name: "UserPrimaryWallets");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserWalletAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "ExternalPayments");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserActions");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "MobileNumbers");

            migrationBuilder.DropTable(
                name: "UserWallets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "ConfigGroups");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SettingGroups");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "MerchantBills");

            migrationBuilder.DropTable(
                name: "MerchantWalletAddresses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "MerchantWallets");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
