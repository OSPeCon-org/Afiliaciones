using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class QuitarEstadosAfiliacion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CemapReferencia",
                schema: "dbo",
                table: "AfiliadosContactos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CemapReferencia",
                schema: "dbo",
                table: "AfiliadosContactos");

            migrationBuilder.AlterColumn<Guid>(
                name: "EstadosAfiliacionId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosAfiliacion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
    }
}
