using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PlayerTournamentDirectorIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TournamentDirectorId",
                table: "Players",
                type: "nchar(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("35d039f5-8c42-4764-beda-ae2e563e8c27"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"),
                column: "TournamentDirectorId",
                value: "2f5bafda-b39e-4b87-84af-73f92b1dfecc");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("916d616d-a760-4a60-8524-bed87bee4411"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f9288114-38dc-445f-ae86-603841f4eca7"),
                column: "TournamentDirectorId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TournamentDirectorId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(36)",
                oldFixedLength: true,
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("35d039f5-8c42-4764-beda-ae2e563e8c27"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"),
                column: "TournamentDirectorId",
                value: new Guid("2f5bafda-b39e-4b87-84af-73f92b1dfecc"));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("916d616d-a760-4a60-8524-bed87bee4411"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"),
                column: "TournamentDirectorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f9288114-38dc-445f-ae86-603841f4eca7"),
                column: "TournamentDirectorId",
                value: null);
        }
    }
}
