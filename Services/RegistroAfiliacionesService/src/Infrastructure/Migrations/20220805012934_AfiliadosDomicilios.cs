using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AfiliadosDomicilios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfiliadosDomicilios",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AfiliadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalidadesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfiliadosDomicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AfiliadosDomicilios_Afiliados_AfiliadosId",
                        column: x => x.AfiliadosId,
                        principalSchema: "dbo",
                        principalTable: "Afiliados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AfiliadosDomicilios_Localidades_LocalidadesId",
                        column: x => x.LocalidadesId,
                        principalSchema: "dbo",
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfiliadosDomicilios_AfiliadosId",
                schema: "dbo",
                table: "AfiliadosDomicilios",
                column: "AfiliadosId");

            migrationBuilder.CreateIndex(
                name: "IX_AfiliadosDomicilios_LocalidadesId",
                schema: "dbo",
                table: "AfiliadosDomicilios",
                column: "LocalidadesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfiliadosDomicilios",
                schema: "dbo");
        }
    }
}
