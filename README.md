
#  Full-Stack E-Commerce Platform

A production-ready full-stack e-commerce Web application built with ASP.NET Core (Web API) and Angular (frontend). Implemented a Clean Architecture (Core/Infrastructure layers) using Entity Framework Core (SQL Server) with repository and unit-of-work patterns for data access. Configured JWT-based authentication (ASP.NET Identity) with role-based authorization, integrated Stripe for payment processing and promotional coupons, and leveraged Redis for caching (shopping cart and API responses). Developed the Angular client with Angular Material and Tailwind CSS, consuming RESTful APIs and using services, guards, and interceptors to support product catalog browsing, shopping cart and checkout workflows, and real-time order notifications via SignalR.


Overview
--------
Skinet is intended as a reference implementation of a scalable e-commerce platform demonstrating:
- Clear separation of concerns (Core / Infrastructure / API / client)
- Testable data access using specifications and Unit of Work patterns
- Secure authentication and role-based authorisation (JWT)
- Payment integration with Stripe (including webhook handling)
- Distributed caching using Redis
- Real-time features using SignalR
- A modern responsive admin + storefront built with Angular

Key Features
------------
Backend (ASP.NET Core Web API)
- Clean, modular architecture following DDD practices
- Specification pattern + Unit of Work for repositories
- JWT authentication with role-based authorisation
- Stripe payments + secure webhook endpoints
- Redis caching for improved performance
- Global error handling and consistent API responses
- EF Core (code-first) with migrations and SQL Server support

Frontend (Angular)
- Angular (15+) storefront and admin UI
- Material UI + Tailwind CSS for styling and layout
- Product catalogue, filtering, cart, checkout flows
- Admin dashboard for product & order management
- SignalR for real-time updates
- Interceptors, guards, services and centralised state practices

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
- Backend: ASP.NET Core, Entity Framework Core
- Frontend: Angular, Angular Material, Tailwind CSS
- Database: SQL Server / LocalDB (EF migrations supported)
- Cache: Redis
- Payments: Stripe (server-side + webhooks)
- Real-time: SignalR
- Containerization: Docker / Docker Compose



