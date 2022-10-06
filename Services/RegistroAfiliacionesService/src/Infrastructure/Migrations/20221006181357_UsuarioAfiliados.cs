using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UsuarioAfiliados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioAfiliados",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AfiliadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAfiliados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados",
                column: "UsuarioAfiliadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_UsuarioAfiliados_UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados",
                column: "UsuarioAfiliadosId",
                principalSchema: "dbo",
                principalTable: "UsuarioAfiliados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_UsuarioAfiliados_UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropTable(
                name: "UsuarioAfiliados",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "UsuarioAfiliadosId",
                schema: "dbo",
                table: "Afiliados");
        }
    }
}
