using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SacarFKLocalidadesAfiliados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Localidades_LocalidadesId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_LocalidadesId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "LocalidadesId",
                schema: "dbo",
                table: "Afiliados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                column: "LocalidadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Localidades_LocalidadesId",
                schema: "dbo",
                table: "Afiliados",
                column: "LocalidadesId",
                principalSchema: "dbo",
                principalTable: "Localidades",
                principalColumn: "Id");
        }
    }
}
