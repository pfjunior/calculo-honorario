using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoHonorario.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Honorarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProLaboreBruto = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProLaboreLiquido = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProvisaoFerias = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProvisaoDecimoTerceiro = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValeRefeicao = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValeTransporte = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fgts = table.Column<decimal>(type: "TEXT", nullable: false),
                    ServicoContabil = table.Column<decimal>(type: "TEXT", nullable: false),
                    SimplesNacional = table.Column<decimal>(type: "TEXT", nullable: false),
                    Inss = table.Column<decimal>(type: "TEXT", nullable: false),
                    Irpf = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorHonorario = table.Column<decimal>(type: "TEXT", nullable: false),
                    LucroBruto = table.Column<decimal>(type: "TEXT", nullable: false),
                    LucroLiquido = table.Column<decimal>(type: "TEXT", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honorarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Honorarios");
        }
    }
}
