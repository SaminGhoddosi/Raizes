# Raízes ERP 🌱

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-orange.svg)](https://www.mysql.com/)

Um ERP completo desenvolvido para fortalecer a agricultura familiar, oferecendo aos pequenos produtores ferramentas simples e acessíveis para organizar finanças, planejar safras e tomar decisões com base em dados reais.

## Sobre o Projeto

**Raízes** é uma solução ERP desenvolvida para atender às necessidades específicas da agricultura familiar. Como **Desenvolvedor Back-End**, fui responsável pela criação completa da API, implementando funcionalidades críticas para gestão agrícola.

**Contexto:** Projeto apresentado na **Amostra de Talentos do Entra-21**, entregue no prazo e funcionando eficientemente.

## Estrutura do Projeto

```
ApiRaizes/
├── 📁 Contracts/                 # Contratos e interfaces
│   ├── 📁 Infrastructure/        # Interfaces de infraestrutura
│   ├── 📁 Repository/            # Interfaces dos repositórios
│   └── 📁 Services/              # Interfaces dos serviços
├── 📁 Controllers/               # Controladores da API
│   ├── SaleController.cs         # Gestão de vendas
│   ├── HarvestController.cs      # Gestão de colheitas
│   ├── PlantingController.cs     # Gestão de plantios
│   ├── UserController.cs         # Gestão de usuários
│   └── (Outros controllers)
├── 📁 DTO/                       # Data Transfer Objects
├── 📁 Entity/                    # Entidades do domínio
├── 📁 Infrastructure/            # Implementações de infraestrutura
│   └── Connection.cs             # Conexão com banco de dados
├── 📁 Repository/                # Implementações dos repositórios
├── 📁 Response/                  # Modelos de resposta padronizados
├── 📁 Services/                  # Camada de serviços
├── Program.cs                    # Configuração e startup
└── appsettings.json              # Configurações da aplicação
```

## Tecnologias e Conceitos Implementados

### Core Framework
- **ASP.NET Core 8** - Framework principal
- **Entity Framework Core** - ORM para acesso a dados
- **MySQL** - Banco de dados relacional

### Segurança e Autenticação
- **JWT (JSON Web Tokens)** - Autenticação stateless
- **Bearer Authentication** - Controle de acesso
- **Token Validation** - Validação de tokens JWT

### Arquitetura e Padrões
- **Repository Pattern** - Abstração da camada de dados
- **Dependency Injection** - Inversão de controle
- **DTO Pattern** - Separação entre modelos de domínio e transferência
- **Service Layer** - Separação de responsabilidades
- **Clean Architecture** - Arquitetura limpa e organizada

### Documentação e API
- **Swagger/OpenAPI** - Documentação interativa da API
- **API Versioning** - Controle de versões
- **CORS** - Cross-Origin Resource Sharing

## Funcionalidades

###  Autenticação e Autorização
- **Autenticação JWT** com tokens seguros
- **Autorização baseada em claims** 
- **Validação de tokens** com assinatura simétrica

###  Módulos do ERP Agrícola
- **Gestão de Plantio** - Espécies, planejamento, matérias-primas
- **Controle de Colheita** - Acompanhamento, armazenamento
- **Gestão de Vendas** - CRM, histórico financeiro
- **Controle de Estoque** - Matérias-primas, insumos
- **Gestão de Equipamentos** - Maquinário agrícola
- **Análise de Solo** - Histórico e tipos de solo
- **Fornecedores** - Cadastro e gestão de parceiros

##  Configuração e Instalação

### Pré-requisitos
- .NET 8 SDK
- MySQL Server
- Visual Studio 2022 ou VS Code

### Configuração
1. **Clone o repositório**
   ```bash
   git clone [url-do-repositorio]
   cd ApiRaizes
   ```

2. **Configure a connection string** no `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=RaizesERP;Uid=usuario;Pwd=senha;"
     },
     "JwtSettings": {
       "SecretKey": "sua-chave-secreta-super-segura-aqui"
     }
   }
   ```

3. **Execute as migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Execute a aplicação**:
   ```bash
   dotnet run
   ```

##  Uso da API

### Autenticação

1. **Login** (exemplo genérico):
   ```http
   POST /api/auth/login
   Content-Type: application/json

   {
     "email": "produtor@exemplo.com",
     "password": "senha123"
   }
   ```

### Exemplos de Requisições

**Listar vendas (requer autenticação)**:
```http
GET /api/Sale
Authorization: Bearer {seu-jwt-token}
```

**Criar novo plantio (requer autenticação)**:
```http
POST /api/Planting
Authorization: Bearer {seu-jwt-token}
Content-Type: application/json

{
  "speciesId": 1,
  "propertyId": 1,
  "plantingDate": "2024-01-15",
  "estimatedHarvestDate": "2024-06-15"
}
```

**Consultar colheitas**:
```http
GET /api/Harvest
Authorization: Bearer {seu-jwt-token}
```

##  Segurança

- **JWT Authentication** com chaves simétricas
- **Validação de tempo de vida** do token
- **Bearer Token** em headers de autorização
- **CORS** configurado para frontend
- **Validação de dados** na camada de serviços

##  Arquitetura

### Padrões de Design
- **Repository Pattern** - Abstração completa da camada de dados
- **Dependency Injection** - Injeção nativa do ASP.NET Core
- **DTO Pattern** - Separação entre modelos de domínio e API
- **Service Layer** - Centralização da lógica de negócio

### Camadas da Aplicação
```
ApiRaizes/
├── Controllers/     # Endpoints da API
├── Services/        # Lógica de negócio
├── Repository/      # Acesso a dados
├── Contracts/       # Interfaces e contratos
├── Entity/          # Modelos de domínio
└── DTO/            # Objetos de transferência
```

##  Módulos Implementados

### Gestão Agrícola
- `Planting` - Plantio e planejamento
- `Harvest` - Colheita e acompanhamento
- `Species` - Espécies cultivadas
- `SoilType` - Tipos de solo

### Gestão Comercial
- `Sale` - Vendas e finanças
- `Supplier` - Fornecedores
- `StockMovement` - Movimentação de estoque

### Recursos
- `Equipment` - Equipamentos agrícolas
- `RawMaterial` - Matérias-primas
- `Property` - Propriedades rurais


##  Aprendizados

### Conceitos Dominados
-  **ASP.NET Core 8** e Web APIs
-  **Entity Framework Core** com MySQL
-  **JWT Authentication** e segurança
-  **Repository Pattern** e Dependency Injection
-  **Clean Architecture** e separação de concerns
-  **Swagger/OpenAPI** para documentação
-  **CORS** e configuração de frontend

### Habilidades Desenvolvidas
- Desenvolvimento de ERP completo
- Arquitetura de software escalável
- Gestão de projetos com prazo definido
- Trabalho em equipe e integração front/back
- Apresentação de projetos para público

### Competências Técnicas
- **Backend:** ASP.NET Core, APIs RESTful, Entity Framework
- **Banco de Dados:** MySQL, Migrations, Design de Schema
- **Segurança:** JWT, Authentication, Authorization
- **Arquitetura:** Clean Architecture, Design Patterns
- **Ferramentas:** Swagger, Dependency Injection, CORS

---

**🌱 Desenvolvido com 💙 para fortalecer a agricultura familiar**
