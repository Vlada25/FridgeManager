using Microsoft.AspNetCore.Identity;

namespace FridgeManager.Domain.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
