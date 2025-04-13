using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circuitos.Migrations
{
    /// <inheritdoc />
    public partial class Circuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Carros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ano",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
