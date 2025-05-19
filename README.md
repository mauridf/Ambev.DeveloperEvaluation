# Ambev Developer Evaluation - Sales API

📋 **Visão Geral**  
API para gerenciamento de vendas com CRUD completo, desenvolvida em .NET 8 seguindo princípios de DDD e CQRS.

---

🚀 **Como Executar**

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Docker (opcional para bancos de dados)
- PostgreSQL ou SQL Server
- MongoDB (opcional)

### Configuração Inicial

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/ambev-developer-evaluation.git
cd ambev-developer-evaluation
```

Configure as conexões de banco de dados no `appsettings.json`:

```json
"ConnectionStrings": {
  "PostgreSQL": "Host=localhost;Database=ambev_dev_eval;Username=postgres;Password=postgres",
  "MongoDB": "mongodb://localhost:27017"
}
```

### Executando com Docker (recomendado)

```bash
docker-compose up -d
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

### Executando localmente

```bash
dotnet restore
dotnet build
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

A API estará disponível em:  
🔗 https://localhost:5001 (HTTPS)  
🔗 http://localhost:5000 (HTTP)

---

🔧 **Endpoints Principais**

| Método | Endpoint                              | Descrição                  |
|--------|---------------------------------------|----------------------------|
| POST   | `/api/sales`                          | Criar nova venda           |
| GET    | `/api/sales/{id}`                     | Obter venda por ID         |
| GET    | `/api/sales`                          | Listar todas as vendas     |
| PUT    | `/api/sales/{id}`                     | Atualizar venda            |
| DELETE | `/api/sales/{id}`                     | Cancelar venda             |
| DELETE | `/api/sales/{id}/items/{itemId}`      | Cancelar item específico   |

---

🧪 **Executando Testes**

### Testes Unitários

```bash
dotnet test tests/Ambev.DeveloperEvaluation.Unit
```

### Testes de Integração

```bash
dotnet test tests/Ambev.DeveloperEvaluation.Integration
```

### Gerando Relatório de Cobertura

```bash
dotnet test --collect:"XPlat Code Coverage"
```

---

📊 **Tecnologias Utilizadas**

- **Backend**: .NET 8, C# 11  
- **Banco de Dados**: PostgreSQL (principal), MongoDB (opcional)  
- **ORM**: Entity Framework Core 8  
- **Testes**: xUnit, Moq, FluentAssertions  
- **Padrões**: DDD, CQRS, Clean Architecture  
- **Outros**: MediatR, AutoMapper, FluentValidation  

---

⚙️ **Estrutura do Projeto**

```
├── src/
│   ├── Application/    # Camada de aplicação (commands, handlers)
│   ├── Domain/         # Regras de negócio e entidades
│   ├── WebApi/         # Controllers e endpoints
│   ├── ORM/            # Configurações do banco de dados
│   └── Common/         # Utilitários compartilhados
│   └── IoC/            # Configuração de injeção de dependência (Dependency Injection)
├── tests/
│   ├── Unit/           # Testes unitários
│   └── Integration/    # Testes de integração
│   └── Funcional/      # Testes funcionais de ponta a ponta (end-to-end)
```

---

🔍 **Documentação da API**

Acesse a documentação Swagger após iniciar a aplicação:  
🔗 https://localhost:5001/swagger

---

⚠️ **Regras de Negócio**

- **Descontos automáticos**:
  - 4-9 itens: 10% de desconto
  - 10-20 itens: 20% de desconto

- **Limite máximo**: 20 unidades por produto
- **Vendas canceladas não podem ser modificadas**

---

📝 **Licença**

Este projeto é para fins avaliativos como parte do processo seletivo da **Ambev**.