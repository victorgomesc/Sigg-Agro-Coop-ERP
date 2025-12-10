# SiggAgroCoop

A SiggAgroCoop é um sistema de grenciamento de propriedades rurais, que tem como principal objetivo ajudar os produtores 
rurais a gerenciar suas propriedades de maneira eficiente através da tecnologia.

## Estagio do Projeto

Atualmente o projeto encontra-se em fase de desenvolvimento.

## Autores

- [@victorgomesc](https://github.com/victorgomesc)


## 🚀 Tecnologias Utilizadas

<ul>
    <li>.NET 8 (ASP.NET Core Web API)</li>
    <li>Entity Framework Core (ORM e acesso a dados)</li>
    <li>PostgreSQL (banco de dados em desenvolvimento)</li>
    <li>xUnit (testes unitários)</li>
    <li>Swagger / Swashbuckle (documentação e testes de endpoints)</li>
    <li>JWT (JSON Web Token) para autenticação</li>
</ul>


## 📐 Arquitetura

A arquitetura utilizada nesse projeto é uma combinação estruturada de <strong>Clean Architecture + DDD (Domain-Driven Design) + CQRS + Repository Pattern</strong>. Essa combinação forma uma solução modular de baixa dependencia e alta escalabilidade, baseado em padrões de sistemas corporativos modernos.

### 1. Clean Architecture (Arquitetura Limpa)
<strong>Objetivo: </strong> <p>Independência entre camadas.</p>
<p>O projeto está dividido em:</p>

📁 Raiz- AgroErp/src  
|
|-- 📦 1- **SiggAgroCoop.Domain (Domain)**
|        |- 📌 Contém regras de negócio puras
|        |- 🧱 Entidades
|        |- 🏷️ Enums
|        |- 📄 Interfaces de domínio (contratos de repositórios)
|
|-- ⚙️ 2- **SiggAgroCoop.Application (Application)**
|        |- 🚀 Casos de uso (Services, Handlers, DTOs)
|        |- 🔁 Orquestra lógica da aplicação
|        |- 📚 Regras de negócio específicas do caso de uso
|        |- 🔌 Interfaces de serviços
|
|-- 🗄️ 3- **SiggAgroCoop.Infrastructure (Infrastructure)**
|        |- 💾 Implementação concreta dos repositórios
|        |- 🧩 Entity Framework Core
|        |- 🏛️ Conexão com o banco (Context)
|        |- 🧱 Migrations
|        |- 🌐 Serviços externos
|
|-- 🌍 4- **SiggAgroCoop.Api (Api)**
|        |- 🎯 Controllers
|        |- 🔐 Middlewares
|        |- 🛡️ Configuração de autenticação
|        |- 🔗 Endpoints REST




