using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations.DataContextTaxMigrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AverageRate",
                columns: table => new
                {
                    AveRateId = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AverageRate", x => x.AveRateId);
                });

            migrationBuilder.CreateTable(
                name: "MinimumRate",
                columns: table => new
                {
                    minRateId = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumRate", x => x.minRateId);
                });

            migrationBuilder.CreateTable(
                name: "rate",
                columns: table => new
                {
                    zip = table.Column<string>(nullable: false),
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
                    state_rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rate", x => x.zip);
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
                name: "summaryRate",
                columns: table => new
                {
                    SummaryId = table.Column<Guid>(nullable: false),
                    country_code = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    region_code = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    minimum_rateminRateId = table.Column<Guid>(nullable: true),
                    average_rateAveRateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_summaryRate", x => x.SummaryId);
                    table.ForeignKey(
                        name: "FK_summaryRate_AverageRate_average_rateAveRateId",
                        column: x => x.average_rateAveRateId,
                        principalTable: "AverageRate",
                        principalColumn: "AveRateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_summaryRate_MinimumRate_minimum_rateminRateId",
                        column: x => x.minimum_rateminRateId,
                        principalTable: "MinimumRate",
                        principalColumn: "minRateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ratezip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.id);
                    table.ForeignKey(
                        name: "FK_rates_rate_ratezip",
                        column: x => x.ratezip,
                        principalTable: "rate",
                        principalColumn: "zip",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rates_ratezip",
                table: "rates",
                column: "ratezip");

            migrationBuilder.CreateIndex(
                name: "IX_summaryRate_average_rateAveRateId",
                table: "summaryRate",
                column: "average_rateAveRateId");

            migrationBuilder.CreateIndex(
                name: "IX_summaryRate_minimum_rateminRateId",
                table: "summaryRate",
                column: "minimum_rateminRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "summaryRate");

            migrationBuilder.DropTable(
                name: "taxItem");

            migrationBuilder.DropTable(
                name: "rate");

            migrationBuilder.DropTable(
                name: "AverageRate");

            migrationBuilder.DropTable(
                name: "MinimumRate");
        }
    }
}
