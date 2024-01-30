<h1 align="center">
    <br>Microservice - Maestro Backoffice<br/> 
</h1>

## Descrição
Microserviço a ser usado pelos funcionários de backoffice responsável por cadastrar os inventarios de itens, 
atualizar o status do pedido, e enviar as mensagens relacioadas ao baixo estoque para o serviço de Logistica.

## Tech Stack

- **Languages**
    - C#, SQL
- **Frameworks**
    - EntityFramework Code-First and Migrations
    - NET Core 8.x
    - Testcontainers, XUnit, FluentAssertions, NSubstitute
- **Message Broker**
    - RabbitMQ
- **Observability**
    - Jaeger Dashboard
- **Architecture**
    - Clean source code
    - Domain Driven Design + Vertical Slice Architecture
    - Dependency injection

## Application

- **Host**: http://localhost:5003
- **Swagger API**: http://localhost:5003/swagger/index.html

## Usage

1. Clone the repo
2. Execute ```docker compose -f docker-compose.yaml```
3. Use Application.