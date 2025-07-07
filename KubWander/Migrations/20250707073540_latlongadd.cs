using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubWander.Migrations
{
    /// <inheritdoc />
    public partial class latlongadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "districts",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "districts",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "cities",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "cities",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "cities");
        }
    }
}
