using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class VenueVenueNameNotUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venues_VenueName",
                table: "Venues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueName",
                table: "Venues",
                column: "VenueName",
                unique: true);
        }
    }
}
