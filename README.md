# .net-base-repository

### BIBLIOTECAS
__Nome__: Entity Framework Core  
__Documentação__: https://docs.microsoft.com/pt-br/ef/  
__Objetivo__: O Entity Framework Core é um mapeador moderno de banco de dados de objeto para .NET. Ele dá suporte a consultas LINQ, controle de alterações, atualizações e migrações de esquema. O EF Core funciona com muitos bancos de dados, incluindo o Banco de Dados SQL (local e do Azure), o SQLite, o MySQL, o PostgreSQL e o Azure Cosmos DB.

__Nome__: Swagger  
__Documentação__: https://github.com/domaindrivendev/Swashbuckle.AspNetCore  
__Objetivo__: Ferramentas para documentar APIs criadas com ASP.NET Core. Possibilita uma bela documentação de API, incluindo uma IU para explorar e testar operações, diretamente de suas rotas, controladores e modelos.

__Nome__: FluentValidator  
__Documentação__: https://docs.fluentvalidation.net/en/latest/  
__Objetivo__: Biblioteca .NET para construir regras de validação fortemente tipadas.

__Nome__: AutoMapper  
__Documentação__: https://docs.automapper.org/en/stable/  
__Objetivo__: Mapeador de objeto-objeto baseado em convenção. Usa um algoritmo de correspondência baseado em convenção para fazer a correspondência entre os valores de origem e destino. AutoMapper é voltado para cenários de projeção de modelo para achatar modelos de objetos complexos para DTOs e outros objetos simples, cujo design é mais adequado para serialização, comunicação, mensagens ou simplesmente uma camada anticorrupção entre o domínio e a camada de aplicativo.

__Nome__: Logging (ILogger)  
__Documentação__: https://docs.microsoft.com/pt-br/dotnet/api/microsoft.extensions.logging.ilogger  
__Objetivo__: Biblioteca interna voltada para implementação e registro de logs.

__Nome__: Moq  
__Documentação__: https://documentation.help/Moq/A6BA45E0.htm  
__Objetivo__: Criar objetos fictícios simulados que imitam o comportamento de objetos reais, geralmente usados em testes de unidade.  

---
### TESTES
__Nome__: xUnit  
__Documentação__: https://xunit.net/  
__Objetivo__: Ferramenta de teste de unidade, de código aberto para o .NET Framework. xUnit.net é a mais recente tecnologia para testes de unidade C #, F #, VB.NET e outras linguagens .NET. Funciona com ReSharper, CodeRush, TestDriven.NET e Xamarin. Faz parte da .NET Foundation e opera de acordo com seu código de conduta. Ele é licenciado sob Apache 2 (uma licença aprovada pela OSI).  

---

### IMPLEMENTAÇÕES IMPORTANTES
__Descrição__: MessageProvider  
__Objetivo__: Padronização de mensagens de retorno e facilitar manutenção.

__Descrição__: Autenticação via JWT  
__Objetivo__: Gerar token assinado para autenticação entre duas partes. Token em Base64 que armazena objetos json com dados que permitem autenticar a requisição.

__Descrição__: ErrorMiddleware  
__Objetivo__: Manipulador de erros que recebe todos os erros as exceções e warnings.

__Descrição__: Endpoints Tenant  
__Objetivo__: Crud para retorno, criação e alteração das informações Tenant atráves dos métodos Create, Update, Delete, Get(paginado), GetById.

__Descrição__: Estrutura de camadas Tenant  
__Objetivo__: Implementação das classes Tenant nas camadas API, Application, Domain e Persistence para fluxo da aplicação e correto funcionamento.

__Descrição__: Inclusão de propriedades   
__Objetivo__: Inclusão das propriedades tenandId na classe Produto e e UserIdentity para melhor relacionamento.  

---

### BRANCHS
__Nome__: main  
__Descrição__: Branch original do projeto base refatorado.

__Nome__: backup/main-backup  
__Descrição__: Backup da main(antiga) onde havia o projeto base antes de ser refatorado.

__Nome__: refactor  
__Descrição__: Criada para melhorias da main com refatoração do projeto base.
