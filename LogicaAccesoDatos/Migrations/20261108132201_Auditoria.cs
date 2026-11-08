using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Auditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectura_Capitulos_FinalAlcanzadoId",
                table: "Lectura");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectura_Historias_HistoriaId",
                table: "Lectura");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectura_Usuarios_UsuarioId",
                table: "Lectura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectura",
                table: "Lectura");

            migrationBuilder.RenameTable(
                name: "Lectura",
                newName: "Lecturas");

            migrationBuilder.RenameIndex(
                name: "IX_Lectura_UsuarioId",
                table: "Lecturas",
                newName: "IX_Lecturas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Lectura_HistoriaId",
                table: "Lecturas",
                newName: "IX_Lecturas_HistoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lectura_FinalAlcanzadoId",
                table: "Lecturas",
                newName: "IX_Lecturas_FinalAlcanzadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturas",
                table: "Lecturas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturas_Capitulos_FinalAlcanzadoId",
                table: "Lecturas",
                column: "FinalAlcanzadoId",
                principalTable: "Capitulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturas_Historias_HistoriaId",
                table: "Lecturas",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturas_Usuarios_UsuarioId",
                table: "Lecturas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturas_Capitulos_FinalAlcanzadoId",
                table: "Lecturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturas_Historias_HistoriaId",
                table: "Lecturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturas_Usuarios_UsuarioId",
                table: "Lecturas");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturas",
                table: "Lecturas");

            migrationBuilder.RenameTable(
                name: "Lecturas",
                newName: "Lectura");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturas_UsuarioId",
                table: "Lectura",
                newName: "IX_Lectura_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturas_HistoriaId",
                table: "Lectura",
                newName: "IX_Lectura_HistoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturas_FinalAlcanzadoId",
                table: "Lectura",
                newName: "IX_Lectura_FinalAlcanzadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectura",
                table: "Lectura",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectura_Capitulos_FinalAlcanzadoId",
                table: "Lectura",
                column: "FinalAlcanzadoId",
                principalTable: "Capitulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectura_Historias_HistoriaId",
                table: "Lectura",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectura_Usuarios_UsuarioId",
                table: "Lectura",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
