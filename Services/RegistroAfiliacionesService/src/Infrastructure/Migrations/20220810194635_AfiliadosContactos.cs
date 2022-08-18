using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AfiliadosContactos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfiliadosContactos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AfiliadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Particular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfiliadosContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AfiliadosContactos_Afiliados_AfiliadosId",
                        column: x => x.AfiliadosId,
                        principalSchema: "dbo",
                        principalTable: "Afiliados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfiliadosContactos_AfiliadosId",
                schema: "dbo",
                table: "AfiliadosContactos",
                column: "AfiliadosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfiliadosContactos",
                schema: "dbo");
        }
    }
}
