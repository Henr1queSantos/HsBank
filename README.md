# 🏦 HS Bank - Digital Banking & Loan Management API

![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?logo=postgresql&logoColor=white)
![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?logo=rabbitmq&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)

## 👋 Welcome to HS Bank!
Hey there! This is a backend REST API I built to showcase modern, enterprise-grade engineering practices in .NET 8. 

I didn't want to build just another simple CRUD application. Instead, I designed this as a **Modular Monolith** with an Event-Driven Architecture. It handles secure customer onboarding and async loan processing, and it is intentionally structured so that it can easily be split out into distributed microservices as the system grows.

## 🏛️ Under the Hood: Why I built it this way

I am a big believer in writing software that is easy to maintain and scale. Here are the core architectural decisions I made for this project:

* **Clean Architecture & DDD:** The core business rules (Domain) are completely isolated from the database and web framework. You can swap out PostgreSQL for SQL Server tomorrow without touching the business logic.
* **CQRS Pattern (via MediatR):** Splitting read operations from write operations just makes sense for a banking app, allowing us to optimize and scale them independently.
* **Event-Driven Architecture:** This is my favorite feature. When a loan is created, the API doesn't hang while waiting to process notifications. It instantly fires a `LoanCreatedEvent` to **RabbitMQ**, returning a fast `201 Created` to the user while a background consumer handles the heavy lifting.
* **Fail-Safe Pipelines:** I implemented a custom Global Exception Handler and FluentValidation interceptors. Bad data is rejected before it ever hits the controllers, and stack traces are never leaked to the client.

## 💻 The Tech Stack
* **Core:** C# 12, .NET 8 ASP.NET Core
* **Database:** PostgreSQL with Entity Framework Core (Code-First)
* **Messaging:** RabbitMQ & MassTransit
* **Security:** JWT Authentication & BCrypt Password Hashing
* **Testing:** xUnit, Moq, FluentAssertions
* **Infrastructure:** Docker & Docker Compose

## 🚀 How to Run It Locally

You will need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and Docker Desktop installed.

**1. Spin up the Database & Message Broker**
```bash
# This starts PostgreSQL and RabbitMQ in the background
docker-compose up -d
```
*(Tip: You can view the RabbitMQ dashboard at `http://localhost:15672` using guest/guest)*

**2. Run the API**
```bash
dotnet build
dotnet run --project HsBank.Api
```
The Swagger UI will be waiting for you at: `http://localhost:5218/swagger`

## 🧪 Testing
I firmly believe code isn't done until it's tested. The domain and application layers are fully covered by unit tests, ensuring the CQRS handlers execute flawlessly without needing a live database connection.

```bash
dotnet test
```

## 📈 What's Next? (Phase 2 Roadmap)
Software is never really finished. Here is what I am planning to implement next as I evolve this into a fully distributed system:
- [ ] Extract the Authentication logic into a standalone Identity Microservice (Keycloak/OAuth2).
- [ ] Implement Redis Distributed Caching to supercharge the GET endpoints.
- [ ] Add full Observability (Serilog, Seq) to trace requests across the event bus.
- [ ] Automate deployments with GitHub Actions CI/CD pipelines.
