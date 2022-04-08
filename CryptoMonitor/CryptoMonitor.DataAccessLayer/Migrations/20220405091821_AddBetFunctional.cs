using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMonitor.DAL.Migrations
{
    public partial class AddBetFunctional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BetDate",
                table: "Bet",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetDate",
                table: "Bet");
        }
    }
}
