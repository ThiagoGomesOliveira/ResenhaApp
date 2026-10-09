using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resenha.Infrastructure.Persistence.Configurations.Categoria;

public class CategoriaMapping : IEntityTypeConfiguration<Resenha.Modulo.Categoria.Entities.Categoria>
{
    public void Configure(EntityTypeBuilder<Resenha.Modulo.Categoria.Entities.Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .UseIdentityByDefaultColumn()
            .HasColumnName("id");

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(400)")
            .HasColumnName("nome");

        builder.Property(c => c.Descricao)
            .HasColumnType("varchar(500)")
            .HasColumnName("descricao");

        builder.Property(c => c.Icone)
            .HasColumnType("varchar(100)")
            .HasColumnName("icone");
    }
}
