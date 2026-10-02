using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestorLigaFutbol.API.Migrations
{
    /// <inheritdoc />
    public partial class V001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    capacidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ligas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    pais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    temporada = table.Column<string>(type: "varchar(22)", maxLength: 22, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    anio_fundacion = table.Column<int>(type: "integer", nullable: false),
                    liga_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipos", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipos_ligas_liga_id",
                        column: x => x.liga_id,
                        principalTable: "ligas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jugadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    posicion = table.Column<string>(type: "varchar(20)", nullable: false),
                    dorsal_camisa = table.Column<int>(type: "integer", nullable: false),
                    equipo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jugadores", x => x.id);
                    table.ForeignKey(
                        name: "FK_jugadores_equipos_equipo_id",
                        column: x => x.equipo_id,
                        principalTable: "equipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_hora = table.Column<DateTime>(type: "timestamp", nullable: false),
                    goles_local = table.Column<int>(type: "integer", nullable: false),
                    goles_visitante = table.Column<int>(type: "integer", nullable: false),
                    jugado = table.Column<bool>(type: "boolean", nullable: false),
                    equipo_local_id = table.Column<int>(type: "integer", nullable: false),
                    equipo_visitante_id = table.Column<int>(type: "integer", nullable: false),
                    estadio_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_partidos_equipos_equipo_local_id",
                        column: x => x.equipo_local_id,
                        principalTable: "equipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partidos_equipos_equipo_visitante_id",
                        column: x => x.equipo_visitante_id,
                        principalTable: "equipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partidos_estadios_estadio_id",
                        column: x => x.estadio_id,
                        principalTable: "estadios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    minuto = table.Column<int>(type: "integer", nullable: false),
                    partido_id = table.Column<int>(type: "integer", nullable: false),
                    jugador_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goles", x => x.id);
                    table.ForeignKey(
                        name: "FK_goles_jugadores_jugador_id",
                        column: x => x.jugador_id,
                        principalTable: "jugadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goles_partidos_partido_id",
                        column: x => x.partido_id,
                        principalTable: "partidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipos_liga_id",
                table: "equipos",
                column: "liga_id");

            migrationBuilder.CreateIndex(
                name: "IX_goles_jugador_id",
                table: "goles",
                column: "jugador_id");

            migrationBuilder.CreateIndex(
                name: "IX_goles_partido_id",
                table: "goles",
                column: "partido_id");

            migrationBuilder.CreateIndex(
                name: "IX_jugadores_equipo_id",
                table: "jugadores",
                column: "equipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_partidos_equipo_local_id",
                table: "partidos",
                column: "equipo_local_id");

            migrationBuilder.CreateIndex(
                name: "IX_partidos_equipo_visitante_id",
                table: "partidos",
                column: "equipo_visitante_id");

            migrationBuilder.CreateIndex(
                name: "IX_partidos_estadio_id",
                table: "partidos",
                column: "estadio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goles");

            migrationBuilder.DropTable(
                name: "jugadores");

            migrationBuilder.DropTable(
                name: "partidos");

            migrationBuilder.DropTable(
                name: "equipos");

            migrationBuilder.DropTable(
                name: "estadios");

            migrationBuilder.DropTable(
                name: "ligas");
        }
    }
}
