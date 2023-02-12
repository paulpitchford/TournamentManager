using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Games : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishResults = table.Column<bool>(type: "bit", nullable: false),
                    GameDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Buyin = table.Column<double>(type: "float", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Buyin", "Fee", "GameDateTime", "GameDetails", "GameTitle", "GameTypeId", "PublishResults", "SeasonId", "VenueId" },
                values: new object[,]
                {
                    { new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), 35.0, 5.0, new DateTime(2021, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 1, £40 buy in.", "Game 1", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") },
                    { new Guid("85eaff7b-dd27-4e43-8976-f10eb415bf61"), 35.0, 5.0, new DateTime(2021, 3, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 3, £40 buy in.", "Game 3", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") },
                    { new Guid("87450acd-ca09-40c2-883b-aad03402f9dc"), 35.0, 5.0, new DateTime(2021, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 6, £40 buy in.", "Game 6", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") },
                    { new Guid("c08c4989-8d4f-4729-a27d-f762f768cc59"), 35.0, 5.0, new DateTime(2021, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 5, £40 buy in.", "Game 5", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") },
                    { new Guid("c9a29408-0b4e-44a8-8a23-c51ddb8b360a"), 35.0, 5.0, new DateTime(2021, 4, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 4, £40 buy in.", "Game 4", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") },
                    { new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), 35.0, 5.0, new DateTime(2021, 2, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "League game 2, £40 buy in.", "Game 2", new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), false, new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeId",
                table: "Games",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SeasonId",
                table: "Games",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VenueId",
                table: "Games",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
