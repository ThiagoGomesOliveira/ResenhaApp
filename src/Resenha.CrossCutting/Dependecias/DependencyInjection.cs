
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resenha.Infrastructure.Persistence;
using Resenha.Infrastructure.Repositories.Usuario;
using Resenha.Infrastructure.Services;
using Resenha.Modulo.Usuario.Application.Interfaces;
using Resenha.Modulo.Usuario.Application.Services;
using Resenha.Modulo.Usuario.Interfaces.Repositories;
using Resenha.Modulo.Usuario.Interfaces.Services;


namespace Resenha.CrossCutting.Dependecias;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //CONFIGURAÇÃO DO BANCO DE DADOS
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        services.AddDbContext<ResenhaDbContext>(options =>
            options.UseNpgsql(connectionString));

        //Injeção de dependência para o repositório
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        //Injecação de dependência para o serviço
        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        services.AddScoped<IAuthService, IdentityAuthService>();


        return services;
    }
}
