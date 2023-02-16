using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GameTypeIsDefaultUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameTypes_Id_IsDefault",
                table: "GameTypes");

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_IsDefault",
                table: "GameTypes",
                column: "IsDefault",
                unique: true,
                filter: "[IsDefault] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameTypes_IsDefault",
                table: "GameTypes");

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_Id_IsDefault",
                table: "GameTypes",
                columns: new[] { "Id", "IsDefault" },
                unique: true,
                filter: "[IsDefault] = 1");
        }
    }
}
