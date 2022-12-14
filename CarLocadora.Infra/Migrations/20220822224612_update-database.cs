using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.Infra.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_CategoriaId",
                table: "Veiculos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Categorias_CategoriaId",
                table: "Veiculos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Categorias_CategoriaId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_CategoriaId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Veiculos");
        }
    }
}
