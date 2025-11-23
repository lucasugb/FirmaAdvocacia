using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirmaAdvocacia.Migrations
{
    /// <inheritdoc />
    public partial class testee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Processos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Processos_ClienteId",
                table: "Processos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Clientes_ClienteId",
                table: "Processos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Clientes_ClienteId",
                table: "Processos");

            migrationBuilder.DropIndex(
                name: "IX_Processos_ClienteId",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Processos");
        }
    }
}
