using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeasonsPointsStructureIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointPosition_PointStructure_PointStructureId",
                table: "PointPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_PointStructure_PointStructureId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointStructure",
                table: "PointStructure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointPosition",
                table: "PointPosition");

            migrationBuilder.RenameTable(
                name: "PointStructure",
                newName: "PointStructures");

            migrationBuilder.RenameTable(
                name: "PointPosition",
                newName: "PointPositions");

            migrationBuilder.RenameIndex(
                name: "IX_PointPosition_PointStructureId_Position",
                table: "PointPositions",
                newName: "IX_PointPositions_PointStructureId_Position");

            migrationBuilder.AlterColumn<Guid>(
                name: "PointStructureId",
                table: "Seasons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointStructures",
                table: "PointStructures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointPositions",
                table: "PointPositions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"),
                column: "PointStructureId",
                value: new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"));

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                column: "PointStructureId",
                value: new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"));

            migrationBuilder.AddForeignKey(
                name: "FK_PointPositions_PointStructures_PointStructureId",
                table: "PointPositions",
                column: "PointStructureId",
                principalTable: "PointStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons",
                column: "PointStructureId",
                principalTable: "PointStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointPositions_PointStructures_PointStructureId",
                table: "PointPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_PointStructures_PointStructureId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointStructures",
                table: "PointStructures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointPositions",
                table: "PointPositions");

            migrationBuilder.RenameTable(
                name: "PointStructures",
                newName: "PointStructure");

            migrationBuilder.RenameTable(
                name: "PointPositions",
                newName: "PointPosition");

            migrationBuilder.RenameIndex(
                name: "IX_PointPositions_PointStructureId_Position",
                table: "PointPosition",
                newName: "IX_PointPosition_PointStructureId_Position");

            migrationBuilder.AlterColumn<Guid>(
                name: "PointStructureId",
                table: "Seasons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointStructure",
                table: "PointStructure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointPosition",
                table: "PointPosition",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"),
                column: "PointStructureId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                column: "PointStructureId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_PointPosition_PointStructure_PointStructureId",
                table: "PointPosition",
                column: "PointStructureId",
                principalTable: "PointStructure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_PointStructure_PointStructureId",
                table: "Seasons",
                column: "PointStructureId",
                principalTable: "PointStructure",
                principalColumn: "Id");
        }
    }
}
