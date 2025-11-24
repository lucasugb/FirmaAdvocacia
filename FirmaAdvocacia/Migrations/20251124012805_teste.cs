using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaAdvocacia.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoProcessos_Advogados_AdvogadoId",
                table: "AdvogadoProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProcessos_Clientes_ClienteId",
                table: "ClientesProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProcessos_Processos_ProcessoId",
                table: "ClientesProcessos");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoProcessos_Advogados_AdvogadoId",
                table: "AdvogadoProcessos",
                column: "AdvogadoId",
                principalTable: "Advogados",
                principalColumn: "AdvogadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProcessos_Clientes_ClienteId",
                table: "ClientesProcessos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProcessos_Processos_ProcessoId",
                table: "ClientesProcessos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvogadoProcessos_Advogados_AdvogadoId",
                table: "AdvogadoProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProcessos_Clientes_ClienteId",
                table: "ClientesProcessos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProcessos_Processos_ProcessoId",
                table: "ClientesProcessos");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvogadoProcessos_Advogados_AdvogadoId",
                table: "AdvogadoProcessos",
                column: "AdvogadoId",
                principalTable: "Advogados",
                principalColumn: "AdvogadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProcessos_Clientes_ClienteId",
                table: "ClientesProcessos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProcessos_Processos_ProcessoId",
                table: "ClientesProcessos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "ProcessoId");
        }
    }
}
