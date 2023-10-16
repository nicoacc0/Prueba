using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.Migrations
{
    public partial class UnionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "TblProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblProductos_CategoriaId",
                table: "TblProductos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProductos_TblCategorias_CategoriaId",
                table: "TblProductos",
                column: "CategoriaId",
                principalTable: "TblCategorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProductos_TblCategorias_CategoriaId",
                table: "TblProductos");

            migrationBuilder.DropIndex(
                name: "IX_TblProductos_CategoriaId",
                table: "TblProductos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "TblProductos");
        }
    }
}
