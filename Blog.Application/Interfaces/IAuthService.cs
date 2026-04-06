using Blog.Application.Dtos;

namespace Blog.Application.Interfaces
{
    public interface IAuthService
    {

        Task<bool> RegisterUser(UserDto dto);
        Task<string> Login(UserDto dto);

    }
}
