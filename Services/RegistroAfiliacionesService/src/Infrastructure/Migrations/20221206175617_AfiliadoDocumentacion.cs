using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AfiliadoDocumentacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprobado",
                schema: "dbo",
                table: "AfiliadosDocumentacion");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocalidadesId",
                schema: "dbo",
                table: "AfiliadosDomicilios",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                schema: "dbo",
                table: "AfiliadosDocumentacion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "dbo",
                table: "AfiliadosDocumentacion");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocalidadesId",
                schema: "dbo",
                table: "AfiliadosDomicilios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                schema: "dbo",
                table: "AfiliadosDocumentacion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
