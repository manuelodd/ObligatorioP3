using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cancer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Historias_HistoriaId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_HistoriaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "Categorias");

            migrationBuilder.AlterColumn<int>(
                name: "CapituloInicialId",
                table: "Historias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CategoriaHistoria",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaHistoria", x => new { x.CategoriasId, x.HistoriaId });
                    table.ForeignKey(
                        name: "FK_CategoriaHistoria_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaHistoria_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaHistoria_HistoriaId",
                table: "CategoriaHistoria",
                column: "HistoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaHistoria");

            migrationBuilder.AlterColumn<int>(
                name: "CapituloInicialId",
                table: "Historias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_HistoriaId",
                table: "Categorias",
                column: "HistoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Historias_HistoriaId",
                table: "Categorias",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id");
        }
    }
}
