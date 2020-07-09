using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class ChangesInKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { new Guid("6157cd72-b417-42a0-b109-f28ad7678833"), new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe") });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "UserId", "InterestId" },
                keyValues: new object[] { new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81"), new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc") });

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserInterests",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "UserId" },
                values: new object[] { new Guid("24e1abe0-b74c-409c-a14d-06827c322273"), new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc"), new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81") });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "UserId" },
                values: new object[] { new Guid("cab8b16d-60b0-4ec2-82bf-01304d2dcb05"), new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe"), new Guid("6157cd72-b417-42a0-b109-f28ad7678833") });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DropIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserInterests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                columns: new[] { "UserId", "InterestId" });
        }
    }
}
