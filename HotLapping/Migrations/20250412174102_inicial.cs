using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circuitos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),      
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Tracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                });

            migrationBuilder.CreateTable(
                name: "Circuitos",
                columns: table => new
                {
                    CircuitoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCurvas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recorde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordePiloto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordeCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuitos", x => x.CircuitoID);
                });

            migrationBuilder.CreateTable(
                name: "Voltas",
                columns: table => new
                {
                    VoltaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    CircuitoID = table.Column<int>(type: "int", nullable: false),
                    Tempo = table.Column<double>(type: "float", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voltas", x => x.VoltaID);
                    table.ForeignKey(
                        name: "FK_Voltas_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voltas_Circuitos_CircuitoID",
                        column: x => x.CircuitoID,
                        principalTable: "Circuitos",
                        principalColumn: "CircuitoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voltas_CarroID",
                table: "Voltas",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Voltas_CircuitoID",
                table: "Voltas",
                column: "CircuitoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voltas");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Circuitos");
        }
    }
}
