using dotnet_api.Dto;

namespace dotnet_api.Services
{
    public interface IAuthManager
    {

        Task<bool> ValidateUser(LoginUserDto user);
        Task<string> CreateToken();

    }
}
