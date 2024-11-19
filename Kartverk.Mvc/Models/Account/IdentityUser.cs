using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kartverk.Mvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
