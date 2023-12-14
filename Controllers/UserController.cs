

using DTOs.User;
using Microsoft.AspNetCore.Mvc;

using Services.UserServices;


namespace User.Controllers;
[ApiController]
[Route("api/[controller]")]




public class UserController : ControllerBase


{
	private readonly IUserService _UserService;

	public UserController(IUserService userService)

	{
		_UserService = userService;
	}

	[HttpPost("signup")]

	public async Task<IActionResult> SignUp([FromBody] UserDto requestBody)
	{
		try
		{
			var result = await _UserService.SignUp(requestBody);
			return StatusCode(200, new { Token = result });
		}
		catch (InvalidOperationException ex)
		{

			return NotFound(new { message = ex.Message });

		}
		catch (InvalidDataException ex)
		{
			return StatusCode(500, new { message = ex.Message });

		}
	}
	[HttpPost("signin")]
	public async Task<IActionResult> SignIn([FromBody] UserLogInDto requestBody)
	{
		try
		{
			var result = await _UserService.SignIn(requestBody);
			return StatusCode(200, new { Token = result });

		}
		catch (InvalidOperationException ex)
		{
			return NotFound(new { message = ex.Message });

		}
		catch (InvalidDataException ex)
		{

			return StatusCode(500, new { message = ex.Message });

		}
	}

}

