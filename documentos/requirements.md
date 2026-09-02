# ResenhaApp - Aplicativo para gerenciar eventos ex:(confraternizações)

## Objetivo
-Desenvolver o sistema que irá realizar o controle do evento, de acordo com  parametrização do usuário, será possível calcular a quantidade de consumo e insumos e despesas para a realização do evento, respeitando a quantidade de participantes do evento. Também será possivel realizar a prestação de contas do evento  do que foi gasto e pago pelos participantes. Este sistema será web/ mobile. Hoje para a realização da confraternização, não existe uma forma de gerenciamento, desta forma ocorre que em certos eventos, não fica claro o que cada um deve levar e o que os participantes devem pagar.

## Usuarios do sistema
-Criador evento(administrador)
-Participante do evento

## Problemas identificados
-Falta de dados do que vai ser gasto e o que deve ser pago.
-Falta de prestação de contas com os participantes que colaboraram.
-Algumas informações apenas o administrador poderá ter acesso.

## Requisitos funcionais
-RF01 - Cadastrar um usuário. 
-RF02 - Cadastrar um evento.
-RF03 - Editar um evento.
-RF04 - Excluir um evento.
-RF05 - Cadastrar parametros do tipo de evento.
-RF06 - Editar parametros do tipo de evento.
-RF07 - Excluir parametros do tipo de evento.
-RF08 - Cadastrar participante. 
-RF09 - Editar um participante.
-RF10 - Excluir o participante.
-RF11 - Cadastrar o participante do evento
-RF12 - Excluir o participante do evento.
-RF13 - Alterar o participante do evento.
-RF14 - Cadastrar categoria
-RF15 - Editar categoria
-RF16 - Excluir categoria

## Requisitos não funcionais 
-RNF01 - Autenticação do usuário é obrigatório
-RNF02 - O sistema deve ser utilizado em mobile.
-RNF03 - Apenas usuários autorizados poderão acessar determinadas áreas.
-RNF04 - Backoup diario.

## Regras de Negócio
-RN01 - Será obrigatório a criação de um usuário para poder utilizar o sistema. 
-RN02 - Caso usuário não exista, não permitir logar no sistema.
-RN03 - Não deve permitir criar usuários com o mesmo email e cpf já existente na plataforma. 
-RN04 - Caso usuário esqueça a senha, permitir alterar ela.
-RN05 - Usuário logado podera criar eventos.
-RN06 - Usuário se quiser poderá parametrizar os valores refente ao consumo, quantidade etc ...
-RN07 - Usuário poderá configurar as categorias, o sistema já deve vir com um determinado padrão de categorias de eventos.
-RN08 - Apenas o usuário que criou o evento poderá parametrizar os valores de acordo com sua necessidade.
-RN09 - Apenas o usuário que criou o evento poderá incluir, editar e excluir os participantes.
-RN10 - Apenas o usuário dono do evento podera visualizar as caracteriscas referente a valores do que foi pago sobre o evento.
-RN11 - O participante poderá visualizar o evento, poderá confirmar presença. Porém não é obrigatório, pois o criador do evento também poderá confirmar a presença para o convidado.
-RN12 - O criador do evento poderá  emitir um relatório com o que foi pago e o que cada participante irá levar.
-RN13 - O criador do evento poderá informar se determinado insumo é obrigatório ou será opcional por participante.
-RN14 - O sistema deve alertar o participante sobre a data do evento. Não obrigatório. Pode ser envio de email.
-RN15 - O sistema poderá enviar um link para confirmação do evento por email, com os detalhes. Não é obrigatório.
-RN16 - O criador do evento poderá adicionar o número do pix, para realizar a cobrança. Não obrigatório.
-RN17 - Poderá ser possivel gerar um alerta ao devedor do evento, pode ser email ou notificação no proprio sistema.
-RN18 - O sistema poderá ter notificações, para informar o criador do evento. 

