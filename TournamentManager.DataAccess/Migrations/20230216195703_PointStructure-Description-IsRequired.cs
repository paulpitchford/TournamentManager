using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PointStructureDescriptionIsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PointStructureDescription",
                table: "PointStructures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PointStructures",
                keyColumn: "Id",
                keyValue: new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"),
                column: "PointStructureDescription",
                value: "Value multiplier of 10 + 15");

            migrationBuilder.UpdateData(
                table: "PointStructures",
                keyColumn: "Id",
                keyValue: new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"),
                column: "PointStructureDescription",
                value: "Points multiplied by player count + 15");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PointStructureDescription",
                table: "PointStructures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
    }
}
