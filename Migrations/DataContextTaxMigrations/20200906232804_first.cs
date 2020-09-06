using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations.DataContextTaxMigrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubRate",
                columns: table => new
                {
                    rate_id = table.Column<Guid>(nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    city = table.Column<string>(nullable: true),
                    city_rate = table.Column<string>(nullable: true),
                    combined_district_rate = table.Column<string>(nullable: true),
                    combined_rate = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    country_rate = table.Column<string>(nullable: true),
                    county = table.Column<string>(nullable: true),
                    county_rate = table.Column<string>(nullable: true),
                    freight_taxable = table.Column<bool>(nullable: false),
                    state = table.Column<string>(nullable: true),
                    state_rate = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRate", x => x.rate_id);
                });

            migrationBuilder.CreateTable(
                name: "taxItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustmerName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EndpointUsed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    SubRateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.id);
                    table.ForeignKey(
                        name: "FK_rates_SubRate_SubRateId",
                        column: x => x.SubRateId,
                        principalTable: "SubRate",
                        principalColumn: "rate_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rates_SubRateId",
                table: "rates",
                column: "SubRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "taxItem");

            migrationBuilder.DropTable(
                name: "SubRate");
        }
    }
}
