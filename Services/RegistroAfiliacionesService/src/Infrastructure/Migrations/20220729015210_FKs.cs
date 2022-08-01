using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_EstadoCivilId",
                schema: "dbo",
                table: "Afiliados",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_NacionalidadId",
                schema: "dbo",
                table: "Afiliados",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_ParentescoId",
                schema: "dbo",
                table: "Afiliados",
                column: "ParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_PlanId",
                schema: "dbo",
                table: "Afiliados",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_TipoDocumentoId",
                schema: "dbo",
                table: "Afiliados",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                schema: "dbo",
                table: "Afiliados",
                column: "EstadoCivilId",
                principalSchema: "dbo",
                principalTable: "EstadosCiviles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                schema: "dbo",
                table: "Afiliados",
                column: "NacionalidadId",
                principalSchema: "dbo",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Parentescos_ParentescoId",
                schema: "dbo",
                table: "Afiliados",
                column: "ParentescoId",
                principalSchema: "dbo",
                principalTable: "Parentescos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Planes_PlanId",
                schema: "dbo",
                table: "Afiliados",
                column: "PlanId",
                principalSchema: "dbo",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_TipoDocumento_TipoDocumentoId",
                schema: "dbo",
                table: "Afiliados",
                column: "TipoDocumentoId",
                principalSchema: "dbo",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Parentescos_ParentescoId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Planes_PlanId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_TipoDocumento_TipoDocumentoId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_EstadoCivilId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_NacionalidadId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_ParentescoId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_PlanId",
                schema: "dbo",
                table: "Afiliados");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_TipoDocumentoId",
                schema: "dbo",
                table: "Afiliados");
        }
    }
}
