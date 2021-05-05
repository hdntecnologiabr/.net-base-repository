using Microsoft.EntityFrameworkCore.Migrations;

namespace hdn.net.architecture.Infrastructure.Identity.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_ApplicationUser_ApplicationUserId",
                schema: "Identity",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Identity",
                table: "User");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "Identity",
                columns: table => new
                {
                    TempId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_ApplicationUser_TempId", x => x.TempId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_ApplicationUser_ApplicationUserId",
                schema: "Identity",
                table: "RefreshToken",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "ApplicationUser",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
