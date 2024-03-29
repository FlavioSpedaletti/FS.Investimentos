# FS.Investimentos
## Rastreador de valores de cotas de ações e FIIs e dashboard pessoal de performance de investimentos.

- https://br.tradingview.com/
- https://statusinvest.com.br/

[![Build status](https://ci.appveyor.com/api/projects/status/frnkwy8w0s9cdpr7?svg=true)](https://ci.appveyor.com/project/FlavioSpedaletti/fs-investimentos) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=FlavioSpedaletti_FS.Investimentos&metric=alert_status)](https://sonarcloud.io/dashboard?id=FlavioSpedaletti_FS.Investimentos) [![Issues](https://img.shields.io/github/issues/FlavioSpedaletti/FS.Investimentos.svg)](https://huboard.com/FlavioSpedaletti/FS.Investimentos)

## Stack
- Asp.Net Core (API)
- EF Core
- Dapper (?)
- MySQL
- Angular (?)
- Hangfire

### Tópicos para estudo
- Migrations
- Domain Driven Design
- Domínios ricos
    - Values objects
    - Encapsulamento (sets privados)
    - Interfaces que revelam a intenção - EVANS (2004)
    - Validações com Notification Pattern
        - Flunt (?)
    - Domain, Subdomains e Bounded Contexts (?)
- Persistência com Repository e Unit of Work Patterns
- Autenticação - JWT ou Basic Authentication (?)
- Testes em todas as camadas
- AutoMapper
- Miniprofiler
- CI/CD
    - GitHub Actions (?)
    - SonarQube / SonarCloud
- Docker (?)
- Azure (?)

## Instruções para rodar
- Para criar o banco de dados já com a estrutura correta basta rodar as migrations:
	- No Package Manager Console: <code>Update-Database</code>, lembrando que o projeto web precisa ser o projeto startup para que a migrations encontre a connectionstring do contexto (EFContext); OU
	- No cmd, na pasta do projeto Investimentos.Infra.Data: <code>dotnet ef database update -s ../Investimentos.Web</code> (ou Investimentos.Api)

## Referências de artigos
- https://itnext.io/creating-an-application-from-scratch-using-net-core-and-angular-part-1-d1c66733c57d
- https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368
- https://maiconheck.com/domain-driven-design-do-inicio-ao-codigo/
- https://medium.com/@ericandrade_24404/parte-01-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-60b851c88461
- https://medium.com/@alexalvess/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686 (tem alguns erros de design, mas pode ser uma boa referência para alguns pontos)
- https://medium.com/@alexalvess/configurando-migrations-no-ef-core-com-mysql-e8f33619c268 e https://www.youtube.com/watch?v=L1bJUKZV0b0 (migrations com mysql)
- https://codeburst.io/adding-basic-authentication-to-an-asp-net-core-web-api-project-5439c4cf78ee (basic auth)

## Referências de projetos
- https://github.com/andrebaltieri/SimpleRoomBookingCore
- https://github.com/rcarneironet/valhalla-clean-architecture
- https://github.com/dotnet-architecture/eShopOnWeb
- https://github.com/maiconheck/keepmoney
- https://github.com/alexalvess/Modelo.Api
