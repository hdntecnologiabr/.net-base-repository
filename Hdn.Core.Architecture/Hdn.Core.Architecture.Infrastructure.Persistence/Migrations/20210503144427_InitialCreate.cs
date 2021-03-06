using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hdn.Core.Architecture.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
         name: "Tenants",
         columns: table => new
         {
             Id = table.Column<int>(nullable: false)
                 .Annotation("SqlServer:Identity", "1, 1"),
             RowId = table.Column<Guid>(nullable: false),
             Created = table.Column<DateTime>(nullable: false),
             CreatedBy = table.Column<string>(nullable: true),
             UpdatedBy = table.Column<string>(nullable: true),
             Updated = table.Column<DateTime>(nullable: true),
             Name = table.Column<string>(nullable: true),
             
         },
         constraints: table =>
         {
             table.PrimaryKey("PK_Tenants", x => x.Id);             
         });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true), 
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey("FK_Tenants", x => x.TenantId, "Tenants", "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
