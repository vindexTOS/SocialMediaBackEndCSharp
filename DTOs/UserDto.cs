
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DTOs.User;

public class UserDto
{
	public int Id { get; set; }
	[Required]
	[EmailAddress(ErrorMessage = "Invalid email format")]
	public string? Email { get; set; }

	[Required]
	[StringLength(50, MinimumLength = 8)]

	public string? UserName { get; set; }
	[Required]
	public string? Password { get; set; }
	public string? ConfPass { get; set; }
	public string? Avatar { get; set; }

	public string? Role { get; set; }
}

public class UserLogInDto
{
	[Required]
	[EmailAddress(ErrorMessage = "Invalid email format")]
	public string? Email { get; set; }
	[Required]
	public string? Password { get; set; }
	public string? ConfPass { get; set; }
}


