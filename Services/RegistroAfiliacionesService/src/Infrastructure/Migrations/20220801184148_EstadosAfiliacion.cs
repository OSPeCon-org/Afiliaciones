using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EstadosAfiliacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EstadosAfiliacion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAfiliacion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                column: "EstadosAfiliacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosAfiliacion_EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                column: "EstadosAfiliacionId",
                principalSchema: "dbo",
                principalTable: "EstadosAfiliacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosAfiliacion_EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropTable(
                name: "EstadosAfiliacion",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados");
        }
    }
}
