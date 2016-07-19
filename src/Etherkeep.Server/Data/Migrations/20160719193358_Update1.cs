using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Etherkeep.Server.Data.Enums;

namespace Etherkeep.Server.Data.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Contacts",
                nullable: false,
                defaultValue: ContactType.User);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contacts");
        }
    }
}
