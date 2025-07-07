using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubWander.Migrations
{
    /// <inheritdoc />
    public partial class PlaceToVisitAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "latitude",
                table: "places",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "places",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "places");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "places");

            
        }
    }
}
