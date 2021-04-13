using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Data.Mapping.Chamados
{
    public class ChamadoMap : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamado");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");

            builder.Property(x => x.Protocolo)
                .HasColumnType("character varying(100)")
                .HasMaxLength(100);

            builder.Property(x => x.ObservacoesEncerramento)
                .HasColumnType("character varying(500)")
                .HasMaxLength(500);

            builder.Property(x => x.AssuntoId)
                .HasColumnName("Assunto");

            builder.Property(x => x.PrioridadeId)
                .HasColumnName("Prioridade");

            builder.Property(x => x.DepartamentoId)
                .HasColumnName("Departamento");

            builder.Property(x => x.AtendenteId)
                .HasColumnName("Atendente");

            builder.Property(x => x.ClienteId)
                .HasColumnName("Cliente");

            builder.Property(x => x.NotaAvaliacaoId)
                .HasColumnName("Avaliacao");

            builder.HasOne(x => x.Assunto)
                .WithMany(x => x.Chamados)
                .HasForeignKey(x => x.AssuntoId)
                .HasConstraintName("FK_Chamado_Assunto");

            builder.HasOne(x => x.NotaAvaliacao)
                .WithMany(x => x.Chamados)
                .HasForeignKey(x => x.NotaAvaliacaoId)
                .HasConstraintName("FK_Chamado_Avaliacao");

            builder.HasOne(x => x.Departamento)
                .WithMany(x => x.Chamados)
                .HasForeignKey(x => x.DepartamentoId)
                .HasConstraintName("FK_Chamado_Departamento");

            builder.HasOne(x => x.Prioridade)
                .WithMany(x => x.Chamados)
                .HasForeignKey(x => x.PrioridadeId)
                .HasConstraintName("FK_Chamado_Prioridade");

            builder.Property(x => x.FranquiaId)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Franquia");

            builder.HasOne(x => x.Franquia)
                .WithMany()
                .HasForeignKey(x => x.FranquiaId)
                .HasConstraintName("FK_Chamado_Franquia");
        }
    }
}