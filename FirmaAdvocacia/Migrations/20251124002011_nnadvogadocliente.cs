using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaAdvocacia.Migrations
{
    /// <inheritdoc />
    public partial class nnadvogadocliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvogadoProcessos",
                columns: table => new
                {
                    AdvogadoId = table.Column<int>(type: "int", nullable: false),
                    ProcessoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvogadoProcessos", x => new { x.AdvogadoId, x.ProcessoId });
                    table.ForeignKey(
                        name: "FK_AdvogadoProcessos_Advogados_AdvogadoId",
                        column: x => x.AdvogadoId,
                        principalTable: "Advogados",
                        principalColumn: "AdvogadoId");
                    table.ForeignKey(
                        name: "FK_AdvogadoProcessos_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "ProcessoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvogadoProcessos_ProcessoId",
                table: "AdvogadoProcessos",
                column: "ProcessoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvogadoProcessos");
        }
    }
}
