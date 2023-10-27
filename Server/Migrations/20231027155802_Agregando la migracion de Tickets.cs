using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migracion_Tarea1_Hasta_Tarea4.Server.Migrations
{
    /// <inheritdoc />
    public partial class AgregandolamigraciondeTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SolicitadoPor = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Asunto = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
