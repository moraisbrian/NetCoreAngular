using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Data.Mapping.Chamados
{
    public class ProtocoloMap : IEntityTypeConfiguration<Protocolo>
    {
        public void Configure(EntityTypeBuilder<Protocolo> builder)
        {
            builder.ToTable("ChamadoProtocolo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Oid");

            builder.Property(x => x.Numero)
                .HasColumnName("Protocolo");
        }
    }
}