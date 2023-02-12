using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeasonPropertyDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeasonName",
                table: "Seasons");

            migrationBuilder.AlterColumn<string>(
                name: "SeasonName",
                table: "Seasons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeasonName",
                table: "Seasons",
                column: "SeasonName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeasonName",
                table: "Seasons");

            migrationBuilder.AlterColumn<string>(
                name: "SeasonName",
                table: "Seasons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeasonName",
                table: "Seasons",
                column: "SeasonName",
                unique: true,
                filter: "[SeasonName] IS NOT NULL");
        }
    }
}
