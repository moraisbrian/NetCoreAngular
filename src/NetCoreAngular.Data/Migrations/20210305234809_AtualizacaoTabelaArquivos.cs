using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAngular.Data.Migrations
{
    public partial class AtualizacaoTabelaArquivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivosChamado");

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character varying", nullable: false),
                    Nome = table.Column<string>(type: "character varying", nullable: true),
                    Conteudo = table.Column<byte[]>(type: "bytea", nullable: true),
                    IdPai = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Oid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.CreateTable(
                name: "ArquivosChamado",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "text", nullable: false),
                    Conteudo = table.Column<byte[]>(type: "bytea", nullable: true),
                    MensagemId = table.Column<string>(type: "character(36)", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Tamanho = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivosChamado", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ArquivosChamado_ChamadoMensagem_MensagemId",
                        column: x => x.MensagemId,
                        principalTable: "ChamadoMensagem",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivosChamado_MensagemId",
                table: "ArquivosChamado",
                column: "MensagemId");
        }
    }
}
