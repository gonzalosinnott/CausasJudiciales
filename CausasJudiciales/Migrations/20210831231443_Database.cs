using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CausasJudiciales.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<int>(type: "int", nullable: true),
                    Representado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caratula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AceptaCargo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Actuacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<int>(type: "int", nullable: true),
                    Representado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caratula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Testigos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InicioDemanda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traslado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeDicteSentencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sentencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Regulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asesor");

            migrationBuilder.DropTable(
                name: "Beneficio");
        }
    }
}
