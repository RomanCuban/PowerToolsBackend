using Microsoft.AspNetCore.Identity;

namespace PowerTools.Models
{
    public class User:IdentityUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
