using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class DeleteBehaviourForUserInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Users_UserId",
                table: "UserInterests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
