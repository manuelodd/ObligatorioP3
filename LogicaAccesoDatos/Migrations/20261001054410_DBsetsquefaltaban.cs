using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class DBsetsquefaltaban : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CantidadVecesAlcanzado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapituloInicialId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Capitulos_CapituloInicialId",
                        column: x => x.CapituloInicialId,
                        principalTable: "Capitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiguienteCapituloId = table.Column<int>(type: "int", nullable: false),
                    IntermedioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opciones_Capitulos_IntermedioId",
                        column: x => x.IntermedioId,
                        principalTable: "Capitulos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opciones_Capitulos_SiguienteCapituloId",
                        column: x => x.SiguienteCapituloId,
                        principalTable: "Capitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalAlcanzadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectura_Capitulos_FinalAlcanzadoId",
                        column: x => x.FinalAlcanzadoId,
                        principalTable: "Capitulos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lectura_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectura_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_HistoriaId",
                table: "Categorias",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_CapituloInicialId",
                table: "Historias",
                column: "CapituloInicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_FinalAlcanzadoId",
                table: "Lectura",
                column: "FinalAlcanzadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_HistoriaId",
                table: "Lectura",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectura_UsuarioId",
                table: "Lectura",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Opciones_IntermedioId",
                table: "Opciones",
                column: "IntermedioId");

            migrationBuilder.CreateIndex(
                name: "IX_Opciones_SiguienteCapituloId",
                table: "Opciones",
                column: "SiguienteCapituloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Lectura");

            migrationBuilder.DropTable(
                name: "Opciones");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Capitulos");
        }
    }
}
