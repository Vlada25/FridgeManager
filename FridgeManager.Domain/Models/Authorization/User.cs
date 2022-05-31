using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Models.Authorization
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Not specified user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Not specified email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Not specified login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
