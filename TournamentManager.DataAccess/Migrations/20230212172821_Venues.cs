using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Venues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WebAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FacebookAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExtraInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "County", "ExtraInformation", "FacebookAddress", "PhoneNumber", "PostCode", "Town", "VenueName", "WebAddress" },
                values: new object[,]
                {
                    { new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"), "High Pavement", "Nottinghamshire", null, null, null, "NG17 4BA", "Sutton in Ashfield", "The Devonshire Arms", null },
                    { new Guid("ae24627e-9e05-4529-b6ff-5917d6b8038e"), "Sutton Road", "Nottinghamshire", null, null, null, "NG17 7GZ", "Kirkby in Ashfield", "Bentinck Social Club", null },
                    { new Guid("cb29fe0d-e42c-4a8a-9ab9-839caeb9d4ea"), "High Pavement", "Nottinghamshire", null, null, null, "NG17 4BD", "Sutton in Ashfield", "Josephs Club", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueName",
                table: "Venues",
                column: "VenueName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
