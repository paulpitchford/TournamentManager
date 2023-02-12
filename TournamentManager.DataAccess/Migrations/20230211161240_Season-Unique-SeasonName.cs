using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeasonUniqueSeasonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeasonName",
                table: "Seasons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                columns: new[] { "SeasonName", "StartDate" },
                values: new object[] { "Season One", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                columns: new[] { "SeasonName", "StartDate" },
                values: new object[] { "Season Three", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeasonName",
                table: "Seasons",
                column: "SeasonName",
                unique: true,
                filter: "[SeasonName] IS NOT NULL");
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
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                columns: new[] { "SeasonName", "StartDate" },
                values: new object[] { "Season Three", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                columns: new[] { "SeasonName", "StartDate" },
                values: new object[] { "Season One", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
