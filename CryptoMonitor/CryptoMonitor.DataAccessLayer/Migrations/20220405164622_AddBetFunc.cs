using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMonitor.DAL.Migrations
{
    public partial class AddBetFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet",
                column: "CurrencyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet",
                column: "CurrencyId");
        }
    }
}
