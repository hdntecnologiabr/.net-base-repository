using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hdn.net.architecture.Infrastructure.Identity.Migrations
{
    public partial class tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "Identity",
                table: "User",
                nullable: false                
                );
        }

    }
}
