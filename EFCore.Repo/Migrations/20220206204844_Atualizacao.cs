using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repo.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Setores_SetorId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "IdCargo",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "IdSetor",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "Cargos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Setores_SetorId",
                table: "Cargos",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Setores_SetorId",
                table: "Cargos");

            migrationBuilder.AddColumn<int>(
                name: "IdCargo",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSetor",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "Cargos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Setores_SetorId",
                table: "Cargos",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
