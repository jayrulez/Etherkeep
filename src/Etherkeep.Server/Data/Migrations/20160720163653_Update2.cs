using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Etherkeep.Server.Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MerchantInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantInfos", x => x.UserId);
                });

            migrationBuilder.AddColumn<int>(
                name: "MerchantInfoUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MerchantInfoUserId",
                table: "AspNetUsers",
                column: "MerchantInfoUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MerchantInfos_MerchantInfoUserId",
                table: "AspNetUsers",
                column: "MerchantInfoUserId",
                principalTable: "MerchantInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MerchantInfos_MerchantInfoUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MerchantInfoUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MerchantInfoUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MerchantInfos");
        }
    }
}
