using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Data.Mapping.Chamados
{
    public class AssuntoMap : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.ToTable("ChamadoAssunto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");

            builder.Property(x => x.DepartamentoId)
                .HasColumnName("Departamento");

            builder.Property(x => x.Identificacao)
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Departamento)
                .WithMany(x => x.Assuntos)
                .HasForeignKey(x => x.DepartamentoId)
                .HasConstraintName("FK_ChamadoAssunto_Departamento");
        }
    }
}