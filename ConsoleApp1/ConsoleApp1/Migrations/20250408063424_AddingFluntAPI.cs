using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddingFluntAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Flights_FlightId",
                table: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_Crews_FlightId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Crews");

            migrationBuilder.CreateTable(
                name: "CrewFlight",
                columns: table => new
                {
                    CrewsId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewFlight", x => new { x.CrewsId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_CrewFlight_Crews_CrewsId",
                        column: x => x.CrewsId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewFlight_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewFlight_FlightId",
                table: "CrewFlight",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "CrewFlight");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Crews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_FlightId",
                table: "Crews",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Flights_FlightId",
                table: "Crews",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
