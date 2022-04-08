using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoMonitor.DAL.Migrations
{
    public partial class AddNotNullForBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_CryptoCurrency_CurrencyId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Bet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet",
                column: "CurrencyId",
                unique: true,
                filter: "[CurrencyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_CryptoCurrency_CurrencyId",
                table: "Bet",
                column: "CurrencyId",
                principalTable: "CryptoCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_CryptoCurrency_CurrencyId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "Bet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_CurrencyId",
                table: "Bet",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_CryptoCurrency_CurrencyId",
                table: "Bet",
                column: "CurrencyId",
                principalTable: "CryptoCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_User_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
