using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PointStructurePointPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PointStructureId",
                table: "Seasons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PointStructure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultPoints = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointStructure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointStructureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<double>(type: "float", nullable: false),
                    MultiplierType = table.Column<int>(type: "int", nullable: false),
                    MultiplierValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointPosition_PointStructure_PointStructureId",
                        column: x => x.PointStructureId,
                        principalTable: "PointStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PointStructure",
                columns: new[] { "Id", "DefaultPoints" },
                values: new object[,]
                {
                    { new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 15.0 },
                    { new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 15.0 }
                });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                column: "PointStructureId",
                value: new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"));

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

            migrationBuilder.InsertData(
                table: "PointPosition",
                columns: new[] { "Id", "MultiplierType", "MultiplierValue", "PointStructureId", "Points", "Position" },
                values: new object[,]
                {
                    { new Guid("150d3953-4f20-444b-8da4-e30b2f3b20d6"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 25.0, 1 },
                    { new Guid("165fe14f-5014-431f-a7af-c6d5d6fdc95b"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 8.0, 6 },
                    { new Guid("1c2cc86a-cb56-4611-ae84-656b067dafd1"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 4.0, 8 },
                    { new Guid("1ffb54d2-2148-4e3d-992a-7bcbeac844a9"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 0.0, 10 },
                    { new Guid("32cfd599-293a-495f-80a4-394beb142a4b"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 0.0, 10 },
                    { new Guid("46c18cf8-8b1c-4637-a0bc-4c7fe24a697b"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 2.0, 9 },
                    { new Guid("4d668d17-cd09-4549-8c4a-6569ded77d97"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 2.0, 9 },
                    { new Guid("59a6663c-ad03-419a-a5c9-6f46a8aece8f"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 4.0, 8 },
                    { new Guid("5e5197ac-7cbb-47a4-b5b3-02b186ddfa90"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 18.0, 2 },
                    { new Guid("63081e77-146a-42dc-be8f-8af1a75d14c6"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 6.0, 7 },
                    { new Guid("64badb29-ca8f-47aa-ae6c-870b36dd7821"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 10.0, 5 },
                    { new Guid("69b8ccd9-56dc-466c-88cc-a03c0116fc6c"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 15.0, 3 },
                    { new Guid("732679d6-5207-46c9-80da-d5584d8f80bd"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 15.0, 3 },
                    { new Guid("758a4d7d-88b6-49dd-be6e-4c4faa8fd377"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 25.0, 1 },
                    { new Guid("7e2929a3-3164-4cf7-bf34-51963621fae2"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 8.0, 6 },
                    { new Guid("966eb214-c0ef-474d-bd24-231c75a6f920"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 12.0, 4 },
                    { new Guid("9679aa37-8b2d-4f7a-9c8f-ed9cf970183e"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 10.0, 5 },
                    { new Guid("ca7d357f-e064-4bd3-a2a0-cae82251e096"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 6.0, 7 },
                    { new Guid("cb27ed5a-7254-4d5c-81e7-34b5eafadf25"), 0, 0.0, new Guid("d9db6444-f33f-4832-befe-46a17ea765cf"), 18.0, 2 },
                    { new Guid("d29caced-7f45-4a1f-b3ef-1cf96ecde27a"), 1, 10.0, new Guid("341891db-1c50-4c99-aee9-b90b33d10be1"), 12.0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_PointStructureId",
                table: "Seasons",
                column: "PointStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_PointPosition_PointStructureId_Position",
                table: "PointPosition",
                columns: new[] { "PointStructureId", "Position" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_PointStructure_PointStructureId",
                table: "Seasons",
                column: "PointStructureId",
                principalTable: "PointStructure",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_PointStructure_PointStructureId",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "PointPosition");

            migrationBuilder.DropTable(
                name: "PointStructure");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_PointStructureId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "PointStructureId",
                table: "Seasons");
        }
    }
}
