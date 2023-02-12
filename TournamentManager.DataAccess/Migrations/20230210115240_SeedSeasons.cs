using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSeasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "SeasonName", "StartDate" },
                values: new object[,]
                {
                    { new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), "Season Three", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"), "Season Two", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"), "Season One", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"));

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"));

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"));
        }
    }
}
