using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Data.Mapping
{
    public class FranquiaMap : IEntityTypeConfiguration<Franquia>
    {
        public void Configure(EntityTypeBuilder<Franquia> builder)
        {
            builder.ToTable("Franquia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");
                
            builder.Property(x => x.Nome)
                .HasColumnType("character varying(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Cnpj)
                .HasColumnName("CNPJ")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.HasMany(x => x.Usuarios)
                .WithMany(x => x.Franquias)
                .UsingEntity(x => x.ToTable("PermissionPolicyUserUsuarios_FranquiaFranquias")
                    .Property("FranquiasId")
                    .HasColumnName("Franquias")
                    .HasColumnType("character(36)")
                    .HasMaxLength(36));
        }
    }
}