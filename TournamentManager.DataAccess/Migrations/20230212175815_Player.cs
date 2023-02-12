using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentDirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "LastName", "TournamentDirectorId" },
                values: new object[,]
                {
                    { new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"), "Adam", "May", null },
                    { new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"), "Trinity", "Lin", null },
                    { new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"), "Malakai", "Davidson", null },
                    { new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"), "Priya", "Arroyo", null },
                    { new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"), "Paul", "Pitchford", new Guid("2f5bafda-b39e-4b87-84af-73f92b1dfecc") },
                    { new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"), "Saul", "Pena", null },
                    { new Guid("916d616d-a760-4a60-8524-bed87bee4411"), "Layla", "Russell", null },
                    { new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"), "Nevaeh", "Hatfield", null },
                    { new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"), "Fleur", "Gray", null },
                    { new Guid("f9288114-38dc-445f-ae86-603841f4eca7"), "Niamh", "Warren", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TournamentDirectorId",
                table: "Players",
                column: "TournamentDirectorId",
                unique: true,
                filter: "[TournamentDirectorId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