## MVP 
-Este projeto poderá ser feito uma entrega mais simples de inicio, contendo a autenticação do usuário e criação dos eventos, conforme for liberado e testado, a segunda parte que contempla as melhorias será realizada.


# Especificação de Domínios e Entidades do Sistema de Churrasco / Eventos

Este documento detalha o modelo de domínio do sistema, organizando os Requisitos Funcionais (RF01 a RF16) em **Bounded Contexts (Domínios)** e definindo suas respectivas **Entidades**, **Atributos**, **Tipos de Dados**, **Relacionamentos** e **Regras de Negócio/Métodos**.

---

## Visão Geral dos Domínios

| Domínio | Descrição | Requisitos Atendidos |
| :--- | :--- | :--- |
| **1. Gestão de Usuários (User Context)** | Gestão dos organizadores e usuários cadastrados na plataforma. | RF01 |
| **2. Gestão de Eventos (Event Context)** | Gerenciamento do ciclo de vida dos eventos. | RF02, RF03, RF04 |
| **3. Parametrização e Regras (Parameter Context)** | Configuração de parâmetros para cálculo de insumos. | RF05, RF06, RF07 |
| **4. Cadastro Base de Pessoas (Person Context)** | Cadastro global de contatos/amigos (com vínculo opcional a conta de usuário). | RF08, RF09, RF10 |
| **5. Lista de Convidados e Presença (Guestlist Context)** | Vínculo entre participantes e um evento específico. | RF11, RF12, RF13 |
| **6. Catálogo e Categorização (Category Context)** | Gestão de categorias de itens (carnes, bebidas, etc.). | RF14, RF15, RF16 |

---

## 1. Domínio de Usuários (`User Context`)

Responsável pela identificação, cadastro e autenticação de pessoas (organizadores ou participantes cadastrados) no sistema.

### Entidade: `Usuario`
* **Descrição:** Representa uma conta de acesso cadastrada na plataforma. O e-mail é a chave única de autenticação.

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador único do usuário. |
| `nome` | `String` | Sim | Nome completo do usuário. |
| `email` | `String` | Sim | E-mail único do usuário (**Constraint UNIQUE**). |
| `IdentityId` | `String` | Sim | // FK que aponta para o AspNetUsers. |
| `telefone` | `String` | Não | Telefone/WhatsApp para contato. |
| `dataCadastro` | `DateTime` | Sim | Timestamp da criação da conta. |
| `ativo` | `Boolean` | Sim | Status da conta (ativo/inativo). |

* **Relacionamentos:**
  * 1 `Usuario` ── (1:N) ──> `Evento` *(Um usuário pode organizar vários eventos)*.
  * 1 `Usuario` ── (1:1 Opcional) ──> `Participante` *(Um usuário pode estar vinculado a um registro de participante na base global)*.
* **Comportamentos / Métodos:**
  * `cadastrar()` [RF01] (Valida unicidade do e-mail).
  * `autenticar()`
  * `inativarConta()`

---

## 2. Domínio de Eventos (`Event Context`)

Responsável pela gestão do evento em si (churrasco, festa, etc.), definindo local, data, orçamento e status.

### Entidade: `Evento`
* **Descrição:** Entidade agregadora principal do evento.

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador único do evento. |
| `organizadorId` | `UUID` / `Long` | Sim | Chave estrangeira referenciando o `Usuario`. |
| `tipoEventoParametroId` | `UUID` / `Long` | Sim | Referência aos parâmetros do tipo de evento utilizado. |
| `nome` | `String` | Sim | Nome do evento (ex: "Churrasco da Firma", "Aniversário"). |
| `descricao` | `String` | Não | Descrição ou observações gerais. |
| `dataHoraInicio` | `DateTime` | Sim | Data e horário de início. |
| `dataHoraFim` | `DateTime` | Não | Data e horário de término previstos. |
| `cep` | `String` | Não | CEP do local para autopreenchimento de endereço via API. |
| `logradouro` | `String` | Não | Endereço completo ou ponto de encontro. |
| `numero` | `String` | Não | Número ou complemento do local. |
| `bairro` | `String` | Não | Bairro do local do evento. |
| `cidade` | `String` | Não | Cidade do evento. |
| `estado` | `String` | Não | UF/Estado do evento. |
| `limiteParticipantes` | `Integer` | Não | Capacidade máxima de vagas. |
| `status` | `Enum` | Sim | Status (`RASCUNHO`, `CONFIRMADO`, `EM_ANDAMENTO`, `FINALIZADO`, `CANCELADO`). |
| `dataCriacao` | `DateTime` | Sim | Data de criação do registro. |

