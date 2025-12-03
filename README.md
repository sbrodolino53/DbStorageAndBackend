# Minimal JWT API – PostgreSQL & EF Core

Light, ASP.NET Core Minimal API that registers and logs-in users, issues signed JWTs, and stores everything in PostgreSQL with EF Core.

---

## Stack
- .NET 8
- ASP.NET Core Minimal APIs
- EF Core 8 & Npgsql
- BCrypt.Net for password hashing
- FluentValidation for input rules
- System.IdentityModel.Tokens.Jwt for bearer tokens
- Scalar (OpenAPI UI in dev)

---

## Quick Start

1. **Clone the repo**  
	git clone https://github.com/sbrodolino53/DbStorageAndBackend.git
	cd DbStorageAndBackend
2. **Add the user secrets (JwtKey and DB connection string)**
	dotnet user-secrets init
	dotnet user-secrets set ConnectionStrings:PersonDb "Host=localhost;Database=minidb;Username=mini;Password=mini"
	dotnet user-secrets set JwtKey "AtLeast32CharactersLongKeyForHmacSha256SecurityScheme"

3. **Build and Run**
	dotnet build
	dotnet run