using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MudancaTipoValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Transacao",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Valor",
                table: "Transacao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
