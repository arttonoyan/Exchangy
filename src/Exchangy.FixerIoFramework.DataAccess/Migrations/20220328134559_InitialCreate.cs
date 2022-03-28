using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchangy.FixerIoFramework.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyRequests",
                columns: table => new
                {
                    CurrencyRequestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseCurrency = table.Column<string>(type: "TEXT", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRequests", x => x.CurrencyRequestId);
                });

            migrationBuilder.CreateTable(
                name: "RateResults",
                columns: table => new
                {
                    RateResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Rate = table.Column<double>(type: "REAL", nullable: false),
                    CurrencyRequestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateResults", x => x.RateResultId);
                    table.ForeignKey(
                        name: "FK_RateResults_CurrencyRequests_CurrencyRequestId",
                        column: x => x.CurrencyRequestId,
                        principalTable: "CurrencyRequests",
                        principalColumn: "CurrencyRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RateResults_CurrencyRequestId",
                table: "RateResults",
                column: "CurrencyRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateResults");

            migrationBuilder.DropTable(
                name: "CurrencyRequests");
        }
    }
}
