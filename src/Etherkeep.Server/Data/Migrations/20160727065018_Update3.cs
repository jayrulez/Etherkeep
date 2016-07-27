using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Etherkeep.Server.Data.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ExternalPaymentSuspenseWallets_ExternalPaymentId",
                table: "ExternalPaymentSuspenseWallets",
                column: "ExternalPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSuspenseWallets_PaymentId",
                table: "PaymentSuspenseWallets",
                column: "PaymentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalPaymentSuspenseWallets");

            migrationBuilder.DropTable(
                name: "PaymentSuspenseWallets");
        }
    }
}
