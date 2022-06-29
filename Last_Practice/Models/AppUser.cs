using Microsoft.AspNetCore.Identity;

namespace Last_Practice.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
