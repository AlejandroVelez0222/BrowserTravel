using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrowserTravel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MarketRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MarketId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerLocation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RentalLocation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketRules_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CardPlateId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PricePerDay = table.Column<double>(type: "double", nullable: false),
                    MarketId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.UniqueConstraint("AK_Vehicles_CardPlateId", x => x.CardPlateId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CardPlateId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLocations_Vehicles_CardPlateId",
                        column: x => x.CardPlateId,
                        principalTable: "Vehicles",
                        principalColumn: "CardPlateId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "LATAM" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "EU" }
                });

            migrationBuilder.InsertData(
                table: "MarketRules",
                columns: new[] { "Id", "CustomerLocation", "MarketId", "RentalLocation" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Bogotá", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Medellín" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Cali", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cartagena" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Medellín", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Bogotá" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "Cartagena", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Cali" },
                    { new Guid("22222222-2222-2222-2222-222222222221"), "Paris", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Lyon" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Berlin", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Munich" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), "Madrid", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Barcelona" },
                    { new Guid("22222222-2222-2222-2222-222222222224"), "Rome", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Florence" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CardPlateId", "Category", "MarketId", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333331"), "Toyota", "ABC123", "Sedan", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Corolla", 150000.0, 2020 },
                    { new Guid("33333333-3333-3333-3333-333333333332"), "Mazda", "XYZ789", "SUV", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "CX-5", 220000.0, 2022 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Chevrolet", "JKL456", "Hatchback", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Spark GT", 120000.0, 2019 },
                    { new Guid("33333333-3333-3333-3333-333333333334"), "Ford", "QWE321", "Pickup", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Ranger", 300000.0, 2021 },
                    { new Guid("33333333-3333-3333-3333-333333333335"), "BMW", "LMN987", "SUV", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "X3", 350000.0, 2021 },
                    { new Guid("33333333-3333-3333-3333-333333333336"), "Audi", "OPQ654", "Sedan", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "A4", 300000.0, 2020 }
                });

            migrationBuilder.InsertData(
                table: "VehicleLocations",
                columns: new[] { "Id", "CardPlateId", "IsAvailable", "Location" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444441"), "ABC123", true, "Bogotá" },
                    { new Guid("44444444-4444-4444-4444-444444444442"), "ABC123", true, "Medellín" },
                    { new Guid("44444444-4444-4444-4444-444444444443"), "XYZ789", false, "Bogotá" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "XYZ789", true, "Cartagena" },
                    { new Guid("55555555-5555-5555-5555-555555555551"), "JKL456", true, "Medellín" },
                    { new Guid("55555555-5555-5555-5555-555555555552"), "JKL456", false, "Cali" },
                    { new Guid("55555555-5555-5555-5555-555555555553"), "QWE321", true, "Bogotá" },
                    { new Guid("55555555-5555-5555-5555-555555555554"), "QWE321", true, "Barranquilla" },
                    { new Guid("66666666-6666-6666-6666-666666666661"), "LMN987", true, "Paris" },
                    { new Guid("66666666-6666-6666-6666-666666666662"), "LMN987", false, "Lyon" },
                    { new Guid("66666666-6666-6666-6666-666666666663"), "OPQ654", true, "Berlin" },
                    { new Guid("66666666-6666-6666-6666-666666666664"), "OPQ654", true, "Munich" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketRules_MarketId",
                table: "MarketRules",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocations_CardPlateId",
                table: "VehicleLocations",
                column: "CardPlateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CardPlateId",
                table: "Vehicles",
                column: "CardPlateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MarketId",
                table: "Vehicles",
                column: "MarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketRules");

            migrationBuilder.DropTable(
                name: "VehicleLocations");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Markets");
        }
    }
}
