using Microsoft.EntityFrameworkCore;
using MinimalApiTemplate.Features.Users;
using MinimalApiTemplate.Infrastructure.Auth;

namespace MinimalApiTemplate.Infrastructure.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/auth/register", Register);
        routes.MapPost("/auth/login",    Login);
    }

    private static async Task<IResult> Register(RegisterDto dto, RegisterDtoValidator validator, AppDbContext db, JwtService jwt)
    {
		var vr = await validator.ValidateAsync(dto);
		if (!vr.IsValid)
			return Results.ValidationProblem(vr.ToDictionary());

        if (await db.Users.AnyAsync(u => u.Email == dto.Email))
            return Results.BadRequest("Email already exists.");

        var user = new User
        {
            Email    = dto.Email,
            Password = PasswordService.Hash(dto.Password)
        };
		// protegge da attacchi sql perché inserisce come data non come sql eseguibile
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return Results.Created($"/users/{user.Id}", new { user.Id, user.Email });
    }

    private static async Task<IResult> Login(LoginDto dto, AppDbContext db, JwtService jwt)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user is null || !PasswordService.Verify(dto.Password, user.Password))
            return Results.Unauthorized();

        var token = jwt.CreateToken(user);
        return Results.Ok(new AuthResponseDto(user.Email, token));
    }
}