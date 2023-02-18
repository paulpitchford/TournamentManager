using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeasonsPointsStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons",
                column: "PointStructureId",
                principalTable: "PointStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons",
                column: "PointStructureId",
                principalTable: "PointStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
