using Microsoft.Extensions.DependencyInjection;
using Resenha.Modulo.Usuario.Application.Interfaces;
using Resenha.Modulo.Usuario.Application.Services;
using Resenha.Modulo.Usuario.Application.Validators;

namespace Resenha.Modulo.Usuario.Application.Dependencias;

public static class DependencyInjection
{
    public static IServiceCollection AddUsuarioApplication(this IServiceCollection services)
    {
        // Injeção de dependência para o serviço
        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        services.AddScoped<RegistrarUsuarioValidator>();
        return services;
    }
}
