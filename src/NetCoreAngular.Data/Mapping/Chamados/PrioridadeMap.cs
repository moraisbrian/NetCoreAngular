using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Data.Mapping.Chamados
{
    public class PrioridadeMap : IEntityTypeConfiguration<Prioridade>
    {
        public void Configure(EntityTypeBuilder<Prioridade> builder)
        {
            builder.ToTable("ChamadoPrioridade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");

            builder.Property(x => x.Identificacao)
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}