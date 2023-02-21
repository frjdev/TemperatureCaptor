using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Temperature.Infrastructure.Migrations;

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
                { 1, 40.0, 22.0, "WARM" },
                { 2, -60.0, 22.0, "COLD" },
                { 3, -60.0, 40.0, "HOT" }
            });

        migrationBuilder.InsertData(
            table: "TemperatureSet",
            columns: new[] { "Id", "Date", "State", "Temp" },
            values: new object[,]
            {
                { 1, new DateTime(2023, 2, 21, 12, 28, 32, 171, DateTimeKind.Local).AddTicks(8353), "WARM", 22.0 },
                { 2, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4505), "COLD", -3.0 },
                { 3, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4534), "HOT", 37.0 },
                { 4, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4537), "HOT", 39.0 },
                { 5, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4539), "HOT", 37.0 },
                { 6, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4547), "HOT", 41.0 },
                { 7, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4549), "HOT", 41.0 },
                { 8, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4551), "HOT", 40.0 },
                { 9, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4604), "HOT", 32.0 },
                { 10, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4607), "HOT", 34.0 },
                { 11, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4609), "WARM", 25.0 },
                { 12, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4611), "WARM", 26.0 },
                { 13, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4613), "COLD", 20.0 },
                { 14, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4614), "COLD", 16.0 },
                { 15, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4616), "COLD", 14.0 },
                { 16, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4618), "COLD", -3.0 },
                { 17, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4620), "HOT", 30.0 },
                { 18, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4623), "WARM", 28.0 },
                { 19, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4624), "WARM", 26.0 },
                { 20, new DateTime(2023, 2, 21, 12, 28, 32, 175, DateTimeKind.Local).AddTicks(4626), "COLD", -3.0 }
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
