using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiggAgroCoop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFarmLocationNullable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Farms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Não informado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Farms",
                type: "text",
                nullable: true,
                defaultValue: "Não informado",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
