using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesREST.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BypassRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BypassDateTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassDateTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BypassDateTimes_BypassRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "BypassRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BypassRouteLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    BypassRouteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassRouteLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BypassRouteLocations_BypassRoutes_BypassRouteId",
                        column: x => x.BypassRouteId,
                        principalTable: "BypassRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BypassRoutePoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BypassRouteIndex = table.Column<int>(type: "integer", nullable: false),
                    NfcTagId = table.Column<string>(type: "text", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassRoutePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BypassRoutePoints_BypassRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "BypassRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performers_BypassRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "BypassRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BypassRoutePointDateTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoutePointId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassRoutePointDateTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BypassRoutePointDateTime_BypassRoutePoints_RoutePointId",
                        column: x => x.RoutePointId,
                        principalTable: "BypassRoutePoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BypassRoutePointLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    BypassRoutePointId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BypassRoutePointLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BypassRoutePointLocations_BypassRoutePoints_BypassRoutePoin~",
                        column: x => x.BypassRoutePointId,
                        principalTable: "BypassRoutePoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BypassDateTimes_RouteId",
                table: "BypassDateTimes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BypassRouteLocations_BypassRouteId",
                table: "BypassRouteLocations",
                column: "BypassRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BypassRoutePointDateTime_RoutePointId",
                table: "BypassRoutePointDateTime",
                column: "RoutePointId");

            migrationBuilder.CreateIndex(
                name: "IX_BypassRoutePointLocations_BypassRoutePointId",
                table: "BypassRoutePointLocations",
                column: "BypassRoutePointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BypassRoutePoints_RouteId",
                table: "BypassRoutePoints",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_RouteId",
                table: "Performers",
                column: "RouteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BypassDateTimes");

            migrationBuilder.DropTable(
                name: "BypassRouteLocations");

            migrationBuilder.DropTable(
                name: "BypassRoutePointDateTime");

            migrationBuilder.DropTable(
                name: "BypassRoutePointLocations");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "BypassRoutePoints");

            migrationBuilder.DropTable(
                name: "BypassRoutes");
        }
    }
}
