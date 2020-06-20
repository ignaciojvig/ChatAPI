using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    InterestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc"), "Kick Smaug out of the Lonely Mountain" },
                    { new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe"), "Chill in the Shire" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81"), "Thorin Oakenshield" },
                    { new Guid("6157cd72-b417-42a0-b109-f28ad7678833"), "Bilbo Baggings" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserId", "InterestId" },
                values: new object[] { new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81"), new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc") });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserId", "InterestId" },
                values: new object[] { new Guid("6157cd72-b417-42a0-b109-f28ad7678833"), new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe") });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
