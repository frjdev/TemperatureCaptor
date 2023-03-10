// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Temperature.Infrastructure;

#nullable disable

namespace Temperature.Infrastructure.Migrations
{
    [DbContext(typeof(TemperatureContext))]
    [Migration("20230221134759_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Temperature.Infrastructure.TemperatureData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<double>("Temp")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TemperatureSet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 435, DateTimeKind.Local).AddTicks(5694),
                            State = "WARM",
                            Temp = 22.0
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2970),
                            State = "COLD",
                            Temp = -3.0
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2993),
                            State = "HOT",
                            Temp = 37.0
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2997),
                            State = "HOT",
                            Temp = 39.0
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(2998),
                            State = "HOT",
                            Temp = 37.0
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3011),
                            State = "HOT",
                            Temp = 41.0
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3013),
                            State = "HOT",
                            Temp = 41.0
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3016),
                            State = "HOT",
                            Temp = 40.0
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3017),
                            State = "HOT",
                            Temp = 32.0
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3020),
                            State = "HOT",
                            Temp = 34.0
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3021),
                            State = "WARM",
                            Temp = 25.0
                        },
                        new
                        {
                            Id = 12,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3023),
                            State = "WARM",
                            Temp = 26.0
                        },
                        new
                        {
                            Id = 13,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3024),
                            State = "COLD",
                            Temp = 20.0
                        },
                        new
                        {
                            Id = 14,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3027),
                            State = "COLD",
                            Temp = 16.0
                        },
                        new
                        {
                            Id = 15,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3028),
                            State = "COLD",
                            Temp = 14.0
                        },
                        new
                        {
                            Id = 16,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3030),
                            State = "COLD",
                            Temp = -3.0
                        },
                        new
                        {
                            Id = 17,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3031),
                            State = "HOT",
                            Temp = 30.0
                        },
                        new
                        {
                            Id = 18,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3034),
                            State = "WARM",
                            Temp = 28.0
                        },
                        new
                        {
                            Id = 19,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3036),
                            State = "WARM",
                            Temp = 26.0
                        },
                        new
                        {
                            Id = 20,
                            Date = new DateTime(2023, 2, 21, 14, 47, 59, 438, DateTimeKind.Local).AddTicks(3037),
                            State = "COLD",
                            Temp = -3.0
                        });
                });

            modelBuilder.Entity("Temperature.Infrastructure.TemperatureDataRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("End")
                        .HasColumnType("REAL");

                    b.Property<double>("Start")
                        .HasColumnType("REAL");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TemperatureRangeSet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = 40.0,
                            Start = 22.0,
                            State = "WARM"
                        },
                        new
                        {
                            Id = 2,
                            End = -60.0,
                            Start = 22.0,
                            State = "COLD"
                        },
                        new
                        {
                            Id = 3,
                            End = -60.0,
                            Start = 40.0,
                            State = "HOT"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