* **Relacionamentos:**
  * `Evento` ── (N:1) ──> `Usuario`
  * `Evento` ── (N:1) ──> `TipoEventoParametro`
  * 1 `Evento` ── (1:N) ──> `ParticipanteEvento`
* **Comportamentos / Métodos:**
  * `criarEvento()` [RF02]
  * `editarEvento()` [RF03]
  * `excluirEvento()` [RF04]
  * `cancelarEvento()`
  * `buscarEnderecoPorCep()`
  * `calcularTotalVagasRestantes()`

---

## 3. Domínio de Parametrização (`Parameter Context`)

Define os modelos/templates configuráveis para cálculo automático de consumo e métricas de cada modalidade de evento.

### Entidade: `TipoEventoParametro`
* **Descrição:** Representa a configuração base usada para calcular quantidades de comida, bebida e estimativas financeiras.

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador único do parâmetro. |
| `nome` | `String` | Sim | Nome do perfil (ex: "Churrasco Padrão 4h"). |
| `descricao` | `String` | Não | Descrição detalhada das premissas. |
| `duracaoPadraoHoras` | `Integer` | Sim | Duração estimada padrão (em horas). |
| `ativo` | `Boolean` | Sim | Indica se o parâmetro está disponível para novos eventos. |

* **Relacionamentos:**
  * 1 `TipoEventoParametro` ── (1:N) ──> `ItemParametro`
* **Comportamentos / Métodos:**
  * `cadastrarParametro()` [RF05]
  * `editarParametro()` [RF06]
  * `excluirParametro()` [RF07]

### Entidade de Apoio: `ItemParametro`
* **Descrição:** Métrica individual de consumo para cada categoria/item dentro do parâmetro.

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador do item de parâmetro. |
| `tipoEventoParametroId` | `UUID` / `Long` | Sim | Referência ao `TipoEventoParametro`. |
| `categoriaId` | `UUID` / `Long` | Sim | Categoria do item (Carnes, Bebida Alcoólica, etc.). |
| `quantidadePorPessoa` | `Decimal` | Sim | Consumo médio estimado por pessoa. |
| `unidadeMedida` | `Enum` | Sim | Unidade (`KG`, `GRAMAS`, `LITROS`, `ML`, `UNIDADE`). |

---

## 4. Domínio de Cadastro Base de Pessoas (`Person Context`)

Mantém o diretório/caderneta de contatos globais do organizador.

### Entidade: `Participante`
* **Descrição:** Representa uma pessoa física cadastrada na agenda do organizador. Pode existir de forma avulsa (apenas nome/telefone) ou estar vinculada a uma conta de `Usuario` (se o amigo também criar login na plataforma).

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador único do participante base. |
| `usuarioCriadorId` | `UUID` / `Long` | Sim | FK referenciando o `Usuario` (organizador) que cadastrou o contato. |
| `usuarioVinculadoId` | `UUID` / `Long` | **Não** | FK opcional referenciando a conta de `Usuario` do participante. |
| `nome` | `String` | Sim | Nome ou apelido do participante. |
| `telefone` | `String` | Não | Número de telefone/WhatsApp. |
| `email` | `String` | Não | E-mail do participante (usado para convites e vínculo de conta). |
| `restricaoAlimentar` | `String` | Não | Ex: Vegano, Vegetariano, Intolerante à Lactose. |

