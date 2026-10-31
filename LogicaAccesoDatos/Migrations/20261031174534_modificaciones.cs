using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class modificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historias_Capitulos_CapituloInicialId",
                table: "Historias");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "Capitulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_HistoriaId",
                table: "Capitulos",
                column: "HistoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capitulos_Historias_HistoriaId",
                table: "Capitulos",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_Capitulos_CapituloInicialId",
                table: "Historias",
                column: "CapituloInicialId",
                principalTable: "Capitulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capitulos_Historias_HistoriaId",
                table: "Capitulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Historias_Capitulos_CapituloInicialId",
                table: "Historias");

            migrationBuilder.DropIndex(
                name: "IX_Capitulos_HistoriaId",
                table: "Capitulos");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "Capitulos");

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_Capitulos_CapituloInicialId",
                table: "Historias",
                column: "CapituloInicialId",
                principalTable: "Capitulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
