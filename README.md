# .net-base-repository

PROJETO: .Net Base
BIBLIOTECAS
Nome: Entity Framework Core
Documentação: https://docs.microsoft.com/pt-br/ef/
Objetivo: O Entity Framework Core é um mapeador moderno de banco de dados de objeto para .NET. Ele dá suporte a consultas LINQ, controle de alterações, atualizações e migrações de esquema. O EF Core funciona com muitos bancos de dados, incluindo o Banco de Dados SQL (local e do Azure), o SQLite, o MySQL, o PostgreSQL e o Azure Cosmos DB.

Nome: Swagger
Documentação: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
Objetivo: Ferramentas para documentar APIs criadas com ASP.NET Core. Possibilita uma bela documentação de API, incluindo uma IU para explorar e testar operações, diretamente de suas rotas, controladores e modelos.

Nome: FluentValidator
Documentação: https://docs.fluentvalidation.net/en/latest/
Objetivo: Biblioteca .NET para construir regras de validação fortemente tipadas.

Nome: AutoMapper
Documentação: https://docs.automapper.org/en/stable/
Objetivo: Mapeador de objeto-objeto baseado em convenção. Usa um algoritmo de correspondência baseado em convenção para fazer a correspondência entre os valores de origem e destino. AutoMapper é voltado para cenários de projeção de modelo para achatar modelos de objetos complexos para DTOs e outros objetos simples, cujo design é mais adequado para serialização, comunicação, mensagens ou simplesmente uma camada anticorrupção entre o domínio e a camada de aplicativo.

Nome: Logging (ILogger)
Documentação: https://docs.microsoft.com/pt-br/dotnet/api/microsoft.extensions.logging.ilogger
Objetivo: Biblioteca interna voltada para implementação e registro de logs.

Nome: Moq
Documentação: https://documentation.help/Moq/A6BA45E0.htm
Objetivo: Criar objetos fictícios simulados que imitam o comportamento de objetos reais, geralmente usados em testes de unidade.

TESTES
Nome: xUnit
Documentação: https://xunit.net/
Objetivo: Ferramenta de teste de unidade, de código aberto para o .NET Framework. xUnit.net é a mais recente tecnologia para testes de unidade C #, F #, VB.NET e outras linguagens .NET. Funciona com ReSharper, CodeRush, TestDriven.NET e Xamarin. Faz parte da .NET Foundation e opera de acordo com seu código de conduta. Ele é licenciado sob Apache 2 (uma licença aprovada pela OSI).

IMPLEMENTAÇÕES IMPORTANTES
Descrição: MessageProvider
Objetivo: Padronização de mensagens de retorno e facilitar manutenção.

Descrição: Autenticação via JWT
Objetivo: Gerar token assinado para autenticação entre duas partes. Token em Base64 que armazena objetos json com dados que permitem autenticar a requisição.

Descrição: ErrorMiddleware
Objetivo: Manipulador de erros que recebe todos os erros as exceções e warnings.

Descrição: Endpoints Tenant
Objetivo: Crud para retorno, criação e alteração das informações Tenant atráves dos métodos Create, Update, Delete, Get(paginado), GetById.

Descrição: Estrutura de camadas Tenant
Objetivo: Implementação das classes Tenant nas camadas API, Application, Domain e Persistence para fluxo da aplicação e correto funcionamento.

Descrição: Inclusão de propriedades 
Objetivo: Inclusão das propriedades tenandId na classe Produto e e UserIdentity para melhor relacionamento.

BRANCHS
Nome: main
Descrição: Branch original do projeto base refatorado.

Nome: backup/main-backup
Descrição: Backup da main(antiga) onde havia o projeto base antes de ser refatorado.

Nome: refactor
Descrição: Criada para melhorias da main com refatoração do projeto base.
