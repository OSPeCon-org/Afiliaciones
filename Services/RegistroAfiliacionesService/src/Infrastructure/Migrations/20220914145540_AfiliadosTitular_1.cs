using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AfiliadosTitular_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TitularId",
                schema: "dbo",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_TitularId",
                schema: "dbo",
                table: "Afiliados",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Afiliados_TitularId",
                schema: "dbo",
                table: "Afiliados",
                column: "TitularId",
                principalSchema: "dbo",
                principalTable: "Afiliados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Afiliados_TitularId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_TitularId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "TitularId",
                schema: "dbo",
                table: "Afiliados");
        }
    }
}
