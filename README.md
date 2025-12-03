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

1. Clone the repo  
```bash
   git clone https://github.com/sbrodolino53/DbStorageAndBackend.git 
   cd DbStorageAndBackend
```

2. Add user secrets (JWT key & DB connection string)
```bash
	dotnet user-secrets init
```
Replace yourDatabaseName, yourUsername and yourPassword with your actual PostgreSQL values:
```bash
	dotnet user-secrets set ConnectionStrings:PersonDb \"Host=localhost;Database=yourDatabaseName;Username=yourUsername;Password=yourPassword"
```
Generate a 32-byte key and store it:
```bash
	dotnet user-secrets set JwtKey "$(openssl rand -base64 32)"
```
3. Create the database
Connect to the PostgreSQL database you have, and in terminal type this
	```bash
		CREATE TABLE users (
			id  BIGSERIAL PRIMARY KEY,
			email    VARCHAR(150) NOT NULL UNIQUE,
			password_hash VARCHAR(100)  NOT NULL,
			role     VARCHAR(20)  NOT NULL DEFAULT 'User'
		);
	```
4. Build and run
```bash
	dotnet build
	dotnet run
```
5. Try the API
Open https://localhost:5246/scalar/v1 in your browser and use the interactive UI to register/login.