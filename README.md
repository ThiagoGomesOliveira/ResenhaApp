# 🥩 ResenhaApp

O **ResenhaApp** é uma aplicação web desenvolvida para simplificar a organização e gestão de eventos sociais, churrascos e encontros ("resenhas"). O sistema permite gerenciar listas de convidados, presença, controle de itens e cálculo de rateio de custos entre os participantes.

Este repositório tem como objetivo principal o **aprendizado prático e aprofundamento no desenvolvimento web com .NET**, explorando tecnologias modernas do ecossistema Microsoft com boas práticas de arquitetura.

---

## 🚀 Tecnologias Utilizadas

* **[.NET 8 / 9](https://dotnet.microsoft.com/)**: Plataforma de desenvolvimento base.
* **[Blazor (Interactive Auto)](https://learn.microsoft.com/aspnet/core/blazor/)**: Modelo de hospedagem unificado combinando Server-Side Rendering (SSR) com a interatividade do WebAssembly (WASM).
* **[ASP.NET Core Identity](https://learn.microsoft.com/aspnet/core/security/authentication/identity)**: Sistema de autenticação, controle de acessos e segurança.
* **[Entity Framework Core](https://learn.microsoft.com/ef/core/)**: ORM para mapeamento de dados e operações no banco.
* **[PostgreSQL](https://www.postgresql.org/)**: Banco de dados relacional principal.
* **Clean Architecture / Monólito Modular**: Organização desacoplada de código separando regras de negócio, casos de uso e infraestrutura.

---

## 🏗️ Estrutura da Solução

O projeto segue a estrutura de **Clean Architecture**, isolando as responsabilidades em camadas dentro do diretório `src/`:

```text
ResenhaApp/
 ├── ResenhaApp.sln                  # Arquivo da Solution principal
 ├── README.md                       # Documentação do projeto
 ├── .gitignore                      # Arquivo de ignorados do Git
 └── src/
      ├── ResenhaWeb.Server/         # Servidor Blazor (SSR, Endpoints e Autenticação)
      ├── ResenhaWeb.Client/         # Componentes WebAssembly interativos no navegador
      ├── Resenha.Domain/            # Entidades de negócio, validações e interfaces puras
      ├── Resenha.Application/       # Casos de uso, DTOs e regras de serviço
      └── Resenha.Infrastructure/    # EF Core, Migrations, PostgreSQL e Identity
