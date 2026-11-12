using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapituloActualId",
                table: "Lecturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CapituloInicialId",
                table: "Historias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturas_CapituloActualId",
                table: "Lecturas",
                column: "CapituloActualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturas_Capitulos_CapituloActualId",
                table: "Lecturas",
                column: "CapituloActualId",
                principalTable: "Capitulos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturas_Capitulos_CapituloActualId",
                table: "Lecturas");

            migrationBuilder.DropIndex(
                name: "IX_Lecturas_CapituloActualId",
                table: "Lecturas");

            migrationBuilder.DropColumn(
                name: "CapituloActualId",
                table: "Lecturas");

            migrationBuilder.AlterColumn<int>(
                name: "CapituloInicialId",
                table: "Historias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
