# Shop API (.NET Backend)

This is the **backend API** for the online store, built with **.NET Core 7** and **Entity Framework Core**.

## 📌 Features

- RESTful API with **CRUD operations**.
- **Search, filtering, and sorting** via query parameters.
- **Entity Framework Core** for database interaction.
- Supports **SQL Server / PostgreSQL**.

## 🛠️ Installation & Setup

### 1️⃣ Install .NET Core SDK

[Download .NET SDK](https://dotnet.microsoft.com/download)

### 2️⃣ Clone the Repository

```sh
git clone https://github.com/delmaroi/ShopAPI.git
cd ShopAPI
```

```
dotnet restore
dotnet ef database update
dotnet run
API will be available at: http://localhost:5138
```

```
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/api/product` | Get all products |
| GET | `/api/product?search=Laptop` | Search for "Laptop" |
| GET | `/api/product?category=Electronics` | Filter by category |
| GET | `/api/product?sortBy=price&order=desc` | Sort by price (descending) |
| GET | `/api/product/{id}` | Get a single product |
```
