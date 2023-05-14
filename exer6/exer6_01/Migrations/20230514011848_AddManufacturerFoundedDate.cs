using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exer6_01.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturerFoundedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                schema: "factory",
                table: "manufacturer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                schema: "factory",
                table: "manufacturer");
        }
    }
}
