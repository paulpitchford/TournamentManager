using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PointStructureDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PointStructureDescription",
                table: "PointStructures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PointStructures",
                keyColumn: "Id",
                keyValue: new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"),
                column: "PointStructureDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "PointStructures",
                keyColumn: "Id",
                keyValue: new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"),
                column: "PointStructureDescription",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointStructureDescription",
                table: "PointStructures");
        }
    }
}
