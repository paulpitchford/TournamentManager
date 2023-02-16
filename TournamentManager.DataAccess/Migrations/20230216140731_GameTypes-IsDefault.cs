using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GameTypesIsDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "GameTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "GameTypes",
                keyColumn: "Id",
                keyValue: new Guid("0bd6aac9-ad90-4fdb-9725-ae363f0d9171"),
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "GameTypes",
                keyColumn: "Id",
                keyValue: new Guid("6117db2a-2143-460d-a5cf-7d038caa3c33"),
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "GameTypes",
                keyColumn: "Id",
                keyValue: new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                column: "IsDefault",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_Id_IsDefault",
                table: "GameTypes",
                columns: new[] { "Id", "IsDefault" },
                unique: true,
                filter: "[IsDefault] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameTypes_Id_IsDefault",
                table: "GameTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "GameTypes");
        }
    }
}
