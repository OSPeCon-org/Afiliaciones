using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AfiliadosDocumentacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfiliadosDocumentacion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AfiliadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetalleDocumentacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    DocumentacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfiliadosDocumentacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AfiliadosDocumentacion_Afiliados_AfiliadosId",
                        column: x => x.AfiliadosId,
                        principalSchema: "dbo",
                        principalTable: "Afiliados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AfiliadosDocumentacion_Documentacion_DocumentacionId",
                        column: x => x.DocumentacionId,
                        principalSchema: "dbo",
                        principalTable: "Documentacion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfiliadosDocumentacion_AfiliadosId",
                schema: "dbo",
                table: "AfiliadosDocumentacion",
                column: "AfiliadosId");

            migrationBuilder.CreateIndex(
                name: "IX_AfiliadosDocumentacion_DocumentacionId",
                schema: "dbo",
                table: "AfiliadosDocumentacion",
                column: "DocumentacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfiliadosDocumentacion",
                schema: "dbo");
        }
    }
}
