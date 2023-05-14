using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exer6_01.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturerFoundedDate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                schema: "factory",
                table: "manufacturer",
                newName: "FoundedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundedAt",
                schema: "factory",
                table: "manufacturer",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoundedAt",
                schema: "factory",
                table: "manufacturer",
                newName: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                schema: "factory",
                table: "manufacturer",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
