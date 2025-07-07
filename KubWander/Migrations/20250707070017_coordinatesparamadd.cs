using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubWander.Migrations
{
    /// <inheritdoc />
    public partial class coordinatesparamadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "max_latitude",
                table: "districts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "max_longitude",
                table: "districts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_latitude",
                table: "districts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "min_longitude",
                table: "districts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "max_latitude",
                table: "cities",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "max_longitude",
                table: "cities",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_latitude",
                table: "cities",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "min_longitude",
                table: "cities",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_latitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "max_longitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "min_latitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "min_longitude",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "max_latitude",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "max_longitude",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "min_latitude",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "min_longitude",
                table: "cities");
        }
    }
}
