using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class Initial : Migration
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
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleClaim_UserClaim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "UserClaim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleClaim_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    InterestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc"), "Kick Smaug out of the Lonely Mountain" },
                    { new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe"), "Chill in the Shire" },
                    { new Guid("7de7833e-a6c1-4876-a596-564449b65835"), "Simply enter Mordor and destroy the One Ring where it was created" }
                });

            migrationBuilder.InsertData(
                table: "UserClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("55b5effa-7ea4-4e32-9bb8-e0bdd191b86e"), "AdminClaim" },
                    { new Guid("e66c0c35-fa66-4e69-9235-3eba45aca3d4"), "UsersManagement" },
                    { new Guid("4cad8312-1f57-48de-99a8-1a1a7caa00c6"), "InterestsManagement" },
                    { new Guid("c2d8ad4d-e248-48fc-be4b-ee3ef15eaa1d"), "UserInterestsManagement" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("bb3af9ee-4d11-4f2d-8c5c-5cc9d5efd9e0"), "Admin" },
                    { new Guid("4df22b4f-27ca-48b9-a1c4-185200a5cdf1"), "Manager" },
                    { new Guid("f9ae2877-5bee-4317-bbc5-0b12f82cb854"), "Regular User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleClaim",
                columns: new[] { "Id", "ClaimId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("d82abfa6-a769-4097-8233-4add1d495b64"), new Guid("55b5effa-7ea4-4e32-9bb8-e0bdd191b86e"), new Guid("bb3af9ee-4d11-4f2d-8c5c-5cc9d5efd9e0") },
                    { new Guid("5169c192-5c95-4ef4-8ff6-9bf790b2a05f"), new Guid("e66c0c35-fa66-4e69-9235-3eba45aca3d4"), new Guid("4df22b4f-27ca-48b9-a1c4-185200a5cdf1") },
                    { new Guid("c61451f5-46e6-4f6f-a97c-70139614971e"), new Guid("4cad8312-1f57-48de-99a8-1a1a7caa00c6"), new Guid("4df22b4f-27ca-48b9-a1c4-185200a5cdf1") },
                    { new Guid("6e4eb59e-5e1a-494f-b06c-2d03322c664d"), new Guid("c2d8ad4d-e248-48fc-be4b-ee3ef15eaa1d"), new Guid("4df22b4f-27ca-48b9-a1c4-185200a5cdf1") },
                    { new Guid("5850951a-f951-492e-8bc7-3767cd7aecc5"), new Guid("4cad8312-1f57-48de-99a8-1a1a7caa00c6"), new Guid("f9ae2877-5bee-4317-bbc5-0b12f82cb854") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "UserRoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81"), "Thorin Oakenshield", "oaken123", new Guid("bb3af9ee-4d11-4f2d-8c5c-5cc9d5efd9e0"), "thorin123" },
                    { new Guid("6157cd72-b417-42a0-b109-f28ad7678833"), "Bilbo Baggings", "baggings123", new Guid("4df22b4f-27ca-48b9-a1c4-185200a5cdf1"), "bilbo123" },
                    { new Guid("39bf4b9a-44b3-47d7-8b90-e08c0ec2c9cb"), "Frodo Baggings", "baggins123", new Guid("f9ae2877-5bee-4317-bbc5-0b12f82cb854"), "frodo123" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "UserId" },
                values: new object[] { new Guid("24e1abe0-b74c-409c-a14d-06827c322273"), new Guid("7956b9f9-95e6-4d71-ac4b-511a4df952bc"), new Guid("d17fee25-322c-40e9-a18f-98b2f03faf81") });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "UserId" },
                values: new object[] { new Guid("cab8b16d-60b0-4ec2-82bf-01304d2dcb05"), new Guid("0394b33b-dc5e-4924-a565-0c4cb876d7fe"), new Guid("6157cd72-b417-42a0-b109-f28ad7678833") });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "UserId" },
                values: new object[] { new Guid("53c915bb-2af2-4228-bc06-5caa43ba6941"), new Guid("7de7833e-a6c1-4876-a596-564449b65835"), new Guid("39bf4b9a-44b3-47d7-8b90-e08c0ec2c9cb") });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaim_ClaimId",
                table: "UserRoleClaim",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaim_RoleId",
                table: "UserRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "UserRoleClaim");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
