using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAngular.Data.Migrations
{
    public partial class Chamados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoDepartamento",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Identificacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoDepartamento", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoNotaAvaliacao",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Identificacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoNotaAvaliacao", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoPrioridade",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Identificacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TempoLimiteAtendimento = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoPrioridade", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoProtocolo",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "text", nullable: false),
                    Protocolo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoProtocolo", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoAssunto",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Identificacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Departamento = table.Column<string>(type: "character(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoAssunto", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ChamadoAssunto_Departamento",
                        column: x => x.Departamento,
                        principalTable: "ChamadoDepartamento",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUser",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    StoredPassword = table.Column<string>(type: "text", nullable: true),
                    ChamadoDepartamento = table.Column<string>(type: "character(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUser", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUser_ChamadoDepartamento",
                        column: x => x.ChamadoDepartamento,
                        principalTable: "ChamadoDepartamento",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Protocolo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataUltimaInteracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Empresa = table.Column<string>(type: "text", nullable: true),
                    Situacao = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ObservacoesEncerramento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Assunto = table.Column<string>(type: "character(36)", nullable: true),
                    Avaliacao = table.Column<string>(type: "character(36)", nullable: true),
                    Departamento = table.Column<string>(type: "character(36)", nullable: true),
                    Prioridade = table.Column<string>(type: "character(36)", nullable: true),
                    Cliente = table.Column<string>(type: "character(36)", nullable: true),
                    Atendente = table.Column<string>(type: "character(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_Chamado_Assunto",
                        column: x => x.Assunto,
                        principalTable: "ChamadoAssunto",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_Avaliacao",
                        column: x => x.Avaliacao,
                        principalTable: "ChamadoNotaAvaliacao",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_Departamento",
                        column: x => x.Departamento,
                        principalTable: "ChamadoDepartamento",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_PermissionPolicyUser_Atendente",
                        column: x => x.Atendente,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_PermissionPolicyUser_Cliente",
                        column: x => x.Cliente,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chamado_Prioridade",
                        column: x => x.Prioridade,
                        principalTable: "ChamadoPrioridade",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoMensagem",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "character(36)", maxLength: 36, nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Chamado = table.Column<string>(type: "character(36)", nullable: true),
                    Usuario = table.Column<string>(type: "character(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoMensagem", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ChamadoMensagem_Chamado",
                        column: x => x.Chamado,
                        principalTable: "Chamado",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChamadoMensagem_Usuario",
                        column: x => x.Usuario,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArquivosChamado",
                columns: table => new
                {
                    Oid = table.Column<string>(type: "text", nullable: false),
                    MensagemId = table.Column<string>(type: "character(36)", nullable: true),
                    Conteudo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Tamanho = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivosChamado", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ArquivosChamado_ChamadoMensagem",
                        column: x => x.MensagemId,
                        principalTable: "ChamadoMensagem",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivosChamado_MensagemId",
                table: "ArquivosChamado",
                column: "MensagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Assunto",
                table: "Chamado",
                column: "Assunto");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Atendente",
                table: "Chamado",
                column: "Atendente");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Avaliacao",
                table: "Chamado",
                column: "Avaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Cliente",
                table: "Chamado",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Departamento",
                table: "Chamado",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_Prioridade",
                table: "Chamado",
                column: "Prioridade");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoAssunto_Departamento",
                table: "ChamadoAssunto",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoMensagem_Chamado",
                table: "ChamadoMensagem",
                column: "Chamado");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoMensagem_Usuario",
                table: "ChamadoMensagem",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyUser_ChamadoDepartamento",
                table: "PermissionPolicyUser",
                column: "ChamadoDepartamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivosChamado");

            migrationBuilder.DropTable(
                name: "ChamadoProtocolo");

            migrationBuilder.DropTable(
                name: "ChamadoMensagem");

            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "ChamadoAssunto");

            migrationBuilder.DropTable(
                name: "ChamadoNotaAvaliacao");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "ChamadoPrioridade");

            migrationBuilder.DropTable(
                name: "ChamadoDepartamento");
        }
    }
}
