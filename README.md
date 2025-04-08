# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed  
- Upload this template to your repository and start working from it  
- Read the instructions carefully and make sure all requirements are being addressed  
- The repository must provide instructions on how to configure, execute and test the project  
- Documentation and overall organization will also be taken into consideration  

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

See:
- [Business Rules](./.doc/business-rules.md)
- [Domain Events](./.doc/domain-events.md)

## ✅ How to Run the Project

```bash
# 1. Navigate to the backend project
cd backend/src/Ambev.DeveloperEvaluation.WebApi

# 2. Restore packages
dotnet restore

# 3. Apply migrations (PostgreSQL)
dotnet ef database update --startup-project ../Ambev.DeveloperEvaluation.WebApi --project ../Ambev.DeveloperEvaluation.ORM

# 4. Run the application
dotnet run
```

> Make sure PostgreSQL is running and the `DefaultConnection` string in `appsettings.json` is correctly configured.

## 🧪 How to Test the Endpoints

You can test the API using tools like **Postman** or **Swagger UI**.

After starting the project:

- Navigate to: `https://localhost:5001/swagger`
- All endpoints will be available under `/api/sales`

Operations available:
- `POST /api/sales` – Create a sale
- `PUT /api/sales/{id}` – Update a sale
- `DELETE /api/sales/{id}` – Delete a sale
- `GET /api/sales` – List all sales
- `GET /api/sales/{id}` – Get sale by ID

## 🗂️ Project Layers

This project follows a clean architecture approach with DDD principles:

```
src/
├── Application     → Commands, Queries, Validators, Event Handlers (MediatR)
├── Domain          → Entities, Enums, Events, Interfaces (Pure Domain Logic)
├── ORM             → DbContext, Mappings, Repositories, UnitOfWork
├── WebApi          → Controllers, DTOs, Swagger, Middleware
├── IoC             → Dependency Injection configuration
└── Common          → Cross-cutting concerns (Validation, Logging, Auth)
```

## 🛠️ Technologies Used

- **.NET 8**
- **Entity Framework Core (PostgreSQL)**
- **AutoMapper**
- **MediatR**
- **FluentValidation**
- **Swagger**
- **Docker (optional)**

## 📘 Business Rules & Domain Events

The system applies a set of business rules and emits events to decouple logic and track important operations.

- [Business Rules](./.doc/business-rules.md)  
- [Domain Events](./.doc/domain-events.md)