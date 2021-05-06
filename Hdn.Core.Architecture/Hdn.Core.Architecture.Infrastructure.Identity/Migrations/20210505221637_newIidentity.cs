using Microsoft.EntityFrameworkCore.Migrations;

namespace Hdn.Core.Architecture.Infrastructure.Identity.Migrations
{
    public partial class newIidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "TenantId",
               schema: "Identity",
               table: "User"
               
               );

            migrationBuilder.AddColumn<int>(
               name: "TenantId",
               schema: "Identity",
               table: "User",
               nullable: false
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
