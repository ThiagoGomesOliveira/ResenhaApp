using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resenha.Infrastructure.Persistence.Configurations.Usuario;

public class UsuarioMapping : IEntityTypeConfiguration<Resenha.Modulo.Usuario.Entities.Usuario>
{
    public void Configure(EntityTypeBuilder<Modulo.Usuario.Entities.Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .UseIdentityByDefaultColumn()
            .HasColumnName("id");

        builder.Property(u => u.Nome)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasColumnName("nome");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasColumnName("email");

        builder.Property(u => u.IdentityId)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .HasColumnName("identity_id");

        builder.Property(u => u.Telefone)
            .IsRequired()
            .HasMaxLength(15)
            .HasColumnType("varchar(15)")
            .HasColumnName("telefone");

        builder.Property(u => u.DataCadastro)
            .IsRequired()
            .HasColumnName("data_cadastro");

        builder.Property(u => u.Ativo)
            .IsRequired()
            .HasColumnName("ativo");

        //índice único 
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("idx_usuarios_email");

        //índice único 
        builder.HasIndex(u => u.IdentityId)
            .IsUnique()
            .HasDatabaseName("idx_usuarios_identity_id");
    }
}