* **Regra de Unicidade e Vínculo:**
  * Se `usuarioVinculadoId` for informado, o e-mail deve obrigatoriamente coincidir com o e-mail cadastrado na entidade `Usuario`.
  * Na criação de uma nova conta em `Usuario`, o sistema busca e vincula automaticamente registros de `Participante` que contenham o mesmo e-mail.

* **Relacionamentos:**
  * `Participante` ── (N:1) ──> `Usuario` *(Organizador criador do contato)*.
  * `Participante` ── (0..1:1) ──> `Usuario` *(Conta de usuário associada, opcional)*.
  * 1 `Participante` ── (1:N) ──> `ParticipanteEvento`.

* **Comportamentos / Métodos:**
  * `cadastrarParticipante()` [RF08]
  * `editarParticipante()` [RF09]
  * `excluirParticipante()` [RF10]
  * `vincularUsuarioPorEmail()`

---

## 5. Domínio de Presença e Convidados (`Guestlist Context`)

Gere a relação específica de um participante com determinado evento (a lista de convidados do evento).

### Entidade: `ParticipanteEvento`
* **Descrição:** A associação/vínculo entre a entidade `Participante` e um `Evento` específico.

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador do vínculo. |
| `eventoId` | `UUID` / `Long` | Sim | Referência ao `Evento`. |
| `participanteId` | `UUID` / `Long` | Sim | Referência ao `Participante` base. |
| `statusPresenca` | `Enum` | Sim | Status (`PENDENTE`, `CONFIRMADO`, `RECUSADO`). |
| `itemAComprarTrazer` | `String` | Não | Descrição do que a pessoa trará (ex: "Gelo", "Sobremesa"). |
| `pago` | `Boolean` | Sim | Indica se a taxa do rateio foi quitada. |
| `dataConfirmacao` | `DateTime` | Não | Timestamp do aceite/confirmação. |

* **Relacionamentos:**
  * `ParticipanteEvento` ── (N:1) ──> `Evento`
  * `ParticipanteEvento` ── (N:1) ──> `Participante`
* **Comportamentos / Métodos:**
  * `adicionarAoEvento()` [RF11]
  * `removerDoEvento()` [RF12]
  * `alterarStatusEItem()` [RF13]
  * `marcarComoPago()`

---

## 6. Domínio de Catálogo (`Category Context`)

Responsável pela taxonomia e classificação dos itens e insumos do sistema.

### Entidade: `Categoria`
* **Descrição:** Classificação geral para agrupar despesas, compras e parâmetros (ex: Carnes, Acompanhamentos, Bebidas Alcoólicas, Bebidas Não Alcoólicas, Descartáveis).

| Atributo | Tipo de Dado | Obrigatório? | Descrição |
| :--- | :--- | :---: | :--- |
| `id` | `UUID` / `Long` | Sim | Identificador único da categoria. |
| `nome` | `String` | Sim | Nome da categoria (ex: "Carnes"). |
| `descricao` | `String` | Não | Breve descrição explicativa. |
| `icone` | `String` | Não | Identificador visual/ícone para a interface. |

* **Relacionamentos:**
  * 1 `Categoria` ── (1:N) ──> `ItemParametro`
* **Comportamentos / Métodos:**
  * `cadastrarCategoria()` [RF14]
  * `editarCategoria()` [RF15]
  * `excluirCategoria()` [RF16]

---

## Mapeamento de Cobertura dos Requisitos

