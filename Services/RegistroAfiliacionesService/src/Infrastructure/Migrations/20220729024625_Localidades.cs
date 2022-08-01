using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Localidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Localidades",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoSSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciasId",
                        column: x => x.ProvinciasId,
                        principalSchema: "dbo",
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                column: "LocalidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciasId",
                schema: "dbo",
                table: "Localidades",
                column: "ProvinciasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Localidades_LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                column: "LocalidadesId",
                principalSchema: "dbo",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Localidades_LocalidadesId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropTable(
                name: "Localidades",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_LocalidadesId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "LocalidadesId",
                schema: "dbo",
                table: "Afiliados");
        }
    }
}
