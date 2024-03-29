﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NetCoreAngular.Data;

namespace NetCoreAngular.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210208225821_Chamados")]
    partial class Chamados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.ArquivoChamado", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Oid");

                    b.Property<byte[]>("Conteudo")
                        .HasColumnType("bytea");

                    b.Property<string>("MensagemId")
                        .HasColumnType("character(36)");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Tamanho")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MensagemId");

                    b.ToTable("ArquivosChamado");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Assunto", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("DepartamentoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Departamento");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("ChamadoAssunto");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Chamado", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("AssuntoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Assunto");

                    b.Property<string>("AtendenteId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Atendente");

                    b.Property<string>("ClienteId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Cliente");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataUltimaInteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartamentoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Departamento");

                    b.Property<string>("Empresa")
                        .HasColumnType("text");

                    b.Property<string>("NotaAvaliacaoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Avaliacao");

                    b.Property<string>("ObservacoesEncerramento")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("PrioridadeId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Prioridade");

                    b.Property<string>("Protocolo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Situacao")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoId");

                    b.HasIndex("AtendenteId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("NotaAvaliacaoId");

                    b.HasIndex("PrioridadeId");

                    b.ToTable("Chamado");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Departamento", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ChamadoDepartamento");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Mensagem", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("ChamadoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Chamado");

                    b.Property<string>("Conteudo")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("character(36)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("ChamadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ChamadoMensagem");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.NotaAvaliacao", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ChamadoNotaAvaliacao");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Prioridade", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("TempoLimiteAtendimento")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ChamadoPrioridade");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Protocolo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Oid");

                    b.Property<int>("Numero")
                        .HasColumnType("integer")
                        .HasColumnName("Protocolo");

                    b.HasKey("Id");

                    b.ToTable("ChamadoProtocolo");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasColumnName("Oid");

                    b.Property<string>("DepartamentoId")
                        .HasColumnType("character(36)")
                        .HasColumnName("ChamadoDepartamento");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("UserName");

                    b.Property<string>("Senha")
                        .HasColumnType("text")
                        .HasColumnName("StoredPassword");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("PermissionPolicyUser");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.ArquivoChamado", b =>
                {
                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Mensagem", "Mensagem")
                        .WithMany()
                        .HasForeignKey("MensagemId");

                    b.Navigation("Mensagem");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Assunto", b =>
                {
                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Departamento", "Departamento")
                        .WithMany("Assuntos")
                        .HasForeignKey("DepartamentoId")
                        .HasConstraintName("FK_ChamadoAssunto_Departamento");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Chamado", b =>
                {
                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Assunto", "Assunto")
                        .WithMany("Chamados")
                        .HasForeignKey("AssuntoId")
                        .HasConstraintName("FK_Chamado_Assunto");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Usuario", "Atendente")
                        .WithMany()
                        .HasForeignKey("AtendenteId");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Departamento", "Departamento")
                        .WithMany("Chamados")
                        .HasForeignKey("DepartamentoId")
                        .HasConstraintName("FK_Chamado_Departamento");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.NotaAvaliacao", "NotaAvaliacao")
                        .WithMany("Chamados")
                        .HasForeignKey("NotaAvaliacaoId")
                        .HasConstraintName("FK_Chamado_Avaliacao");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Prioridade", "Prioridade")
                        .WithMany("Chamados")
                        .HasForeignKey("PrioridadeId")
                        .HasConstraintName("FK_Chamado_Prioridade");

                    b.Navigation("Assunto");

                    b.Navigation("Atendente");

                    b.Navigation("Cliente");

                    b.Navigation("Departamento");

                    b.Navigation("NotaAvaliacao");

                    b.Navigation("Prioridade");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Mensagem", b =>
                {
                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Chamado", "Chamado")
                        .WithMany("Mensagens")
                        .HasForeignKey("ChamadoId")
                        .HasConstraintName("FK_ChamadoMensagem_Chamado");

                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Usuario", "Usuario")
                        .WithMany("Mensagens")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_ChamadoMensagem_Usuario");

                    b.Navigation("Chamado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Usuario", b =>
                {
                    b.HasOne("NetCoreAngular.Domain.Entidades.Chamados.Departamento", "Departamento")
                        .WithMany("Usuarios")
                        .HasForeignKey("DepartamentoId")
                        .HasConstraintName("FK_PermissionPolicyUser_ChamadoDepartamento");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Assunto", b =>
                {
                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Chamado", b =>
                {
                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Departamento", b =>
                {
                    b.Navigation("Assuntos");

                    b.Navigation("Chamados");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.NotaAvaliacao", b =>
                {
                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Prioridade", b =>
                {
                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("NetCoreAngular.Domain.Entidades.Chamados.Usuario", b =>
                {
                    b.Navigation("Mensagens");
                });
#pragma warning restore 612, 618
        }
    }
}
