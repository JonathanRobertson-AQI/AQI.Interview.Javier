using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AQI.Interview.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumericValue = table.Column<double>(type: "REAL", precision: 18, scale: 6, nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Precision = table.Column<int>(type: "INTEGER", nullable: false),
                    Parameter = table.Column<int>(type: "INTEGER", nullable: false),
                    UTCCapturedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UTCSavedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
