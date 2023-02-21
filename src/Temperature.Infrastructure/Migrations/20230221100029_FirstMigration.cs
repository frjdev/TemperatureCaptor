using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Temperature.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Start = table.Column<double>(type: "REAL", nullable: false),
                    End = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureRangeSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Start = table.Column<double>(type: "REAL", nullable: false),
                    End = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureRangeSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temp = table.Column<double>(type: "REAL", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureSet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TemperatureRange",
                columns: new[] { "Id", "End", "Start", "State" },
                values: new object[,]
                {
                    { 1, 60.0, 40.0, "HOT" },
                    { 2, -50.0, 22.0, "COLD" },
                    { 3, 40.0, 22.0, "WARM" }
                });

            migrationBuilder.InsertData(
                table: "TemperatureSet",
                columns: new[] { "Id", "Date", "State", "Temp" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 21, 11, 0, 29, 124, DateTimeKind.Local).AddTicks(5887), "COLD", 4.0 },
                    { 2, new DateTime(2023, 2, 21, 11, 0, 29, 124, DateTimeKind.Local).AddTicks(5974), "HOT", 41.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureRange");

            migrationBuilder.DropTable(
                name: "TemperatureRangeSet");

            migrationBuilder.DropTable(
                name: "TemperatureSet");
        }
    }
}
