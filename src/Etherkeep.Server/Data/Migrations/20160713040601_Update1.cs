using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Etherkeep.Server.Data.Enums;

namespace Etherkeep.Server.Data.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_SubjectUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Transfers_TransferId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransferId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SubjectUserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "TransferInvitations");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SubjectUserId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "CountryCurrencies");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspenseWallets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    TransferInvitationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseWallets", x => x.Id);
                    table.UniqueConstraint("AK_SuspenseWallets_TransferInvitationId", x => x.TransferInvitationId);
                });

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                table: "Actions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: UserType.Personal);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "TransferInvitations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InvokerExchangeRate",
                table: "TransferInvitations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SuspenseWalletTransferInvitationId",
                table: "TransferInvitations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetExchangeRate",
                table: "TransferInvitations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Transfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InvokerExchangeRate",
                table: "Transfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TargetExchangeRate",
                table: "Transfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Transfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransferTransactionId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferInvitations_SuspenseWalletTransferInvitationId",
                table: "TransferInvitations",
                column: "SuspenseWalletTransferInvitationId",
                unique: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Transfers_TransactionId",
                table: "Transfers",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransferTransactionId",
                table: "Transactions",
                column: "TransferTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyCode",
                table: "Countries",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyCode",
                table: "Countries",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Transfers_TransferTransactionId",
                table: "Transactions",
                column: "TransferTransactionId",
                principalTable: "Transfers",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferInvitations_SuspenseWallets_SuspenseWalletTransferInvitationId",
                table: "TransferInvitations",
                column: "SuspenseWalletTransferInvitationId",
                principalTable: "SuspenseWallets",
                principalColumn: "TransferInvitationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyCode",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Transfers_TransferTransactionId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferInvitations_SuspenseWallets_SuspenseWalletTransferInvitationId",
                table: "TransferInvitations");

            migrationBuilder.DropIndex(
                name: "IX_TransferInvitations_SuspenseWalletTransferInvitationId",
                table: "TransferInvitations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Transfers_TransactionId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransferTransactionId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ActionType",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TransferInvitations");

            migrationBuilder.DropColumn(
                name: "InvokerExchangeRate",
                table: "TransferInvitations");

            migrationBuilder.DropColumn(
                name: "SuspenseWalletTransferInvitationId",
                table: "TransferInvitations");

            migrationBuilder.DropColumn(
                name: "TargetExchangeRate",
                table: "TransferInvitations");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "InvokerExchangeRate",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TargetExchangeRate",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransferTransactionId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SuspenseWallets");

            migrationBuilder.CreateTable(
                name: "CountryCurrencies",
                columns: table => new
                {
                    CountryCode = table.Column<string>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrencies", x => new { x.CountryCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_CountryCurrencies_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrencies_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Actions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ExchangeRate",
                table: "TransferInvitations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ExchangeRate",
                table: "Transfers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectUserId",
                table: "Notifications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransferId",
                table: "Transactions",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SubjectUserId",
                table: "Notifications",
                column: "SubjectUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrencies_CountryCode",
                table: "CountryCurrencies",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrencies_CurrencyCode",
                table: "CountryCurrencies",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_SubjectUserId",
                table: "Notifications",
                column: "SubjectUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Transfers_TransferId",
                table: "Transactions",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