| Requisito Funcional | Entidade Principal | Domínio / Bounded Context |
| :--- | :--- | :--- |
| **RF01** - Cadastrar um usuário | `Usuario` | Gestão de Usuários |
| **RF02** - Cadastrar um evento | `Evento` | Gestão de Eventos |
| **RF03** - Editar um evento | `Evento` | Gestão de Eventos |
| **RF04** - Excluir um evento | `Evento` | Gestão de Eventos |
| **RF05** - Cadastrar parâmetros do tipo de evento | `TipoEventoParametro` | Parametrização e Regras |
| **RF06** - Editar parâmetros do tipo de evento | `TipoEventoParametro` | Parametrização e Regras |
| **RF07** - Excluir parâmetros do tipo de evento | `TipoEventoParametro` | Parametrização e Regras |
| **RF08** - Cadastrar participante | `Participante` | Cadastro Base de Pessoas |
| **RF09** - Editar um participante | `Participante` | Cadastro Base de Pessoas |
| **RF10** - Excluir o participante | `Participante` | Cadastro Base de Pessoas |
| **RF11** - Cadastrar o participante do evento | `ParticipanteEvento` | Lista de Convidados e Presença |
| **RF12** - Excluir o participante do evento | `ParticipanteEvento` | Lista de Convidados e Presença |
| **RF13** - Alterar o participante do evento | `ParticipanteEvento` | Lista de Convidados e Presença |
| **RF14** - Cadastrar categoria | `Categoria` | Catálogo e Categorização |
| **RF15** - Editar categoria | `Categoria` | Catálogo e Categorização |
| **RF16** - Excluir categoria | `Categoria` | Catálogo e Categorização |


# Diagrama de Casos de Uso - Sistema de Churrasco / Eventos

Este documento apresenta o **Diagrama de Casos de Uso (UML)** do sistema, mapeando as interações entre os **Atores** e as **Funcionalidades (Casos de Uso)** derivadas dos Requisitos Funcionais (RF01 ao RF16).

---

## 1. Atores do Sistema

* **Organizador / Usuário Autenticado:** Pessoa responsável por criar e gerenciar eventos, parâmetros, categorias e convidados.
* **Visitante / Não Autenticado:** Pessoa que acessa o sistema para criar sua conta (RF01).
* **Participante / Convidado:** Pessoa que faz parte da lista de presença de um evento específico.

---

## 2. Diagrama de Casos de Uso (Sintaxe Mermaid)

```mermaid
usecaseDiagram
    direction LR

    actor "Visitante" as Visitor
    actor "Organizador (Usuário)" as User
    actor "Participante / Convidado" as Guest

    rectangle "Sistema de Gestão  Eventos" {

        %% Módulo de Usuários
        usecase "UC01 - Cadastrar Usuário" as UC01
        usecase "UC00 - Efetuar Login / Autenticação" as UC00

        %% Módulo de Eventos
        usecase "UC02 - Cadastrar Evento" as UC02
        usecase "UC03 - Editar Evento" as UC03
        usecase "UC04 - Excluir Evento" as UC04

        %% Módulo de Parametrização
        usecase "UC05 - Cadastrar Parâmetros do Tipo de Evento" as UC05
        usecase "UC06 - Editar Parâmetros do Tipo de Evento" as UC06
        usecase "UC07 - Excluir Parâmetros do Tipo de Evento" as UC07

        %% Módulo de Cadastro Base de Pessoas
        usecase "UC08 - Cadastrar Participante (Contatos)" as UC08
        usecase "UC09 - Editar Participante (Contatos)" as UC09
        usecase "UC10 - Excluir Participante (Contatos)" as UC10

        %% Módulo de Gestão de Convidados do Evento
        usecase "UC11 - Adicionar Participante ao Evento" as UC11
        usecase "UC12 - Remover Participante do Evento" as UC12
        usecase "UC13 - Alterar Status/Item do Participante no Evento" as UC13

        %% Módulo de Categorias
        usecase "UC14 - Cadastrar Categoria" as UC14
        usecase "UC15 - Editar Categoria" as UC15
        usecase "UC16 - Excluir Categoria" as UC16
    }

    %% Interações de Atores Não Autenticados
    Visitor --> UC01

    %% Interações do Organizador (Usuário Logado)
    User --> UC00
    User --> UC02
    User --> UC03
    User --> UC04

    User --> UC05
    User --> UC06
    User --> UC07

    User --> UC08
    User --> UC09
    User --> UC10

    User --> UC11
    User --> UC12
    User --> UC13

    User --> UC14
    User --> UC15
    User --> UC16

    %% Interações de Relações de Inclusão e Extensão
    UC02 ..> UC00 : <<include>>
    UC03 ..> UC02 : <<extend>>
    UC11 ..> UC08 : <<include>>
    UC11 ..> UC02 : <<include>>
    UC13 --> Guest : Interage / Responde Convite
```

