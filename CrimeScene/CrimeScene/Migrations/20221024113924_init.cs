using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeScene.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lawEnforcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RankEnforcementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lawEnforcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lawEnforcements_ranks_RankEnforcementId",
                        column: x => x.RankEnforcementId,
                        principalTable: "ranks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrimeEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postalCode = table.Column<float>(type: "real", nullable: true),
                    isAssigend = table.Column<bool>(type: "bit", nullable: true),
                    isFinished = table.Column<bool>(type: "bit", nullable: true),
                    lawEnforcement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LawEnforcementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrimeEvent_lawEnforcements_LawEnforcementId",
                        column: x => x.LawEnforcementId,
                        principalTable: "lawEnforcements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvent_LawEnforcementId",
                table: "CrimeEvent",
                column: "LawEnforcementId");

            migrationBuilder.CreateIndex(
                name: "IX_lawEnforcements_RankEnforcementId",
                table: "lawEnforcements",
                column: "RankEnforcementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEvent");

            migrationBuilder.DropTable(
                name: "lawEnforcements");

            migrationBuilder.DropTable(
                name: "ranks");
        }
    }
}
