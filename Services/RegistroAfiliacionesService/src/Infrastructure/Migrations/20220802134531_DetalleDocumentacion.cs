using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DetalleDocumentacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleDocumentacion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentescoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDocumentacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDocumentacion_Documentacion_DocumentacionId",
                        column: x => x.DocumentacionId,
                        principalSchema: "dbo",
                        principalTable: "Documentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleDocumentacion_Planes_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "dbo",
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDocumentacion_DocumentacionId",
                schema: "dbo",
                table: "DetalleDocumentacion",
                column: "DocumentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDocumentacion_PlanId",
                schema: "dbo",
                table: "DetalleDocumentacion",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleDocumentacion",
                schema: "dbo");
        }
    }
}
