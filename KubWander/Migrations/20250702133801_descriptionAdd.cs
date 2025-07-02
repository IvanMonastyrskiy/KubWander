using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KubWander.Migrations
{
    /// <inheritdoc />
    public partial class descriptionAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "description",
            table: "cities",
            type: "text", // или другой тип, например, "nvarchar(255)", если нужна ограниченная длина
            nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "description",
            table: "cities");
        }
    }
}
