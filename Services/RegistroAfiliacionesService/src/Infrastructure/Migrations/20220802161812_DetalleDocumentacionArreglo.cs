using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DetalleDocumentacionArreglo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obligatorio",
                schema: "dbo",
                table: "Documentacion");

            migrationBuilder.AddColumn<bool>(
                name: "Obligatorio",
                schema: "dbo",
                table: "DetalleDocumentacion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obligatorio",
                schema: "dbo",
                table: "DetalleDocumentacion");

            migrationBuilder.AddColumn<bool>(
                name: "Obligatorio",
                schema: "dbo",
                table: "Documentacion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
