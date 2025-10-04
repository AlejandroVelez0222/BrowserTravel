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
                    Market = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PricePerDay = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.UniqueConstraint("AK_Vehicles_CardPlateId", x => x.CardPlateId);
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
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CardPlateId", "Category", "Market", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { new Guid("06f03e74-6df8-4dbf-8c5c-409312d10d50"), "Mazda", "XYZ789", "SUV", "LATAM", "CX-5", 220000.0, 2022 },
                    { new Guid("31092cfc-ba1a-426c-8697-80684e113458"), "Toyota", "ABC123", "Sedan", "LATAM", "Corolla", 150000.0, 2020 },
                    { new Guid("4b43397e-e400-4383-b890-88888dd78445"), "Chevrolet", "JKL456", "Hatchback", "LATAM", "Spark GT", 120000.0, 2019 },
                    { new Guid("7d70a7eb-3502-4612-a06c-3db59820a6ea"), "Ford", "QWE321", "Pickup", "LATAM", "Ranger", 300000.0, 2021 }
                });

            migrationBuilder.InsertData(
                table: "VehicleLocations",
                columns: new[] { "Id", "CardPlateId", "IsAvailable", "Location" },
                values: new object[,]
                {
                    { new Guid("43bfda21-fb01-4d9c-9cf4-f8450e276ab4"), "JKL456", false, "Cali" },
                    { new Guid("456d8f5a-a81a-4dc7-bd81-d215123d2c1a"), "XYZ789", false, "Bogotá" },
                    { new Guid("5dd7a6ba-e33d-4ecf-91b6-51012c4aa821"), "XYZ789", true, "Cartagena" },
                    { new Guid("6726b0eb-1f58-447e-803e-a780fde26e7f"), "QWE321", true, "Bogotá" },
                    { new Guid("78fbe1db-73d4-427c-8eb7-709d82e48cc5"), "JKL456", true, "Medellín" },
                    { new Guid("8dad1da3-6788-4616-9158-4be7f19f92c4"), "QWE321", true, "Barranquilla" },
                    { new Guid("c37b3f1a-c0f9-4d69-93c4-bd097d2a5118"), "ABC123", true, "Bogotá" },
                    { new Guid("e37a9aed-e225-4d7f-ae44-3c3e693a3270"), "ABC123", true, "Medellín" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocations_CardPlateId",
                table: "VehicleLocations",
                column: "CardPlateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CardPlateId",
                table: "Vehicles",
                column: "CardPlateId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleLocations");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
