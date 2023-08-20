using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScraper_PropertyResearch.Migrations
{
    public partial class ManyToManySiteCheckMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsedSiteChecks",
                columns: table => new
                {
                    UsedSiteCheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SiteCheckId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedSiteChecks", x => x.UsedSiteCheckId);
                    table.ForeignKey(
                        name: "FK_UsedSiteChecks_SiteChecks_SiteCheckId",
                        column: x => x.SiteCheckId,
                        principalTable: "SiteChecks",
                        principalColumn: "SiteCheckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedSiteChecks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSiteChecks_SiteCheckId",
                table: "UsedSiteChecks",
                column: "SiteCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSiteChecks_UserId",
                table: "UsedSiteChecks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsedSiteChecks");
        }
    }
}
