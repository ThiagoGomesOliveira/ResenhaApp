using Microsoft.AspNetCore.Identity;
using Resenha.Modulo.Usuario.Interfaces.Services;

namespace Resenha.Infrastructure.Services;

public class IdentityAuthService(UserManager<IdentityUser> _userManager,
    SignInManager<IdentityUser> _signInManager) : IAuthService
{
    public async Task<bool> AutenticarAsync(string email, string senha)
    {
        var result = await _signInManager.PasswordSignInAsync(email, senha, isPersistent: false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<(bool Sucesso, string IdentityId, IEnumerable<string> Erros)> CriarContaAsync(string email, string senha)
    {
        var userIdentity = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };

        var result = await _userManager.CreateAsync(userIdentity);

        if (!result.Succeeded)
        {
            var erros = result.Errors.Select(e => e.Description);
            return (false, string.Empty, erros);
        }

        return (true, userIdentity.Id, Enumerable.Empty<string>());
    }

    public async Task DeslogarAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
