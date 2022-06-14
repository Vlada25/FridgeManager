using FridgeManager.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
