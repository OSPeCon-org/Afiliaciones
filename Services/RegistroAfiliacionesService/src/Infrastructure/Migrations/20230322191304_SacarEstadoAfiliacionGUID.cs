using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SacarEstadoAfiliacionGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
