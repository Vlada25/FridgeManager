using FridgeManager.DTO.User;

namespace FridgeManager.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
