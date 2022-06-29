using System.ComponentModel.DataAnnotations;

namespace Last_Practice.ViewModels
{
    public class LoginVM
    {
        [Required,StringLength(maximumLength:20)]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
