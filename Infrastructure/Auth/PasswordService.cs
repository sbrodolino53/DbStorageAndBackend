namespace MinimalApiTemplate.Infrastructure.Auth;

public static class PasswordService
{
    public static string Hash(string plain)       => BCrypt.Net.BCrypt.HashPassword(plain);
    public static bool   Verify(string plain, string hash) => BCrypt.Net.BCrypt.Verify(plain, hash);
}