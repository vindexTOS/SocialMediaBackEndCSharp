
using DTOs.User;
using Models.User;

namespace Services.UserServices;
 
	public interface IUserService
	{
 

   	Task <string>  SignUp(UserDto requestBody);
	Task<string> SignIn(UserLogInDto requestBody);
	}
 