using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAngular.Domain.Entidades;

namespace NetCoreAngular.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("PermissionPolicyUser");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("character(36)")
                .HasMaxLength(36)
                .HasColumnName("Oid");

            builder.Property(x => x.Nome)
                .HasColumnName("UserName")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnType("character varying(100)")
                .HasColumnName("SenhaMobile");

            builder.Property(x => x.DepartamentoId)
                .HasColumnName("ChamadoDepartamento");

            builder.Property(x => x.Email)
                .HasColumnType("character varying(255)")
                .HasMaxLength(255);

            builder.HasOne(x => x.Departamento)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.DepartamentoId)
                .HasConstraintName("FK_PermissionPolicyUser_ChamadoDepartamento");

            builder.HasMany(x => x.Franquias)
                .WithMany(x => x.Usuarios)
                .UsingEntity(x => x.ToTable("PermissionPolicyUserUsuarios_FranquiaFranquias")
                    .Property("UsuariosId")
                    .HasColumnName("Usuarios")
                    .HasColumnType("character(36)")
                    .HasMaxLength(36));
        }
    }
}