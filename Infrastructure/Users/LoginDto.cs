using System.ComponentModel.DataAnnotations;

namespace MinimalApiTemplate.Features.Users;

public record LoginDto(
	[property: EmailAddress] string Email, 
	[property: MinLength(1)] string Password
	);