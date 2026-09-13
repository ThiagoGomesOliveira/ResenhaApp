using Resenha.Modulo.Usuario.Application.DTOs;
using Resenha.Modulo.Usuario.Application.Interfaces;

namespace ResenhaWeb.Endpoints;

public static class UsuarioEndpoints
{
    public static IEndpointRouteBuilder MapUsuarioEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/usuarios/", async (RegistrarUsuarioDto dto, IUsuarioAppService usuarioAppService) =>
         {
             var (sucesso, erros) = await usuarioAppService.RegistrarAsync(dto);

             if (!sucesso)
                 return Results.BadRequest(new { Erros = erros });

             return Results.Ok(new { Mensagem = "Usuário registrado com sucesso." });
         })
         .WithName("RegistrarUsuario")
         .WithTags("Usuarios");

        return endpoints;
    }
}
