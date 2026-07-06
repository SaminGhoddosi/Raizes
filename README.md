# Raízes ERP 🌱

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-orange.svg)](https://www.mysql.com/)

A complete ERP built to strengthen family farming, giving small producers simple and accessible tools to organize their finances, plan harvests, and make decisions based on real data.

## About the Project

**Raízes** is an ERP solution developed to meet the specific needs of family farming. As **Back-End Developer**, I was responsible for the entire API build, implementing critical features for agricultural management.

**Context:** Project presented at the **Entra-21 Talent Showcase**, delivered on time and running efficiently.

## Project Structure

```
ApiRaizes/
├── 📁 Contracts/                 # Contracts and interfaces
│   ├── 📁 Infrastructure/        # Infrastructure interfaces
│   ├── 📁 Repository/            # Repository interfaces
│   └── 📁 Services/              # Service interfaces
├── 📁 Controllers/               # API controllers
│   ├── SaleController.cs         # Sales management
│   ├── HarvestController.cs      # Harvest management
│   ├── PlantingController.cs     # Planting management
│   ├── UserController.cs         # User management
│   └── (Other controllers)
├── 📁 DTO/                       # Data Transfer Objects
├── 📁 Entity/                    # Domain entities
├── 📁 Infrastructure/            # Infrastructure implementations
│   └── Connection.cs             # Database connection
├── 📁 Repository/                # Repository implementations
├── 📁 Response/                  # Standardized response models
├── 📁 Services/                  # Service layer
├── Program.cs                    # App configuration and startup
└── appsettings.json              # Application settings
```

## Technologies and Concepts Implemented

### Core Framework
- **ASP.NET Core 8** - Main framework
- **Entity Framework Core** - ORM for data access
- **MySQL** - Relational database

### Security and Authentication
- **JWT (JSON Web Tokens)** - Stateless authentication
- **Bearer Authentication** - Access control
- **Token Validation** - JWT token validation

### Architecture and Patterns
- **Repository Pattern** - Data layer abstraction
- **Dependency Injection** - Inversion of control
- **DTO Pattern** - Separation between domain models and transfer objects
- **Service Layer** - Separation of concerns
- **Clean Architecture** - Clean, organized architecture

### Documentation and API
- **Swagger/OpenAPI** - Interactive API documentation
- **API Versioning** - Version control
- **CORS** - Cross-Origin Resource Sharing

## Features

### Authentication and Authorization
- **JWT Authentication** with secure tokens
- **Claims-based authorization**
- **Token validation** with symmetric signing

### Agricultural ERP Modules
- **Planting Management** - Species, planning, raw materials
- **Harvest Control** - Tracking, storage
- **Sales Management** - CRM, financial history
- **Inventory Control** - Raw materials, supplies
- **Equipment Management** - Farm machinery
- **Soil Analysis** - History and soil types
- **Suppliers** - Partner registration and management

## Setup and Installation

### Prerequisites
- .NET 8 SDK
- MySQL Server
- Visual Studio 2022 or VS Code

### Configuration
1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd ApiRaizes
   ```

2. **Configure the connection string** in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=RaizesERP;Uid=user;Pwd=password;"
     },
     "JwtSettings": {
       "SecretKey": "your-super-secure-secret-key-here"
     }
   }
   ```

3. **Run the migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

## Using the API

### Authentication

1. **Login** (generic example):
   ```http
   POST /api/auth/login
   Content-Type: application/json

   {
     "email": "producer@example.com",
     "password": "password123"
   }
   ```

### Request Examples

**List sales (requires authentication)**:
```http
GET /api/Sale
Authorization: Bearer {your-jwt-token}
```

**Create a new planting (requires authentication)**:
```http
POST /api/Planting
Authorization: Bearer {your-jwt-token}
Content-Type: application/json

{
  "speciesId": 1,
  "propertyId": 1,
  "plantingDate": "2024-01-15",
  "estimatedHarvestDate": "2024-06-15"
}
```

**Query harvests**:
```http
GET /api/Harvest
Authorization: Bearer {your-jwt-token}
```

## Security

- **JWT Authentication** with symmetric keys
- **Token lifetime validation**
- **Bearer Token** in authorization headers
- **CORS** configured for the frontend
- **Data validation** at the service layer

## Architecture

### Design Patterns
- **Repository Pattern** - Full data layer abstraction
- **Dependency Injection** - Native ASP.NET Core injection
- **DTO Pattern** - Separation between domain models and API
- **Service Layer** - Centralized business logic

### Application Layers
```
ApiRaizes/
├── Controllers/     # API endpoints
├── Services/        # Business logic
├── Repository/      # Data access
├── Contracts/       # Interfaces and contracts
├── Entity/          # Domain models
└── DTO/            # Transfer objects
```

## Implemented Modules

### Agricultural Management
- `Planting` - Planting and planning
- `Harvest` - Harvest and tracking
- `Species` - Cultivated species
- `SoilType` - Soil types

### Commercial Management
- `Sale` - Sales and finance
- `Supplier` - Suppliers
- `StockMovement` - Stock movement

### Resources
- `Equipment` - Farm equipment
- `RawMaterial` - Raw materials
- `Property` - Rural properties


## Key Takeaways

### Concepts Mastered
- **ASP.NET Core 8** and Web APIs
- **Entity Framework Core** with MySQL
- **JWT Authentication** and security
- **Repository Pattern** and Dependency Injection
- **Clean Architecture** and separation of concerns
- **Swagger/OpenAPI** for documentation
- **CORS** and frontend configuration

### Skills Developed
- Full ERP development
- Scalable software architecture
- Project management under a fixed deadline
- Teamwork and front/back-end integration
- Presenting projects to an audience

### Technical Competencies
- **Backend:** ASP.NET Core, RESTful APIs, Entity Framework
- **Database:** MySQL, Migrations, Schema Design
- **Security:** JWT, Authentication, Authorization
- **Architecture:** Clean Architecture, Design Patterns
- **Tools:** Swagger, Dependency Injection, CORS

---

**🌱 Built with 💙 to strengthen family farming**
