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

📁 Raiz- AgroErp/src <br>
| <br>
|-- 📦 1- **SiggAgroCoop.Domain (Domain)** <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 📌 Contém regras de negócio puras <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🧱 Entidades <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🏷️ Enums <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 📄 Interfaces de domínio (contratos de repositórios) <br>
| <br>
|-- ⚙️ 2- **SiggAgroCoop.Application (Application)** <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🚀 Casos de uso (Services, Handlers, DTOs) <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🔁 Orquestra lógica da aplicação <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 📚 Regras de negócio específicas do caso de uso <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🔌 Interfaces de serviços <br>
| <br>
|-- 🗄️ 3- **SiggAgroCoop.Infrastructure (Infrastructure)** <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 💾 Implementação concreta dos repositórios <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🧩 Entity Framework Core <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🏛️ Conexão com o banco (Context) <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🧱 Migrations <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🌐 Serviços externos <br>
| <br>
|-- 🌍 4- **SiggAgroCoop.Api (Api)** <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🎯 Controllers <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🔐 Middlewares <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🛡️ Configuração de autenticação <br>
|&nbsp;&nbsp;&nbsp;&nbsp;|- 🔗 Endpoints REST <br>




