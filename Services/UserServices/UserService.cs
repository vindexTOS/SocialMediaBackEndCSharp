 
using Auth.API.Infrastructure.Auth.JWT;
using Auth.JWT;
using Data.Context;
using DTOs.User;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
 
using Models.User;
 
namespace Services.UserServices;

public class UserService : IUserService
{
	private readonly DataDbContext _dbContext;

	private readonly IOptions<JWTConfiguration> _options;

	public UserService(DataDbContext dbContext, IOptions<JWTConfiguration> options)
	{
		_dbContext = dbContext;

	}

	public async Task <string>  SignUp(UserDto requestBody)
	{

		var email = await _dbContext.Users.AnyAsync(u => u.Email == requestBody.Email);
	 
			if(email){
		throw new InvalidOperationException("Email already exists");
			}
		if (requestBody.ConfPass != requestBody.Password)
		{
			throw new InvalidOperationException("Passwords do not match");
		}

		var user = new UserModel
		{
			UserName = requestBody.UserName,
			Email = requestBody.Email,
			Password = requestBody.Password,
			Avatar = requestBody.Avatar,
		};
		user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

		await _dbContext.Users.AddAsync(user);
		await _dbContext.SaveChangesAsync();
		return JwtConvertor(user);

	}



	public async Task <string> SignIn(UserLogInDto user )
	{
		var isUserExist = await _dbContext.Users.FirstOrDefaultAsync(x=> x.Email == user.Email ) ?? throw new InvalidOperationException("User dose not exist");

		bool isPassword = BCrypt.Net.BCrypt.Verify(user.Password, isUserExist.Password) ? true :  throw new InvalidOperationException("Passwords dose not match");
		
	   	return JwtConvertor(isUserExist);

	}


	private string JwtConvertor (UserModel user)
	{ 

	return JWTHelper.GenerateSecurityToken(
						user.UserName,
						user.Id,
						user.Role,
						_options).ToString();
	}

}

