using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades.Chamados;

namespace NetCoreAngular.Data.Mapping.Chamados
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.ToTable("ChamadoMensagem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");

            builder.Property(x => x.Conteudo)
                .HasColumnType("text");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("Usuario");

            builder.Property(x => x.ChamadoId)
                .HasColumnName("Chamado");

            builder.HasOne(x => x.Chamado)
                .WithMany(x => x.Mensagens)
                .HasForeignKey(x => x.ChamadoId)
                .HasConstraintName("FK_ChamadoMensagem_Chamado");

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Mensagens)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_ChamadoMensagem_Usuario");
        }
    }
}