using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaAdvocacia.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoProcessos_Processos_ProcessoId",
                table: "AdvogadoProcessos");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoProcessos_Processos_ProcessoId",
                table: "AdvogadoProcessos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoProcessos_Processos_ProcessoId",
                table: "AdvogadoProcessos");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoProcessos_Processos_ProcessoId",
                table: "AdvogadoProcessos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "ProcessoId");
        }
    }
}
