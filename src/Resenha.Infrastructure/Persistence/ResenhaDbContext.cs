using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resenha.Modulo.Usuario.Entities;

namespace Resenha.Infrastructure.Persistence;

public class ResenhaDbContext(DbContextOptions<ResenhaDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ResenhaDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}
