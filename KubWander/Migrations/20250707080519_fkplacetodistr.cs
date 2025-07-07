using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubWander.Migrations
{
    /// <inheritdoc />
    public partial class fkplacetodistr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "places",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_places_DistrictId",
                table: "places",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_places_districts_DistrictId",
                table: "places",
                column: "DistrictId",
                principalTable: "districts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_places_districts_DistrictId",
                table: "places");

            migrationBuilder.DropIndex(
                name: "IX_places_DistrictId",
                table: "places");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "places");
        }
    }
}
