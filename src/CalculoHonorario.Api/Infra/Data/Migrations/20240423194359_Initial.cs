using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoHonorario.Api.Infra.Data.Migrations
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProLaboreBruto = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ProLaboreLiquido = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    LucroBruto = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    LucroLiquido = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ValorHonorario = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ProvisaoFerias = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ProvisaoDecimoTerceiro = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Fgts = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Inss = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Irpf = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ValeRefeicao = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ValeTransporte = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    ServicoContabil = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    SimplesNacional = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
