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
            name: "TemperatureRangeSet",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                State = table.Column<string>(type: "TEXT", nullable: false),
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
            table: "TemperatureRangeSet",
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
                { 1, new DateTime(2023, 2, 21, 14, 47, 59, 435, DateTimeKind.Local).AddTicks(5694), "WARM", 22.0 },
                { 2, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2970), "COLD", -3.0 },
                { 3, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2993), "HOT", 37.0 },
                { 4, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2997), "HOT", 39.0 },
                { 5, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2998), "HOT", 37.0 },
                { 6, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3011), "HOT", 41.0 },
                { 7, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3013), "HOT", 41.0 },
                { 8, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3016), "HOT", 40.0 },
                { 9, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3017), "HOT", 32.0 },
                { 10, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3020), "HOT", 34.0 },
                { 11, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3021), "WARM", 25.0 },
                { 12, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3023), "WARM", 26.0 },
                { 13, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3024), "COLD", 20.0 },
                { 14, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3027), "COLD", 16.0 },
                { 15, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3028), "COLD", 14.0 },
                { 16, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3030), "COLD", -3.0 },
                { 17, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3031), "HOT", 30.0 },
                { 18, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3034), "WARM", 28.0 },
                { 19, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3036), "WARM", 26.0 },
                { 20, new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3037), "COLD", -3.0 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TemperatureRangeSet");

        migrationBuilder.DropTable(
            name: "TemperatureSet");
    }
}
