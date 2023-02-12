using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GameTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AwardPoints = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameTypes",
                columns: new[] { "Id", "AwardPoints", "GameTypeName" },
                values: new object[,]
                {
                    { new Guid("0bd6aac9-ad90-4fdb-9725-ae363f0d9171"), false, "Special" },
                    { new Guid("6117db2a-2143-460d-a5cf-7d038caa3c33"), false, "Final" },
                    { new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), true, "League" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_GameTypeName",
                table: "GameTypes",
                column: "GameTypeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}
