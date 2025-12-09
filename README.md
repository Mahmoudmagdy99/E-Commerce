Full-Stack E-Commerce Platform

A production-ready e-commerce application built with ASP.NET Core Web API and Angular, showcasing advanced architecture, clean code practices, and real-world features such as authentication, payments, caching, and real-time updates.

🚀 Overview

Skinet is a full-stack e-commerce platform demonstrating Clean Architecture, domain-driven design principles, and scalable application structure.
The project integrates robust security, enterprise-grade data access patterns, high-performance caching, and a modern UI with real-time capabilities.

🏗️ Key Features
🔹 Backend (ASP.NET Core Web API)

Clean, modular architecture following DDD principles

Specification + Unit of Work patterns for flexible and testable data access

JWT authentication with role-based authorization

Integrated Stripe payments with secure webhook handling

Redis distributed caching for performance optimization

Global error handling and consistent API response structure

Entity Framework Core with SQL Server (code-first migrations)

🔹 Frontend (Angular)

Modern, responsive UI using Material UI and Tailwind CSS

Real-time updates with SignalR

Full e-commerce experience: product catalog, filtering, cart, checkout

Comprehensive admin dashboard for product and order management

Interceptors, guards, services, and state management best practices

🔹 DevOps & Infrastructure

Dockerized development environment

Configurable environment variables

Structured solution using Core, Infrastructure, and API layers

📁 Project Structure
Skinet/
├── Core/                # Domain models, interfaces, specifications
├── Infrastructure/      # EF Core, repositories, Unit of Work, context, caching
├── API/                 # Controllers, middleware, authentication, DI setup
└── client/              # Angular application (UI, components, services)

🛠️ Technologies Used

ASP.NET Core 7 Web API

Angular 15+

Entity Framework Core

SQL Server / LocalDB

Redis

Stripe Payments

SignalR

Material UI / Tailwind CSS

Docker
