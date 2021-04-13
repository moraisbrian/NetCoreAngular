using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Data.Mapping
{
    public class ArquivoMap : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("Arquivos");

            builder.Property(x => x.Id)
                .HasColumnName("Oid")
                .HasColumnType("character varying");

            builder.Property(x => x.Nome)
                .HasColumnType("character varying");

            builder.Property(x => x.IdPai)
                .HasColumnType("character varying");

            builder.Property(x => x.Conteudo)
                .HasColumnType("bytea");
        }
    }
}