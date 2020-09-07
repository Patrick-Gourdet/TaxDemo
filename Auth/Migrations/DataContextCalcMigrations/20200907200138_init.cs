using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations.DataContextCalcMigrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taxCalcItem",
                columns: table => new
                {
                    CalcId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Percent = table.Column<decimal>(nullable: false),
                    CalculatedAmount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TaxId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxCalcItem", x => x.CalcId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taxCalcItem");
        }
    }
}
