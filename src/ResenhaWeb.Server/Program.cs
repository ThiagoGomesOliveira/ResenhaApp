using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resenha.CrossCutting.Dependecias;
using Resenha.Infrastructure.Persistence;
using Resenha.Infrastructure.Repositories.Usuario;
using Resenha.Infrastructure.Services;
using Resenha.Modulo.Usuario.Application.Dependencias;
using Resenha.Modulo.Usuario.Application.Interfaces;
using Resenha.Modulo.Usuario.Application.Services;
using Resenha.Modulo.Usuario.Interfaces.Repositories;
using Resenha.Modulo.Usuario.Interfaces.Services;
using ResenhaWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUsuarioApplication();

//configuração do identity
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ResenhaDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configurações de senha
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    // Configurações de bloqueio
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Configurações de usuário
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ResenhaWeb.Client._Imports).Assembly);

app.Run();
