namespace MinimalApiTemplate.Features.Users;

public class User
{
    public long   Id       { get; set; }
    public string Email    { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role     { get; set; } = "User";
}