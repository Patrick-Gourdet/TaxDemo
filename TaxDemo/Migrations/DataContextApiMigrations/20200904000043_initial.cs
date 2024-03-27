using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxDemo.Migrations.DataContextApiMigrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apiDBItem",
                columns: table => new
                {
                    ApiId = table.Column<Guid>(nullable: false),
                    APIName = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    UserHash = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apiDBItem", x => x.ApiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apiDBItem");
        }
    }
}
