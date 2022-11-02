using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagamentoApi.Migrations
{
    public partial class TabelaVendaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendedorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendedorEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPedido = table.Column<int>(type: "int", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaEntity_VendedorEntity_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "VendedorEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendaItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    VendaEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaItens_VendaEntity_VendaEntityId",
                        column: x => x.VendaEntityId,
                        principalTable: "VendaEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaEntity_VendedorId",
                table: "VendaEntity",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_VendaEntityId",
                table: "VendaItens",
                column: "VendaEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "VendaItens");

            migrationBuilder.DropTable(
                name: "VendaEntity");

            migrationBuilder.DropTable(
                name: "VendedorEntity");
        }
    }
}
