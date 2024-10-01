using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ass1gnment.Migrations
{
    /// <inheritdoc />
    public partial class Innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_Measurement_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Standing" },
                    { 2, "Sitting" },
                    { 3, "Supine" }
                });

            migrationBuilder.InsertData(
                table: "Measurement",
                columns: new[] { "MeasurementID", "Date", "Diastolic", "PositionID", "Systolic" },
                values: new object[,]
                {
                    { 1, new DateTime(2008, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 1, 181 },
                    { 2, new DateTime(2025, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 3, 142 },
                    { 3, new DateTime(2002, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1, 131 },
                    { 4, new DateTime(1998, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2, 122 },
                    { 5, new DateTime(1996, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2, 188 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_PositionID",
                table: "Measurement",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