---

## 3. Especificação e Mapeamento dos Casos de Uso

| Caso de Uso | Nome | Requisito Funcional | Ator Principal | Descrição Sucinta |
| :--- | :--- | :---: | :--- | :--- |
| **UC01** | Cadastrar Usuário | **RF01** | Visitante | Permite que uma nova pessoa crie uma conta de organizador na plataforma. |
| **UC02** | Cadastrar Evento | **RF02** | Organizador | Cria um novo churrasco ou evento, definindo nome, data, horário e localização. |
| **UC03** | Editar Evento | **RF03** | Organizador | Atualiza as informações gerais de um evento cadastrado. |
| **UC04** | Excluir Evento | **RF04** | Organizador | Remove um evento e suas vinculações. |
| **UC05** | Cadastrar Parâmetros | **RF05** | Organizador | Define regras/métricas de consumo por pessoa para um tipo de evento. |
| **UC06** | Editar Parâmetros | **RF06** | Organizador | Altera as regras e quantidades médias configuradas para um tipo de evento. |
| **UC07** | Excluir Parâmetros | **RF07** | Organizador | Exclui um perfil de parametrização cadastrado. |
| **UC08** | Cadastrar Participante | **RF08** | Organizador | Adiciona um amigo ou contato à agenda/base global de pessoas. |
| **UC09** | Editar Participante | **RF09** | Organizador | Altera dados cadastrais de um contato (nome, telefone, restrições alimentares). |
| **UC10** | Excluir Participante | **RF10** | Organizador | Remove um contato da base global de pessoas. |
| **UC11** | Adicionar Participante ao Evento | **RF11** | Organizador | Vincula uma pessoa da base global à lista de convidados de um evento específico. |
| **UC12** | Remover Participante do Evento | **RF12** | Organizador | Retira um participante da lista de presenças de um evento. |
| **UC13** | Alterar Participante do Evento | **RF13** | Organizador / Convidado | Atualiza status de confirmação (`Confirmado`, `Pendente`) ou o item a levar/comprar. |
| **UC14** | Cadastrar Categoria | **RF14** | Organizador | Cria uma categoria de insumo (ex: Carnes, Bebidas, Acompanhamentos). |
| **UC15** | Editar Categoria | **RF15** | Organizador | Atualiza o nome, ícone ou descrição de uma categoria. |
| **UC16** | Excluir Categoria | **RF16** | Organizador | Remove uma categoria do catálogo. |

---

## 4. Detalhamento de Fluxos Principais (Exemplo)

### UC11 - Adicionar Participante ao Evento (RF11)
* **Ator Principal:** Organizador.
* **Pré-condições:** O organizador deve estar autenticado, o evento deve estar criado (**RF02**) e a pessoa deve estar cadastrada na base de contatos (**RF08**).
* **Fluxo Principal:**
  1. O organizador seleciona um evento ativo.
  2. O sistema exibe a opção "Adicionar Participante".
  3. O organizador busca e escolhe um contato da sua base global.
  4. O organizador define o status inicial (ex: "Pendente" ou "Confirmado") e o item a levar (opcional).
  5. O sistema registra o vínculo na entidade `ParticipanteEvento`.
* **Pós-condições:** O número de participantes confirmados/pendentes é atualizado nas métricas do evento.