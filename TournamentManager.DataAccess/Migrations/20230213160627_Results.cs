using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Results : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<double>(type: "float", nullable: false),
                    Points = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "Cash", "GameId", "PlayerId", "Points", "Position" },
                values: new object[,]
                {
                    { new Guid("07636c15-e4dc-4773-984e-75345884b7c1"), 100.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"), 150.0, 2 },
                    { new Guid("1400ba4b-0cbd-4ef8-94a3-5b711f8e11cb"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("f9288114-38dc-445f-ae86-603841f4eca7"), 15.0, 8 },
                    { new Guid("1cd86510-3464-4ef0-90ea-e8b7cac22567"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"), 50.0, 5 },
                    { new Guid("22b3aa24-66b9-46f6-8cf3-4f5e6b033f45"), 75.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("916d616d-a760-4a60-8524-bed87bee4411"), 100.0, 3 },
                    { new Guid("2f905b1d-648f-4a70-beca-c71c77d6ce49"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"), 15.0, 10 },
                    { new Guid("33b3383c-598a-4933-a8b4-d9dc37ea469c"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"), 15.0, 7 },
                    { new Guid("34f60507-7c52-4ffe-b282-87a1f3f7ce0c"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"), 25.0, 6 },
                    { new Guid("6a2c53e5-058b-4fe0-bd10-f30404e2700e"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"), 50.0, 5 },
                    { new Guid("6ced4a42-898e-4ba9-afe9-39eb1a14798e"), 75.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("f9288114-38dc-445f-ae86-603841f4eca7"), 100.0, 3 },
                    { new Guid("7bdd396b-6918-4c70-a4e3-603f55c458c6"), 200.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"), 200.0, 1 },
                    { new Guid("92b0c68f-391d-42dc-8a00-6649749467cb"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"), 25.0, 6 },
                    { new Guid("9f923e68-afc9-46e7-bb92-d76d3c0825b0"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("916d616d-a760-4a60-8524-bed87bee4411"), 15.0, 8 },
                    { new Guid("bb09a001-830e-4e70-b6ac-b4b9790e59fd"), 200.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"), 200.0, 1 },
                    { new Guid("c465c4d8-494a-449d-8b17-72146a752d2b"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"), 15.0, 7 },
                    { new Guid("cad67546-e0b2-461e-8869-e7325a770114"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"), 75.0, 4 },
                    { new Guid("cc851e84-814a-4c7f-826a-044b15ca5034"), 100.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"), 150.0, 2 },
                    { new Guid("d0c911ad-5812-46eb-906c-fc83e9c97522"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"), 15.0, 9 },
                    { new Guid("e5e8347e-d2e3-424e-b007-f5d4966954a0"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"), 15.0, 9 },
                    { new Guid("eb438c54-477a-4e09-9084-d453b96f9834"), 0.0, new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"), new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"), 75.0, 4 },
                    { new Guid("f2577898-1878-4309-9094-a94fa288f577"), 0.0, new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"), new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"), 15.0, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameId_PlayerId",
                table: "Results",
                columns: new[] { "GameId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_PlayerId",
                table: "Results",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
