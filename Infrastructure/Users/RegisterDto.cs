using System.ComponentModel.DataAnnotations;
namespace MinimalApiTemplate.Features.Users;

public record RegisterDto(string Email, string Password);