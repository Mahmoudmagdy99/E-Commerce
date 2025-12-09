```markdown
# Skinet — Full-Stack E-Commerce Platform

A production-ready full-stack e-commerce application built with ASP.NET Core (Web API) and Angular. Skinet demonstrates clean architecture, domain-driven design (DDD) principles, and real-world features like authentication, payments, caching, and admin tooling.

> Note: This README is a guided overview and quickstart. For environment-specific details, check configuration files in the repo (API/appsettings.*, client/environments/*) and any Docker Compose files.

Table of Contents
- [Overview](#overview)
- [Key Features](#key-features)
- [Architecture & Project Structure](#architecture--project-structure)
- [Tech Stack](#tech-stack)
- [Getting Started (Quickstart)](#getting-started-quickstart)
  - [Prerequisites](#prerequisites)
  - [Clone the Repository](#clone-the-repository)
  - [Backend (API) - Local Run](#backend-api---local-run)
  - [Frontend (Angular) - Local Run](#frontend-angular---local-run)
  - [Run with Docker (recommended for dev)](#run-with-docker-recommended-for-dev)
- [Configuration & Secrets](#configuration--secrets)
- [Testing](#testing)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [License & Acknowledgements](#license--acknowledgements)
- [Contact](#contact)

Overview
--------
Skinet is intended as a reference implementation of a scalable e-commerce platform demonstrating:
- Clear separation of concerns (Core / Infrastructure / API / client)
- Testable data access using specifications and Unit of Work patterns
- Secure authentication and role-based authorization (JWT)
- Payment integration with Stripe (including webhook handling)
- Distributed caching using Redis
- Real-time features using SignalR
- A modern responsive admin + storefront built with Angular

Key Features
------------
Backend (ASP.NET Core Web API)
- Clean, modular architecture following DDD practices
- Specification pattern + Unit of Work for repositories
- JWT authentication with role-based authorization
- Stripe payments + secure webhook endpoints
- Redis caching for improved performance
- Global error handling and consistent API responses
- EF Core (code-first) with migrations and SQL Server support

Frontend (Angular)
- Angular (15+) storefront and admin UI
- Material UI + Tailwind CSS for styling and layout
- Product catalog, filtering, cart, checkout flows
- Admin dashboard for product & order management
- SignalR for real-time updates
- Interceptors, guards, services and centralized state practices

DevOps & Infrastructure
- Dockerized development environment
- Configurable environment variables for different environments
- Clear solution layering: Core / Infrastructure / API / client

Architecture & Project Structure
-------------------------------
Top-level layout:
- Core/ — Domain models, interfaces, DTOs, specifications
- Infrastructure/ — EF Core context, repositories, Unit of Work, caching, external integrations
- API/ — Controllers, middleware, DI setup, authentication, startup
- client/ — Angular application (storefront + admin)

Tech Stack
----------
- Backend: ASP.NET Core 7, Entity Framework Core
- Frontend: Angular 15+, Angular Material, Tailwind CSS
- Database: SQL Server / LocalDB (EF migrations supported)
- Cache: Redis
- Payments: Stripe (server-side + webhooks)
- Real-time: SignalR
- Containerization: Docker / Docker Compose

Getting Started (Quickstart)
---------------------------

Prerequisites
- .NET 7 SDK
- Node.js (16+) and npm or yarn
- Angular CLI (optional, for development): npm i -g @angular/cli
- SQL Server or LocalDB
- Redis (or Docker)
- Docker & Docker Compose (optional but recommended)
- Stripe account (for testing payments) — obtain API keys and webhook secret

Clone the repository
```bash
git clone https://github.com/Mahmoudmagdy99/E-Commerce.git
cd E-Commerce
```

Backend (API) - Local Run
1. Navigate to the API project folder (adjust path if different):
```bash
cd API
```
2. Restore and build:
```bash
dotnet restore
dotnet build
```
3. Configure connection string and secrets:
- Update API/appsettings.Development.json or user secrets with:
  - ConnectionStrings:DefaultConnection
  - Stripe:SecretKey
  - Stripe:WebhookSecret
  - Redis:Connection
  - JWT settings (Issuer, Key, Expiry)
4. Apply EF Core migrations:
```bash
# from the solution root or API project folder
dotnet ef database update --project Infrastructure --startup-project API
```
(Replace project paths as appropriate if your solution layout differs.)

5. Run the API:
```bash
dotnet run --project API
```

Frontend (Angular) - Local Run
1. Go to client folder:
```bash
cd client
```
2. Install dependencies and run:
```bash
npm install
ng serve --open
```
3. Update client environment files (client/src/environments/) for API base URL, Stripe public key, etc.

Run with Docker (recommended for dev)
- If the repo includes a docker-compose.yml, you can build and run containers:
```bash
docker-compose up --build
```
This typically starts the API, database, and Redis services. Check docker-compose.yml for service names and ports.

Configuration & Secrets
-----------------------
- API configuration is in appsettings.json / appsettings.Development.json. Sensitive values (DB connection, JWT secret, Stripe keys) should be stored in environment variables, Docker secrets, or user secrets for local development.
- Example environment variables:
  - ConnectionStrings__DefaultConnection
  - JWT__Key
  - Stripe__SecretKey
  - Stripe__WebhookSecret
  - Redis__Connection

Stripe Webhooks
---------------
- When developing locally, you can use the Stripe CLI to forward webhooks to your local API:
```bash
stripe listen --forward-to localhost:5000/api/payments/webhook
```
- Verify that the webhook signing secret is set in the API configuration.

Testing
-------
- Backend unit/integration tests (if present) can be run with:
```bash
dotnet test
```
- Frontend tests (if included) can be run with Angular's testing commands:
```bash
cd client
npm test
```

Deployment
----------
- You can containerize the API and client and deploy with your preferred cloud provider or container platform (AKS, ECS, GKE, Azure App Service, etc.).
- Ensure production configuration for:
  - Strong JWT signing key and secure storage
  - TLS/HTTPS endpoints
  - Secure Stripe secrets and webhook endpoints
  - Proper CORS configuration
  - Scaling for Redis, DB, and SignalR

Contributing
------------
Contributions are welcome. If you'd like to contribute:
1. Fork the repository
2. Create a feature branch (git checkout -b feature/your-feature)
3. Implement changes and add tests
4. Open a pull request with a clear description

License & Acknowledgements
--------------------------
- Add your preferred license file (e.g. MIT) to the repository root.
- This project draws on common patterns and community libraries for ASP.NET Core and Angular.

Contact
-------
- Maintainer: Mahmoudmagdy99
- For issues: use the GitHub repository Issues tab.

```
