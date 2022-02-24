using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TripplanetAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "urls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    small = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    positionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_location_position_positionId",
                        column: x => x.positionId,
                        principalTable: "position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id = table.Column<string>(type: "text", nullable: false),
                    urlsId = table.Column<int>(type: "integer", nullable: true),
                    locationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_location_locationId",
                        column: x => x.locationId,
                        principalTable: "location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_urls_urlsId",
                        column: x => x.urlsId,
                        principalTable: "urls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_location_positionId",
                table: "location",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_locationId",
                table: "Location",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_urlsId",
                table: "Location",
                column: "urlsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "urls");

            migrationBuilder.DropTable(
                name: "position");
        }
    }
}
